namespace SistemPenggajianKaryawan.Model
{
    internal class KomponenGaji
    {
        private int     _komponen_id;
        private string  _nama_komponen;
        private string  _tipe;          // "Tambah" | "Potong"
        private string  _jenis_nilai;   // "Nominal" | "Persen"
        private decimal _nilai;
        private string  _berlaku_untuk; // "Semua" | "Tetap" | "Kontrak" | "Harian"

        public int     komponen_id   { get { return _komponen_id; }   set { _komponen_id = value; } }
        public string  nama_komponen { get { return _nama_komponen; } set { _nama_komponen = value; } }
        public string  tipe          { get { return _tipe; }          set { _tipe = value; } }
        public string  jenis_nilai   { get { return _jenis_nilai; }   set { _jenis_nilai = value; } }
        public decimal nilai         { get { return _nilai; }         set { _nilai = value; } }
        public string  berlaku_untuk { get { return _berlaku_untuk; } set { _berlaku_untuk = value; } }

        public KomponenGaji()
        {
            _komponen_id   = 0;
            _nama_komponen = "";
            _tipe          = "";
            _jenis_nilai   = "";
            _nilai         = 0;
            _berlaku_untuk = "";
        }

        // Hitung nominal berdasarkan jenis: flat atau persen dari gaji pokok,
        // serta dukung tunjangan makan yang dipengaruhi jumlah kehadiran.
        public decimal HitungNominal(decimal gaji_pokok, int jumlahHadir = 0)
        {
            if (_nama_komponen.ToLower().Contains("makan"))
            {
                return _nilai * jumlahHadir;
            }
            if (_jenis_nilai == "Persen")
                return gaji_pokok * (_nilai / 100);
            return _nilai;
        }
    }
}
