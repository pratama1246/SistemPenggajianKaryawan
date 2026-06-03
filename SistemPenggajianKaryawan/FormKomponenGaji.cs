using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormKomponenGaji : Form
    {
        private KomponenGaji_serv kompServ = new KomponenGaji_serv();
        private int selectedKomponenId     = -1;  // -1 = mode tambah baru
        private bool isCariPlaceholder     = true;
        private const string PlaceholderText = "🔍 Cari komponen...";

        public FormKomponenGaji()
        {
            InitializeComponent();
        }

        private void FormKomponenGaji_Load(object sender, EventArgs e)
        {
            // Cek role keamanan
            if (UserSession.role != "HRD" && UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            setupDataGridView();
            bersihkan();
            tampilGrid();
        }

        // ─────────────────────────────────────────────────────────────────────
        // SETUP DGV
        // ─────────────────────────────────────────────────────────────────────
        private void setupDataGridView()
        {
            komponen_dgv.EnableHeadersVisualStyles                        = false;
            komponen_dgv.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(70, 130, 180); // #4682B4
            komponen_dgv.ColumnHeadersDefaultCellStyle.ForeColor          = Color.White;
            komponen_dgv.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            komponen_dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            komponen_dgv.ColumnHeadersHeight                              = 34;
            komponen_dgv.CellBorderStyle                                  = DataGridViewCellBorderStyle.SingleHorizontal;
            komponen_dgv.DefaultCellStyle.SelectionBackColor              = Color.FromArgb(91, 200, 245); // primary
            komponen_dgv.DefaultCellStyle.SelectionForeColor              = Color.FromArgb(26, 26, 26);
        }

        // ─────────────────────────────────────────────────────────────────────
        // DATA
        // ─────────────────────────────────────────────────────────────────────
        private void tampilGrid()
        {
            string keyword = (isCariPlaceholder || string.IsNullOrWhiteSpace(cari_txt.Text))
                ? "" : cari_txt.Text.Trim();

            DataTable dt = string.IsNullOrEmpty(keyword)
                ? kompServ.viewAll()
                : kompServ.search(keyword);

            komponen_dgv.DataSource = dt;
            renameHeaders();
            warnaiBaris();
        }

        private void renameHeaders()
        {
            if (komponen_dgv.Columns.Count == 0) return;
            if (komponen_dgv.Columns["komponen_id"]   != null) komponen_dgv.Columns["komponen_id"].Visible = false;
            if (komponen_dgv.Columns["nama_komponen"] != null) komponen_dgv.Columns["nama_komponen"].HeaderText = "Nama";
            if (komponen_dgv.Columns["tipe"]          != null) komponen_dgv.Columns["tipe"].HeaderText          = "Tipe";
            if (komponen_dgv.Columns["jenis_nilai"]   != null) komponen_dgv.Columns["jenis_nilai"].HeaderText   = "Jenis";
            if (komponen_dgv.Columns["nilai"]         != null) komponen_dgv.Columns["nilai"].HeaderText         = "Nilai";
            if (komponen_dgv.Columns["berlaku_untuk"] != null) komponen_dgv.Columns["berlaku_untuk"].HeaderText = "Berlaku";
        }

        private void warnaiBaris()
        {
            foreach (DataGridViewRow row in komponen_dgv.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.BackColor = row.Index % 2 == 0
                        ? Color.FromArgb(240, 248, 255)   // Alice Blue — dgv-row-even
                        : Color.FromArgb(176, 196, 222);  // Light Steel Blue — dgv-row-odd
        }

        private void bersihkan()
        {
            selectedKomponenId = -1;
            nama_txt.Clear();
            tipe_cmb.SelectedIndex      = 0;
            jenisNilai_cmb.SelectedIndex = 0;
            nilai_txt.Text              = "0";
            berlaku_cmb.SelectedIndex   = 0;
            updateNilaiLabel();
            nama_txt.Focus();
            komponen_dgv.ClearSelection();
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENTS — Jenis Nilai label
        // ─────────────────────────────────────────────────────────────────────
        private void jenisNilai_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateNilaiLabel();
        }

        private void updateNilaiLabel()
        {
            if (jenisNilai_cmb.SelectedItem?.ToString() == "Persen")
                nilai_lbl.Text = "Nilai (%)";
            else
                nilai_lbl.Text = "Nilai";
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENTS — Cari
        // ─────────────────────────────────────────────────────────────────────
        private void cari_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCariPlaceholder)
            {
                cari_txt.Text      = "";
                cari_txt.ForeColor = Color.FromArgb(45, 55, 72);
                isCariPlaceholder  = false;
            }
        }

        private void cari_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cari_txt.Text))
            {
                cari_txt.Text      = PlaceholderText;
                cari_txt.ForeColor = Color.FromArgb(160, 174, 192);
                isCariPlaceholder  = true;
            }
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENTS — Grid click → isi form
        // ─────────────────────────────────────────────────────────────────────
        private void komponen_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = komponen_dgv.Rows[e.RowIndex];
            if (row.Cells["komponen_id"].Value == null) return;

            selectedKomponenId = Convert.ToInt32(row.Cells["komponen_id"].Value);

            nama_txt.Text                = row.Cells["nama_komponen"].Value?.ToString() ?? "";
            tipe_cmb.Text                = row.Cells["tipe"].Value?.ToString()          ?? "Tambah";
            jenisNilai_cmb.Text          = row.Cells["jenis_nilai"].Value?.ToString()   ?? "Nominal";
            berlaku_cmb.Text             = row.Cells["berlaku_untuk"].Value?.ToString() ?? "Semua";

            // Format nilai: hilangkan koma desimal jika bulat
            if (row.Cells["nilai"].Value != null && row.Cells["nilai"].Value != DBNull.Value)
            {
                decimal nilaiVal = Convert.ToDecimal(row.Cells["nilai"].Value);
                nilai_txt.Text = (nilaiVal == Math.Floor(nilaiVal))
                    ? ((long)nilaiVal).ToString()
                    : nilaiVal.ToString("G");
            }

            updateNilaiLabel();
            nama_txt.Focus();
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENTS — Cell Formatting
        // ─────────────────────────────────────────────────────────────────────
        private void komponen_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || komponen_dgv.Columns.Count == 0) return;

            string col = komponen_dgv.Columns[e.ColumnIndex].Name;

            // 1. Alternating rows (diset juga di warnaiBaris tapi kita set selection style)
            e.CellStyle.ForeColor          = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245);
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            // 2. Badge kolom Tipe: Tambah = hijau, Potong = merah
            if (col == "tipe" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Tambah")
                {
                    e.CellStyle.BackColor       = Color.FromArgb(76, 175, 80);  // success green
                    e.CellStyle.ForeColor       = Color.White;
                    e.CellStyle.Font            = new Font("Segoe UI", 9F, FontStyle.Bold);
                    e.CellStyle.Alignment       = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(56, 142, 60);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else if (val == "Potong")
                {
                    e.CellStyle.BackColor       = Color.FromArgb(205, 92, 92);  // error red
                    e.CellStyle.ForeColor       = Color.White;
                    e.CellStyle.Font            = new Font("Segoe UI", 9F, FontStyle.Bold);
                    e.CellStyle.Alignment       = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(183, 28, 28);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }

            // 3. Format kolom Nilai: Persen → tampilkan "5%", Nominal → format ribuan
            if (col == "nilai" && e.Value != null && e.Value != DBNull.Value)
            {
                // Ambil jenis_nilai dari kolom di baris yang sama
                if (komponen_dgv.Columns["jenis_nilai"] != null)
                {
                    object jenisObj = komponen_dgv.Rows[e.RowIndex].Cells["jenis_nilai"].Value;
                    decimal nilaiDec;
                    if (jenisObj != null && decimal.TryParse(e.Value.ToString(), out nilaiDec))
                    {
                        if (jenisObj.ToString() == "Persen")
                        {
                            e.Value = nilaiDec.ToString("G") + "%";
                        }
                        else
                        {
                            e.Value = string.Format("{0:N0}", nilaiDec);
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // TOMBOL AKSI
        // ─────────────────────────────────────────────────────────────────────
        private void simpan_btn_Click(object sender, EventArgs e)
        {
            // Validasi nama
            if (string.IsNullOrWhiteSpace(nama_txt.Text))
            {
                MessageBox.Show("Nama komponen tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nama_txt.Focus();
                return;
            }

            // Validasi nilai
            decimal nilaiInput;
            if (!decimal.TryParse(nilai_txt.Text, out nilaiInput) || nilaiInput < 0)
            {
                MessageBox.Show("Nilai harus berupa angka positif.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nilai_txt.Focus();
                return;
            }

            // Validasi persen maks 100
            if (jenisNilai_cmb.Text == "Persen" && nilaiInput > 100)
            {
                MessageBox.Show("Nilai persen tidak boleh melebihi 100.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nilai_txt.Focus();
                return;
            }

            kompServ.nama_komponen  = nama_txt.Text.Trim();
            kompServ.tipe           = tipe_cmb.Text;
            kompServ.jenis_nilai    = jenisNilai_cmb.Text;
            kompServ.nilai          = nilaiInput;
            kompServ.berlaku_untuk  = berlaku_cmb.Text;

            if (selectedKomponenId < 0)
            {
                // INSERT baru
                if (kompServ.Save() > 0)
                {
                    MessageBox.Show("Komponen berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan komponen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // UPDATE
                if (MessageBox.Show("Yakin ingin mengubah komponen ini?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (kompServ.update(selectedKomponenId) > 0)
                    {
                        MessageBox.Show("Komponen berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bersihkan();
                        tampilGrid();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengubah komponen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void hapus_btn_Click(object sender, EventArgs e)
        {
            if (selectedKomponenId < 0)
            {
                MessageBox.Show("Pilih komponen dari tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus komponen ini?", "Hapus Data",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (kompServ.delete(selectedKomponenId) > 0)
                {
                    MessageBox.Show("Komponen berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus komponen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bersihkan();
        }
    }
}
