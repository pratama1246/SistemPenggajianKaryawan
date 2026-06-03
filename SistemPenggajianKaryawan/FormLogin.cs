using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormLogin : Form
    {
        Auth_serv auth = new Auth_serv();

        public FormLogin()
        {
            InitializeComponent();
            LoadLogo();
        }

        private void LoadLogo()
        {
            try
            {
                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SistemPenggajianKaryawan.Resources.Politeknik_Negeri_Cilacap.png"))
                {
                    if (stream != null)
                    {
                        logoPic.Image = new Bitmap(stream);
                    }
                }
            }
            catch { }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            username_txt.Focus();
            error_lbl.Visible = false;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            prosesLogin();
        }

        // Biar bisa Enter dari keyboard juga
        private void password_txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                prosesLogin();
        }

        private void username_txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                password_txt.Focus();
        }

        void prosesLogin()
        {
            if (username_txt.Text.Trim() == "" || password_txt.Text == "")
            {
                tampilError("Username dan password tidak boleh kosong.");
                return;
            }

            DataTable hasil = auth.login(username_txt.Text.Trim(), password_txt.Text);

            if (hasil.Rows.Count > 0)
            {
                // Isi UserSession
                UserSession.user_id  = Convert.ToInt32(hasil.Rows[0]["user_id"]);
                UserSession.nama     = hasil.Rows[0]["nama"].ToString();
                UserSession.username = hasil.Rows[0]["username"].ToString();
                UserSession.role     = hasil.Rows[0]["role"].ToString();

                // Redirect sesuai role
                Form dashboard = null;

                switch (UserSession.role)
                {
                    case "Admin":
                        dashboard = new FormDashboardAdmin();
                        break;
                    case "HRD":
                        dashboard = new FormDashboarHRD();
                        break;
                    case "Karyawan":
                        dashboard = new FormDashboardKaryawan();
                        break;
                    default:
                        tampilError("Role tidak dikenali. Hubungi administrator.");
                        return;
                }

                this.Hide();
                dashboard.ShowDialog();
                // Kalau dashboard ditutup (logout), balik ke login
                UserSession.Clear();
                this.Show();
                bersihkan();
            }
            else
            {
                tampilError("Username atau password salah.");
                password_txt.Clear();
                password_txt.Focus();
            }
        }

        void tampilError(string pesan)
        {
            error_lbl.Text    = pesan;
            error_lbl.Visible = true;
        }

        void bersihkan()
        {
            username_txt.Clear();
            password_txt.Clear();
            error_lbl.Visible = false;
            username_txt.Focus();
        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
