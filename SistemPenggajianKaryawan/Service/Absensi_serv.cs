using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Model;

namespace SistemPenggajianKaryawan.Service
{
    internal class Absensi_serv
    {
        private Koneksi server;

        public Absensi_serv()
        {
            server = new Koneksi();
        }

        public DataTable getKaryawanAktif()
        {
            return server.eksekusiQuery("SELECT karyawan_id, kode_karyawan, nama_karyawan, jenis, jabatan FROM karyawan WHERE is_aktif = 1");
        }

        public KonfigurasiAbsensi getKonfigurasi()
        {
            KonfigurasiAbsensi config = new KonfigurasiAbsensi();
            try
            {
                DataTable dt = server.eksekusiQuery("SELECT jam_masuk_normal, jam_keluar_normal, toleransi_menit FROM konfigurasi_absensi LIMIT 1");
                if (dt.Rows.Count > 0)
                {
                    config.jam_masuk_normal = (TimeSpan)dt.Rows[0]["jam_masuk_normal"];
                    config.jam_keluar_normal = (TimeSpan)dt.Rows[0]["jam_keluar_normal"];
                    config.toleransi_menit = Convert.ToInt32(dt.Rows[0]["toleransi_menit"]);
                }
            }
            catch (Exception) { }
            return config;
        }

        public bool jikaAda(int karyawanId, int bulan, int tahun)
        {
            // Compatibility method for old code if referenced
            string q = "SELECT * FROM absensi WHERE karyawan_id = @karyawan_id AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun";
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
            return viewAbsensiBulanan(bulan, tahun);
        }

        public DataTable searchAbsensiPeriode(int bulan, int tahun, string keyword)
        {
            KonfigurasiAbsensi config = getKonfigurasi();
            string jamKeluarStr = config.jam_keluar_normal.ToString(@"hh\:mm\:ss");

            string q = @"
                SELECT 
                    k.karyawan_id,
                    k.kode_karyawan,
                    k.nama_karyawan,
                    k.jenis,
                    COALESCE(SUM(CASE WHEN a.status = 'Hadir' THEN 1 ELSE 0 END), 0) AS hadir,
                    COALESCE(SUM(CASE WHEN a.status = 'Izin' THEN 1 ELSE 0 END), 0) AS izin,
                    COALESCE(SUM(CASE WHEN a.status = 'Sakit' THEN 1 ELSE 0 END), 0) AS sakit,
                    COALESCE(SUM(CASE WHEN a.status = 'Alpha' THEN 1 ELSE 0 END), 0) AS alpha,
                    COALESCE(SUM(CASE WHEN a.status = 'Hadir' AND a.jam_keluar > @jam_keluar THEN TIME_TO_SEC(TIMEDIFF(a.jam_keluar, @jam_keluar)) / 3600.0 ELSE 0 END), 0) AS lembur,
                    'Selesai' AS status
                FROM karyawan k
                LEFT JOIN absensi a ON k.karyawan_id = a.karyawan_id AND MONTH(a.tanggal) = @bulan AND YEAR(a.tanggal) = @tahun
                WHERE k.is_aktif = 1 AND (k.nama_karyawan LIKE @keyword OR k.kode_karyawan LIKE @keyword)
                GROUP BY k.karyawan_id, k.kode_karyawan, k.nama_karyawan, k.jenis";
            
            var p = new Dictionary<string, object>
            {
                { "@bulan", bulan },
                { "@tahun", tahun },
                { "@jam_keluar", jamKeluarStr },
                { "@keyword", "%" + keyword + "%" }
            };
            return server.eksekusiQueryParam(q, p);
        }

        public int Save(DataAbsensi absensi)
        {
            // Compatibility method
            string q = @"
                INSERT INTO absensi (karyawan_id, tanggal, jam_masuk, jam_keluar, status, keterangan)
                VALUES (@karyawan_id, @tanggal, @jam_masuk, @jam_keluar, @status, @keterangan)";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", absensi.karyawan_id },
                { "@tanggal", absensi.tanggal },
                { "@jam_masuk", absensi.jam_masuk },
                { "@jam_keluar", absensi.jam_keluar },
                { "@status", absensi.status },
                { "@keterangan", absensi.keterangan }
            };
            return server.eksekusiNonQueryParam(q, p);
        }

        public int update(DataAbsensi absensi)
        {
            // Compatibility method
            string q = @"
                UPDATE absensi 
                SET jam_masuk = @jam_masuk, jam_keluar = @jam_keluar, status = @status, keterangan = @keterangan 
                WHERE karyawan_id = @karyawan_id AND tanggal = @tanggal";
            var p = new Dictionary<string, object>
            {
                { "@jam_masuk", absensi.jam_masuk },
                { "@jam_keluar", absensi.jam_keluar },
                { "@status", absensi.status },
                { "@keterangan", absensi.keterangan },
                { "@karyawan_id", absensi.karyawan_id },
                { "@tanggal", absensi.tanggal }
            };
            return server.eksekusiNonQueryParam(q, p);
        }

        // ── SECTION 13: METHOD WAJIB ──────────────────────────────────────────

        public bool sudahAbsenMasuk(int karyawan_id)
        {
            string q = "SELECT * FROM absensi WHERE karyawan_id = @karyawan_id AND tanggal = CURDATE() AND jam_masuk IS NOT NULL";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawan_id }
            };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public bool sudahAbsenKeluar(int karyawan_id)
        {
            string q = "SELECT * FROM absensi WHERE karyawan_id = @karyawan_id AND tanggal = CURDATE() AND jam_keluar IS NOT NULL";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawan_id }
            };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public int simpanAbsenMasuk(int karyawan_id)
        {
            string q = @"
                INSERT INTO absensi (karyawan_id, tanggal, jam_masuk, status, keterangan)
                VALUES (@karyawan_id, CURDATE(), CURTIME(), 'Hadir', '')
                ON DUPLICATE KEY UPDATE jam_masuk = CURTIME(), status = 'Hadir'";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawan_id }
            };
            return server.eksekusiNonQueryParam(q, p);
        }

        public int simpanAbsenKeluar(int karyawan_id)
        {
            string q = "UPDATE absensi SET jam_keluar = CURTIME() WHERE karyawan_id = @karyawan_id AND tanggal = CURDATE()";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawan_id }
            };
            return server.eksekusiNonQueryParam(q, p);
        }

        public List<DataAbsensi> getAbsensiBulanan(int karyawan_id, int bulan, int tahun)
        {
            List<DataAbsensi> list = new List<DataAbsensi>();
            string q = @"
                SELECT absensi_id, karyawan_id, tanggal, jam_masuk, jam_keluar, status, keterangan 
                FROM absensi 
                WHERE karyawan_id = @karyawan_id AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun";
            var p = new Dictionary<string, object>
            {
                { "@karyawan_id", karyawan_id },
                { "@bulan", bulan },
                { "@tahun", tahun }
            };
            DataTable dt = server.eksekusiQueryParam(q, p);
            foreach (DataRow row in dt.Rows)
            {
                DataAbsensi abs = new DataAbsensi();
                abs.absensi_id = Convert.ToInt32(row["absensi_id"]);
                abs.karyawan_id = Convert.ToInt32(row["karyawan_id"]);
                abs.tanggal = Convert.ToDateTime(row["tanggal"]);
                abs.jam_masuk = row["jam_masuk"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)row["jam_masuk"];
                abs.jam_keluar = row["jam_keluar"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)row["jam_keluar"];
                abs.status = row["status"].ToString();
                abs.keterangan = row["keterangan"].ToString();
                list.Add(abs);
            }
            return list;
        }

        public DataTable viewAbsensiHarian(DateTime tanggal)
        {
            string q = @"
                SELECT 
                    k.kode_karyawan AS 'Kode',
                    k.nama_karyawan AS 'Nama',
                    k.jabatan AS 'Jabatan',
                    k.jenis AS 'Jenis',
                    a.jam_masuk AS 'Jam Masuk',
                    a.jam_keluar AS 'Jam Keluar',
                    COALESCE(a.status, 'Alpha') AS 'Status',
                    COALESCE(a.keterangan, '') AS 'Keterangan'
                FROM karyawan k
                LEFT JOIN absensi a ON k.karyawan_id = a.karyawan_id AND a.tanggal = @tanggal
                WHERE k.is_aktif = 1";
            var p = new Dictionary<string, object>
            {
                { "@tanggal", tanggal.ToString("yyyy-MM-dd") }
            };
            return server.eksekusiQueryParam(q, p);
        }

        public DataTable viewAbsensiBulanan(int bulan, int tahun)
        {
            KonfigurasiAbsensi config = getKonfigurasi();
            string jamKeluarStr = config.jam_keluar_normal.ToString(@"hh\:mm\:ss");

            string q = @"
                SELECT 
                    k.karyawan_id,
                    k.kode_karyawan,
                    k.nama_karyawan,
                    k.jenis,
                    COALESCE(SUM(CASE WHEN a.status = 'Hadir' THEN 1 ELSE 0 END), 0) AS hadir,
                    COALESCE(SUM(CASE WHEN a.status = 'Izin' THEN 1 ELSE 0 END), 0) AS izin,
                    COALESCE(SUM(CASE WHEN a.status = 'Sakit' THEN 1 ELSE 0 END), 0) AS sakit,
                    COALESCE(SUM(CASE WHEN a.status = 'Alpha' THEN 1 ELSE 0 END), 0) AS alpha,
                    COALESCE(SUM(CASE WHEN a.status = 'Hadir' AND a.jam_keluar > @jam_keluar THEN TIME_TO_SEC(TIMEDIFF(a.jam_keluar, @jam_keluar)) / 3600.0 ELSE 0 END), 0) AS lembur,
                    'Selesai' AS status
                FROM karyawan k
                LEFT JOIN absensi a ON k.karyawan_id = a.karyawan_id AND MONTH(a.tanggal) = @bulan AND YEAR(a.tanggal) = @tahun
                WHERE k.is_aktif = 1
                GROUP BY k.karyawan_id, k.kode_karyawan, k.nama_karyawan, k.jenis";
            
            var p = new Dictionary<string, object>
            {
                { "@bulan", bulan },
                { "@tahun", tahun },
                { "@jam_keluar", jamKeluarStr }
            };
            return server.eksekusiQueryParam(q, p);
        }
    }
}
