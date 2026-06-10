using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan.Konfigurasi
{
    internal static class DatabaseSeeder
    {
        public static void Seed()
        {
            try
            {
                Koneksi server = new Koneksi();

                // 1. Buat tabel users jika belum ada
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS users (
                        user_id INT AUTO_INCREMENT PRIMARY KEY,
                        nama VARCHAR(100) NOT NULL,
                        username VARCHAR(50) NOT NULL UNIQUE,
                        password VARCHAR(64) NOT NULL,
                        role ENUM('Admin', 'HRD', 'Karyawan') NOT NULL,
                        is_active TINYINT(1) NOT NULL DEFAULT 1,
                        karyawan_id INT DEFAULT NULL,
                        FOREIGN KEY (karyawan_id) REFERENCES karyawan(karyawan_id) ON DELETE SET NULL
                    );";
                server.eksekusiNonQuery(createTableQuery);

                // 2. Seed Karyawan secara aman
                Action<string, string, string, string, decimal> insertKaryawanIfNotExist = (kode, nama, jabatan, jenis, gapok) =>
                {
                    DataTable dt = server.eksekusiQueryParam("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = @kode", 
                        new Dictionary<string, object> { { "@kode", kode } });
                    if (dt.Rows.Count == 0)
                    {
                        server.eksekusiNonQueryParam("INSERT INTO karyawan (kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok, is_aktif) VALUES (@kode, @nama, @jabatan, @jenis, @gapok, 1)",
                            new Dictionary<string, object>
                            {
                                { "@kode", kode },
                                { "@nama", nama },
                                { "@jabatan", jabatan },
                                { "@jenis", jenis },
                                { "@gapok", gapok }
                            });
                    }
                };

                insertKaryawanIfNotExist("K001", "Karyawan Staff", "Staff Administrasi", "Tetap", 4500000.00m);
                insertKaryawanIfNotExist("K002", "Ahmad H.", "Supervisor", "Tetap", 3500000.00m);
                insertKaryawanIfNotExist("K003", "Budi S.", "Operator", "Harian", 150000.00m);
                insertKaryawanIfNotExist("K004", "Citra D.", "Staff IT", "Kontrak", 2800000.00m);

                // 3. Seed Komponen Gaji secara aman
                Action<string, string, string, decimal, string> insertKomponenIfNotExist = (nama, tipe, jenisNilai, nilai, berlaku) =>
                {
                    DataTable dt = server.eksekusiQueryParam("SELECT komponen_id FROM komponengaji WHERE nama_komponen = @nama",
                        new Dictionary<string, object> { { "@nama", nama } });
                    if (dt.Rows.Count == 0)
                    {
                        server.eksekusiNonQueryParam("INSERT INTO komponengaji (nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk) VALUES (@nama, @tipe, @jenisNilai, @nilai, @berlaku)",
                            new Dictionary<string, object>
                            {
                                { "@nama", nama },
                                { "@tipe", tipe },
                                { "@jenisNilai", jenisNilai },
                                { "@nilai", nilai },
                                { "@berlaku", berlaku }
                            });
                    }
                };

                insertKomponenIfNotExist("Tunjangan Jabatan", "Tambah", "Persen", 10.00m, "Semua");
                insertKomponenIfNotExist("Tunjangan Keluarga", "Tambah", "Persen", 10.00m, "Tetap");
                insertKomponenIfNotExist("Potongan BPJS", "Potong", "Persen", 5.00m, "Semua");
                insertKomponenIfNotExist("Potongan Koperasi", "Potong", "Persen", 5.00m, "Tetap");

                // 4. Seed Absensi secara aman (Periode Mei 2026 - Bulan 5 Tahun 2026)
                Action<string, int, int, int, int, int, int, decimal> insertAbsensiIfNotExist = (kodeKar, bulan, tahun, hadir, izin, sakit, alpha, lembur) =>
                {
                    DataTable dtKar = server.eksekusiQueryParam("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = @kode",
                        new Dictionary<string, object> { { "@kode", kodeKar } });
                    if (dtKar.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(dtKar.Rows[0]["karyawan_id"]);
                        DataTable dtAbs = server.eksekusiQueryParam("SELECT absensi_id FROM absensi WHERE karyawan_id = @id AND bulan = @bulan AND tahun = @tahun",
                            new Dictionary<string, object>
                            {
                                { "@id", id },
                                { "@bulan", bulan },
                                { "@tahun", tahun }
                            });
                        if (dtAbs.Rows.Count == 0)
                        {
                            server.eksekusiNonQueryParam("INSERT INTO absensi (karyawan_id, bulan, tahun, hadir, izin, sakit, alpha, lembur) VALUES (@id, @bulan, @tahun, @hadir, @izin, @sakit, @alpha, @lembur)",
                                new Dictionary<string, object>
                                {
                                    { "@id", id },
                                    { "@bulan", bulan },
                                    { "@tahun", tahun },
                                    { "@hadir", hadir },
                                    { "@izin", izin },
                                    { "@sakit", sakit },
                                    { "@alpha", alpha },
                                    { "@lembur", lembur }
                                });
                        }
                    }
                };

                insertAbsensiIfNotExist("K001", 5, 2026, 22, 0, 0, 0, 0.00m);
                insertAbsensiIfNotExist("K002", 5, 2026, 22, 0, 0, 0, 0.00m);
                insertAbsensiIfNotExist("K003", 5, 2026, 20, 0, 0, 0, 8.00m);
                insertAbsensiIfNotExist("K004", 5, 2026, 22, 0, 0, 0, 0.00m);

                // 5. Seed Users default
                Auth_serv auth = new Auth_serv();

                if (!auth.usernameAda("admin"))
                {
                    string qAdmin = "INSERT INTO users (nama, username, password, role, is_active) VALUES (@nama, @username, @password, @role, 1)";
                    var pAdmin = new Dictionary<string, object>
                    {
                        { "@nama", "Administrator" },
                        { "@username", "admin" },
                        { "@password", auth.hashPassword("admin123") },
                        { "@role", "Admin" }
                    };
                    server.eksekusiNonQueryParam(qAdmin, pAdmin);
                }

                if (!auth.usernameAda("hrd"))
                {
                    string qHrd = "INSERT INTO users (nama, username, password, role, is_active) VALUES (@nama, @username, @password, @role, 1)";
                    var pHrd = new Dictionary<string, object>
                    {
                        { "@nama", "HRD Manager" },
                        { "@username", "hrd" },
                        { "@password", auth.hashPassword("hrd123") },
                        { "@role", "HRD" }
                    };
                    server.eksekusiNonQueryParam(qHrd, pHrd);
                }

                if (!auth.usernameAda("karyawan"))
                {
                    object karyawanId = DBNull.Value;
                    DataTable dtStaff = server.eksekusiQuery("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = 'K001'");
                    if (dtStaff.Rows.Count > 0)
                    {
                        karyawanId = Convert.ToInt32(dtStaff.Rows[0]["karyawan_id"]);
                    }

                    string qKaryawan = "INSERT INTO users (nama, username, password, role, is_active, karyawan_id) VALUES (@nama, @username, @password, @role, 1, @karyawan_id)";
                    var pKaryawan = new Dictionary<string, object>
                    {
                        { "@nama", "Karyawan Staff" },
                        { "@username", "karyawan" },
                        { "@password", auth.hashPassword("karyawan123") },
                        { "@role", "Karyawan" },
                        { "@karyawan_id", karyawanId }
                    };
                    server.eksekusiNonQueryParam(qKaryawan, pKaryawan);
                }
            }
            catch (Exception ex)
            {
                // Biarkan silent agar tidak merusak startup
                Console.WriteLine("Seed Error: " + ex.Message);
            }
        }
    }
}
