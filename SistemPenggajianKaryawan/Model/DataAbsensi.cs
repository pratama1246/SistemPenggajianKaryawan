namespace SistemPenggajianKaryawan.Model
{
    internal class DataAbsensi
    {
        private int _karyawan_id;
        private int _bulan;
        private int _tahun;
        private int _hadir;
        private int _izin;
        private int _sakit;
        private int _alpha;
        private decimal _lembur;

        public int karyawan_id { get { return _karyawan_id; } set { _karyawan_id = value; } }
        public int bulan       { get { return _bulan; }       set { _bulan = value; } }
        public int tahun       { get { return _tahun; }       set { _tahun = value; } }
        public int hadir       { get { return _hadir; }       set { _hadir = value; } }
        public int izin        { get { return _izin; }        set { _izin = value; } }
        public int sakit       { get { return _sakit; }       set { _sakit = value; } }
        public int alpha       { get { return _alpha; }       set { _alpha = value; } }
        public decimal lembur  { get { return _lembur; }      set { _lembur = value; } }

        public DataAbsensi()
        {
            _karyawan_id = 0;
            _bulan       = 0;
            _tahun       = 0;
            _hadir       = 0;
            _izin        = 0;
            _sakit       = 0;
            _alpha       = 0;
            _lembur      = 0;
        }
    }
}
