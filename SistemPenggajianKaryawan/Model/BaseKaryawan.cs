using System.Collections.Generic;

namespace SistemPenggajianKaryawan.Model
{
    internal abstract class BaseKaryawan
    {
        private int     _karyawan_id;
        private string  _kode_karyawan;
        private string  _nama_karyawan;
        private string  _jabatan;
        private string  _jenis;
        private decimal _gaji_pokok;
        private bool    _is_aktif;

        public int     karyawan_id    { get { return _karyawan_id; }    set { _karyawan_id = value; } }
        public string  kode_karyawan  { get { return _kode_karyawan; }  set { _kode_karyawan = value; } }
        public string  nama_karyawan  { get { return _nama_karyawan; }  set { _nama_karyawan = value; } }
        public string  jabatan        { get { return _jabatan; }        set { _jabatan = value; } }
        public string  jenis          { get { return _jenis; }          set { _jenis = value; } }
        public decimal gaji_pokok     { get { return _gaji_pokok; }     set { _gaji_pokok = value; } }
        public bool    is_aktif       { get { return _is_aktif; }       set { _is_aktif = value; } }

        public BaseKaryawan()
        {
            _karyawan_id   = 0;
            _kode_karyawan = "";
            _nama_karyawan = "";
            _jabatan       = "";
            _jenis         = "";
            _gaji_pokok    = 0;
            _is_aktif      = true;
        }

        // Wajib diimplementasikan tiap subclass
        public abstract decimal HitungGaji(
            List<DataAbsensi>  absensiList,
            List<KomponenGaji> komponen,
            KonfigurasiAbsensi config);

        public abstract string GetJenis();

        // Konkret
        public string GetInfo()
        {
            return "[" + _jenis + "] " + _nama_karyawan + " - " + _jabatan;
        }
    }
}