using System.Data;

namespace SistemPenggajianKaryawan.Konfigurasi
{
    internal class Konfigurasi
    {
        public abstract int eksekusiNonQuery(string query);
        public abstract DataTable eksekusiQuery(string query);
    }
}
