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

                // 0. Buat tabel karyawan jika belum ada
                string createKaryawanTable = @"
                    CREATE TABLE IF NOT EXISTS karyawan (
                        karyawan_id INT AUTO_INCREMENT PRIMARY KEY,
                        kode_karyawan VARCHAR(50) NOT NULL UNIQUE,
                        nama_karyawan VARCHAR(100) NOT NULL,
                        jabatan VARCHAR(100) NOT NULL,
                        jenis VARCHAR(50) NOT NULL,
                        gaji_pokok DECIMAL(15, 2) NOT NULL,
                        is_aktif TINYINT(1) NOT NULL DEFAULT 1
                    );";
                server.eksekusiNonQuery(createKaryawanTable);

                // Jalankan ALTER TABLE untuk memastikan kolom kode_karyawan bertipe VARCHAR(50) jika tabel lama masih VARCHAR kecil
                try
                {
                    server.eksekusiNonQuery("ALTER TABLE karyawan MODIFY COLUMN kode_karyawan VARCHAR(50) NOT NULL;");
                }
                catch (Exception) { }

                // 1. Buat tabel users jika belum ada
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS users (
                        user_id INT AUTO_INCREMENT PRIMARY KEY,
                        nama VARCHAR(100) NOT NULL,
                        username VARCHAR(50) NOT NULL UNIQUE,
                        password VARCHAR(64) NOT NULL,
                        role ENUM('Admin', 'HRD', 'Karyawan', 'Kiosk') NOT NULL,
                        is_active TINYINT(1) NOT NULL DEFAULT 1,
                        karyawan_id INT DEFAULT NULL,
                        FOREIGN KEY (karyawan_id) REFERENCES karyawan(karyawan_id) ON DELETE SET NULL
                    );";
                server.eksekusiNonQuery(createTableQuery);

                // Jalankan ALTER TABLE untuk memastikan ENUM 'Kiosk' terdaftar jika tabel sudah pernah dibuat sebelumnya
                try
                {
                    server.eksekusiNonQuery("ALTER TABLE users MODIFY COLUMN role ENUM('Admin', 'HRD', 'Karyawan', 'Kiosk') NOT NULL;");
                }
                catch (Exception) { }

                // 1b. Buat tabel absensi jika belum ada
                bool isOldSchema = false;
                try
                {
                    DataTable columns = server.eksekusiQuery("SHOW COLUMNS FROM absensi LIKE 'bulan'");
                    if (columns.Rows.Count > 0)
                    {
                        isOldSchema = true;
                    }
                }
                catch (Exception) { }

                if (isOldSchema)
                {
                    server.eksekusiNonQuery("DROP TABLE IF EXISTS absensi");
                }

                string createAbsensiTable = @"
                    CREATE TABLE IF NOT EXISTS absensi (
                        absensi_id    INT AUTO_INCREMENT PRIMARY KEY,
                        karyawan_id   INT          NOT NULL,
                        tanggal       DATE         NOT NULL,
                        jam_masuk     TIME         NULL,
                        jam_keluar    TIME         NULL,
                        status        ENUM('Hadir','Izin','Sakit','Alpha') NOT NULL DEFAULT 'Hadir',
                        keterangan    VARCHAR(255) NULL,
                        created_at    DATETIME     DEFAULT NOW(),
                        FOREIGN KEY (karyawan_id) REFERENCES karyawan(karyawan_id) ON DELETE CASCADE,
                        UNIQUE KEY unik_absensi (karyawan_id, tanggal)
                    );";
                server.eksekusiNonQuery(createAbsensiTable);

                // Buat tabel konfigurasi_absensi jika belum ada
                string createConfigTable = @"
                    CREATE TABLE IF NOT EXISTS konfigurasi_absensi (
                        config_id         INT AUTO_INCREMENT PRIMARY KEY,
                        jam_masuk_normal  TIME NOT NULL DEFAULT '08:00:00',
                        jam_keluar_normal TIME NOT NULL DEFAULT '17:00:00',
                        toleransi_menit   INT  NOT NULL DEFAULT 15,
                        updated_at        DATETIME DEFAULT NOW()
                    );";
                server.eksekusiNonQuery(createConfigTable);

                DataTable dtConf = server.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM konfigurasi_absensi");
                if (dtConf.Rows.Count > 0 && Convert.ToInt32(dtConf.Rows[0]["jumlah"]) == 0)
                {
                    server.eksekusiNonQuery("INSERT INTO konfigurasi_absensi (jam_masuk_normal, jam_keluar_normal, toleransi_menit) VALUES ('08:00:00', '17:00:00', 15)");
                }

                // 1c. Buat tabel komponen_gaji jika belum ada
                string createKomponenTable = @"
                    CREATE TABLE IF NOT EXISTS komponen_gaji (
                        komponen_id   INT AUTO_INCREMENT PRIMARY KEY,
                        nama_komponen VARCHAR(100) NOT NULL,
                        tipe          ENUM('Tambah','Potong') NOT NULL,
                        jenis_nilai   ENUM('Nominal','Persen') NOT NULL,
                        nilai         DECIMAL(15,2) NOT NULL DEFAULT 0,
                        berlaku_untuk ENUM('Semua','Tetap','Kontrak','Harian') NOT NULL DEFAULT 'Semua',
                        is_aktif      TINYINT(1) NOT NULL DEFAULT 1
                    );";
                server.eksekusiNonQuery(createKomponenTable);

                // 1d. Buat tabel penggajian jika belum ada
                string createPenggajianTable = @"
                    CREATE TABLE IF NOT EXISTS penggajian (
                        penggajian_id INT AUTO_INCREMENT PRIMARY KEY,
                        karyawan_id   INT NOT NULL,
                        bulan         INT NOT NULL,
                        tahun         INT NOT NULL,
                        gaji_pokok    DECIMAL(15, 2) NOT NULL,
                        total_tunjangan DECIMAL(15, 2) NOT NULL,
                        total_potongan  DECIMAL(15, 2) NOT NULL,
                        gaji_bersih   DECIMAL(15, 2) NOT NULL,
                        diproses_oleh INT NOT NULL,
                        tgl_proses    DATETIME NOT NULL,
                        FOREIGN KEY (karyawan_id) REFERENCES karyawan(karyawan_id) ON DELETE CASCADE,
                        FOREIGN KEY (diproses_oleh) REFERENCES users(user_id),
                        UNIQUE KEY unik_penggajian (karyawan_id, bulan, tahun)
                    );";
                server.eksekusiNonQuery(createPenggajianTable);

                // Migrasi Otomatis: Ubah kode karyawan lama (seperti K001 atau KRY-001) ke format baru PNC.2026.XXXX
                try
                {
                    DataTable dtOld = server.eksekusiQuery("SELECT karyawan_id, kode_karyawan FROM karyawan WHERE kode_karyawan NOT LIKE 'PNC.%'");
                    foreach (DataRow r in dtOld.Rows)
                    {
                        int id = Convert.ToInt32(r["karyawan_id"]);
                        string oldCode = r["kode_karyawan"].ToString();
                        
                        // Ambil hanya angka dari kode lama
                        string digitsOnly = "";
                        foreach (char c in oldCode)
                        {
                            if (char.IsDigit(c)) digitsOnly += c;
                        }
                        
                        int numVal = 1;
                        if (!string.IsNullOrEmpty(digitsOnly))
                        {
                            int.TryParse(digitsOnly, out numVal);
                        }
                        
                        string newCode = $"PNC.2026.{numVal.ToString("D4")}";
                        
                        // Cek apakah kode baru sudah terpakai
                        DataTable dtCheck = server.eksekusiQueryParam("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = @newCode", 
                            new Dictionary<string, object> { { "@newCode", newCode } });
                        
                        if (dtCheck.Rows.Count == 0)
                        {
                            server.eksekusiNonQueryParam("UPDATE karyawan SET kode_karyawan = @newCode WHERE karyawan_id = @id",
                                new Dictionary<string, object>
                                {
                                    { "@newCode", newCode },
                                    { "@id", id }
                                });
                        }
                    }
                }
                catch (Exception) { }

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

                insertKaryawanIfNotExist("PNC.2026.0001", "Karyawan Staff", "Staff Administrasi", "Tetap", 4500000.00m);
                insertKaryawanIfNotExist("PNC.2026.0002", "Ahmad H.", "Supervisor", "Tetap", 3500000.00m);
                insertKaryawanIfNotExist("PNC.2026.0003", "Budi S.", "Operator", "Harian", 150000.00m);
                insertKaryawanIfNotExist("PNC.2026.0004", "Citra D.", "Staff IT", "Kontrak", 2800000.00m);

                // 3. Seed Komponen Gaji secara aman
                Action<string, string, string, decimal, string> insertKomponenIfNotExist = (nama, tipe, jenisNilai, nilai, berlaku) =>
                {
                    DataTable dt = server.eksekusiQueryParam("SELECT komponen_id FROM komponen_gaji WHERE nama_komponen = @nama",
                        new Dictionary<string, object> { { "@nama", nama } });
                    if (dt.Rows.Count == 0)
                    {
                        server.eksekusiNonQueryParam("INSERT INTO komponen_gaji (nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk) VALUES (@nama, @tipe, @jenisNilai, @nilai, @berlaku)",
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

                // 4. Seed Absensi secara aman (Daily logs untuk Mei 2026 - week days only)
                Action<string, DateTime, TimeSpan, TimeSpan, string> insertDailyAbsensiIfNotExist = (kodeKar, tanggal, jamMasuk, jamKeluar, status) =>
                {
                    DataTable dtKar = server.eksekusiQueryParam("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = @kode",
                        new Dictionary<string, object> { { "@kode", kodeKar } });
                    if (dtKar.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(dtKar.Rows[0]["karyawan_id"]);
                        DataTable dtAbs = server.eksekusiQueryParam("SELECT absensi_id FROM absensi WHERE karyawan_id = @id AND tanggal = @tanggal",
                            new Dictionary<string, object>
                            {
                                { "@id", id },
                                { "@tanggal", tanggal }
                            });
                        if (dtAbs.Rows.Count == 0)
                        {
                            server.eksekusiNonQueryParam("INSERT INTO absensi (karyawan_id, tanggal, jam_masuk, jam_keluar, status, keterangan) VALUES (@id, @tanggal, @jamMasuk, @jamKeluar, @status, '')",
                                new Dictionary<string, object>
                                {
                                    { "@id", id },
                                    { "@tanggal", tanggal },
                                    { "@jamMasuk", jamMasuk },
                                    { "@jamKeluar", jamKeluar },
                                    { "@status", status }
                                });
                        }
                    }
                };

                try
                {
                    DataTable dtAbsCount = server.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM absensi WHERE MONTH(tanggal) = 5 AND YEAR(tanggal) = 2026");
                    if (dtAbsCount.Rows.Count > 0 && Convert.ToInt32(dtAbsCount.Rows[0]["jumlah"]) == 0)
                    {
                        string[] kodes = { "PNC.2026.0001", "PNC.2026.0002", "PNC.2026.0003", "PNC.2026.0004" };
                        for (int day = 1; day <= 31; day++)
                        {
                            DateTime dt = new DateTime(2026, 5, day);
                            if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                            {
                                foreach (var kode in kodes)
                                {
                                    TimeSpan masuk = new TimeSpan(8, 0, 0);
                                    TimeSpan keluar = new TimeSpan(17, 0, 0);
                                    string status = "Hadir";
 
                                    if (kode == "PNC.2026.0002" && day == 5)
                                    {
                                        masuk = new TimeSpan(8, 20, 0); // Late 20 mins
                                    }
                                    if (kode == "PNC.2026.0003" && day == 10)
                                    {
                                        keluar = new TimeSpan(19, 0, 0); // Lembur 2 hours
                                    }
                                    if (kode == "PNC.2026.0004" && day == 15)
                                    {
                                        status = "Izin";
                                        masuk = TimeSpan.Zero;
                                        keluar = TimeSpan.Zero;
                                    }
 
                                    insertDailyAbsensiIfNotExist(kode, dt, masuk, keluar, status);
                                }
                            }
                        }
                    }
                }
                catch (Exception) { }

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
                    DataTable dtStaff = server.eksekusiQuery("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = 'PNC.2026.0001'");
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

                if (!auth.usernameAda("kiosk"))
                {
                    string qKiosk = "INSERT INTO users (nama, username, password, role, is_active) VALUES (@nama, @username, @password, @role, 1)";
                    var pKiosk = new Dictionary<string, object>
                    {
                        { "@nama", "Kiosk Absensi Pintu" },
                        { "@username", "kiosk" },
                        { "@password", auth.hashPassword("kiosk123") },
                        { "@role", "Kiosk" }
                    };
                    server.eksekusiNonQueryParam(qKiosk, pKiosk);
                }
                else
                {
                    // Self-healing: Hubungkan user 'karyawan' dengan karyawan_id 'PNC.2026.0001' jika saat ini masih NULL
                    DataTable dtCheck = server.eksekusiQuery("SELECT karyawan_id FROM users WHERE username = 'karyawan'");
                    if (dtCheck.Rows.Count > 0 && dtCheck.Rows[0]["karyawan_id"] == DBNull.Value)
                    {
                        DataTable dtStaff = server.eksekusiQuery("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = 'PNC.2026.0001'");
                        if (dtStaff.Rows.Count > 0)
                        {
                            int karyawanId = Convert.ToInt32(dtStaff.Rows[0]["karyawan_id"]);
                            server.eksekusiNonQueryParam(
                                "UPDATE users SET karyawan_id = @karyawan_id WHERE username = 'karyawan'",
                                new Dictionary<string, object> { { "@karyawan_id", karyawanId } }
                            );
                        }
                    }
                }

                // Reset/Verify default users passwords to encrypted if they are currently plain or hashed
                string qCheckHash = "SELECT user_id, username, password FROM users";
                DataTable dtUsers = server.eksekusiQuery(qCheckHash);
                foreach (DataRow r in dtUsers.Rows)
                {
                    string uname = r["username"].ToString();
                    string pw = r["password"].ToString();
                    int uid = Convert.ToInt32(r["user_id"]);
                    
                    // Coba dekripsi. Jika hasil dekripsi sama dengan aslinya (berarti plain text atau old hash), maka kita harus mengenkripsinya.
                    string decrypted = auth.decryptPassword(pw);
                    if (decrypted == pw) 
                    {
                        string plainPw = pw;
                        // Jika panjangnya 64 (kemungkinan SHA-256 hash lama), reset ke password default aslinya
                        if (pw.Length == 64)
                        {
                            if (uname == "admin") plainPw = "admin123";
                            else if (uname == "hrd") plainPw = "hrd123";
                            else if (uname == "karyawan") plainPw = "karyawan123";
                            else if (uname == "kiosk") plainPw = "kiosk123";
                        }
                        
                        // Encrypt and update
                        string encrypted = auth.encryptPassword(plainPw);
                        string qUp = "UPDATE users SET password = @pw WHERE user_id = @uid";
                        var pUp = new Dictionary<string, object>
                        {
                            { "@pw", encrypted },
                            { "@uid", uid }
                        };
                        server.eksekusiNonQueryParam(qUp, pUp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Seed Error: " + ex.Message);
            }
        }
    }
}
