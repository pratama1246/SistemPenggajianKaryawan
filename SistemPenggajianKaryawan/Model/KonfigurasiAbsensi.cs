using System;

namespace SistemPenggajianKaryawan.Model
{
    internal class KonfigurasiAbsensi
    {
        public TimeSpan jam_masuk_normal  { get; set; }
        public TimeSpan jam_keluar_normal { get; set; }
        public int      toleransi_menit   { get; set; }

        public KonfigurasiAbsensi()
        {
            jam_masuk_normal  = new TimeSpan(8, 0, 0);   // 08:00
            jam_keluar_normal = new TimeSpan(17, 0, 0);  // 17:00
            toleransi_menit   = 15;
        }

        // Upah per jam dari gaji pokok
        // 22 hari kerja x 8 jam = 176 jam per bulan
        public decimal upahPerJam(decimal gaji_pokok)
        {
            return gaji_pokok / 176;
        }
    }
}
