using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormKaryawan : Form
    {
        private Karyawan_serv karyawan = new Karyawan_serv();
        private string currentFilter = "Semua";
        private bool isCariPlaceholder = true;
        private const string PlaceholderText = "🔍 Cari nama atau kode...";
        private Button btnCetakQR;

        public FormKaryawan()
        {
            InitializeComponent();
        }

        private void FormKaryawan_Load(object sender, EventArgs e)
        {
            // 1. Hak Akses: Hanya Admin dan HRD
            if (UserSession.role != "HRD" && UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak. Form ini hanya dapat diakses oleh HRD atau Admin.", 
                                "Akses Terbatas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // 2. Jika Admin, buat form menjadi Read-Only (Admin bukan dewa)
            if (UserSession.role == "Admin")
            {
                panel_left.Enabled = false;
                inputTitle_lbl.Text = "INPUT DATA (READ-ONLY)";
            }

            // Inisialisasi awal
            bersihkan();
            hitungStatistikFilter();
            tampilGrid();

            // Tambahkan Tombol Preview QR secara dinamis di panel_left
            btnCetakQR = new Button();
            btnCetakQR.Name = "btn_cetak_qr";
            btnCetakQR.Text = "Preview & Cetak QR Code";
            btnCetakQR.Location = new Point(23, 485);
            btnCetakQR.Size = new Size(277, 35);
            btnCetakQR.FlatStyle = FlatStyle.Flat;
            btnCetakQR.FlatAppearance.BorderSize = 1;
            btnCetakQR.FlatAppearance.BorderColor = Color.FromArgb(91, 200, 245); // primary cyan
            btnCetakQR.ForeColor = Color.FromArgb(30, 144, 255); // primary-dark
            btnCetakQR.BackColor = Color.White;
            btnCetakQR.Cursor = Cursors.Hand;
            btnCetakQR.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCetakQR.Enabled = false; // default mati sampai pilih karyawan
            btnCetakQR.Click += btnCetakQR_Click;
            panel_left.Controls.Add(btnCetakQR);
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOGIKA RESET / BERSIHKAN
        // ─────────────────────────────────────────────────────────────────────
        private void bersihkan()
        {
            kode_txt.Text = karyawan.createCode();
            if (btnCetakQR != null) btnCetakQR.Enabled = false;
            nama_txt.Clear();
            jabatan_txt.Clear();
            jenis_cmb.SelectedIndex = 0;
            gaji_txt.Text = "0";

            karyawan_dgv.ClearSelection();

            // Fokus ke input nama jika bukan admin
            if (UserSession.role != "Admin")
            {
                nama_txt.Focus();
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOGIKA REKAP HITUNG STATISTIK DI TOMBOL FILTER
        // ─────────────────────────────────────────────────────────────────────
        private void hitungStatistikFilter()
        {
            var counts = karyawan.getCounts();
            btn_filter_semua.Text = "Semua (" + counts["Semua"] + ")";
            btn_filter_tetap.Text = "Tetap (" + counts["Tetap"] + ")";
            btn_filter_kontrak.Text = "Kontrak (" + counts["Kontrak"] + ")";
            btn_filter_harian.Text = "Harian (" + counts["Harian"] + ")";
        }

        // ─────────────────────────────────────────────────────────────────────
        // TAMPILKAN DATA GRID
        // ─────────────────────────────────────────────────────────────────────
        private void tampilGrid()
        {
            string keyword = (isCariPlaceholder || string.IsNullOrWhiteSpace(cari_txt.Text))
                ? "" : cari_txt.Text.Trim();

            DataTable dt = string.IsNullOrEmpty(keyword)
                ? karyawan.viewAll(currentFilter)
                : karyawan.search(keyword, currentFilter);

            karyawan_dgv.DataSource = dt;
            formatHeaders();
            warnaiAlternatingRows();
        }

        private void formatHeaders()
        {
            if (karyawan_dgv.Columns.Count == 0) return;

            // Sembunyikan kolom ID dan is_aktif
            if (karyawan_dgv.Columns.Contains("karyawan_id")) karyawan_dgv.Columns["karyawan_id"].Visible = false;
            if (karyawan_dgv.Columns.Contains("is_aktif"))    karyawan_dgv.Columns["is_aktif"].Visible    = false;

            // Rename Header Text
            if (karyawan_dgv.Columns.Contains("kode_karyawan")) karyawan_dgv.Columns["kode_karyawan"].HeaderText = "Kode";
            if (karyawan_dgv.Columns.Contains("nama_karyawan")) karyawan_dgv.Columns["nama_karyawan"].HeaderText = "Nama";
            if (karyawan_dgv.Columns.Contains("jabatan"))       karyawan_dgv.Columns["jabatan"].HeaderText       = "Jabatan";
            if (karyawan_dgv.Columns.Contains("jenis"))         karyawan_dgv.Columns["jenis"].HeaderText         = "Jenis";
            if (karyawan_dgv.Columns.Contains("gaji_pokok"))    karyawan_dgv.Columns["gaji_pokok"].HeaderText    = "Gaji Pokok";

            // Atur visual Header DataGridView
            karyawan_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            karyawan_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            karyawan_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            karyawan_dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            karyawan_dgv.ColumnHeadersHeight = 34;
        }

        private void warnaiAlternatingRows()
        {
            foreach (DataGridViewRow row in karyawan_dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Jangan timpa warna kolom 'jenis' karena akan diwarnai badge
                    if (karyawan_dgv.Columns[cell.ColumnIndex].Name == "jenis") continue;

                    cell.Style.BackColor = row.Index % 2 == 0
                        ? Color.FromArgb(240, 248, 255)   // Alice Blue
                        : Color.FromArgb(176, 196, 222);  // Light Steel Blue
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // FORMAT BADGE & MATA UANG DI GRID (CELL FORMATTING)
        // ─────────────────────────────────────────────────────────────────────
        private void karyawan_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = karyawan_dgv.Columns[e.ColumnIndex].Name;

            // 1. Format Default Teks & Pilihan
            e.CellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245); // Primary Blue
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            // 2. Warnai Badge Kolom 'Jenis' (Tetap, Kontrak, Harian)
            if (colName == "jenis" && e.Value != null)
            {
                string val = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (val == "Tetap")
                {
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);      // Light Blue
                    e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175);        // Dark Blue text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
                }
                else if (val == "Harian")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);      // Light Green
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);        // Dark Green text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(187, 247, 208);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (val == "Kontrak")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);      // Light Amber
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);         // Dark Amber text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(253, 230, 138);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(180, 83, 9);
                }
            }

            // 3. Format Gaji Pokok (Nominal vs Harian)
            if (colName == "gaji_pokok" && e.Value != null && e.Value != DBNull.Value)
            {
                decimal nominal = Convert.ToDecimal(e.Value);
                object typeObj = karyawan_dgv.Rows[e.RowIndex].Cells["jenis"].Value;

                if (typeObj != null && typeObj.ToString() == "Harian")
                {
                    e.Value = string.Format("Rp {0:N0}/hr", nominal);
                }
                else
                {
                    e.Value = string.Format("Rp {0:N0}", nominal);
                }
                e.FormattingApplied = true;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // KLIK GRID → ISI DATA KE PANEL INPUT
        // ─────────────────────────────────────────────────────────────────────
        private void karyawan_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = karyawan_dgv.Rows[e.RowIndex];
            if (row.Cells["kode_karyawan"].Value == null) return;

            kode_txt.Text     = row.Cells["kode_karyawan"].Value.ToString();
            nama_txt.Text     = row.Cells["nama_karyawan"].Value.ToString();
            jabatan_txt.Text  = row.Cells["jabatan"].Value.ToString();
            jenis_cmb.Text    = row.Cells["jenis"].Value.ToString();

            if (row.Cells["gaji_pokok"].Value != null && row.Cells["gaji_pokok"].Value != DBNull.Value)
            {
                decimal gajiDec = Convert.ToDecimal(row.Cells["gaji_pokok"].Value);
                gaji_txt.Text   = (gajiDec == Math.Floor(gajiDec))
                    ? ((long)gajiDec).ToString()
                    : gajiDec.ToString("G");
            }

            if (UserSession.role != "Admin")
            {
                nama_txt.Focus();
                nama_txt.SelectAll();
            }

            if (btnCetakQR != null) btnCetakQR.Enabled = true;
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOGIKA CARI & PLACEHOLDER
        // ─────────────────────────────────────────────────────────────────────
        private void cari_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCariPlaceholder)
            {
                cari_txt.Text = "";
                cari_txt.ForeColor = Color.FromArgb(45, 55, 72);
                isCariPlaceholder = false;
            }
        }

        private void cari_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cari_txt.Text))
            {
                cari_txt.Text = PlaceholderText;
                cari_txt.ForeColor = Color.FromArgb(160, 174, 192);
                isCariPlaceholder = true;
            }
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        // ─────────────────────────────────────────────────────────────────────
        // TOMBOL FILTER CATEGORY (TABS)
        // ─────────────────────────────────────────────────────────────────────
        private void ubahAktifFilter(Button activeBtn, Color themeColor)
        {
            // Reset style semua filter ke inactive
            Button[] filterButtons = { btn_filter_semua, btn_filter_tetap, btn_filter_kontrak, btn_filter_harian };
            Color[] defaultColors = { 
                Color.FromArgb(91, 200, 245), // Semua - Sky Blue
                Color.FromArgb(30, 144, 255), // Tetap - Dodger Blue
                Color.FromArgb(245, 166, 35), // Kontrak - Orange
                Color.FromArgb(76, 175, 80)   // Harian - Green
            };

            for (int i = 0; i < filterButtons.Length; i++)
            {
                Button btn = filterButtons[i];
                if (btn == activeBtn)
                {
                    btn.BackColor = themeColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = defaultColors[i];
                    btn.FlatAppearance.BorderColor = defaultColors[i];
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
        }

        private void btn_filter_semua_Click(object sender, EventArgs e)
        {
            currentFilter = "Semua";
            ubahAktifFilter(btn_filter_semua, Color.FromArgb(91, 200, 245));
            tampilGrid();
        }

        private void btn_filter_tetap_Click(object sender, EventArgs e)
        {
            currentFilter = "Tetap";
            ubahAktifFilter(btn_filter_tetap, Color.FromArgb(30, 144, 255));
            tampilGrid();
        }

        private void btn_filter_kontrak_Click(object sender, EventArgs e)
        {
            currentFilter = "Kontrak";
            ubahAktifFilter(btn_filter_kontrak, Color.FromArgb(245, 166, 35));
            tampilGrid();
        }

        private void btn_filter_harian_Click(object sender, EventArgs e)
        {
            currentFilter = "Harian";
            ubahAktifFilter(btn_filter_harian, Color.FromArgb(76, 175, 80));
            tampilGrid();
        }

        // ─────────────────────────────────────────────────────────────────────
        // TOMBOL CRUD (SIMPAN / HAPUS / BATAL)
        // ─────────────────────────────────────────────────────────────────────
        private void simpan_btn_Click(object sender, EventArgs e)
        {
            // Validasi Input
            if (string.IsNullOrWhiteSpace(nama_txt.Text))
            {
                MessageBox.Show("Nama Karyawan tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nama_txt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(jabatan_txt.Text))
            {
                MessageBox.Show("Jabatan tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                jabatan_txt.Focus();
                return;
            }

            decimal gajiVal;
            if (!decimal.TryParse(gaji_txt.Text, out gajiVal) || gajiVal < 0)
            {
                MessageBox.Show("Gaji Pokok harus berupa angka positif.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gaji_txt.Focus();
                return;
            }

            karyawan.kode_karyawan = kode_txt.Text.Trim();
            karyawan.nama_karyawan = nama_txt.Text.Trim();
            karyawan.jabatan       = jabatan_txt.Text.Trim();
            karyawan.jenis         = jenis_cmb.Text;
            karyawan.gaji_pokok    = gajiVal;

            if (!karyawan.jikaAda(kode_txt.Text.Trim()))
            {
                // INSERT baru
                if (karyawan.Save() > 0)
                {
                    MessageBox.Show("Data karyawan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    hitungStatistikFilter();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data karyawan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // UPDATE data lama
                if (MessageBox.Show("Yakin ingin mengubah data karyawan ini?", "Konfirmasi Edit",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (karyawan.update(kode_txt.Text.Trim()) > 0)
                    {
                        MessageBox.Show("Data karyawan berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bersihkan();
                        hitungStatistikFilter();
                        tampilGrid();
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui data karyawan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void hapus_btn_Click(object sender, EventArgs e)
        {
            string kode = kode_txt.Text.Trim();
            if (!karyawan.jikaAda(kode))
            {
                MessageBox.Show("Pilih data karyawan dari tabel terlebih dahulu untuk dihapus.", 
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus/menonaktifkan karyawan " + nama_txt.Text.Trim() + "?", 
                                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (karyawan.delete(kode) > 0)
                {
                    MessageBox.Show("Data karyawan berhasil dinonaktifkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    hitungStatistikFilter();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menonaktifkan data karyawan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bersihkan();
        }

        private void btnCetakQR_Click(object sender, EventArgs e)
        {
            string kode = kode_txt.Text.Trim();
            string nama = nama_txt.Text.Trim();
            if (!string.IsNullOrEmpty(kode) && !string.IsNullOrEmpty(nama))
            {
                using (FormQRPreview qrForm = new FormQRPreview(kode, nama))
                {
                    qrForm.ShowDialog();
                }
            }
        }

        private void accentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
