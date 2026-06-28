using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormRekapGaji : Form
    {
        private Gaji_serv gajiService = new Gaji_serv();

        public FormRekapGaji()
        {
            InitializeComponent();
        }

        private void FormRekapGaji_Load(object sender, EventArgs e)
        {
            // Cek role keamanan - Hanya Admin yang dapat memantau rekap gaji
            if (UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak. Halaman Rekap Gaji hanya dapat diakses oleh Admin.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Inisialisasi ComboBox Bulan
            bulan_cmb.Items.Clear();
            bulan_cmb.Items.Add("Semua Bulan");
            string[] namaBulan = {
                "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                "Juli", "Agustus", "September", "Oktober", "November", "Desember"
            };
            bulan_cmb.Items.AddRange(namaBulan);
            bulan_cmb.SelectedIndex = 0;

            // Inisialisasi ComboBox Tahun (5 tahun ke belakang)
            thn_cmb.Items.Clear();
            thn_cmb.Items.Add("Semua Tahun");
            int tahunSekarang = DateTime.Now.Year;
            for (int i = tahunSekarang; i >= tahunSekarang - 5; i--)
            {
                thn_cmb.Items.Add(i.ToString());
            }
            thn_cmb.SelectedIndex = 0;

            // Kustomisasi visual grid
            KustomisasiGrid();
            muatData();
        }

        private void KustomisasiGrid()
        {
            rekap_dgv.ReadOnly = true;
            rekap_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rekap_dgv.MultiSelect = false;
            rekap_dgv.AllowUserToAddRows = false;
            rekap_dgv.AllowUserToDeleteRows = false;
            rekap_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            rekap_dgv.EnableHeadersVisualStyles = false;
            rekap_dgv.GridColor = Color.FromArgb(203, 213, 225); // border #CBD5E1
            rekap_dgv.BorderStyle = BorderStyle.None;

            rekap_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue #4682B4
            rekap_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            rekap_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rekap_dgv.ColumnHeadersHeight = 34;

            rekap_dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        }

        private void muatData()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                int bulan = bulan_cmb.SelectedIndex; // Index 0 = Semua Bulan, Index 1 = Januari, dst.
                int tahun = 0;
                if (thn_cmb.SelectedIndex > 0)
                {
                    tahun = Convert.ToInt32(thn_cmb.SelectedItem);
                }

                string keyword = cari_txt.Text.Trim();

                DataTable dt = gajiService.getRekapGaji(bulan, tahun, keyword);
                rekap_dgv.DataSource = dt;

                // Sembunyikan kolom ID penggajian
                if (rekap_dgv.Columns.Contains("penggajian_id"))
                    rekap_dgv.Columns["penggajian_id"].Visible = false;

                // Hitung data ringkasan statistik
                int totalKaryawan = dt.Rows.Count;
                decimal totalPengeluaran = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["Gaji Bersih"] != DBNull.Value)
                    {
                        totalPengeluaran += Convert.ToDecimal(row["Gaji Bersih"]);
                    }
                }

                stat_karyawan_lbl.Text = totalKaryawan.ToString();
                stat_pengeluaran_lbl.Text = string.Format("Rp {0:N0}", totalPengeluaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat rekap gaji: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tampilkan_btn_Click(object sender, EventArgs e)
        {
            muatData();
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bulan_cmb.SelectedIndex = 0;
            thn_cmb.SelectedIndex = 0;
            cari_txt.Clear();
            muatData();
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            muatData();
        }

        private void rekap_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Standard grid styling: alternating row background colors
            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // #F0F8FF Alice Blue (dgv-row-even)
                : Color.FromArgb(176, 196, 222); // #B0C4DE Light Steel Blue (dgv-row-odd)

            e.CellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245); // primary
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            string columnName = rekap_dgv.Columns[e.ColumnIndex].Name;

            // Format Nilai Bulan dari angka ke nama bulan
            if (columnName == "Bulan" && e.Value != null && e.Value != DBNull.Value)
            {
                int m = Convert.ToInt32(e.Value);
                string[] namaBulan = {
                    "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                    "Juli", "Agustus", "September", "Oktober", "November", "Desember"
                };
                if (m >= 1 && m <= 12)
                {
                    e.Value = namaBulan[m - 1];
                    e.FormattingApplied = true;
                }
            }

            // Format Currency
            if (columnName == "Gaji Pokok" || columnName == "Tunjangan" || columnName == "Potongan" || columnName == "Gaji Bersih")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    decimal val = Convert.ToDecimal(e.Value);
                    e.Value = string.Format("Rp {0:N0}", val);
                    e.FormattingApplied = true;
                }
            }

            // Format Tgl Proses
            if (columnName == "Tgl Proses" && e.Value != null && e.Value != DBNull.Value)
            {
                if (e.Value is DateTime dtVal)
                {
                    e.Value = dtVal.ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }

            // Custom coloring for metrics (Tunjangan = Hijau, Potongan = Merah, Gaji Bersih = Bold)
            if (columnName == "Tunjangan")
            {
                e.CellStyle.ForeColor = Color.FromArgb(76, 175, 80); // Success Green
            }
            else if (columnName == "Potongan")
            {
                if (e.Value != null && Convert.ToDecimal(rekap_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(205, 92, 92); // Soft Danger Red
                }
            }
            else if (columnName == "Gaji Bersih")
            {
                e.CellStyle.Font = new Font(rekap_dgv.Font, FontStyle.Bold);
            }
        }
    }
}
