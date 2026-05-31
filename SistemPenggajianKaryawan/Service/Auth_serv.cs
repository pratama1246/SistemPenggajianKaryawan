using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan.Service
{
    internal class Auth_serv
    {
        Koneksi server;
        string Query;

        public Auth_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        // Hash password pakai SHA-256
        public string hashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // Login: cek username + password hash, return data user jika cocok
        public DataTable login(string username, string password)
        {
            string hash  = hashPassword(password);
            Query = "SELECT user_id, nama, username, role FROM users " +
                    "WHERE username = @username AND password = @password AND is_active = 1";
            var param = new Dictionary<string, object>
            {
                { "@username", username },
                { "@password", hash     }
            };
            return server.eksekusiQueryParam(Query, param);
        }

        // Cek apakah username sudah ada (untuk validasi tambah user)
        public bool usernameAda(string username)
        {
            Query = "SELECT user_id FROM users WHERE username = @username";
            var param = new Dictionary<string, object> { { "@username", username } };
            return server.eksekusiQueryParam(Query, param).Rows.Count > 0;
        }
    }
}
