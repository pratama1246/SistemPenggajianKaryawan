using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormRekapAbsensi : Form
    {
        private Absensi_serv absensiService = new Absensi_serv();
        private int karyawanId = 0;

        public FormRekapAbsensi()
        {
            InitializeComponent();
        }

        private void FormRekapAbsensi_Load(object sender, EventArgs e)
        {
            // Hak akses keamanan: Hanya karyawan
            if (UserSession.role != "Karyawan")
            {
                MessageBox.Show("Akses ditolak. Halaman Rekap Absensi hanya dapat diakses oleh Karyawan.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Dapatkan karyawan_id langsung dari UserSession (sudah di-set saat login)
            karyawanId = UserSession.karyawan_id;
            if (karyawanId == 0)
            {
                MessageBox.Show(
                    "Profil karyawan tidak ditemukan untuk akun ini.\n\n" +
                    "Pastikan akun Anda sudah di-link ke data karyawan oleh Admin\n" +
                    "melalui menu Manajemen User → kolom 'Karyawan Terkait'.",
                    "Profil Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                DataTable dt = absensiService.getRekapAbsensiPersonal(karyawanId, bulan, tahun);
                rekap_dgv.DataSource = dt;

                // Hitung data ringkasan kehadiran
                int totalHadir = 0;
                int totalIzin = 0;
                int totalSakit = 0;
                int totalAlpha = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"]?.ToString();
                    if (status == "Hadir") totalHadir++;
                    else if (status == "Izin") totalIzin++;
                    else if (status == "Sakit") totalSakit++;
                    else if (status == "Alpha") totalAlpha++;
                }

                lbl_hadir_val.Text = totalHadir.ToString();
                lbl_izin_val.Text = totalIzin.ToString();
                lbl_sakit_val.Text = totalSakit.ToString();
                lbl_alpha_val.Text = totalAlpha.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat rekap absensi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void filter_btn_Click(object sender, EventArgs e)
        {
            muatData();
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bulan_cmb.SelectedIndex = 0;
            thn_cmb.SelectedIndex = 0;
            muatData();
        }

        private void rekap_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Background alternating rows (Alice Blue dan Light Steel Blue)
            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // #F0F8FF Alice Blue (dgv-row-even)
                : Color.FromArgb(176, 196, 222); // #B0C4DE Light Steel Blue (dgv-row-odd)

            e.CellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245); // primary
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            string columnName = rekap_dgv.Columns[e.ColumnIndex].Name;

            // Format Tanggal
            if (columnName == "Tanggal" && e.Value != null && e.Value != DBNull.Value)
            {
                if (e.Value is DateTime dtVal)
                {
                    e.Value = dtVal.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

            // Format Jam Masuk dan Keluar
            if ((columnName == "Jam Masuk" || columnName == "Jam Keluar") && e.Value != null && e.Value != DBNull.Value)
            {
                if (e.Value is TimeSpan tsVal)
                {
                    if (tsVal == TimeSpan.Zero)
                    {
                        e.Value = "—";
                    }
                    else
                    {
                        e.Value = tsVal.ToString(@"hh\:mm\:ss");
                    }
                    e.FormattingApplied = true;
                }
            }

            // Format Status
            if (columnName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Hadir")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Success Light Green
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61); // Success Dark Green
                }
                else if (status == "Alpha")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Danger Light Red
                    e.CellStyle.ForeColor = Color.FromArgb(205, 92, 92); // Danger Red
                }
                else // Izin / Sakit
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Warning Light Amber
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9); // Warning Dark Amber
                }
            }
        }
    }
}
