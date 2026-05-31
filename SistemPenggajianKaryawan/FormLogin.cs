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

        private void logoPic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw outer subtle glowing ring matching the primary color #5BC8F5
            using (var pen = new Pen(Color.FromArgb(91, 200, 245), 1.5f))
            {
                e.Graphics.DrawEllipse(pen, 5, 5, 90, 90);
            }

            // Draw three modern stylized building pillars representing PNC
            // Left pillar (Blue #5BC8F5)
            using (var brush = new SolidBrush(Color.FromArgb(91, 200, 245)))
            {
                e.Graphics.FillRectangle(brush, 31, 28, 11, 44);
            }
            // Middle pillar (Neutral gray #C8C8C8)
            using (var brush = new SolidBrush(Color.FromArgb(200, 200, 200)))
            {
                e.Graphics.FillRectangle(brush, 44, 22, 11, 50);
            }
            // Right pillar (Amber #F5A623)
            using (var brush = new SolidBrush(Color.FromArgb(245, 166, 35)))
            {
                e.Graphics.FillRectangle(brush, 57, 34, 11, 38);
            }

            // Connect pillars at the bottom with a solid base
            using (var brush = new SolidBrush(Color.FromArgb(91, 200, 245)))
            {
                e.Graphics.FillRectangle(brush, 28, 73, 44, 4);
            }
        }
    }
}
