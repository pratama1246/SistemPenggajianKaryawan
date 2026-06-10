using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Model;

namespace SistemPenggajianKaryawan.Service
{
    internal class Gaji_serv
    {
        Koneksi server;
        string Query;

        public Gaji_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        // Factory Method - sesuai dengan instruksi di AGENTS.md
        private BaseKaryawan buatObjekKaryawan(string jenis)
        {
            if (jenis == "Tetap") return new KaryawanTetap();
            if (jenis == "Kontrak") return new KaryawanKontrak();
            if (jenis == "Harian") return new KaryawanHarian();
            return null;
        }

        // Hitung gaji bulanan seluruh karyawan aktif
        public DataTable hitungGajiBulanan(int bulan, int tahun)
        {
            DataTable dtHasil = new DataTable();
            dtHasil.Columns.Add("karyawan_id", typeof(int));
            dtHasil.Columns.Add("nama_karyawan", typeof(string));
            dtHasil.Columns.Add("jenis", typeof(string));
            dtHasil.Columns.Add("gaji_pokok", typeof(decimal));
            dtHasil.Columns.Add("tunjangan", typeof(decimal));
            dtHasil.Columns.Add("potongan", typeof(decimal));
            dtHasil.Columns.Add("gaji_netto", typeof(decimal));

            // Ambil semua karyawan aktif
            string qEmp = "SELECT karyawan_id, kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok FROM karyawan WHERE is_aktif = 1";
            DataTable dtEmp = server.eksekusiQuery(qEmp);

            // Ambil semua komponen gaji
            string qComp = "SELECT komponen_id, nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk FROM komponen_gaji";
            DataTable dtComp = server.eksekusiQuery(qComp);
            List<KomponenGaji> komponenList = new List<KomponenGaji>();
            foreach (DataRow r in dtComp.Rows)
            {
                komponenList.Add(new KomponenGaji
                {
                    komponen_id = Convert.ToInt32(r["komponen_id"]),
                    nama_komponen = r["nama_komponen"].ToString(),
                    tipe = r["tipe"].ToString(),
                    jenis_nilai = r["jenis_nilai"].ToString(),
                    nilai = Convert.ToDecimal(r["nilai"]),
                    berlaku_untuk = r["berlaku_untuk"].ToString()
                });
            }

            Absensi_serv absServ = new Absensi_serv();
            KonfigurasiAbsensi config = absServ.getKonfigurasi();

            foreach (DataRow rEmp in dtEmp.Rows)
            {
                int karId = Convert.ToInt32(rEmp["karyawan_id"]);
                string jenis = rEmp["jenis"].ToString();
                decimal gapok = Convert.ToDecimal(rEmp["gaji_pokok"]);

                BaseKaryawan karObj = buatObjekKaryawan(jenis);
                if (karObj == null) continue;

                karObj.karyawan_id = karId;
                karObj.kode_karyawan = rEmp["kode_karyawan"].ToString();
                karObj.nama_karyawan = rEmp["nama_karyawan"].ToString();
                karObj.jabatan = rEmp["jabatan"].ToString();
                karObj.jenis = jenis;
                karObj.gaji_pokok = gapok;

                // Ambil data absensi harian
                List<DataAbsensi> absensiList = absServ.getAbsensiBulanan(karId, bulan, tahun);

                decimal tunjangan = 0;
                decimal potongan = 0;

                if (jenis == "Tetap" || jenis == "Kontrak")
                {
                    // Tunjangan
                    foreach (var k in komponenList.Where(k => k.tipe == "Tambah" && (k.berlaku_untuk == "Semua" || k.berlaku_untuk == jenis)))
                    {
                        tunjangan += k.HitungNominal(gapok);
                    }
                    // Potongan
                    foreach (var k in komponenList.Where(k => k.tipe == "Potong" && (k.berlaku_untuk == "Semua" || k.berlaku_untuk == jenis)))
                    {
                        potongan += k.HitungNominal(gapok);
                    }
                    // Potongan alpha
                    int jumlahAlpha = absensiList.Count(a => a.status == "Alpha");
                    potongan += (gapok / 22) * jumlahAlpha;

                    // Potongan telat & pulang cepat, serta tambah lembur (kalkulasi jam)
                    decimal upahPerJam = config.upahPerJam(gapok);
                    foreach (var abs in absensiList.Where(a => a.status == "Hadir"))
                    {
                        double menitTelat = abs.menitTelat(config.jam_masuk_normal);
                        if (menitTelat > config.toleransi_menit)
                        {
                            potongan += (decimal)(menitTelat / 60) * upahPerJam;
                        }

                        double jamPulcep = abs.jamPulangCepat(config.jam_keluar_normal);
                        if (jamPulcep > 0)
                        {
                            potongan += (decimal)jamPulcep * upahPerJam;
                        }

                        double jamLembur = abs.jamLembur(config.jam_keluar_normal);
                        if (jamLembur > 0)
                        {
                            tunjangan += (decimal)jamLembur * upahPerJam * 1.5m;
                        }
                    }
                }
                else if (jenis == "Harian")
                {
                    // Harian: upah hadir + upah lembur
                    decimal upahPerHari = gapok;
                    decimal upahPerJam = upahPerHari / 8;
                    int jumlahHadir = absensiList.Count(a => a.status == "Hadir");
                    double totalLemburHours = 0;
                    foreach (var abs in absensiList.Where(a => a.status == "Hadir"))
                    {
                        totalLemburHours += abs.jamLembur(config.jam_keluar_normal);
                    }

                    decimal totalHadir = upahPerHari * jumlahHadir;
                    decimal totalLembur = upahPerJam * 1.5m * (decimal)totalLemburHours;

                    tunjangan = totalLembur;
                    gapok = totalHadir;
                    potongan = 0;
                }

                // Kalkulasi Gaji Bersih menggunakan polymorphism
                decimal netto = karObj.HitungGaji(absensiList, komponenList, config);

                dtHasil.Rows.Add(karId, karObj.nama_karyawan, jenis, gapok, tunjangan, potongan, netto);
            }

            return dtHasil;
        }

        // Simpan hasil kalkulasi gaji ke database
        public int simpanSemuaGaji(int bulan, int tahun, DataTable dtGaji, int userId)
        {
            int rowsSaved = 0;
            try
            {
                // Delete data gaji periode tersebut jika sudah ada untuk menghindari duplikat
                string deleteQuery = "DELETE FROM penggajian WHERE bulan = @bulan AND tahun = @tahun";
                var deleteParam = new Dictionary<string, object>
                {
                    { "@bulan", bulan },
                    { "@tahun", tahun }
                };
                server.eksekusiNonQueryParam(deleteQuery, deleteParam);

                // Insert masing-masing record hasil kalkulasi
                foreach (DataRow row in dtGaji.Rows)
                {
                    string insertQuery = "INSERT INTO penggajian (karyawan_id, bulan, tahun, gaji_pokok, total_tunjangan, total_potongan, gaji_bersih, diproses_oleh, tgl_proses) " +
                                         "VALUES (@karyawan_id, @bulan, @tahun, @gaji_pokok, @total_tunjangan, @total_potongan, @gaji_bersih, @diproses_oleh, NOW())";
                    var param = new Dictionary<string, object>
                    {
                        { "@karyawan_id", Convert.ToInt32(row["karyawan_id"]) },
                        { "@bulan", bulan },
                        { "@tahun", tahun },
                        { "@gaji_pokok", Convert.ToDecimal(row["gaji_pokok"]) },
                        { "@total_tunjangan", Convert.ToDecimal(row["tunjangan"]) },
                        { "@total_potongan", Convert.ToDecimal(row["potongan"]) },
                        { "@gaji_bersih", Convert.ToDecimal(row["gaji_netto"]) },
                        { "@diproses_oleh", userId }
                    };
                    
                    if (server.eksekusiNonQueryParam(insertQuery, param) > 0)
                    {
                        rowsSaved++;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return rowsSaved;
        }
    }
}
