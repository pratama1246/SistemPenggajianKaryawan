using System.Collections.Generic;
using System.Linq;

namespace SistemPenggajianKaryawan.Model
{
    internal class KaryawanKontrak : BaseKaryawan
    {
        public override string GetJenis() => "Kontrak";

        public override decimal HitungGaji(DataAbsensi absensi, List<KomponenGaji> komponen)
        {
            decimal total = gaji_pokok;

            // Tambah tunjangan yang berlaku untuk Kontrak atau Semua
            // Tidak dapat tunjangan khusus Tetap
            foreach (var k in komponen.Where(k => k.tipe == "Tambah" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Kontrak")))
                total += k.HitungNominal(gaji_pokok);

            // Potongan yang berlaku untuk Kontrak atau Semua
            // Tidak kena potongan khusus Tetap (misal BPJS penuh)
            foreach (var k in komponen.Where(k => k.tipe == "Potong" &&
                     (k.berlaku_untuk == "Semua" || k.berlaku_untuk == "Kontrak")))
                total -= k.HitungNominal(gaji_pokok);

            // Potongan alpha tetap berlaku
            total -= (gaji_pokok / 22) * absensi.alpha;

            return total < 0 ? 0 : total;
        }
    }
}