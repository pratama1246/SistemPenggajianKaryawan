using System.Collections.Generic;
using System.Linq;

namespace SistemPenggajianKaryawan.Model
{
    internal class KaryawanTetap : BaseKaryawan
    {
        public override string GetJenis() => "Tetap";

        public override decimal HitungGaji(DataAbsensi absensi, List<KomponenGaji> komponen)
        {
            decimal total = gaji_pokok;

            // Tambah semua tunjangan yang berlaku untuk Tetap atau Semua
            foreach (var k in komponen.Where(k => k.tipe == "Tambah" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Tetap")))
                total += k.HitungNominal(gaji_pokok);

            // Kurangi semua potongan yang berlaku untuk Tetap atau Semua
            foreach (var k in komponen.Where(k => k.tipe == "Potong" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Tetap")))
                total -= k.HitungNominal(gaji_pokok);

            // Potongan alpha: gaji pokok / 22 hari kerja * jumlah alpha
            total -= (gaji_pokok / 22) * absensi.alpha;

            return total < 0 ? 0 : total;
        }
    }
}