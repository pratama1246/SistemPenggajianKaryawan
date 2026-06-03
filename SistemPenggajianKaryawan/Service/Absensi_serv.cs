using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Model;

namespace SistemPenggajianKaryawan.Service
{
    internal class Absensi_serv
    {
        Koneksi server;

        public Absensi_serv()
        {
            server = new Koneksi();
        }

        public DataTable getKaryawanAktif()
        {
            return server.eksekusiQuery("SELECT karyawan_id, kode_karyawan, nama_karyawan, jenis FROM karyawan WHERE is_aktif = 1");
        }

        public bool jikaAda(int karyawanId, int bulan, int tahun)
        {
            string q = "SELECT * FROM absensi WHERE karyawan_id = @karyawan_id AND bulan = @bulan AND tahun = @tahun";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawanId },
                { "@bulan", bulan },
                { "@tahun", tahun }
            };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public DataTable viewAbsensiPeriode(int bulan, int tahun)
        {
            string q = @"
                SELECT 
                    k.karyawan_id,
                    k.kode_karyawan,
                    k.nama_karyawan,
                    k.jenis,
                    a.hadir,
                    a.izin,
                    a.sakit,
                    a.alpha,
                    a.lembur,
                    CASE WHEN a.karyawan_id IS NULL THEN 'Pending' ELSE 'Selesai' END AS status
                FROM karyawan k
                LEFT JOIN absensi a ON k.karyawan_id = a.karyawan_id AND a.bulan = @bulan AND a.tahun = @tahun
                WHERE k.is_aktif = 1";
            var p = new Dictionary<string, object>
            {
                { "@bulan", bulan },
                { "@tahun", tahun }
            };
            return server.eksekusiQueryParam(q, p);
        }

        public DataTable searchAbsensiPeriode(int bulan, int tahun, string keyword)
        {
            string q = @"
                SELECT 
                    k.karyawan_id,
                    k.kode_karyawan,
                    k.nama_karyawan,
                    k.jenis,
                    a.hadir,
                    a.izin,
                    a.sakit,
                    a.alpha,
                    a.lembur,
                    CASE WHEN a.karyawan_id IS NULL THEN 'Pending' ELSE 'Selesai' END AS status
                FROM karyawan k
                LEFT JOIN absensi a ON k.karyawan_id = a.karyawan_id AND a.bulan = @bulan AND a.tahun = @tahun
                WHERE k.is_aktif = 1 AND (k.nama_karyawan LIKE @keyword OR k.kode_karyawan LIKE @keyword)";
            var p = new Dictionary<string, object>
            {
                { "@bulan", bulan },
                { "@tahun", tahun },
                { "@keyword", "%" + keyword + "%" }
            };
            return server.eksekusiQueryParam(q, p);
        }

        public int Save(DataAbsensi absensi)
        {
            int nilai = -1;
            string q = @"
                INSERT INTO absensi (karyawan_id, bulan, tahun, hadir, izin, sakit, alpha, lembur)
                VALUES (@karyawan_id, @bulan, @tahun, @hadir, @izin, @sakit, @alpha, @lembur)";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", absensi.karyawan_id },
                { "@bulan", absensi.bulan },
                { "@tahun", absensi.tahun },
                { "@hadir", absensi.hadir },
                { "@izin", absensi.izin },
                { "@sakit", absensi.sakit },
                { "@alpha", absensi.alpha },
                { "@lembur", absensi.lembur }
            };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }

        public int update(DataAbsensi absensi)
        {
            int nilai = -1;
            string q = @"
                UPDATE absensi 
                SET hadir = @hadir, izin = @izin, sakit = @sakit, alpha = @alpha, lembur = @lembur 
                WHERE karyawan_id = @karyawan_id AND bulan = @bulan AND tahun = @tahun";
            var p = new Dictionary<string, object>
            {
                { "@hadir", absensi.hadir },
                { "@izin", absensi.izin },
                { "@sakit", absensi.sakit },
                { "@alpha", absensi.alpha },
                { "@lembur", absensi.lembur },
                { "@karyawan_id", absensi.karyawan_id },
                { "@bulan", absensi.bulan },
                { "@tahun", absensi.tahun }
            };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }

        public int delete(int karyawanId, int bulan, int tahun)
        {
            int nilai = -1;
            string q = "DELETE FROM absensi WHERE karyawan_id = @karyawan_id AND bulan = @bulan AND tahun = @tahun";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawanId },
                { "@bulan", bulan },
                { "@tahun", tahun }
            };
            try { nilai = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai;
        }
    }
}
