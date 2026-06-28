using System;

namespace SistemPenggajianKaryawan.Model
{
    internal class DataAbsensi
    {
        private int      _absensi_id;
        private int      _karyawan_id;
        private DateTime _tanggal;
        private TimeSpan _jam_masuk;
        private TimeSpan _jam_keluar;
        private string   _foto_masuk;
        private string   _foto_keluar;
        private string   _status;       // "Hadir" | "Izin" | "Sakit" | "Alpha"
        private string   _keterangan;

        public int      absensi_id  { get { return _absensi_id; }  set { _absensi_id = value; } }
        public int      karyawan_id { get { return _karyawan_id; } set { _karyawan_id = value; } }
        public DateTime tanggal     { get { return _tanggal; }     set { _tanggal = value; } }
        public TimeSpan jam_masuk   { get { return _jam_masuk; }   set { _jam_masuk = value; } }
        public TimeSpan jam_keluar  { get { return _jam_keluar; }  set { _jam_keluar = value; } }
        public string   foto_masuk  { get { return _foto_masuk; }  set { _foto_masuk = value; } }
        public string   foto_keluar { get { return _foto_keluar; } set { _foto_keluar = value; } }
        public string   status      { get { return _status; }      set { _status = value; } }
        public string   keterangan  { get { return _keterangan; }  set { _keterangan = value; } }

        public DataAbsensi()
        {
            _absensi_id  = 0;
            _karyawan_id = 0;
            _tanggal     = DateTime.Today;
            _jam_masuk   = TimeSpan.Zero;
            _jam_keluar  = TimeSpan.Zero;
            _foto_masuk  = "";
            _foto_keluar = "";
            _status      = "Hadir";
            _keterangan  = "";
        }

        // ── Helper properties untuk kalkulasi gaji ──────────

        // Total jam kerja hari ini
        public double totalJamKerja
        {
            get
            {
                if (_jam_masuk == TimeSpan.Zero || _jam_keluar == TimeSpan.Zero)
                    return 0;
                return (_jam_keluar - _jam_masuk).TotalHours;
            }
        }

        // Menit telat (dibanding jam masuk normal 08:00)
        public double menitTelat(TimeSpan jamMasukNormal)
        {
            if (_jam_masuk <= jamMasukNormal) return 0;
            return (_jam_masuk - jamMasukNormal).TotalMinutes;
        }

        // Jam lembur (lebih dari jam keluar normal 17:00)
        public double jamLembur(TimeSpan jamKeluarNormal)
        {
            if (_jam_keluar <= jamKeluarNormal) return 0;
            return (_jam_keluar - jamKeluarNormal).TotalHours;
        }

        // Jam pulang cepat (kurang dari jam keluar normal)
        public double jamPulangCepat(TimeSpan jamKeluarNormal)
        {
            // Jika jam_keluar belum diisi (Zero), jangan anggap sebagai pulang cepat
            if (_jam_keluar == TimeSpan.Zero) return 0;
            if (_jam_keluar >= jamKeluarNormal) return 0;
            return (jamKeluarNormal - _jam_keluar).TotalHours;
        }

        // Sudah absen masuk hari ini?
        public bool sudahAbsenMasuk  => _jam_masuk != TimeSpan.Zero;

        // Sudah absen keluar hari ini?
        public bool sudahAbsenKeluar => _jam_keluar != TimeSpan.Zero;
    }
}
