using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemPenggajianKaryawan.Model
{
    internal class KaryawanHarian : BaseKaryawan
    {
        public override string GetJenis() => "Harian";

        public override decimal HitungGaji(
            List<DataAbsensi>  absensiList,
            List<KomponenGaji> komponen,
            KonfigurasiAbsensi config)
        {
            // Gaji pokok = upah per hari
            decimal upahPerHari = gaji_pokok;
            decimal upahPerJam  = upahPerHari / 8;
            decimal total       = 0;

            foreach (var absensi in absensiList.Where(a => a.status == "Hadir"))
            {
                // Upah hadir per hari
                total += upahPerHari;

                // Tambahan lembur 1.5x
                double jamLembur = absensi.jamLembur(config.jam_keluar_normal);
                if (jamLembur > 0)
                    total += (decimal)jamLembur * upahPerJam * 1.5m;
            }

            // Harian tidak kena potongan tetap
            // Alpha = tidak dibayar (sudah tidak masuk hitungan hadir)

            return total < 0 ? 0 : total;
        }
    }
}