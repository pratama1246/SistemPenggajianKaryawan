using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan.Service
{
    internal class Karyawan_serv
    {
        internal int karyawan_id;
        internal string kode_karyawan;
        internal string nama_karyawan;
        internal string jabatan;
        internal string jenis;
        internal decimal gaji_pokok;
        internal bool is_aktif;

        Koneksi server;
        string Query;

        public Karyawan_serv()
        {
            server = new Koneksi();
            Query = "";
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

        public DataTable viewAll()
        {
            return server.eksekusiQuery("SELECT * FROM karyawan WHERE is_aktif = 1");
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

        public DataTable search(string keyword)
        {
            string q = "SELECT * FROM karyawan WHERE is_aktif = 1 AND (nama_karyawan LIKE @keyword " +
                       "OR kode_karyawan LIKE @keyword)";
            var p = new Dictionary<string, object> { { "@keyword", "%" + keyword + "%" } };
            return server.eksekusiQueryParam(q, p);
        }
    }
}
