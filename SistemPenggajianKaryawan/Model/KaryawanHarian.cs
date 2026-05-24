using System.Collections.Generic;

namespace SistemPenggajianKaryawan.Model
{
    internal class KaryawanHarian : BaseKaryawan
    {
        public override string GetJenis() => "Harian";

        public override decimal HitungGaji(DataAbsensi absensi, List<KomponenGaji> komponen)
        {
            // Gaji pokok di sini = upah per hari
            decimal upahPerHari = gaji_pokok;
            decimal upahPerJam = upahPerHari / 8; // asumsi 8 jam kerja per hari

            // Upah hadir
            decimal totalHadir = upahPerHari * absensi.hadir;

            // Upah lembur = 1.5x upah per jam
            decimal totalLembur = upahPerJam * 1.5m * absensi.lembur;

            // Tidak ada tunjangan/potongan tetap untuk harian
            decimal total = totalHadir + totalLembur;

            return total < 0 ? 0 : total;
        }
    }
}