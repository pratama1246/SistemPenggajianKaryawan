using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan
{
    public partial class FormDashboardKaryawan : Form
    {
        private Form activeForm = null;

        public FormDashboardKaryawan()
        {
            InitializeComponent();
        }

        private void FormDashboardKaryawan_Load(object sender, EventArgs e)
        {
            // 1. Cek role keamanan
            if (UserSession.role != "Karyawan")
            {
                MessageBox.Show("Akses ditolak.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 2. Set Tanggal Hari Ini
            tanggal_lbl.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

            // 3. Ambil data profil dari database berdasarkan user login
            MuatProfilKaryawan();
        }

        private void MuatProfilKaryawan()
        {
            try
            {
                Koneksi server = new Koneksi();
                
                // Ambil link karyawan_id dari tabel users
                string qUser = "SELECT karyawan_id FROM users WHERE user_id = @user_id";
                var pUser = new Dictionary<string, object> { { "@user_id", UserSession.user_id } };
                DataTable dtUser = server.eksekusiQueryParam(qUser, pUser);

                if (dtUser.Rows.Count > 0 && dtUser.Rows[0]["karyawan_id"] != DBNull.Value)
                {
                    int karyawanId = Convert.ToInt32(dtUser.Rows[0]["karyawan_id"]);

                    // Query data karyawan konkret
                    string qKaryawan = "SELECT kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok FROM karyawan WHERE karyawan_id = @karyawan_id";
                    var pKaryawan = new Dictionary<string, object> { { "@karyawan_id", karyawanId } };
                    DataTable dtKaryawan = server.eksekusiQueryParam(qKaryawan, pKaryawan);

                    if (dtKaryawan.Rows.Count > 0)
                    {
                        string kode = dtKaryawan.Rows[0]["kode_karyawan"].ToString();
                        string nama = dtKaryawan.Rows[0]["nama_karyawan"].ToString();
                        string jabatan = dtKaryawan.Rows[0]["jabatan"].ToString();
                        string jenis = dtKaryawan.Rows[0]["jenis"].ToString();
                        decimal gapok = Convert.ToDecimal(dtKaryawan.Rows[0]["gaji_pokok"]);

                        sambut_lbl.Text = "Selamat datang, " + nama;
                        stat_kode_lbl.Text = kode;
                        stat_jabatan_lbl.Text = jabatan;
                        stat_jenis_lbl.Text = jenis;
                        stat_gapok_lbl.Text = string.Format("Rp {0:N0}", gapok);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // Silently fallback to session information if database fails
            }

            // Fallback default (misal user seeder awal yang belum ditautkan data karyawannya)
            sambut_lbl.Text = "Selamat datang, " + UserSession.nama;
            stat_kode_lbl.Text = "K-PENDING";
            stat_jabatan_lbl.Text = "Staff";
            stat_jenis_lbl.Text = "Tetap";
            stat_gapok_lbl.Text = "Rp 3.500.000";
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

        private void stat_jenis_lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
