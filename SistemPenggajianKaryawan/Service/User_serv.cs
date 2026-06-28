using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan.Service
{
    internal class User_serv
    {
        internal string  nama;
        internal string  username;
        internal string  password; // Hashed password
        internal string  role;     // "Admin" | "HRD" | "Karyawan"
        internal int     is_active;   // 1 = Aktif, 0 = Tidak Aktif
        internal int?    karyawan_id; // NULL jika bukan role Karyawan

        Koneksi server;

        public User_serv()
        {
            server = new Koneksi();
        }

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("S1st3mP3ngg4j14nK4ry4w4nKey12345"); // 32 bytes for AES-256
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("PBO_Praktikum_IV"); // 16 bytes

        // Mengenkripsi password menggunakan AES-256 agar tersimpan aman di database
        public string hashPassword(string pw)
        {
            return encryptPassword(pw);
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

        // Cek jika username sudah ada selain user_id tertentu (untuk mencegah duplikasi)
        public bool jikaAda(string uname, int excludeId)
        {
            string q = "SELECT * FROM users WHERE username = @username AND user_id != @excludeId";
            var p = new Dictionary<string, object>
            {
                { "@username", uname },
                { "@excludeId", excludeId }
            };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public DataTable viewAll()
        {
            return server.eksekusiQuery(
                "SELECT user_id, nama, username, password, role, CAST(is_active AS SIGNED) AS is_active FROM users ORDER BY nama");
        }

        public DataTable search(string keyword)
        {
            string q = "SELECT user_id, nama, username, password, role, CAST(is_active AS SIGNED) AS is_active FROM users " +
                       "WHERE nama LIKE @keyword OR username LIKE @keyword OR role LIKE @keyword " +
                       "ORDER BY nama";
            var p = new Dictionary<string, object> { { "@keyword", "%" + keyword + "%" } };
            return server.eksekusiQueryParam(q, p);
        }

        public int Save()
        {
            int nilai_ret = -1;
            string q = "INSERT INTO users (nama, username, password, role, is_active, karyawan_id) " +
                       "VALUES (@nama, @username, @password, @role, @is_active, @karyawan_id)";
            var p = new Dictionary<string, object>
            {
                { "@nama",        nama      },
                { "@username",    username  },
                { "@password",    password  },
                { "@role",        role      },
                { "@is_active",   is_active },
                { "@karyawan_id", (object)karyawan_id ?? DBNull.Value }
            };
            try { nilai_ret = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai_ret;
        }

        public int update(int id, bool updatePassword)
        {
            int nilai_ret = -1;
            string q;
            Dictionary<string, object> p;
            if (updatePassword)
            {
                q = "UPDATE users SET nama = @nama, username = @username, password = @password, " +
                    "role = @role, is_active = @is_active, karyawan_id = @karyawan_id WHERE user_id = @id";
                p = new Dictionary<string, object>
                {
                    { "@nama",        nama      },
                    { "@username",    username  },
                    { "@password",    password  },
                    { "@role",        role      },
                    { "@is_active",   is_active },
                    { "@karyawan_id", (object)karyawan_id ?? DBNull.Value },
                    { "@id",          id        }
                };
            }
            else
            {
                q = "UPDATE users SET nama = @nama, username = @username, " +
                    "role = @role, is_active = @is_active, karyawan_id = @karyawan_id WHERE user_id = @id";
                p = new Dictionary<string, object>
                {
                    { "@nama",        nama      },
                    { "@username",    username  },
                    { "@role",        role      },
                    { "@is_active",   is_active },
                    { "@karyawan_id", (object)karyawan_id ?? DBNull.Value },
                    { "@id",          id        }
                };
            }
            try { nilai_ret = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai_ret;
        }

        public int delete(int id)
        {
            // Hard delete. Jika user pernah memproses gaji (FK constraint dari
            // tabel penggajian), MySqlException akan dilempar ke caller.
            string q = "DELETE FROM users WHERE user_id = @id";
            var p = new Dictionary<string, object> { { "@id", id } };
            return server.eksekusiNonQueryParam(q, p);
        }

        // Cek apakah user pernah memproses penggajian
        // (digunakan sebelum hapus untuk menghindari FK constraint error)
        public bool sudahProsesGaji(int userId)
        {
            string q = "SELECT COUNT(*) AS jumlah FROM penggajian WHERE diproses_oleh = @id";
            var p = new Dictionary<string, object> { { "@id", userId } };
            try
            {
                DataTable dt = server.eksekusiQueryParam(q, p);
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["jumlah"]) > 0;
            }
            catch (Exception) { }
            return false;
        }

        // Verifikasi password lama cocok dengan hash di DB
        public bool verifikasiPasswordLama(int userId, string passwordLama)
        {
            string hashed = hashPassword(passwordLama);
            string q = "SELECT password FROM users WHERE user_id = @id";
            var p = new Dictionary<string, object> { { "@id", userId } };
            DataTable dt = server.eksekusiQueryParam(q, p);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["password"].ToString() == hashed;
            }
            return false;
        }

        // Ganti password baru dengan hashing SHA-256
        public int gantiPassword(int userId, string passwordBaru)
        {
            string hashed = hashPassword(passwordBaru);
            string q = "UPDATE users SET password = @password WHERE user_id = @id";
            var p = new Dictionary<string, object>
            {
                { "@password", hashed },
                { "@id", userId }
            };
            return server.eksekusiNonQueryParam(q, p);
        }
    }
}
