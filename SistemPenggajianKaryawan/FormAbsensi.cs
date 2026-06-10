using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormAbsensi : Form
    {
        private Absensi_serv absensi_serv = new Absensi_serv();
        private int selectedKaryawanId = 0;
        private string selectedNama = "";

        public FormAbsensi()
        {
            InitializeComponent();
        }

        private void FormAbsensi_Load(object sender, EventArgs e)
        {
            // Set default date & clock display immediately
            timer_jam_Tick(null, null);

            // Configure DataGridView
            SetupDataGridView();

            // Load today's log
            tampilGrid();

            // Focus on barcode scanner input
            kode_txt.Focus();
        }

        private void SetupDataGridView()
        {
            log_dgv.ReadOnly = true;
            log_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            log_dgv.MultiSelect = false;
            log_dgv.AllowUserToAddRows = false;
            log_dgv.AllowUserToDeleteRows = false;
            log_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            log_dgv.EnableHeadersVisualStyles = false;
            log_dgv.BorderStyle = BorderStyle.None;
            log_dgv.RowHeadersVisible = false;

            // Background & Border colors
            log_dgv.BackgroundColor = Color.FromArgb(38, 38, 38);
            log_dgv.GridColor = Color.FromArgb(58, 58, 58);

            // Headers Styling
            log_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            log_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            log_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            log_dgv.ColumnHeadersHeight = 32;

            log_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void tampilGrid()
        {
            try
            {
                DataTable dt = absensi_serv.viewAbsensiHarian(DateTime.Today);
                log_dgv.DataSource = dt;
            }
            catch (Exception) { }
        }

        private void timer_jam_Tick(object sender, EventArgs e)
        {
            jam_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            tanggal_lbl.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
        }

        private void kode_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // suppress default beep sound on Enter
                string kode = kode_txt.Text.Trim();
                kode_txt.Clear();
                prosesAbsensi(kode);
            }
        }

        private void prosesAbsensi(string kode)
        {
            if (string.IsNullOrEmpty(kode)) return;

            try
            {
                Koneksi server = new Koneksi();
                string q = "SELECT karyawan_id, nama_karyawan, jabatan, jenis FROM karyawan WHERE kode_karyawan = @kode AND is_aktif = 1";
                var p = new Dictionary<string, object> { { "@kode", kode } };
                DataTable dt = server.eksekusiQueryParam(q, p);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    int karyawanId = Convert.ToInt32(row["karyawan_id"]);
                    string nama = row["nama_karyawan"].ToString();
                    string jabatan = row["jabatan"].ToString();
                    string jenis = row["jenis"].ToString();

                    selectedKaryawanId = karyawanId;
                    selectedNama = nama;

                    nama_lbl.Text = nama;
                    jabatan_lbl.Text = jabatan + " (" + jenis + ")";

                    bool sudahMasuk = absensi_serv.sudahAbsenMasuk(karyawanId);
                    bool sudahKeluar = absensi_serv.sudahAbsenKeluar(karyawanId);

                    if (!sudahMasuk)
                    {
                        if (absensi_serv.simpanAbsenMasuk(karyawanId) > 0)
                        {
                            info_lbl.Text = "Halo " + nama + ",\r\nABSEN MASUK berhasil dicatat pada " + DateTime.Now.ToString("HH:mm:ss");
                            info_lbl.ForeColor = Color.FromArgb(76, 175, 80); // Success green
                        }
                        else
                        {
                            info_lbl.Text = "Gagal mencatat Absen Masuk.";
                            info_lbl.ForeColor = Color.IndianRed;
                        }
                    }
                    else if (!sudahKeluar)
                    {
                        if (absensi_serv.simpanAbsenKeluar(karyawanId) > 0)
                        {
                            info_lbl.Text = "Halo " + nama + ",\r\nABSEN KELUAR berhasil dicatat pada " + DateTime.Now.ToString("HH:mm:ss");
                            info_lbl.ForeColor = Color.FromArgb(30, 144, 255); // Blue
                        }
                        else
                        {
                            info_lbl.Text = "Gagal mencatat Absen Keluar.";
                            info_lbl.ForeColor = Color.IndianRed;
                        }
                    }
                    else
                    {
                        info_lbl.Text = "Halo " + nama + ",\r\nAbsensi Anda hari ini sudah lengkap.";
                        info_lbl.ForeColor = Color.FromArgb(245, 166, 35); // Amber
                    }

                    // Refresh clock times displayed on UI
                    updateTampilanWaktu(karyawanId);

                    // Refresh log grid
                    tampilGrid();
                }
                else
                {
                    // Reset fields
                    selectedKaryawanId = 0;
                    selectedNama = "";
                    nama_lbl.Text = "—";
                    jabatan_lbl.Text = "—";
                    status_masuk_lbl.Text = "Jam Masuk: —";
                    status_keluar_lbl.Text = "Jam Keluar: —";

                    info_lbl.Text = "Karyawan dengan kode '" + kode + "' tidak ditemukan atau tidak aktif!";
                    info_lbl.ForeColor = Color.IndianRed;
                }
            }
            catch (Exception ex)
            {
                info_lbl.Text = "Terjadi kesalahan: " + ex.Message;
                info_lbl.ForeColor = Color.IndianRed;
            }
        }

        private void updateTampilanWaktu(int karyawanId)
        {
            try
            {
                Koneksi server = new Koneksi();
                string q = "SELECT jam_masuk, jam_keluar FROM absensi WHERE karyawan_id = @karyawan_id AND tanggal = CURDATE()";
                var p = new Dictionary<string, object> { { "@karyawan_id", karyawanId } };
                DataTable dt = server.eksekusiQueryParam(q, p);
                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    string jamMasuk = row["jam_masuk"] == DBNull.Value ? "—" : row["jam_masuk"].ToString();
                    string jamKeluar = row["jam_keluar"] == DBNull.Value ? "—" : row["jam_keluar"].ToString();
                    status_masuk_lbl.Text = "Jam Masuk: " + jamMasuk;
                    status_keluar_lbl.Text = "Jam Keluar: " + jamKeluar;
                }
                else
                {
                    status_masuk_lbl.Text = "Jam Masuk: —";
                    status_keluar_lbl.Text = "Jam Keluar: —";
                }
            }
            catch (Exception) { }
        }

        private void absen_masuk_btn_Click(object sender, EventArgs e)
        {
            if (selectedKaryawanId == 0)
            {
                MessageBox.Show("Silakan scan kartu atau masukkan kode karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sudahMasuk = absensi_serv.sudahAbsenMasuk(selectedKaryawanId);
            if (sudahMasuk)
            {
                MessageBox.Show("Karyawan " + selectedNama + " sudah melakukan absen masuk hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (absensi_serv.simpanAbsenMasuk(selectedKaryawanId) > 0)
            {
                info_lbl.Text = "Halo " + selectedNama + ",\r\nABSEN MASUK berhasil dicatat.";
                info_lbl.ForeColor = Color.FromArgb(76, 175, 80);
                updateTampilanWaktu(selectedKaryawanId);
                tampilGrid();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan absen masuk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void absen_keluar_btn_Click(object sender, EventArgs e)
        {
            if (selectedKaryawanId == 0)
            {
                MessageBox.Show("Silakan scan kartu atau masukkan kode karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sudahMasuk = absensi_serv.sudahAbsenMasuk(selectedKaryawanId);
            if (!sudahMasuk)
            {
                MessageBox.Show("Karyawan " + selectedNama + " belum melakukan absen masuk hari ini. Tidak dapat absen keluar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sudahKeluar = absensi_serv.sudahAbsenKeluar(selectedKaryawanId);
            if (sudahKeluar)
            {
                MessageBox.Show("Karyawan " + selectedNama + " sudah melakukan absen keluar hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (absensi_serv.simpanAbsenKeluar(selectedKaryawanId) > 0)
            {
                info_lbl.Text = "Halo " + selectedNama + ",\r\nABSEN KELUAR berhasil dicatat.";
                info_lbl.ForeColor = Color.FromArgb(30, 144, 255);
                updateTampilanWaktu(selectedKaryawanId);
                tampilGrid();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan absen keluar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void log_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = log_dgv.Columns[e.ColumnIndex].Name;

            // Alternate backgrounds
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(43, 43, 43);
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(50, 50, 50);
            }
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255);
            e.CellStyle.SelectionForeColor = Color.White;

            // Format status column with color badge
            if (colName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Hadir")
                {
                    e.CellStyle.BackColor = Color.FromArgb(28, 69, 50);
                    e.CellStyle.ForeColor = Color.FromArgb(154, 230, 180);
                }
                else if (status == "Izin" || status == "Sakit")
                {
                    e.CellStyle.BackColor = Color.FromArgb(116, 66, 16);
                    e.CellStyle.ForeColor = Color.FromArgb(254, 215, 170);
                }
                else if (status == "Alpha")
                {
                    e.CellStyle.BackColor = Color.FromArgb(93, 26, 26);
                    e.CellStyle.ForeColor = Color.FromArgb(244, 144, 144);
                }
            }

            // Display time formats clearly
            if ((colName == "Jam Masuk" || colName == "Jam Keluar") && e.Value != null && e.Value != DBNull.Value)
            {
                if (e.Value is TimeSpan ts)
                {
                    if (ts == TimeSpan.Zero)
                    {
                        e.Value = "—";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = ts.ToString(@"hh\:mm\:ss");
                        e.FormattingApplied = true;
                    }
                }
            }

        }
    }
}
