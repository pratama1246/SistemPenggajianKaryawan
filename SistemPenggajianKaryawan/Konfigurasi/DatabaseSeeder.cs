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

                // 1. Buat tabel tbl_Users jika belum ada
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS tbl_Users (
                        user_id INT AUTO_INCREMENT PRIMARY KEY,
                        nama VARCHAR(100) NOT NULL,
                        username VARCHAR(50) NOT NULL UNIQUE,
                        password VARCHAR(256) NOT NULL,
                        role VARCHAR(20) NOT NULL,
                        is_aktif TINYINT DEFAULT 1
                    );";
                server.eksekusiNonQuery(createTableQuery);

                // 2. Cek apakah tabel kosong
                string checkQuery = "SELECT COUNT(*) FROM tbl_Users";
                DataTable dt = server.eksekusiQuery(checkQuery);
                
                int count = 0;
                if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    count = Convert.ToInt32(dt.Rows[0][0]);
                }

                // 3. Jika kosong, masukkan data seeder default
                if (count == 0)
                {
                    Auth_serv auth = new Auth_serv();

                    // Seed Admin (pass: admin)
                    string qAdmin = "INSERT INTO tbl_Users (nama, username, password, role, is_aktif) VALUES (@nama, @username, @password, @role, 1)";
                    var pAdmin = new Dictionary<string, object>
                    {
                        { "@nama", "Administrator" },
                        { "@username", "admin" },
                        { "@password", auth.hashPassword("admin") },
                        { "@role", "Admin" }
                    };
                    server.eksekusiNonQueryParam(qAdmin, pAdmin);

                    // Seed HRD (pass: hrd)
                    string qHrd = "INSERT INTO tbl_Users (nama, username, password, role, is_aktif) VALUES (@nama, @username, @password, @role, 1)";
                    var pHrd = new Dictionary<string, object>
                    {
                        { "@nama", "HRD Manager" },
                        { "@username", "hrd" },
                        { "@password", auth.hashPassword("hrd") },
                        { "@role", "HRD" }
                    };
                    server.eksekusiNonQueryParam(qHrd, pHrd);

                    // Seed Karyawan (pass: karyawan)
                    string qKaryawan = "INSERT INTO tbl_Users (nama, username, password, role, is_aktif) VALUES (@nama, @username, @password, @role, 1)";
                    var pKaryawan = new Dictionary<string, object>
                    {
                        { "@nama", "Karyawan Staff" },
                        { "@username", "karyawan" },
                        { "@password", auth.hashPassword("karyawan") },
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
