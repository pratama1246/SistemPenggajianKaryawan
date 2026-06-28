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
        private int slip1Bulan = 0;
        private int slip1Tahun = 0;
        private int slip2Bulan = 0;
        private int slip2Tahun = 0;

        public FormDashboardKaryawan()
        {
            InitializeComponent();
            content_panel.BringToFront();
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

            // 3. Set standard text labels for menu buttons
            menu_dashboard_btn.Text = "  Dashboard";
            menu_absensi_btn.Text   = "  Absensi";
            menu_slip_btn.Text      = "  Slip Gaji";
            menu_rekap_btn.Text     = "  Rekap Absensi";
            menu_password_btn.Text  = "  Ganti Password";
            logout_btn.Text         = "  Logout";

            // 4. Ambil data profil dari database berdasarkan user login
            MuatProfilKaryawan();

            // Highlight default menu
            setAktifMenu(menu_dashboard_btn);
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

                        sambut_lbl.Text = "Selamat datang, " + nama;
                        profile_nama_lbl.Text = nama;
                        profile_job_lbl.Text = jenis + " · " + jabatan;

                        // Inisial avatar
                        string[] nameParts = nama.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string initials = "";
                        if (nameParts.Length > 0) initials += nameParts[0][0];
                        if (nameParts.Length > 1) initials += nameParts[1][0];
                        avatar_lbl.Text = initials.ToUpper();

                        // Query statistics: Hadir & Alpha count for current month & year
                        int currentBulan = DateTime.Now.Month;
                        int currentTahun = DateTime.Now.Year;

                        string qAbs = @"
                            SELECT 
                                COALESCE(SUM(CASE WHEN status = 'Hadir' THEN 1 ELSE 0 END), 0) AS hadir,
                                COALESCE(SUM(CASE WHEN status = 'Alpha' THEN 1 ELSE 0 END), 0) AS alpha
                            FROM absensi 
                            WHERE karyawan_id = @id AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun";
                        var pAbs = new Dictionary<string, object>
                        {
                            { "@id", karyawanId },
                            { "@bulan", currentBulan },
                            { "@tahun", currentTahun }
                        };
                        DataTable dtAbs = server.eksekusiQueryParam(qAbs, pAbs);
                        int countHadir = 0;
                        int countAlpha = 0;
                        if (dtAbs.Rows.Count > 0)
                        {
                            countHadir = Convert.ToInt32(dtAbs.Rows[0]["hadir"]);
                            countAlpha = Convert.ToInt32(dtAbs.Rows[0]["alpha"]);
                        }
                        stat_hadir_lbl.Text = countHadir.ToString();
                        stat_alpha_lbl.Text = countAlpha.ToString();

                        // Query latest salary from penggajian table
                        string qGaji = "SELECT gaji_bersih FROM penggajian WHERE karyawan_id = @id ORDER BY tahun DESC, bulan DESC LIMIT 1";
                        var pGaji = new Dictionary<string, object> { { "@id", karyawanId } };
                        DataTable dtGaji = server.eksekusiQueryParam(qGaji, pGaji);
                        if (dtGaji.Rows.Count > 0)
                        {
                            decimal gajiBersih = Convert.ToDecimal(dtGaji.Rows[0]["gaji_bersih"]);
                            if (gajiBersih >= 1000000)
                            {
                                stat_gajibulan_lbl.Text = string.Format("{0:0.#}jt", gajiBersih / 1000000m);
                            }
                            else
                            {
                                stat_gajibulan_lbl.Text = string.Format("Rp {0:N0}", gajiBersih);
                            }
                        }
                        else
                        {
                            stat_gajibulan_lbl.Text = "Rp 0";
                        }

                        // Query latest 2 slips
                        string qSlips = "SELECT bulan, tahun FROM penggajian WHERE karyawan_id = @id ORDER BY tahun DESC, bulan DESC LIMIT 2";
                        DataTable dtSlips = server.eksekusiQueryParam(qSlips, pGaji);

                        string[] namaBulanArr = {
                            "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                            "Juli", "Agustus", "September", "Oktober", "November", "Desember"
                        };

                        if (dtSlips.Rows.Count == 0)
                        {
                            slip1_panel.Visible = false;
                            slip2_panel.Visible = false;
                            slip_terbaru_lbl.Text = "Belum ada slip gaji tersedia";
                        }
                        else if (dtSlips.Rows.Count == 1)
                        {
                            slip1Bulan = Convert.ToInt32(dtSlips.Rows[0]["bulan"]);
                            slip1Tahun = Convert.ToInt32(dtSlips.Rows[0]["tahun"]);
                            string bName = (slip1Bulan >= 1 && slip1Bulan <= 12) ? namaBulanArr[slip1Bulan - 1] : "";
                            slip1_title.Text = $"Slip Gaji {bName} {slip1Tahun}";
                            slip1_panel.Visible = true;

                            slip2_panel.Visible = false;
                            slip_terbaru_lbl.Text = "Slip gaji terbaru";
                        }
                        else
                        {
                            slip1Bulan = Convert.ToInt32(dtSlips.Rows[0]["bulan"]);
                            slip1Tahun = Convert.ToInt32(dtSlips.Rows[0]["tahun"]);
                            string bName1 = (slip1Bulan >= 1 && slip1Bulan <= 12) ? namaBulanArr[slip1Bulan - 1] : "";
                            slip1_title.Text = $"Slip Gaji {bName1} {slip1Tahun}";
                            slip1_panel.Visible = true;

                            slip2Bulan = Convert.ToInt32(dtSlips.Rows[1]["bulan"]);
                            slip2Tahun = Convert.ToInt32(dtSlips.Rows[1]["tahun"]);
                            string bName2 = (slip2Bulan >= 1 && slip2Bulan <= 12) ? namaBulanArr[slip2Bulan - 1] : "";
                            slip2_title.Text = $"Slip Gaji {bName2} {slip2Tahun}";
                            slip2_panel.Visible = true;
                            slip_terbaru_lbl.Text = "Slip gaji terbaru";
                        }
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // Fallback default
            }

            // Fallback default details
            sambut_lbl.Text = "Selamat datang, " + UserSession.nama;
            profile_nama_lbl.Text = UserSession.nama;
            profile_job_lbl.Text = "Karyawan Tetap · Staff";
            avatar_lbl.Text = "K";
            stat_hadir_lbl.Text = "0";
            stat_alpha_lbl.Text = "0";
            stat_gajibulan_lbl.Text = "Rp 0";
            slip1_panel.Visible = false;
            slip2_panel.Visible = false;
            slip_terbaru_lbl.Text = "Belum ada slip gaji tersedia";
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

        private void TampilkanErrorProfilBelumTerkait()
        {
            MessageBox.Show(
                "Profil karyawan tidak ditemukan untuk akun ini.\n\n" +
                "Pastikan akun Anda sudah di-link ke data karyawan oleh Admin/HRD " +
                "melalui menu Manajemen User → kolom 'Karyawan Terkait'.",
                "Profil Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void menu_absensi_btn_Click(object sender, EventArgs e)
        {
            if (UserSession.karyawan_id == 0)
            {
                TampilkanErrorProfilBelumTerkait();
                return;
            }
            setAktifMenu(menu_absensi_btn);
            openChildForm(new FormAbsensi());
        }

        private void menu_slip_btn_Click(object sender, EventArgs e)
        {
            if (UserSession.karyawan_id == 0)
            {
                TampilkanErrorProfilBelumTerkait();
                return;
            }
            setAktifMenu(menu_slip_btn);
            openChildForm(new FormSlipGaji());
        }

        private void menu_rekap_btn_Click(object sender, EventArgs e)
        {
            if (UserSession.karyawan_id == 0)
            {
                TampilkanErrorProfilBelumTerkait();
                return;
            }
            setAktifMenu(menu_rekap_btn);
            openChildForm(new FormRekapAbsensi());
        }

        private void menu_password_btn_Click(object sender, EventArgs e)
        {
            setAktifMenu(menu_password_btn);
            openChildForm(new FormGantiPassword());
        }

        private void slip1_view_btn_Click(object sender, EventArgs e)
        {
            if (slip1Bulan > 0 && slip1Tahun > 0)
            {
                FormSlipGaji.PreSelectedBulan = slip1Bulan;
                FormSlipGaji.PreSelectedTahun = slip1Tahun;
                menu_slip_btn_Click(sender, e);
            }
        }

        private void slip2_view_btn_Click(object sender, EventArgs e)
        {
            if (slip2Bulan > 0 && slip2Tahun > 0)
            {
                FormSlipGaji.PreSelectedBulan = slip2Bulan;
                FormSlipGaji.PreSelectedTahun = slip2Tahun;
                menu_slip_btn_Click(sender, e);
            }
        }

        private void avatar_lbl_Paint(object sender, PaintEventArgs e)
        {
            using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, avatar_lbl.Width - 1, avatar_lbl.Height - 1);
                avatar_lbl.Region = new Region(gp);
            }
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
