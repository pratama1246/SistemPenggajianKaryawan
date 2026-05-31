using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Seed database tables and sample accounts
            DatabaseSeeder.Seed();

            Application.Run(new FormSplash());
        }
    }
}
