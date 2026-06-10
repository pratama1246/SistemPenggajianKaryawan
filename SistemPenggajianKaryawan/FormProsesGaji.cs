using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormProsesGaji : Form
    {
        private Gaji_serv gajiService = new Gaji_serv();
        private DataTable dtGajiKalkulasi = null;

        public FormProsesGaji()
        {
            InitializeComponent();
            
            // Pasang event handler untuk formatting cell grid secara programmatic
            this.gaji_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gaji_dgv_CellFormatting);
        }

        private void FormProsesGaji_Load(object sender, EventArgs e)
        {
            // Cek role keamanan - hanya HRD atau Admin yang boleh memproses gaji
            if (UserSession.role != "HRD" && UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Inisialisasi ComboBox Bulan
            string[] namaBulan = {
                "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                "Juli", "Agustus", "September", "Oktober", "November", "Desember"
            };
            bulan_cmb.Items.Clear();
            bulan_cmb.Items.AddRange(namaBulan);
            bulan_cmb.SelectedIndex = DateTime.Now.Month - 1;

            // Inisialisasi ComboBox Tahun (tahun ini sampai 5 tahun ke belakang)
            thn_cmb.Items.Clear();
            int tahunSekarang = DateTime.Now.Year;
            for (int i = tahunSekarang; i >= tahunSekarang - 5; i--)
            {
                thn_cmb.Items.Add(i.ToString());
            }
            thn_cmb.SelectedIndex = 0;

            // Terapkan konfigurasi visual DataGridView
            KustomisasiGrid();
            bersihkan();
        }

        private void KustomisasiGrid()
        {
            gaji_dgv.ReadOnly = true;
            gaji_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gaji_dgv.MultiSelect = false;
            gaji_dgv.AllowUserToAddRows = false;
            gaji_dgv.AllowUserToDeleteRows = false;
            gaji_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gaji_dgv.EnableHeadersVisualStyles = false;
            gaji_dgv.GridColor = Color.FromArgb(203, 213, 225); // border #CBD5E1
            gaji_dgv.BorderStyle = BorderStyle.None;

            gaji_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
            gaji_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gaji_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gaji_dgv.ColumnHeadersHeight = 32;

            gaji_dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        }

        private void bersihkan()
        {
            dtGajiKalkulasi = null;
            gaji_dgv.DataSource = null;
            stat_karyawan_lbl.Text = "0";
            stat_pengeluaran_lbl.Text = "Rp 0";
            judul_lbl.Text = "Hasil Kalkulasi";
        }

        private void hitung_btn_Click(object sender, EventArgs e)
        {
            if (bulan_cmb.SelectedIndex == -1 || thn_cmb.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih periode bulan dan tahun.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun = Convert.ToInt32(thn_cmb.SelectedItem);

            Cursor = Cursors.WaitCursor;
            try
            {
                dtGajiKalkulasi = gajiService.hitungGajiBulanan(bulan, tahun);
                gaji_dgv.DataSource = dtGajiKalkulasi;

                // Format visibilitas kolom
                if (gaji_dgv.Columns.Contains("karyawan_id"))
                    gaji_dgv.Columns["karyawan_id"].Visible = false;

                // Format Header Text
                if (gaji_dgv.Columns.Contains("nama_karyawan"))
                    gaji_dgv.Columns["nama_karyawan"].HeaderText = "Nama";
                if (gaji_dgv.Columns.Contains("jenis"))
                    gaji_dgv.Columns["jenis"].HeaderText = "Jenis";
                if (gaji_dgv.Columns.Contains("gaji_pokok"))
                    gaji_dgv.Columns["gaji_pokok"].HeaderText = "Gaji Pokok";
                if (gaji_dgv.Columns.Contains("tunjangan"))
                    gaji_dgv.Columns["tunjangan"].HeaderText = "Tunjangan";
                if (gaji_dgv.Columns.Contains("potongan"))
                    gaji_dgv.Columns["potongan"].HeaderText = "Potongan";
                if (gaji_dgv.Columns.Contains("gaji_netto"))
                    gaji_dgv.Columns["gaji_netto"].HeaderText = "Gaji Netto";

                // Hitung Summary Statistik Ringkasan
                int totalKar = dtGajiKalkulasi.Rows.Count;
                decimal totalPengeluaran = 0;
                foreach (DataRow r in dtGajiKalkulasi.Rows)
                {
                    totalPengeluaran += Convert.ToDecimal(r["gaji_netto"]);
                }

                stat_karyawan_lbl.Text = totalKar.ToString();
                stat_pengeluaran_lbl.Text = string.Format("Rp {0:N0}", totalPengeluaran);

                judul_lbl.Text = "Hasil Kalkulasi — " + bulan_cmb.SelectedItem.ToString() + " " + tahun;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung gaji: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            if (dtGajiKalkulasi == null || dtGajiKalkulasi.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk disimpan. Silakan lakukan hitung gaji terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun = Convert.ToInt32(thn_cmb.SelectedItem);
            string periodeText = bulan_cmb.SelectedItem.ToString() + " " + tahun;

            if (MessageBox.Show("Yakin ingin memproses dan menyimpan seluruh gaji periode " + periodeText + "?\nData lama pada periode ini akan dihapus dan ditimpa.", "Konfirmasi Simpan Gaji",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                int saved = gajiService.simpanSemuaGaji(bulan, tahun, dtGajiKalkulasi, UserSession.user_id);
                Cursor = Cursors.Default;

                if (saved >= 0)
                {
                    MessageBox.Show("Berhasil menyimpan data penggajian " + saved + " karyawan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data penggajian ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gaji_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Background alternating rows (Alice Blue dan Light Steel Blue)
            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // #F0F8FF Alice Blue
                : Color.FromArgb(176, 196, 222); // #B0C4DE Light Steel Blue

            string columnName = gaji_dgv.Columns[e.ColumnIndex].Name;

            // Format numeric currency
            if (columnName == "gaji_pokok" || columnName == "tunjangan" || columnName == "potongan" || columnName == "gaji_netto")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    decimal val = Convert.ToDecimal(e.Value);
                    e.Value = string.Format("Rp {0:N0}", val);
                    e.FormattingApplied = true;
                }
            }

            // Pewarnaan teks kolom spesifik agar premium
            if (columnName == "tunjangan")
            {
                e.CellStyle.ForeColor = Color.FromArgb(76, 175, 80); // Success Green
            }
            else if (columnName == "potongan")
            {
                if (e.Value != null && Convert.ToDecimal(gaji_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(205, 92, 92); // Soft Danger Red
                }
            }
            else if (columnName == "gaji_netto")
            {
                e.CellStyle.Font = new Font(gaji_dgv.Font, FontStyle.Bold);
            }
        }
    }
}
