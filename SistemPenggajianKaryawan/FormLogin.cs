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
                UserSession.user_id     = Convert.ToInt32(hasil.Rows[0]["user_id"]);
                UserSession.nama        = hasil.Rows[0]["nama"].ToString();
                UserSession.username    = hasil.Rows[0]["username"].ToString();
                UserSession.role        = hasil.Rows[0]["role"].ToString();
                UserSession.karyawan_id = hasil.Rows[0]["karyawan_id"] != DBNull.Value
                    ? Convert.ToInt32(hasil.Rows[0]["karyawan_id"])
                    : 0;

                // Redirect sesuai role
                Form dashboard = null;

                switch (UserSession.role)
                {
                    case "Admin":
                        dashboard = new FormDashboardAdmin();
                        break;
                    case "HRD":
                        dashboard = new FormDashboardHRD();
                        break;
                    case "Karyawan":
                        dashboard = new FormDashboardKaryawan();
                        break;
                    case "Kiosk":
                        dashboard = new FormAbsensi();
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

        private void showPw_btn_Click(object sender, EventArgs e)
        {
            password_txt.UseSystemPasswordChar = !password_txt.UseSystemPasswordChar;
            showPw_btn.Invalidate();
        }

        private void showPw_btn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            int w = showPw_btn.Width;
            int h = showPw_btn.Height;
            
            float cx = w / 2f;
            float cy = h / 2f;
            
            using (Pen pen = new Pen(Color.FromArgb(113, 128, 150), 1.5f))
            using (Brush brush = new SolidBrush(Color.FromArgb(113, 128, 150)))
            {
                // Draw pupil
                e.Graphics.FillEllipse(brush, cx - 2.5f, cy - 2.5f, 5, 5);
                
                // Draw upper and lower eyelid curves
                e.Graphics.DrawArc(pen, cx - 8.5f, cy - 9f, 17, 13, 25, 130);
                e.Graphics.DrawArc(pen, cx - 8.5f, cy - 4f, 17, 13, 205, 130);
                
                if (!password_txt.UseSystemPasswordChar)
                {
                    // Draw a slash across the eye when revealed
                    using (Pen slashPen = new Pen(Color.FromArgb(205, 92, 92), 1.5f))
                    {
                        e.Graphics.DrawLine(slashPen, cx - 7, cy - 5, cx + 7, cy + 5);
                    }
                }
            }
        }
    }
}
