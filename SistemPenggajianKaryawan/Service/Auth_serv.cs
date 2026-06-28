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

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("S1st3mP3ngg4j14nK4ry4w4nKey12345"); // 32 bytes for AES-256
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("PBO_Praktikum_IV"); // 16 bytes

        // Mengenkripsi password menggunakan AES-256 agar tersimpan aman di database
        public string hashPassword(string password)
        {
            return encryptPassword(password);
        }

        public string encryptPassword(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;
                    var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch { return plainText; }
        }

        public string decryptPassword(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return "";
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;
                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new System.IO.StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch { return cipherText; }
        }

        // Login: cek username + password hash, return data user jika cocok
        public DataTable login(string username, string password)
        {
            string hash  = hashPassword(password);
            Query = "SELECT user_id, nama, username, role, karyawan_id FROM users " +
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

        public int getJumlahUserAktif()
        {
            try
            {
                DataTable dt = server.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM users WHERE is_active = 1");
                if (dt.Rows.Count > 0) return Convert.ToInt32(dt.Rows[0]["jumlah"]);
            }
            catch (Exception) { }
            return 0;
        }
    }
}
