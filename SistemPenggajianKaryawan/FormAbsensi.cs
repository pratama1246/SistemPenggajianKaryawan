using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Model;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormAbsensi : Form
    {
        private Absensi_serv absensi_serv = new Absensi_serv();
        private bool isCariPlaceholder = true;
        private string placeholderText = "🔍 Cari karyawan...";

        public FormAbsensi()
        {
            InitializeComponent();
        }

        private void FormAbsensi_Load(object sender, EventArgs e)
        {
            // 1. Cek Role Keamanan
            if (UserSession.role != "HRD" && UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak. Form ini hanya untuk Admin atau HRD.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 2. Setup DataGridView Properties
            SetupDataGridView();

            // 3. Set Default Periode (Bulan Ini)
            bulan_cmb.SelectedIndex = DateTime.Now.Month - 1;
            tahun_txt.Text = DateTime.Now.Year.ToString();

            // 4. Muat Data
            muatKaryawanCmb();
            bersihkan();
            tampilGrid();
        }

        private void SetupDataGridView()
        {
            absensi_dgv.ReadOnly = true;
            absensi_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            absensi_dgv.MultiSelect = false;
            absensi_dgv.AllowUserToAddRows = false;
            absensi_dgv.AllowUserToDeleteRows = false;
            absensi_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            absensi_dgv.EnableHeadersVisualStyles = false;
            absensi_dgv.BorderStyle = BorderStyle.None;
            absensi_dgv.RowHeadersVisible = false;

            // Background & Border colors
            absensi_dgv.BackgroundColor = Color.FromArgb(38, 38, 38);
            absensi_dgv.GridColor = Color.FromArgb(58, 58, 58);

            // Headers Styling
            absensi_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            absensi_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            absensi_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            absensi_dgv.ColumnHeadersHeight = 32;

            // Row cell margins
            absensi_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void muatKaryawanCmb()
        {
            try
            {
                DataTable dt = absensi_serv.getKaryawanAktif();
                karyawan_cmb.DataSource = dt;
                karyawan_cmb.DisplayMember = "nama_karyawan";
                karyawan_cmb.ValueMember = "karyawan_id";
                if (dt.Rows.Count > 0)
                {
                    karyawan_cmb.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }

        private void tampilGrid()
        {
            if (bulan_cmb.SelectedIndex == -1) return;

            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun;
            if (!int.TryParse(tahun_txt.Text, out tahun))
            {
                tahun = DateTime.Now.Year;
            }

            string keyword = (isCariPlaceholder || string.IsNullOrEmpty(cari_txt.Text)) ? "" : cari_txt.Text.Trim();

            DataTable dt;
            if (string.IsNullOrEmpty(keyword))
            {
                dt = absensi_serv.viewAbsensiPeriode(bulan, tahun);
            }
            else
            {
                dt = absensi_serv.searchAbsensiPeriode(bulan, tahun, keyword);
            }

            absensi_dgv.DataSource = dt;

            // Atur Visibilitas Kolom
            if (absensi_dgv.Columns.Count > 0)
            {
                // Hide ID dan kode karyawan agar rapi seperti mockup
                if (absensi_dgv.Columns["karyawan_id"] != null) absensi_dgv.Columns["karyawan_id"].Visible = false;
                if (absensi_dgv.Columns["kode_karyawan"] != null) absensi_dgv.Columns["kode_karyawan"].Visible = false;
                if (absensi_dgv.Columns["izin"] != null) absensi_dgv.Columns["izin"].Visible = false;
                if (absensi_dgv.Columns["sakit"] != null) absensi_dgv.Columns["sakit"].Visible = false;

                // Rename headers
                if (absensi_dgv.Columns["nama_karyawan"] != null) absensi_dgv.Columns["nama_karyawan"].HeaderText = "Nama";
                if (absensi_dgv.Columns["jenis"] != null) absensi_dgv.Columns["jenis"].HeaderText = "Jenis";
                if (absensi_dgv.Columns["hadir"] != null) absensi_dgv.Columns["hadir"].HeaderText = "Hadir";
                if (absensi_dgv.Columns["alpha"] != null) absensi_dgv.Columns["alpha"].HeaderText = "Alpha";
                if (absensi_dgv.Columns["lembur"] != null) absensi_dgv.Columns["lembur"].HeaderText = "Lembur";
                if (absensi_dgv.Columns["status"] != null) absensi_dgv.Columns["status"].HeaderText = "Status";
            }

            // Hitung Belum Input
            int countPending = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["status"].ToString() == "Pending")
                {
                    countPending++;
                }
            }

            belumInput_lbl.Text = "Belum Input: " + countPending;
            if (countPending > 0)
            {
                belumInput_lbl.BackColor = Color.FromArgb(245, 166, 23); // Orange
                belumInput_lbl.ForeColor = Color.Black;
            }
            else
            {
                belumInput_lbl.BackColor = Color.FromArgb(76, 175, 80); // Green
                belumInput_lbl.ForeColor = Color.White;
            }
        }

        private void bersihkan()
        {
            hadir_txt.Text = "22"; // standard working days default
            izin_txt.Text = "0";
            sakit_txt.Text = "0";
            alpha_txt.Text = "0";
            lembur_txt.Text = "0";

            if (karyawan_cmb.Items.Count > 0)
            {
                karyawan_cmb.SelectedIndex = 0;
            }
            absensi_dgv.ClearSelection();
        }

        private void loadDetailKehadiran(int karyawanId)
        {
            foreach (DataGridViewRow row in absensi_dgv.Rows)
            {
                if (row.Cells["karyawan_id"].Value != null && Convert.ToInt32(row.Cells["karyawan_id"].Value) == karyawanId)
                {
                    object statusObj = row.Cells["status"].Value;
                    if (statusObj != null && statusObj.ToString() == "Selesai")
                    {
                        hadir_txt.Text = row.Cells["hadir"].Value.ToString();
                        izin_txt.Text = row.Cells["izin"].Value.ToString();
                        sakit_txt.Text = row.Cells["sakit"].Value.ToString();
                        alpha_txt.Text = row.Cells["alpha"].Value.ToString();
                        
                        decimal lemburVal = Convert.ToDecimal(row.Cells["lembur"].Value);
                        lembur_txt.Text = lemburVal.ToString("0");
                    }
                    else
                    {
                        // Reset to defaults for new input
                        hadir_txt.Text = "22";
                        izin_txt.Text = "0";
                        sakit_txt.Text = "0";
                        alpha_txt.Text = "0";
                        lembur_txt.Text = "0";
                    }
                    break;
                }
            }
        }

        private void absensi_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = absensi_dgv.Rows[e.RowIndex];
                if (row.Cells["karyawan_id"].Value != null)
                {
                    int karyawanId = Convert.ToInt32(row.Cells["karyawan_id"].Value);
                    karyawan_cmb.SelectedValue = karyawanId;
                    loadDetailKehadiran(karyawanId);
                }
            }
        }

        private void karyawan_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (karyawan_cmb.SelectedValue != null && karyawan_cmb.SelectedValue is int)
            {
                loadDetailKehadiran((int)karyawan_cmb.SelectedValue);
            }
        }

        private void bulan_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void tahun_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void cari_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCariPlaceholder)
            {
                cari_txt.Text = "";
                cari_txt.ForeColor = Color.White;
                isCariPlaceholder = false;
            }
        }

        private void cari_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cari_txt.Text))
            {
                cari_txt.Text = placeholderText;
                cari_txt.ForeColor = Color.Gray;
                isCariPlaceholder = true;
            }
        }

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            if (karyawan_cmb.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int karyawanId = Convert.ToInt32(karyawan_cmb.SelectedValue);
            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun;

            if (!int.TryParse(tahun_txt.Text, out tahun) || tahun < 2000 || tahun > 2100)
            {
                MessageBox.Show("Format tahun tidak valid (masukkan angka antara 2000-2100).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tahun_txt.Focus();
                return;
            }

            int hadir, izin, sakit, alpha;
            decimal lembur;

            if (!int.TryParse(hadir_txt.Text, out hadir) || hadir < 0 || hadir > 31)
            {
                MessageBox.Show("Input Hadir harus berupa angka positif (maks 31).", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hadir_txt.Focus();
                return;
            }

            if (!int.TryParse(izin_txt.Text, out izin) || izin < 0 || izin > 31)
            {
                MessageBox.Show("Input Izin harus berupa angka positif.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                izin_txt.Focus();
                return;
            }

            if (!int.TryParse(sakit_txt.Text, out sakit) || sakit < 0 || sakit > 31)
            {
                MessageBox.Show("Input Sakit harus berupa angka positif.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sakit_txt.Focus();
                return;
            }

            if (!int.TryParse(alpha_txt.Text, out alpha) || alpha < 0 || alpha > 31)
            {
                MessageBox.Show("Input Alpha harus berupa angka positif.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alpha_txt.Focus();
                return;
            }

            if (!decimal.TryParse(lembur_txt.Text, out lembur) || lembur < 0)
            {
                MessageBox.Show("Input Lembur harus berupa angka desimal positif.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lembur_txt.Focus();
                return;
            }

            DataAbsensi abs = new DataAbsensi();
            abs.karyawan_id = karyawanId;
            abs.bulan = bulan;
            abs.tahun = tahun;
            abs.hadir = hadir;
            abs.izin = izin;
            abs.sakit = sakit;
            abs.alpha = alpha;
            abs.lembur = lembur;

            bool exists = absensi_serv.jikaAda(karyawanId, bulan, tahun);

            if (exists)
            {
                if (MessageBox.Show("Yakin ingin mengubah data absensi untuk karyawan ini pada periode tersebut?", 
                    "Konfirmasi Perubahan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (absensi_serv.update(abs) > 0)
                    {
                        MessageBox.Show("Data absensi berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bersihkan();
                        tampilGrid();
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui data absensi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (absensi_serv.Save(abs) > 0)
                {
                    MessageBox.Show("Data absensi berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data absensi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bersihkan();
        }

        private void absensi_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = absensi_dgv.Columns[e.ColumnIndex].Name;

            // 1. Format alternating rows dark background
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(43, 43, 43);
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(50, 50, 50);
            }
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255); // Selection Dodger Blue
            e.CellStyle.SelectionForeColor = Color.White;

            // 2. Format Badge untuk Kolom Jenis Karyawan
            if (colName == "jenis" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Tetap")
                {
                    e.CellStyle.BackColor = Color.FromArgb(26, 54, 93); // Dark Blue Badge
                    e.CellStyle.ForeColor = Color.FromArgb(144, 205, 244);
                }
                else if (val == "Harian")
                {
                    e.CellStyle.BackColor = Color.FromArgb(28, 69, 50); // Dark Green Badge
                    e.CellStyle.ForeColor = Color.FromArgb(154, 230, 180);
                }
                else if (val == "Kontrak")
                {
                    e.CellStyle.BackColor = Color.FromArgb(116, 66, 16); // Dark Orange/Brown Badge
                    e.CellStyle.ForeColor = Color.FromArgb(254, 215, 170);
                }
            }

            // 3. Format Lembur to append " jam" unit
            if (colName == "lembur" && e.Value != null && e.Value != DBNull.Value)
            {
                string valStr = e.Value.ToString();
                if (valStr == "—" || valStr == "") return;
                
                decimal val;
                if (decimal.TryParse(valStr, out val))
                {
                    e.Value = string.Format("{0:0} jam", val);
                    e.FormattingApplied = true;
                }
            }

            // 4. Format Status Badge
            if (colName == "status" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Pending")
                {
                    e.CellStyle.BackColor = Color.FromArgb(116, 66, 16); // Dark Orange
                    e.CellStyle.ForeColor = Color.FromArgb(254, 215, 170);
                }
                else if (val == "Selesai")
                {
                    e.CellStyle.BackColor = Color.FromArgb(28, 69, 50); // Dark Green
                    e.CellStyle.ForeColor = Color.FromArgb(154, 230, 180);
                    e.Value = "✔ Selesai";
                    e.FormattingApplied = true;
                }
            }

            // 5. Ubah DBNull/Null/Empty ke tanda "—" untuk data kehadiran yang pending
            if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (colName == "hadir" || colName == "alpha" || colName == "lembur")
                {
                    e.Value = "—";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Color.FromArgb(120, 120, 120);
                }
            }
        }

        private void panel_left_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
