using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan.Service
{
    internal class Karyawan_serv
    {
        internal string kode_karyawan;
        internal string nama_karyawan;
        internal string jabatan;
        internal string jenis;
        internal decimal gaji_pokok;

        Koneksi server;

        public Karyawan_serv()
        {
            server = new Koneksi();
        }

        public bool jikaAda(string kode)
        {
            string q = "SELECT * FROM karyawan WHERE kode_karyawan = @kode";
            var p = new Dictionary<string, object> { { "@kode", kode } };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public int Save()
        {
            int nilai = -1;
            string q = "INSERT INTO karyawan (kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok, is_aktif) " +
                       "VALUES (@kode, @nama, @jabatan, @jenis, @gaji, 1)";
            var p = new Dictionary<string, object>
            {
                { "@kode", kode_karyawan },
                { "@nama", nama_karyawan },
                { "@jabatan", jabatan },
                { "@jenis", jenis },
                { "@gaji", gaji_pokok }
            };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }

        public DataTable viewAll(string jenisFilter = "Semua")
        {
            if (string.IsNullOrEmpty(jenisFilter) || jenisFilter == "Semua")
            {
                return server.eksekusiQuery("SELECT * FROM karyawan WHERE is_aktif = 1 ORDER BY kode_karyawan ASC");
            }
            string q = "SELECT * FROM karyawan WHERE is_aktif = 1 AND jenis = @jenis ORDER BY kode_karyawan ASC";
            var p = new Dictionary<string, object> { { "@jenis", jenisFilter } };
            return server.eksekusiQueryParam(q, p);
        }

        public int update(string kodeLama)
        {
            int nilai = -1;
            string q = "UPDATE karyawan SET nama_karyawan = @nama, jabatan = @jabatan, jenis = @jenis, " +
                       "gaji_pokok = @gaji WHERE kode_karyawan = @kode";
            var p = new Dictionary<string, object>
            {
                { "@nama", nama_karyawan },
                { "@jabatan", jabatan },
                { "@jenis", jenis },
                { "@gaji", gaji_pokok },
                { "@kode", kodeLama }
            };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }

        public int delete(string kode)
        {
            int nilai = -1;
            // Soft delete
            string q = "UPDATE karyawan SET is_aktif = 0 WHERE kode_karyawan = @kode";
            var p = new Dictionary<string, object> { { "@kode", kode } };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }

        public DataTable search(string keyword, string jenisFilter = "Semua")
        {
            string q = "SELECT * FROM karyawan WHERE is_aktif = 1 AND (nama_karyawan LIKE @keyword OR kode_karyawan LIKE @keyword)";
            var p = new Dictionary<string, object> { { "@keyword", "%" + keyword + "%" } };
            
            if (!string.IsNullOrEmpty(jenisFilter) && jenisFilter != "Semua")
            {
                q += " AND jenis = @jenis";
                p.Add("@jenis", jenisFilter);
            }
            
            q += " ORDER BY kode_karyawan ASC";
            return server.eksekusiQueryParam(q, p);
        }

        public string createCode()
        {
            string prefix = "KRY-";
            int nextNum = 1;
            try
            {
                // Cek data KRY- dulu
                string q1 = "SELECT kode_karyawan FROM karyawan WHERE kode_karyawan LIKE 'KRY-%' ORDER BY kode_karyawan DESC LIMIT 1";
                DataTable dt1 = server.eksekusiQuery(q1);
                if (dt1.Rows.Count > 0)
                {
                    string maxCode = dt1.Rows[0][0].ToString();
                    string numPart = maxCode.Substring(4);
                    int num;
                    if (int.TryParse(numPart, out num))
                    {
                        nextNum = num + 1;
                    }
                }
                else
                {
                    // Kalau tidak ada KRY-, tapi ada K001, K002
                    string q2 = "SELECT kode_karyawan FROM karyawan WHERE kode_karyawan LIKE 'K%' ORDER BY kode_karyawan DESC LIMIT 1";
                    DataTable dt2 = server.eksekusiQuery(q2);
                    if (dt2.Rows.Count > 0)
                    {
                        string maxCode = dt2.Rows[0][0].ToString();
                        string numPart = maxCode.Substring(1); // skip 'K'
                        int num;
                        if (int.TryParse(numPart, out num))
                        {
                            nextNum = num + 1;
                        }
                    }
                }
            }
            catch (Exception) { }
            return prefix + nextNum.ToString("D3");
        }

        public Dictionary<string, int> getCounts()
        {
            var counts = new Dictionary<string, int>
            {
                { "Semua", 0 },
                { "Tetap", 0 },
                { "Kontrak", 0 },
                { "Harian", 0 }
            };
            try
            {
                DataTable dt = server.eksekusiQuery("SELECT jenis, COUNT(*) AS jumlah FROM karyawan WHERE is_aktif = 1 GROUP BY jenis");
                int total = 0;
                foreach (DataRow r in dt.Rows)
                {
                    string jenis = r["jenis"].ToString();
                    int count = Convert.ToInt32(r["jumlah"]);
                    if (counts.ContainsKey(jenis))
                    {
                        counts[jenis] = count;
                    }
                    total += count;
                }
                counts["Semua"] = total;
            }
            catch (Exception) { }
            return counts;
        }
    }
}
