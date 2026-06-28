namespace SistemPenggajianKaryawan.Konfigurasi
{
    internal static class UserSession
    {
        public static int user_id      { get; set; }
        public static string nama      { get; set; }
        public static string username  { get; set; }
        public static string role      { get; set; } // "Admin" | "HRD" | "Karyawan"
        public static int karyawan_id  { get; set; } // 0 jika bukan role Karyawan

        public static void Clear()
        {
            user_id     = 0;
            nama        = "";
            username    = "";
            role        = "";
            karyawan_id = 0;
        }

        public static bool IsLoggedIn() => user_id > 0;
    }
}