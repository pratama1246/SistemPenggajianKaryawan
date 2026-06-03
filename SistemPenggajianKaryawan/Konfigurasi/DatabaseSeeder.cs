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

                // 1b. Buat tabel absensi jika belum ada
                string createAbsensiTable = @"
                    CREATE TABLE IF NOT EXISTS absensi (
                        karyawan_id INT NOT NULL,
                        bulan INT NOT NULL,
                        tahun INT NOT NULL,
                        hadir INT NOT NULL DEFAULT 0,
                        izin INT NOT NULL DEFAULT 0,
                        sakit INT NOT NULL DEFAULT 0,
                        alpha INT NOT NULL DEFAULT 0,
                        lembur DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
                        PRIMARY KEY (karyawan_id, bulan, tahun),
                        FOREIGN KEY (karyawan_id) REFERENCES karyawan(karyawan_id) ON DELETE CASCADE
                    );";
                server.eksekusiNonQuery(createAbsensiTable);

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

                // Seed komponen gaji default
                DataTable dtKomp = server.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM komponen_gaji");
                if (dtKomp.Rows.Count > 0 && Convert.ToInt32(dtKomp.Rows[0]["jumlah"]) == 0)
                {
                    string qKomp = "INSERT INTO komponen_gaji (nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk) VALUES (@nama, @tipe, @jenis, @nilai, @berlaku)";
                    var seedData = new[]
                    {
                        new { nama = "Tunjangan Transport", tipe = "Tambah", jenis = "Nominal", nilai = 400000m, berlaku = "Semua" },
                        new { nama = "Tunjangan Makan",    tipe = "Tambah", jenis = "Nominal", nilai = 300000m, berlaku = "Tetap" },
                        new { nama = "BPJS Kesehatan",     tipe = "Potong", jenis = "Persen",  nilai = 5m,      berlaku = "Tetap" },
                        new { nama = "BPJS Naker",         tipe = "Potong", jenis = "Persen",  nilai = 5m,      berlaku = "Tetap" },
                    };
                    foreach (var s in seedData)
                    {
                        var p = new Dictionary<string, object>
                        {
                            { "@nama",   s.nama   },
                            { "@tipe",   s.tipe   },
                            { "@jenis",  s.jenis  },
                            { "@nilai",  s.nilai  },
                            { "@berlaku",s.berlaku }
                        };
                        server.eksekusiNonQueryParam(qKomp, p);
                    }
                }

                // 2. Masukkan data seeder default jika belum ada
                Auth_serv auth = new Auth_serv();

                // Seed Admin jika belum ada
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

                // Seed HRD jika belum ada
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

                // Seed Karyawan jika belum ada
                if (!auth.usernameAda("karyawan"))
                {
                    object karyawanId = DBNull.Value;
                    
                    try
                    {
                        DataTable dtKar = server.eksekusiQuery("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = 'K001'");
                        if (dtKar.Rows.Count > 0)
                        {
                            karyawanId = Convert.ToInt32(dtKar.Rows[0]["karyawan_id"]);
                        }
                        else
                        {
                            string qInsertKar = "INSERT INTO karyawan (kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok, is_aktif) VALUES ('K001', 'Karyawan Staff', 'Staff Administrasi', 'Tetap', 4500000.00, 1)";
                            server.eksekusiNonQuery(qInsertKar);
                            
                            DataTable dtNewKar = server.eksekusiQuery("SELECT karyawan_id FROM karyawan WHERE kode_karyawan = 'K001'");
                            if (dtNewKar.Rows.Count > 0)
                            {
                                karyawanId = Convert.ToInt32(dtNewKar.Rows[0]["karyawan_id"]);
                            }
                        }
                    }
                    catch (Exception) { }

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
            catch (Exception)
            {
                // Silently ignore if MySQL server is offline or database doesn't exist yet
            }
        }
    }
}
