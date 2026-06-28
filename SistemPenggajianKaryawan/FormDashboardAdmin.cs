using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormDashboardAdmin : Form
    {
        private Form activeForm = null;

        public FormDashboardAdmin()
        {
            InitializeComponent();
            content_panel.BringToFront();
        }

        private void FormDashboardAdmin_Load(object sender, EventArgs e)
        {
            if (UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak.");
                this.Close();
                return;
            }

            sambut_lbl.Text  = "Selamat datang, " + UserSession.nama;
            tanggal_lbl.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy",
                               new System.Globalization.CultureInfo("id-ID"));

            muatStatistik();
        }

        void muatStatistik()
        {
            try
            {
                Karyawan_serv karyawan = new Karyawan_serv();
                Auth_serv auth = new Auth_serv();
                KomponenGaji_serv komponen = new KomponenGaji_serv();

                stat_karyawan_lbl.Text = karyawan.getCounts()["Semua"].ToString();
                stat_user_lbl.Text = auth.getJumlahUserAktif().ToString();
                stat_komponen_lbl.Text = komponen.getJumlahKomponenAktif().ToString();
                stat_periode_lbl.Text = DateTime.Now.ToString("MMM", new System.Globalization.CultureInfo("id-ID"));
            }
            catch (Exception)
            {
                stat_karyawan_lbl.Text = "0";
                stat_user_lbl.Text = "0";
                stat_komponen_lbl.Text = "0";
                stat_periode_lbl.Text = "-";
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            dashboard_home_panel.Visible = false;

            content_panel.Controls.Add(childForm);

            if (childForm.IsDisposed)
            {
                activeForm = null;
                dashboard_home_panel.Visible = true;
                setAktifMenu(menu_dashboard_btn);
                return;
            }

            content_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void setAktifMenu(Button btnAktif)
        {
            foreach (Control c in sidebar_panel.Controls)
            {
                if (c is Button btn)
                {
                    if (btn == btnAktif)
                    {
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        btn.ForeColor = Color.FromArgb(24, 24, 24);
                        btn.BackColor = Color.FromArgb(91, 200, 245);
                    }
                    else
                    {
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                        btn.ForeColor = btn == logout_btn ? Color.FromArgb(205, 92, 92) : Color.FromArgb(74, 85, 104);
                        btn.BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void menu_dashboard_btn_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }
            dashboard_home_panel.Visible = true;
            setAktifMenu(menu_dashboard_btn);
        }

        // Navigasi menu
        private void menu_user_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_user_btn);
            openChildForm(new FormManajemenUser());
        }

        private void menu_komponen_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_komponen_btn);
            openChildForm(new FormKomponenGaji());
        }

        private void menu_rekap_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_rekap_btn);
            openChildForm(new FormRekapGaji());
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.Clear();
                this.Close();
            }
        }
    }
}

