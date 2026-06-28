using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;
using SistemPenggajianKaryawan.Model;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SistemPenggajianKaryawan
{
    public partial class FormAbsensi : Form
    {
        private Absensi_serv absensi_serv = new Absensi_serv();
        private KonfigurasiAbsensi config;

        // Webcam/Camera integration fields for Kiosk mode
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private PictureBox picWebcam;
        private BarcodeReader barcodeReader;
        private bool isScanning = false;
        private DateTime lastScanTime = DateTime.MinValue;

        // Karyawan Mode Stats Cache
        private int statSudahAbsen = 0;
        private int statBelumAbsen = 0;
        private int statTelat = 0;
        private int statSudahKeluar = 0;

        // Logged in user info
        private string loggedInKodeKaryawan = "";
        private int hrdSelectedKaryawanId = 0;

        // HRD Mode Search Placeholder flag
        private bool isHrdCariPlaceholder = true;
        private const string HrdPlaceholderText = "🔍 Cari karyawan...";

        public FormAbsensi()
        {
            InitializeComponent();
        }

        private void FormAbsensi_Load(object sender, EventArgs e)
        {
            // Cek role keamanan
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Akses ditolak. Silakan login terlebih dahulu.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Kiosk specific window configuration
            if (UserSession.role == "Kiosk")
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.MinimizeBox = false;
                this.MaximizeBox = false;
                this.ControlBox = false;
            }

            // Sembunyikan label statis bawaan designer agar tidak tumpang tindih dengan text custom
            label_masuk_config.Visible = false;
            label_keluar_config.Visible = false;

            // Load configuration
            config = absensi_serv.getKonfigurasi();

            // 1. Tampilkan panel UI yang sesuai berdasarkan role
            if (UserSession.role == "Karyawan" || UserSession.role == "Kiosk")
            {
                panel_karyawan_mode.Visible = true;
                panel_karyawan_mode.Dock = DockStyle.Fill;
                panel_hrd_mode.Visible = false;

                // Setup jam & data mandiri karyawan
                timer_jam_Tick(null, null);
                SetupDataGridView();

                if (UserSession.role == "Karyawan")
                {
                    dapatkanUserKodeKaryawan();

                    // Ubah tombol clear_btn (X) menjadi tombol QR Code untuk akses mandiri karyawan
                    clear_btn.Text = "QR";
                    clear_btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    clear_btn.ForeColor = Color.FromArgb(30, 144, 255); // primary-dark
                    clear_btn.FlatAppearance.BorderColor = Color.FromArgb(91, 200, 245); // primary cyan
                    
                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(clear_btn, "Preview & Unduh QR Code Absensi Anda");
                }
                else // Kiosk mode
                {
                    loggedInKodeKaryawan = "";
                    kode_txt.Text = "";
                    kode_txt.ReadOnly = false;

                    // Perbesar area panel_scanner_target agar tampilan kamera lebih besar & jelas
                    panel_scanner_target.Height = 220;

                    // Geser kontrol lainnya ke bawah agar tidak tumpang tindih
                    kode_txt.Top = 275;
                    clear_btn.Top = 275;
                    absen_masuk_btn.Top = 320;
                    absen_keluar_btn.Top = 320;
                    info_lbl.Top = 365;
                    info_lbl.Height = 55;

                    // Perbesar container panel_scan_card agar memuat kontrol yang digeser
                    panel_scan_card.Height = 430;

                    // Geser recent_flow_panel (riwayat scan harian) di bawah panel_scan_card
                    recent_flow_panel.Top = 440;
                    recent_flow_panel.Height = 60; // Disesuaikan agar pas di panel_left_container (tinggi 500)

                    // Register FormClosing dynamically to stop webcam
                    this.FormClosing += new FormClosingEventHandler(FormAbsensi_FormClosing);

                    // Initialize Barcode Reader for Kiosk Mode
                    barcodeReader = new BarcodeReader();
                    barcodeReader.Options.PossibleFormats = new List<BarcodeFormat> {
                        BarcodeFormat.QR_CODE,
                        BarcodeFormat.CODE_128,
                        BarcodeFormat.CODE_39,
                        BarcodeFormat.EAN_13,
                        BarcodeFormat.EAN_8
                    };
                    barcodeReader.Options.TryHarder = true;

                    // Setup Live Webcam PictureBox in panel_scanner_target
                    picWebcam = new PictureBox();
                    picWebcam.Dock = DockStyle.Fill;
                    picWebcam.SizeMode = PictureBoxSizeMode.Zoom;
                    panel_scanner_target.Controls.Add(picWebcam);
                    picWebcam.BringToFront();

                    // Start camera
                    try
                    {
                        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        if (videoDevices.Count > 0)
                        {
                            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                            videoSource.NewFrame += VideoSource_NewFrame;
                            videoSource.Start();
                            isScanning = true;
                        }
                        else
                        {
                            info_lbl.Text = "Kamera tidak ditemukan.\r\nSilakan pasang webcam.";
                            info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                        }
                    }
                    catch (Exception ex)
                    {
                        info_lbl.Text = "Gagal memulai kamera:\r\n" + ex.Message;
                        info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                    }

                    // Tambahkan Tombol Keluar Kiosk secara dinamis di panel_header
                    Button btnExitKiosk = new Button();
                    btnExitKiosk.Text = "Keluar Kiosk";
                    btnExitKiosk.Size = new Size(120, 32);
                    btnExitKiosk.Location = new Point(panel_header.Width - btnExitKiosk.Width - 15, 15);
                    btnExitKiosk.FlatStyle = FlatStyle.Flat;
                    btnExitKiosk.FlatAppearance.BorderSize = 1;
                    btnExitKiosk.FlatAppearance.BorderColor = Color.FromArgb(205, 92, 92);
                    btnExitKiosk.ForeColor = Color.FromArgb(205, 92, 92);
                    btnExitKiosk.BackColor = Color.White;
                    btnExitKiosk.Cursor = Cursors.Hand;
                    btnExitKiosk.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    btnExitKiosk.Click += (s, ev) => {
                        using (FormAuthExit formAuth = new FormAuthExit())
                        {
                            if (formAuth.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    };
                    panel_header.Controls.Add(btnExitKiosk);
                    btnExitKiosk.BringToFront();
                }

                refreshSemuaData();
            }
            else // HRD atau Admin
            {
                panel_hrd_mode.Visible = true;
                panel_hrd_mode.Dock = DockStyle.Fill;
                panel_karyawan_mode.Visible = false;
                hrd_panel_right.BringToFront();

                // Setup HRD controls
                SetupHrdDataGridView();
                hrd_tanggal_dtp.Value = DateTime.Today;
                hrd_bersihkan();
                hrd_tampilGrid();
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 1: LOGIKA KARYAWAN MODE (Absensi Mandiri / Scan Kartu)
        // ─────────────────────────────────────────────────────────────────────
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

            log_dgv.BackgroundColor = Color.White;
            log_dgv.GridColor = Color.FromArgb(241, 245, 249);

            log_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(14, 165, 233); // sky blue
            log_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            log_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            log_dgv.ColumnHeadersHeight = 32;

            log_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            log_dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(this.log_dgv_CellFormatting);
        }

        private void dapatkanUserKodeKaryawan()
        {
            if (UserSession.role == "Karyawan")
            {
                try
                {
                    Koneksi server = new Koneksi();
                    string q = "SELECT k.kode_karyawan FROM users u JOIN karyawan k ON u.karyawan_id = k.karyawan_id WHERE u.user_id = @user_id";
                    var p = new Dictionary<string, object> { { "@user_id", UserSession.user_id } };
                    DataTable dt = server.eksekusiQueryParam(q, p);
                    if (dt.Rows.Count > 0)
                    {
                        loggedInKodeKaryawan = dt.Rows[0]["kode_karyawan"].ToString();
                        kode_txt.Text = loggedInKodeKaryawan;
                    }
                }
                catch { }
            }
        }

        private void refreshSemuaData()
        {
            loadRecentScans();
            loadRekap();
            tampilGrid();
            kode_txt.Focus();
        }

        private void timer_jam_Tick(object sender, EventArgs e)
        {
            jam_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            tanggal_lbl.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new CultureInfo("id-ID"));
        }

        private void kode_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string kode = kode_txt.Text.Trim();
                kode_txt.Clear();
                prosesAbsensi(kode);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            if (UserSession.role == "Karyawan")
            {
                string kode = kode_txt.Text.Trim();
                string nama = UserSession.nama;
                if (!string.IsNullOrEmpty(kode))
                {
                    using (FormQRPreview qrForm = new FormQRPreview(kode, nama))
                    {
                        qrForm.ShowDialog();
                    }
                }
            }
            else
            {
                kode_txt.Clear();
                kode_txt.Focus();
            }
        }

        private int dapatkanKaryawanId(string kode, out string nama)
        {
            nama = "";
            try
            {
                Koneksi server = new Koneksi();
                string q = "SELECT karyawan_id, nama_karyawan FROM karyawan WHERE kode_karyawan = @kode AND is_aktif = 1";
                var p = new Dictionary<string, object> { { "@kode", kode } };
                DataTable dt = server.eksekusiQueryParam(q, p);
                if (dt.Rows.Count > 0)
                {
                    nama = dt.Rows[0]["nama_karyawan"].ToString();
                    return Convert.ToInt32(dt.Rows[0]["karyawan_id"]);
                }
            }
            catch { }
            return 0;
        }

        private void prosesAbsensi(string kode)
        {
            if (string.IsNullOrEmpty(kode)) return;

            if (UserSession.role == "Karyawan" && kode != loggedInKodeKaryawan)
            {
                info_lbl.Text = "Akses Ditolak!\r\nAnda hanya boleh mencatat absensi diri sendiri.";
                info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                return;
            }

            int karyawanId = dapatkanKaryawanId(kode, out string nama);
            if (karyawanId == 0)
            {
                info_lbl.Text = $"Kode '{kode}' tidak ditemukan\r\natau karyawan tidak aktif.";
                info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                return;
            }

            bool sudahMasuk = absensi_serv.sudahAbsenMasuk(karyawanId);
            bool sudahKeluar = absensi_serv.sudahAbsenKeluar(karyawanId);
            string timeStr = DateTime.Now.ToString("HH:mm:ss");

            if (!sudahMasuk)
            {
                if (absensi_serv.simpanAbsenMasuk(karyawanId) > 0)
                {
                    bool isLate = false;
                    int lateMinutes = 0;
                    if (config != null)
                    {
                        TimeSpan waktuAbsen = DateTime.Now.TimeOfDay;
                        TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                        if (waktuAbsen > normalLimit)
                        {
                            isLate = true;
                            lateMinutes = (int)(waktuAbsen - config.jam_masuk_normal).TotalMinutes;
                        }
                    }

                    if (isLate)
                    {
                        info_lbl.Text = $"{nama} - Absen masuk berhasil - {timeStr} (Telat {lateMinutes} m)";
                        info_lbl.ForeColor = Color.FromArgb(217, 119, 6); // Orange
                        info_lbl.BackColor = Color.FromArgb(254, 243, 199);
                    }
                    else
                    {
                        info_lbl.Text = $"{nama} - Absen masuk berhasil - {timeStr}";
                        info_lbl.ForeColor = Color.FromArgb(22, 163, 74); // Green
                        info_lbl.BackColor = Color.FromArgb(220, 252, 231);
                    }
                }
                else
                {
                    info_lbl.Text = "Gagal mencatat Absen Masuk.";
                    info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                    info_lbl.BackColor = Color.FromArgb(254, 226, 226);
                }
            }
            else if (!sudahKeluar)
            {
                // Batasi absen keluar otomatis via QR/webcam (Kiosk) sebelum waktunya
                if (config != null)
                {
                    TimeSpan waktuSekarang = DateTime.Now.TimeOfDay;
                    TimeSpan batasAwalKeluar = config.jam_keluar_normal.Subtract(TimeSpan.FromMinutes(30));
                    
                    if (waktuSekarang < batasAwalKeluar)
                    {
                        info_lbl.Text = $"{nama} - Sudah absen masuk.\r\nBelum waktunya absen keluar (mulai {batasAwalKeluar.ToString(@"hh\:mm")}).";
                        info_lbl.ForeColor = Color.FromArgb(180, 83, 9); // Amber/Orange
                        info_lbl.BackColor = Color.FromArgb(254, 243, 199);
                        return;
                    }
                }

                if (absensi_serv.simpanAbsenKeluar(karyawanId) > 0)
                {
                    info_lbl.Text = $"{nama} - Absen keluar berhasil - {timeStr}";
                    info_lbl.ForeColor = Color.FromArgb(14, 165, 233); // Blue
                    info_lbl.BackColor = Color.FromArgb(240, 249, 255);
                }
                else
                {
                    info_lbl.Text = "Gagal mencatat Absen Keluar.";
                    info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                    info_lbl.BackColor = Color.FromArgb(254, 226, 226);
                }
            }
            else
            {
                info_lbl.Text = $"{nama} - Absensi Anda hari ini sudah lengkap.";
                info_lbl.ForeColor = Color.FromArgb(180, 83, 9);
                info_lbl.BackColor = Color.FromArgb(254, 243, 199);
            }

            refreshSemuaData();
        }

        private void absen_masuk_btn_Click(object sender, EventArgs e)
        {
            string kode = kode_txt.Text.Trim();
            if (string.IsNullOrEmpty(kode))
            {
                MessageBox.Show("Silakan ketik atau scan kode karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserSession.role == "Karyawan" && kode != loggedInKodeKaryawan)
            {
                info_lbl.Text = "Akses Ditolak!\r\nAnda hanya boleh mencatat absensi diri sendiri.";
                info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                return;
            }

            int karyawanId = dapatkanKaryawanId(kode, out string nama);
            if (karyawanId == 0)
            {
                MessageBox.Show("Karyawan tidak ditemukan atau tidak aktif.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (absensi_serv.sudahAbsenMasuk(karyawanId))
            {
                MessageBox.Show("Karyawan " + nama + " sudah melakukan absen masuk hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (absensi_serv.simpanAbsenMasuk(karyawanId) > 0)
            {
                string timeStr = DateTime.Now.ToString("HH:mm:ss");
                bool isLate = false;
                int lateMinutes = 0;
                if (config != null)
                {
                    TimeSpan waktuAbsen = DateTime.Now.TimeOfDay;
                    TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                    if (waktuAbsen > normalLimit)
                    {
                        isLate = true;
                        lateMinutes = (int)(waktuAbsen - config.jam_masuk_normal).TotalMinutes;
                    }
                }

                if (isLate)
                {
                    info_lbl.Text = $"{nama} - Absen masuk berhasil - {timeStr} (Telat {lateMinutes} m)";
                    info_lbl.ForeColor = Color.FromArgb(217, 119, 6);
                    info_lbl.BackColor = Color.FromArgb(254, 243, 199);
                }
                else
                {
                    info_lbl.Text = $"{nama} - Absen masuk berhasil - {timeStr}";
                    info_lbl.ForeColor = Color.FromArgb(22, 163, 74);
                    info_lbl.BackColor = Color.FromArgb(220, 252, 231);
                }

                kode_txt.Clear();
                refreshSemuaData();
            }
            else
            {
                MessageBox.Show("Gagal mencatat Absen Masuk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void absen_keluar_btn_Click(object sender, EventArgs e)
        {
            string kode = kode_txt.Text.Trim();
            if (string.IsNullOrEmpty(kode))
            {
                MessageBox.Show("Silakan ketik atau scan kode karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserSession.role == "Karyawan" && kode != loggedInKodeKaryawan)
            {
                info_lbl.Text = "Akses Ditolak!\r\nAnda hanya boleh mencatat absensi diri sendiri.";
                info_lbl.ForeColor = Color.FromArgb(220, 38, 38);
                return;
            }

            int karyawanId = dapatkanKaryawanId(kode, out string nama);
            if (karyawanId == 0)
            {
                MessageBox.Show("Karyawan tidak ditemukan atau tidak aktif.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!absensi_serv.sudahAbsenMasuk(karyawanId))
            {
                MessageBox.Show("Karyawan " + nama + " belum melakukan absen masuk hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (absensi_serv.sudahAbsenKeluar(karyawanId))
            {
                MessageBox.Show("Karyawan " + nama + " sudah melakukan absen keluar hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Konfirmasi jika melakukan absen keluar lebih awal dari 30 menit sebelum jam kerja berakhir
            if (config != null)
            {
                TimeSpan waktuSekarang = DateTime.Now.TimeOfDay;
                TimeSpan batasAwalKeluar = config.jam_keluar_normal.Subtract(TimeSpan.FromMinutes(30));
                
                if (waktuSekarang < batasAwalKeluar)
                {
                    var confirmResult = MessageBox.Show(
                        $"Jam kerja normal belum selesai (Absen keluar normal baru mulai pukul {batasAwalKeluar.ToString(@"hh\:mm")}).\r\n\r\n" +
                        "Apakah Anda yakin ingin mencatat absen keluar lebih awal?",
                        "Konfirmasi Absen Keluar Awal",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (confirmResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            if (absensi_serv.simpanAbsenKeluar(karyawanId) > 0)
            {
                string timeStr = DateTime.Now.ToString("HH:mm:ss");
                info_lbl.Text = $"{nama} - Absen keluar berhasil - {timeStr}";
                info_lbl.ForeColor = Color.FromArgb(14, 165, 233);
                info_lbl.BackColor = Color.FromArgb(240, 249, 255);
                kode_txt.Clear();
                refreshSemuaData();
            }
            else
            {
                MessageBox.Show("Gagal mencatat Absen Keluar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadRecentScans()
        {
            try
            {
                Koneksi server = new Koneksi();
                string q;
                Dictionary<string, object> p = null;

                if (UserSession.role == "Karyawan")
                {
                    q = @"
                        SELECT 
                            k.nama_karyawan, 
                            k.jabatan, 
                            k.jenis, 
                            a.jam_masuk AS waktu_scan, 
                            'Masuk' AS tipe_scan
                        FROM absensi a 
                        JOIN karyawan k ON a.karyawan_id = k.karyawan_id 
                        WHERE a.tanggal = CURDATE() AND a.jam_masuk IS NOT NULL AND k.kode_karyawan = @kode
                        UNION ALL
                        SELECT 
                            k.nama_karyawan, 
                            k.jabatan, 
                            k.jenis, 
                            a.jam_keluar AS waktu_scan, 
                            'Keluar' AS tipe_scan
                        FROM absensi a 
                        JOIN karyawan k ON a.karyawan_id = k.karyawan_id 
                        WHERE a.tanggal = CURDATE() AND a.jam_keluar IS NOT NULL AND k.kode_karyawan = @kode
                        ORDER BY waktu_scan DESC
                        LIMIT 3";
                    p = new Dictionary<string, object> { { "@kode", loggedInKodeKaryawan } };
                }
                else
                {
                    q = @"
                        SELECT 
                            k.nama_karyawan, 
                            k.jabatan, 
                            k.jenis, 
                            a.jam_masuk AS waktu_scan, 
                            'Masuk' AS tipe_scan
                        FROM absensi a 
                        JOIN karyawan k ON a.karyawan_id = k.karyawan_id 
                        WHERE a.tanggal = CURDATE() AND a.jam_masuk IS NOT NULL
                        UNION ALL
                        SELECT 
                            k.nama_karyawan, 
                            k.jabatan, 
                            k.jenis, 
                            a.jam_keluar AS waktu_scan, 
                            'Keluar' AS tipe_scan
                        FROM absensi a 
                        JOIN karyawan k ON a.karyawan_id = k.karyawan_id 
                        WHERE a.tanggal = CURDATE() AND a.jam_keluar IS NOT NULL
                        ORDER BY waktu_scan DESC
                        LIMIT 3";
                }

                DataTable dt = p != null ? server.eksekusiQueryParam(q, p) : server.eksekusiQuery(q);
                recent_flow_panel.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string nama = row["nama_karyawan"].ToString();
                    string jabatan = row["jabatan"].ToString();
                    string jenis = row["jenis"].ToString();
                    TimeSpan waktu = (TimeSpan)row["waktu_scan"];
                    string tipe = row["tipe_scan"].ToString();

                    Panel card = CreateRecentScanCard(nama, jabatan, jenis, waktu, tipe);
                    recent_flow_panel.Controls.Add(card);
                }
            }
            catch { }
        }

        private Panel CreateRecentScanCard(string nama, string jabatan, string jenis, TimeSpan waktu, string tipe)
        {
            Panel p = new Panel();
            p.Size = new Size(480, 68);
            p.Margin = new Padding(10, 4, 10, 4);
            p.BackColor = Color.Transparent;

            string initials = GetInitials(nama);
            string timeStr = waktu.ToString(@"hh\:mm");
            
            bool isLate = false;
            int lateMinutes = 0;
            if (tipe == "Masuk" && config != null)
            {
                TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                if (waktu > normalLimit)
                {
                    isLate = true;
                    lateMinutes = (int)(waktu - config.jam_masuk_normal).TotalMinutes;
                }
            }

            p.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                Rectangle bounds = new Rectangle(1, 1, p.Width - 3, p.Height - 3);

                Color cardBg;
                Color cardBorder;
                Color circleBg;
                Color themeColor;
                string subtitle;

                if (tipe == "Keluar")
                {
                    cardBg = Color.FromArgb(240, 249, 255);
                    cardBorder = Color.FromArgb(186, 230, 253);
                    circleBg = Color.FromArgb(14, 165, 233);
                    themeColor = Color.FromArgb(3, 105, 161);
                    subtitle = $"{jabatan} · {jenis} · Absen keluar berhasil";
                }
                else if (isLate)
                {
                    cardBg = Color.FromArgb(255, 251, 235);
                    cardBorder = Color.FromArgb(253, 230, 138);
                    circleBg = Color.FromArgb(245, 158, 11);
                    themeColor = Color.FromArgb(180, 83, 9);
                    subtitle = $"{jabatan} · {jenis} · Telat {lateMinutes} menit";
                }
                else
                {
                    cardBg = Color.FromArgb(240, 253, 244);
                    cardBorder = Color.FromArgb(187, 247, 208);
                    circleBg = Color.FromArgb(34, 197, 94);
                    themeColor = Color.FromArgb(21, 128, 61);
                    subtitle = $"{jabatan} · {jenis} · Absen masuk berhasil";
                }

                using (var path = GetRoundedRect(bounds, 8))
                {
                    using (var brush = new SolidBrush(cardBg))
                        g.FillPath(brush, path);
                    using (var pen = new Pen(cardBorder, 1f))
                        g.DrawPath(pen, path);
                }

                Rectangle circleRect = new Rectangle(15, (p.Height - 38) / 2, 38, 38);
                using (var brush = new SolidBrush(circleBg))
                    g.FillEllipse(brush, circleRect);

                using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    SizeF size = g.MeasureString(initials, font);
                    g.DrawString(initials, font, brush, circleRect.Left + (circleRect.Width - size.Width) / 2 + 1, circleRect.Top + (circleRect.Height - size.Height) / 2);
                }

                using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                {
                    g.DrawString(nama, font, brush, 65, 15);
                }

                using (var font = new Font("Segoe UI", 8F))
                using (var brush = new SolidBrush(Color.FromArgb(100, 110, 125)))
                {
                    g.DrawString(subtitle, font, brush, 65, 34);
                }

                using (var font = new Font("Segoe UI", 11F, FontStyle.Bold))
                using (var brush = new SolidBrush(themeColor))
                {
                    SizeF size = g.MeasureString(timeStr, font);
                    g.DrawString(timeStr, font, brush, p.Width - size.Width - 20, (p.Height - size.Height) / 2);
                }
            };

            return p;
        }

        private void loadRekap()
        {
            try
            {
                Koneksi server = new Koneksi();
                
                if (UserSession.role == "Karyawan")
                {
                    DataTable dtMyAbs = server.eksekusiQueryParam(
                        "SELECT jam_masuk, jam_keluar FROM absensi WHERE tanggal = CURDATE() AND karyawan_id = (SELECT karyawan_id FROM users WHERE user_id = @user_id)",
                        new Dictionary<string, object> { { "@user_id", UserSession.user_id } }
                    );

                    if (dtMyAbs.Rows.Count > 0)
                    {
                        var row = dtMyAbs.Rows[0];
                        bool hasIn = row["jam_masuk"] != DBNull.Value;
                        bool hasOut = row["jam_keluar"] != DBNull.Value;

                        statSudahAbsen = hasIn ? 1 : 0;
                        statBelumAbsen = hasIn ? 0 : 1;
                        statSudahKeluar = hasOut ? 1 : 0;

                        if (hasIn && config != null)
                        {
                            TimeSpan inTime = (TimeSpan)row["jam_masuk"];
                            TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                            statTelat = (inTime > normalLimit) ? 1 : 0;
                        }
                        else
                        {
                            statTelat = 0;
                        }
                    }
                    else
                    {
                        statSudahAbsen = 0;
                        statBelumAbsen = 1;
                        statTelat = 0;
                        statSudahKeluar = 0;
                    }
                }
                else // HRD
                {
                    DataTable dtTotal = server.eksekusiQuery("SELECT COUNT(*) AS total FROM karyawan WHERE is_aktif = 1");
                    int totalKar = dtTotal.Rows.Count > 0 ? Convert.ToInt32(dtTotal.Rows[0]["total"]) : 0;

                    DataTable dtMasuk = server.eksekusiQuery("SELECT COUNT(*) AS total FROM absensi WHERE tanggal = CURDATE() AND jam_masuk IS NOT NULL");
                    statSudahAbsen = dtMasuk.Rows.Count > 0 ? Convert.ToInt32(dtMasuk.Rows[0]["total"]) : 0;

                    TimeSpan limitTime = config != null ? config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit)) : new TimeSpan(8, 15, 0);
                    string limitStr = limitTime.ToString(@"hh\:mm\:ss");
                    DataTable dtTelat = server.eksekusiQueryParam(
                        "SELECT COUNT(*) AS total FROM absensi WHERE tanggal = CURDATE() AND jam_masuk > @limit",
                        new Dictionary<string, object> { { "@limit", limitStr } });
                    statTelat = dtTelat.Rows.Count > 0 ? Convert.ToInt32(dtTelat.Rows[0]["total"]) : 0;

                    DataTable dtKeluar = server.eksekusiQuery("SELECT COUNT(*) AS total FROM absensi WHERE tanggal = CURDATE() AND jam_keluar IS NOT NULL");
                    statSudahKeluar = dtKeluar.Rows.Count > 0 ? Convert.ToInt32(dtKeluar.Rows[0]["total"]) : 0;

                    statBelumAbsen = Math.Max(0, totalKar - statSudahAbsen);
                }

                panel_rekap_card.Invalidate();
            }
            catch { }
        }

        private void tampilGrid()
        {
            try
            {
                DataTable dt = absensi_serv.viewAbsensiHarian(DateTime.Today);
                if (UserSession.role == "Karyawan")
                {
                    if (!string.IsNullOrEmpty(loggedInKodeKaryawan))
                    {
                        dt.DefaultView.RowFilter = $"Kode = '{loggedInKodeKaryawan}'";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = "1=0";
                    }
                }
                log_dgv.DataSource = dt;
            }
            catch { }
        }

        private string GetInitials(string name)
        {
            if (string.IsNullOrEmpty(name)) return "";
            string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
            return (parts[0].Substring(0, 1) + parts[1].Substring(0, 1)).ToUpper();
        }

        private void log_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // Alice Blue
                : Color.FromArgb(176, 196, 222); // Light Steel Blue
            
            e.CellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            e.CellStyle.SelectionBackColor = Color.FromArgb(14, 165, 233);
            e.CellStyle.SelectionForeColor = Color.White;

            string colName = log_dgv.Columns[e.ColumnIndex].Name;

            if (colName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                
                if (status == "Hadir" && config != null)
                {
                    object inVal = log_dgv.Rows[e.RowIndex].Cells["Jam Masuk"].Value;
                    if (inVal != null && inVal != DBNull.Value && inVal is TimeSpan inTime)
                    {
                        TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                        if (inTime > normalLimit)
                        {
                            e.Value = "Telat";
                            e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                            e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                            e.FormattingApplied = true;
                            return;
                        }
                    }
                }

                if (status == "Hadir" || status == "Tepat")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (status == "Alpha")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                }
            }

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

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 2: LOGIKA HRD MODE (Monitor & Koreksi CRUD)
        // ─────────────────────────────────────────────────────────────────────
        private void SetupHrdDataGridView()
        {
            hrd_log_dgv.ReadOnly = true;
            hrd_log_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            hrd_log_dgv.MultiSelect = false;
            hrd_log_dgv.AllowUserToAddRows = false;
            hrd_log_dgv.AllowUserToDeleteRows = false;
            hrd_log_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            hrd_log_dgv.EnableHeadersVisualStyles = false;
            hrd_log_dgv.BorderStyle = BorderStyle.None;
            hrd_log_dgv.RowHeadersVisible = false;

            hrd_log_dgv.BackgroundColor = Color.White;
            hrd_log_dgv.GridColor = Color.FromArgb(241, 245, 249);

            hrd_log_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            hrd_log_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            hrd_log_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            hrd_log_dgv.ColumnHeadersHeight = 34;

            hrd_log_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void hrd_bersihkan()
        {
            hrd_karyawan_txt.Clear();
            hrdSelectedKaryawanId = 0;
            
            hrd_status_cmb.SelectedIndex = 0; // default Hadir
            hrd_masuk_txt.Text = "08:00:00";
            hrd_keluar_txt.Text = "17:00:00";

            hrd_log_dgv.ClearSelection();
        }

        private void hrd_tampilGrid()
        {
            try
            {
                string keyword = (isHrdCariPlaceholder || string.IsNullOrWhiteSpace(hrd_cari_txt.Text))
                    ? "" : hrd_cari_txt.Text.Trim();

                DataTable dt = absensi_serv.viewAbsensiHarian(hrd_tanggal_dtp.Value);
                
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Escape karakter khusus DataView RowFilter agar tidak crash
                    string safeKeyword = keyword
                        .Replace("[", "[[]")
                        .Replace("]", "[]]")
                        .Replace("'", "''");
                    dt.DefaultView.RowFilter = $"Nama LIKE '%{safeKeyword}%' OR Kode LIKE '%{safeKeyword}%'";
                }

                hrd_log_dgv.DataSource = dt;

                // Format Headers
                if (hrd_log_dgv.Columns.Count > 0)
                {
                    if (hrd_log_dgv.Columns.Contains("Keterangan"))
                        hrd_log_dgv.Columns["Keterangan"].Visible = false;
                }

                hrd_warnaiAlternatingRows();
                hrd_hitungBelumAbsen(dt);
            }
            catch { }
        }

        private void hrd_warnaiAlternatingRows()
        {
            foreach (DataGridViewRow row in hrd_log_dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (hrd_log_dgv.Columns[cell.ColumnIndex].Name == "Jenis" ||
                        hrd_log_dgv.Columns[cell.ColumnIndex].Name == "Status") continue;

                    cell.Style.BackColor = row.Index % 2 == 0
                        ? Color.FromArgb(240, 248, 255) // Alice Blue
                        : Color.FromArgb(176, 196, 222); // Light Steel Blue
                }
            }
        }

        private void hrd_hitungBelumAbsen(DataTable dt)
        {
            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                string status = r["Status"].ToString();
                object masuk = r["Jam Masuk"];
                if (masuk == DBNull.Value || status == "Alpha")
                {
                    count++;
                }
            }
            hrd_stat_belum_lbl.Text = "Belum absen: " + count;
        }

        private void hrd_tanggal_dtp_ValueChanged(object sender, EventArgs e)
        {
            hrd_tampilGrid();
        }

        private void hrd_log_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = hrd_log_dgv.Rows[e.RowIndex];
            string kode = row.Cells["Kode"].Value?.ToString() ?? "";
            
            int karyawanId = dapatkanKaryawanId(kode, out string nama);
            hrdSelectedKaryawanId = karyawanId;
            hrd_karyawan_txt.Text = nama;

            // Set other fields
            hrd_status_cmb.Text = row.Cells["Status"].Value?.ToString() ?? "Hadir";

            object inVal = row.Cells["Jam Masuk"].Value;
            if (inVal != null && inVal != DBNull.Value)
            {
                if (inVal is TimeSpan ts && ts == TimeSpan.Zero)
                    hrd_masuk_txt.Text = "";
                else
                    hrd_masuk_txt.Text = inVal.ToString();
            }
            else hrd_masuk_txt.Text = "";

            object outVal = row.Cells["Jam Keluar"].Value;
            if (outVal != null && outVal != DBNull.Value)
            {
                if (outVal is TimeSpan ts && ts == TimeSpan.Zero)
                    hrd_keluar_txt.Text = "";
                else
                    hrd_keluar_txt.Text = outVal.ToString();
            }
            else hrd_keluar_txt.Text = "";
        }

        private void hrd_log_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = hrd_log_dgv.Columns[e.ColumnIndex].Name;

            // General styles
            e.CellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245);
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            // Alternate colors (manually applied here as hrd_warnaiAlternatingRows sets the backcolors, we just need to keep selection styles)

            // Status Column Badge
            if (colName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cek if late
                if (status == "Hadir" && config != null)
                {
                    object inVal = hrd_log_dgv.Rows[e.RowIndex].Cells["Jam Masuk"].Value;
                    if (inVal != null && inVal != DBNull.Value && inVal is TimeSpan inTime && inTime > TimeSpan.Zero)
                    {
                        TimeSpan normalLimit = config.jam_masuk_normal.Add(TimeSpan.FromMinutes(config.toleransi_menit));
                        if (inTime > normalLimit)
                        {
                            status = "Telat";
                            e.Value = "Telat";
                        }
                    }
                }

                if (status == "Hadir" || status == "Tepat")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // light green
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61); // dark green text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(187, 247, 208);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (status == "Telat")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // light yellow
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9); // dark yellow text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(253, 230, 138);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(180, 83, 9);
                }
                else if (status == "Alpha")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // light red
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27); // dark red text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(254, 202, 202);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(153, 27, 27);
                }
                else // Izin / Sakit
                {
                    e.CellStyle.BackColor = Color.FromArgb(243, 244, 246); // light gray
                    e.CellStyle.ForeColor = Color.FromArgb(75, 85, 99); // dark gray text
                    e.CellStyle.SelectionBackColor = Color.FromArgb(229, 231, 235);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(75, 85, 99);
                }
            }

            // Jenis Column Badge
            if (colName == "Jenis" && e.Value != null)
            {
                string val = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (val == "Tetap")
                {
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
                }
                else if (val == "Harian")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(187, 247, 208);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (val == "Kontrak")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(253, 230, 138);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(180, 83, 9);
                }
            }

            // Jam format
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

        private void hrd_cari_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (isHrdCariPlaceholder)
            {
                hrd_cari_txt.Text = "";
                hrd_cari_txt.ForeColor = Color.FromArgb(45, 55, 72);
                isHrdCariPlaceholder = false;
            }
        }

        private void hrd_cari_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hrd_cari_txt.Text))
            {
                hrd_cari_txt.Text = HrdPlaceholderText;
                hrd_cari_txt.ForeColor = Color.FromArgb(160, 174, 192);
                isHrdCariPlaceholder = true;
            }
        }

        private void hrd_cari_txt_TextChanged(object sender, EventArgs e)
        {
            hrd_tampilGrid();
        }

        private void hrd_simpan_btn_Click(object sender, EventArgs e)
        {
            if (hrdSelectedKaryawanId <= 0)
            {
                MessageBox.Show("Silakan pilih karyawan dengan mengklik baris pada tabel terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int karyawanId = hrdSelectedKaryawanId;
            DateTime tanggal = hrd_tanggal_dtp.Value.Date;
            string status = hrd_status_cmb.Text;

            TimeSpan jamMasuk = TimeSpan.Zero;
            TimeSpan jamKeluar = TimeSpan.Zero;

            // Jam Masuk Parsing
            if (status == "Hadir")
            {
                if (string.IsNullOrWhiteSpace(hrd_masuk_txt.Text))
                {
                    MessageBox.Show("Jam Masuk tidak boleh kosong jika status Hadir.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hrd_masuk_txt.Focus();
                    return;
                }
                if (!TimeSpan.TryParse(hrd_masuk_txt.Text, out jamMasuk))
                {
                    MessageBox.Show("Format Jam Masuk tidak valid. Gunakan format HH:mm:ss.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hrd_masuk_txt.Focus();
                    return;
                }
            }

            // Jam Keluar Parsing
            if (!string.IsNullOrWhiteSpace(hrd_keluar_txt.Text) && hrd_keluar_txt.Text != "—" && hrd_keluar_txt.Text != "00:00:00")
            {
                if (!TimeSpan.TryParse(hrd_keluar_txt.Text, out jamKeluar))
                {
                    MessageBox.Show("Format Jam Keluar tidak valid. Gunakan format HH:mm:ss.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hrd_keluar_txt.Focus();
                    return;
                }
            }

            // Construct DataAbsensi model
            DataAbsensi abs = new DataAbsensi();
            abs.karyawan_id = karyawanId;
            abs.tanggal = tanggal;
            abs.jam_masuk = jamMasuk;
            abs.jam_keluar = jamKeluar;
            abs.status = status;
            abs.keterangan = "";

            try
            {
                // Cek apakah data absen sudah ada di DB
                Koneksi server = new Koneksi();
                string q = "SELECT COUNT(*) FROM absensi WHERE karyawan_id = @id AND tanggal = @tanggal";
                var p = new Dictionary<string, object>
                {
                    { "@id", karyawanId },
                    { "@tanggal", tanggal.ToString("yyyy-MM-dd") }
                };
                DataTable dt = server.eksekusiQueryParam(q, p);
                bool exists = dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;

                int result;
                if (exists)
                {
                    result = absensi_serv.update(abs);
                }
                else
                {
                    result = absensi_serv.Save(abs);
                }

                if (result > 0)
                {
                    MessageBox.Show("Data absensi berhasil dikoreksi dan disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hrd_bersihkan();
                    hrd_tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data absensi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hrd_batal_btn_Click(object sender, EventArgs e)
        {
            hrd_bersihkan();
        }

        // ─────────────────────────────────────────────────────────────────────
        // CUSTOM PAINT HANDLERS (Drawing logic for Karyawan Mode cards)
        // ─────────────────────────────────────────────────────────────────────
        private void HeaderCard_Paint(object sender, PaintEventArgs e)
        {
            Card_Paint(sender, e);
            if (config != null)
            {
                using (var iconFont = new Font("Segoe MDL2 Assets", 10F))
                using (var textFont = new Font("Segoe UI", 9F))
                using (var brush = new SolidBrush(Color.FromArgb(100, 110, 125)))
                {
                    string masukIcon = "\uE895";
                    string masukText = $"Masuk normal: {config.jam_masuk_normal.ToString(@"hh\:mm")} · toleransi {config.toleransi_menit} m";

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    // Pusatkan teks ke tengah vertikal (Y=35) dan geser ke kiri (Width - 450) agar tidak tertabrak tombol "Keluar Kiosk"
                    e.Graphics.DrawString(masukIcon, iconFont, brush, panel_header.Width - 450, 35);
                    e.Graphics.DrawString(masukText, textFont, brush, panel_header.Width - 430, 35);
                }
            }
        }

        private void ScanCard_Paint(object sender, PaintEventArgs e)
        {
            Card_Paint(sender, e);
        }

        private void ScannerTarget_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(1, 1, panel_scanner_target.Width - 3, panel_scanner_target.Height - 3);

            using (var pen = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
            {
                pen.DashStyle = DashStyle.Dash;
                using (var path = GetRoundedRect(bounds, 8))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void RekapCard_Paint(object sender, PaintEventArgs e)
        {
            Card_Paint(sender, e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (var iconFont = new Font("Segoe MDL2 Assets", 10F))
            using (var titleFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var blueBrush = new SolidBrush(Color.FromArgb(14, 165, 233)))
            using (var titleBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
            {
                g.DrawString("\uF246", iconFont, blueBrush, 20, 16);
                g.DrawString("Rekap Hari Ini", titleFont, titleBrush, 40, 14);
            }

            using (var pen = new Pen(Color.FromArgb(241, 245, 249), 1f))
            {
                g.DrawLine(pen, 15, 40, panel_rekap_card.Width - 15, 40);
            }

            string[] labels = { "Sudah absen", "Belum absen", "Telat", "Sudah keluar" };
            int[] values = { statSudahAbsen, statBelumAbsen, statTelat, statSudahKeluar };

            using (var labelFont = new Font("Segoe UI", 9F))
            using (var valueFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var labelBrush = new SolidBrush(Color.FromArgb(100, 110, 125)))
            using (var valueBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
            using (var linePen = new Pen(Color.FromArgb(241, 245, 249), 1f))
            {
                int startY = 45;
                int rowHeight = 29;

                for (int i = 0; i < 4; i++)
                {
                    g.DrawString(labels[i], labelFont, labelBrush, 20, startY + (rowHeight - 16) / 2);

                    string valStr = values[i].ToString();
                    SizeF valSize = g.MeasureString(valStr, valueFont);
                    g.DrawString(valStr, valueFont, valueBrush, panel_rekap_card.Width - valSize.Width - 25, startY + (rowHeight - 16) / 2);

                    if (i < 3)
                    {
                        g.DrawLine(linePen, 20, startY + rowHeight, panel_rekap_card.Width - 20, startY + rowHeight);
                    }

                    startY += rowHeight;
                }
            }
        }

        private void LogCard_Paint(object sender, PaintEventArgs e)
        {
            Card_Paint(sender, e);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Control ctrl = (Control)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(1, 1, ctrl.Width - 3, ctrl.Height - 3);

            using (var path = GetRoundedRect(bounds, 8))
            {
                using (var brush = new SolidBrush(Color.White))
                    g.FillPath(brush, path);
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
                    g.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ─────────────────────────────────────────────────────────────────────
        // WEBCAM SCANNING LOGIC FOR KIOSK MODE
        // ─────────────────────────────────────────────────────────────────────
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!isScanning) return;

            try
            {
                // Clone 1: Untuk rendering di UI Thread Preview
                Bitmap bitmapForPreview = (Bitmap)eventArgs.Frame.Clone();

                // Update webcam preview box on UI thread
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    if (picWebcam != null && !picWebcam.IsDisposed)
                    {
                        if (picWebcam.Image != null)
                        {
                            picWebcam.Image.Dispose();
                        }
                        picWebcam.Image = bitmapForPreview;
                    }
                    else
                    {
                        // Jika picturebox tidak ada atau sudah didispose, dispose clone preview ini
                        bitmapForPreview.Dispose();
                    }
                }));

                // Clone 2: Untuk proses decoding di Background Thread (dalam block 'using' agar langsung dibebaskan dari RAM)
                using (Bitmap bitmapForDecoding = (Bitmap)eventArgs.Frame.Clone())
                {
                    // Cooldown: Blok proses decoding selama 3 detik setelah scan sukses
                    if ((DateTime.Now - lastScanTime).TotalSeconds < 3)
                    {
                        return;
                    }

                    // Lakukan pencarian QR/Barcode dengan ZXing menggunakan bitmap decoding
                    var result = barcodeReader.Decode(bitmapForDecoding);
                    if (result != null)
                    {
                        lastScanTime = DateTime.Now;
                        string decodedText = result.Text.Trim();

                        // Mainkan suara beep singkat
                        System.Media.SystemSounds.Asterisk.Play();

                        // Eksekusi proses absensi di UI thread
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            prosesAbsensi(decodedText);
                        }));
                    }
                }
            }
            catch { }
        }

        private void FormAbsensi_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWebcam();
        }

        private void StopWebcam()
        {
            try
            {
                isScanning = false;
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.NewFrame -= VideoSource_NewFrame;
                    videoSource = null;
                }

                if (picWebcam != null && picWebcam.Image != null)
                {
                    picWebcam.Image.Dispose();
                    picWebcam.Image = null;
                }
            }
            catch { }
        }
    }
}
