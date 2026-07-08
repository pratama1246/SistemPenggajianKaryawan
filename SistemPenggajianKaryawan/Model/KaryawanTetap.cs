using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemPenggajianKaryawan.Model
{
    internal class KaryawanTetap : BaseKaryawan
    {
        public override string GetJenis() => "Tetap";

        public override decimal HitungGaji(
            List<DataAbsensi>  absensiList,
            List<KomponenGaji> komponen,
            KonfigurasiAbsensi config)
        {
            decimal upahPerJam = config.upahPerJam(gaji_pokok);
            decimal total      = gaji_pokok;
            int jumlahHadir    = absensiList.Count(a => a.status == "Hadir");

            // Tunjangan Makan Otomatis: 10k per hari masuk
            total += 10000m * jumlahHadir;

            // Tambah tunjangan Tetap / Semua
            foreach (var k in komponen.Where(k => k.tipe == "Tambah" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Tetap")))
                total += k.HitungNominal(gaji_pokok, jumlahHadir);

            // Kurangi potongan Tetap / Semua
            foreach (var k in komponen.Where(k => k.tipe == "Potong" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Tetap")))
                total -= k.HitungNominal(gaji_pokok, jumlahHadir);

            // Kalkulasi per hari
            foreach (var absensi in absensiList.Where(a => a.status == "Hadir"))
            {
                double menitTelat = absensi.menitTelat(config.jam_masuk_normal);
                if (menitTelat > config.toleransi_menit)
                    total -= (decimal)(menitTelat / 60) * upahPerJam;

                double jamPulcep = absensi.jamPulangCepat(config.jam_keluar_normal);
                if (jamPulcep > 0)
                    total -= (decimal)jamPulcep * upahPerJam;

                double jamLembur = absensi.jamLembur(config.jam_keluar_normal);
                if (jamLembur > 0)
                    total += (decimal)jamLembur * upahPerJam * 1.5m;
            }

            // Potongan alpha per hari
            int jumlahAlpha = absensiList.Count(a => a.status == "Alpha");
            total -= (gaji_pokok / 22) * jumlahAlpha;

            return total < 0 ? 0 : total;
        }
    }
}