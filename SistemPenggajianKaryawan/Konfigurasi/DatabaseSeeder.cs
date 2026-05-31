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
                    string qKaryawan = "INSERT INTO users (nama, username, password, role, is_active) VALUES (@nama, @username, @password, @role, 1)";
                    var pKaryawan = new Dictionary<string, object>
                    {
                        { "@nama", "Karyawan Staff" },
                        { "@username", "karyawan" },
                        { "@password", auth.hashPassword("karyawan123") },
                        { "@role", "Karyawan" }
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
