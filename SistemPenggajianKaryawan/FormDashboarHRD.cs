using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormDashboarHRD : Form
    {
        private Form activeForm = null;

        public FormDashboarHRD()
        {
            InitializeComponent();
        }

        private void FormDashboarHRD_Load(object sender, System.EventArgs e)
        {
            if (UserSession.role != "HRD")
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
            // Nanti diisi dari service masing-masing
            // Sementara placeholder dulu biar form bisa jalan
            stat_karyawan_lbl.Text  = "24";
            stat_absensi_lbl.Text   = "22";
            stat_gaji_lbl.Text      = "18";
            stat_periode_lbl.Text   = DateTime.Now.ToString("MMM",
                                      new System.Globalization.CultureInfo("id-ID"));
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
                        btn.ForeColor = btn == logout_btn ? Color.FromArgb(205, 92, 92) : Color.FromArgb(160, 160, 160);
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
        private void menu_karyawan_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_karyawan_btn);
            openChildForm(new FormKaryawan());
        }

        private void menu_absensi_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_absensi_btn);
            openChildForm(new FormAbsensi());
        }

        private void menu_proses_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_proses_btn);
            openChildForm(new FormProsesGaji());
        }

        private void menu_slip_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_slip_btn);
            openChildForm(new FormSlipGaji());
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

