using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormDashboardHRD : Form
    {
        private Form activeForm = null;

        public FormDashboardHRD()
        {
            InitializeComponent();
            content_panel.BringToFront();
        }

        private void FormDashboardHRD_Load(object sender, System.EventArgs e)
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

            // Set standard text labels for menu buttons (with Y spacing spacing)
            menu_dashboard_btn.Text = "  Dashboard";
            menu_karyawan_btn.Text  = "  Data Karyawan";
            menu_absensi_btn.Text   = "  Absensi";
            menu_proses_btn.Text    = "  Proses Gaji";
            menu_slip_btn.Text      = "  Slip Gaji";
            logout_btn.Text         = "  Logout";

            muatStatistik();

            // Highlight default active menu
            setAktifMenu(menu_dashboard_btn);
        }

        void muatStatistik()
        {
            try
            {
                Absensi_serv absServ = new Absensi_serv();
                int karyawanAktif = absServ.getJumlahKaryawanAktif();
                int absensiInput = absServ.getJumlahAbsenHariIni();
                int belumInput = karyawanAktif - absensiInput;
                if (belumInput < 0) belumInput = 0;

                stat_karyawan_lbl.Text = karyawanAktif.ToString();
                stat_absensi_lbl.Text = absensiInput.ToString();
                stat_gaji_lbl.Text = belumInput.ToString();
            }
            catch (Exception)
            {
                stat_karyawan_lbl.Text = "0";
                stat_absensi_lbl.Text = "0";
                stat_gaji_lbl.Text = "0";
            }
        }

        private void quick_absensi_btn_Click(object sender, EventArgs e)
        {
            menu_absensi_btn_Click(sender, e);
        }

        private void quick_proses_btn_Click(object sender, EventArgs e)
        {
            menu_proses_btn_Click(sender, e);
        }

        private void quick_slip_btn_Click(object sender, EventArgs e)
        {
            menu_slip_btn_Click(sender, e);
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
