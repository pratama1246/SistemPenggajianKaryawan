namespace SistemPenggajianKaryawan.Konfigurasi
{
    internal static class UserSession
    {
        public static int user_id { get; set; }
        public static string nama { get; set; }
        public static string username { get; set; }
        public static string role { get; set; } // "Admin" | "HRD" | "Karyawan"

        public static void Clear()
        {
            user_id = 0;
            nama = "";
            username = "";
            role = "";
        }

        public static bool IsLoggedIn() => user_id > 0;
    }
}