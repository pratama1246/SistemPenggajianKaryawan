namespace SistemPenggajianKaryawan
{
    partial class FormDashboarHRD
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.accentPanel         = new System.Windows.Forms.Panel();
            this.sidebar_panel       = new System.Windows.Forms.Panel();
            this.menu_title_lbl      = new System.Windows.Forms.Label();
            this.menu_dashboard_btn  = new System.Windows.Forms.Button();
            this.menu_karyawan_btn   = new System.Windows.Forms.Button();
            this.menu_absensi_btn    = new System.Windows.Forms.Button();
            this.menu_proses_btn     = new System.Windows.Forms.Button();
            this.menu_slip_btn       = new System.Windows.Forms.Button();
            this.divider_panel       = new System.Windows.Forms.Panel();
            this.logout_btn          = new System.Windows.Forms.Button();
            this.content_panel       = new System.Windows.Forms.Panel();
            
            // Container Panel Home
            this.dashboard_home_panel = new System.Windows.Forms.Panel();
            
            this.sambut_lbl          = new System.Windows.Forms.Label();
            this.tanggal_lbl         = new System.Windows.Forms.Label();

            // Stat cards
            this.card_karyawan       = new System.Windows.Forms.Panel();
            this.stat_karyawan_lbl   = new System.Windows.Forms.Label();
            this.statlbl_karyawan    = new System.Windows.Forms.Label();

            this.card_absensi        = new System.Windows.Forms.Panel();
            this.stat_absensi_lbl    = new System.Windows.Forms.Label();
            this.statlbl_absensi     = new System.Windows.Forms.Label();

            this.card_gaji           = new System.Windows.Forms.Panel();
            this.stat_gaji_lbl       = new System.Windows.Forms.Label();
            this.statlbl_gaji        = new System.Windows.Forms.Label();

            this.card_periode        = new System.Windows.Forms.Panel();
            this.stat_periode_lbl    = new System.Windows.Forms.Label();
            this.statlbl_periode     = new System.Windows.Forms.Label();

            // Aktivitas
            this.aktivitas_lbl       = new System.Windows.Forms.Label();
            this.akt1_panel          = new System.Windows.Forms.Panel();
            this.akt1_lbl            = new System.Windows.Forms.Label();
            this.akt1_badge          = new System.Windows.Forms.Label();
            this.akt2_panel          = new System.Windows.Forms.Panel();
            this.akt2_lbl            = new System.Windows.Forms.Label();
            this.akt2_badge          = new System.Windows.Forms.Label();
            this.akt3_panel          = new System.Windows.Forms.Panel();
            this.akt3_lbl            = new System.Windows.Forms.Label();
            this.akt3_badge          = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ── FORM ──────────────────────────────────────────
            this.ClientSize        = new System.Drawing.Size(1100, 640);
            this.BackColor         = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle   = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox       = false;
            this.StartPosition     = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text              = "Dashboard HRD - Sistem Penggajian Karyawan";
            this.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.Load             += new System.EventHandler(this.FormDashboarHRD_Load);

            // ── ACCENT BAR ────────────────────────────────────
            this.accentPanel.Location  = new System.Drawing.Point(0, 0);
            this.accentPanel.Size      = new System.Drawing.Size(1100, 4);
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);

            // ── SIDEBAR ───────────────────────────────────────
            this.sidebar_panel.Location  = new System.Drawing.Point(0, 4);
            this.sidebar_panel.Size      = new System.Drawing.Size(180, 636);
            this.sidebar_panel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);

            // Menu title
            this.menu_title_lbl.Text      = "MENU HRD";
            this.menu_title_lbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.menu_title_lbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.menu_title_lbl.Location  = new System.Drawing.Point(14, 20);
            this.menu_title_lbl.Size      = new System.Drawing.Size(152, 18);

            // Helper buat bikin menu button
            buatMenuBtn(this.menu_dashboard_btn, "  Dashboard",   44,  true);
            buatMenuBtn(this.menu_karyawan_btn,  "  Data Karyawan",  80,  false);
            buatMenuBtn(this.menu_absensi_btn,   "  Input Absensi",  116, false);
            buatMenuBtn(this.menu_proses_btn,    "  Proses Gaji",    152, false);
            buatMenuBtn(this.menu_slip_btn,      "  Cetak Slip Gaji",188, false);

            this.menu_dashboard_btn.Click += new System.EventHandler(this.menu_dashboard_btn_Click);
            this.menu_karyawan_btn.Click += new System.EventHandler(this.menu_karyawan_btn_Click);
            this.menu_absensi_btn.Click  += new System.EventHandler(this.menu_absensi_btn_Click);
            this.menu_proses_btn.Click   += new System.EventHandler(this.menu_proses_btn_Click);
            this.menu_slip_btn.Click     += new System.EventHandler(this.menu_slip_btn_Click);

            // Divider
            this.divider_panel.Location  = new System.Drawing.Point(10, 236);
            this.divider_panel.Size      = new System.Drawing.Size(160, 1);
            this.divider_panel.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);

            // Logout
            buatMenuBtn(this.logout_btn, "  Logout", 248, false);
            this.logout_btn.ForeColor = System.Drawing.Color.FromArgb(205, 92, 92);
            this.logout_btn.Click    += new System.EventHandler(this.logout_btn_Click);

            this.sidebar_panel.Controls.Add(this.menu_title_lbl);
            this.sidebar_panel.Controls.Add(this.menu_dashboard_btn);
            this.sidebar_panel.Controls.Add(this.menu_karyawan_btn);
            this.sidebar_panel.Controls.Add(this.menu_absensi_btn);
            this.sidebar_panel.Controls.Add(this.menu_proses_btn);
            this.sidebar_panel.Controls.Add(this.menu_slip_btn);
            this.sidebar_panel.Controls.Add(this.divider_panel);
            this.sidebar_panel.Controls.Add(this.logout_btn);

            // ── CONTENT PANEL ─────────────────────────────────
            this.content_panel.Location  = new System.Drawing.Point(180, 4);
            this.content_panel.Size      = new System.Drawing.Size(920, 636);
            this.content_panel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // ── CONTAINER PANEL HOME ──────────────────────────
            this.dashboard_home_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard_home_panel.Location = new System.Drawing.Point(0, 0);
            this.dashboard_home_panel.Size = new System.Drawing.Size(920, 636);
            this.dashboard_home_panel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // Sambutan
            this.sambut_lbl.Text      = "Selamat datang, HRD";
            this.sambut_lbl.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sambut_lbl.ForeColor = System.Drawing.Color.White;
            this.sambut_lbl.Location  = new System.Drawing.Point(24, 24);
            this.sambut_lbl.Size      = new System.Drawing.Size(860, 30);

            this.tanggal_lbl.Text      = "";
            this.tanggal_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.tanggal_lbl.Location  = new System.Drawing.Point(24, 56);
            this.tanggal_lbl.Size      = new System.Drawing.Size(860, 20);

            // ── STAT CARDS ────────────────────────────────────
            buatStatCard(this.card_karyawan, this.stat_karyawan_lbl, this.statlbl_karyawan,
                         24, 90, "24", "Total Karyawan",
                         System.Drawing.Color.White);

            buatStatCard(this.card_absensi, this.stat_absensi_lbl, this.statlbl_absensi,
                         248, 90, "22", "Absensi Masuk",
                         System.Drawing.Color.FromArgb(245, 166, 35));

            buatStatCard(this.card_gaji, this.stat_gaji_lbl, this.statlbl_gaji,
                         472, 90, "18", "Gaji Diproses",
                         System.Drawing.Color.FromArgb(91, 200, 245));

            buatStatCard(this.card_periode, this.stat_periode_lbl, this.statlbl_periode,
                         696, 90, "Mei", "Periode Aktif",
                         System.Drawing.Color.FromArgb(76, 175, 80));

            // ── AKTIVITAS TERBARU ─────────────────────────────
            this.aktivitas_lbl.Text      = "Aktivitas Terbaru";
            this.aktivitas_lbl.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.aktivitas_lbl.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.aktivitas_lbl.Location  = new System.Drawing.Point(24, 196);
            this.aktivitas_lbl.Size      = new System.Drawing.Size(860, 22);

            buatAktivitasRow(this.akt1_panel, this.akt1_lbl, this.akt1_badge,
                             236, "Absensi bulan Mei 2026 telah diperbarui", "Selesai",
                             System.Drawing.Color.FromArgb(76, 175, 80));

            buatAktivitasRow(this.akt2_panel, this.akt2_lbl, this.akt2_badge,
                             284, "Karyawan baru: Ahmad Ridwan ditambahkan", "Info",
                             System.Drawing.Color.FromArgb(91, 200, 245));

            buatAktivitasRow(this.akt3_panel, this.akt3_lbl, this.akt3_badge,
                             332, "Slip gaji Mei 2026 siap dicetak", "Update",
                             System.Drawing.Color.FromArgb(245, 166, 35));

            // Tambah semua ke dashboard_home_panel
            this.dashboard_home_panel.Controls.Add(this.sambut_lbl);
            this.dashboard_home_panel.Controls.Add(this.tanggal_lbl);
            this.dashboard_home_panel.Controls.Add(this.card_karyawan);
            this.dashboard_home_panel.Controls.Add(this.card_absensi);
            this.dashboard_home_panel.Controls.Add(this.card_gaji);
            this.dashboard_home_panel.Controls.Add(this.card_periode);
            this.dashboard_home_panel.Controls.Add(this.aktivitas_lbl);
            this.dashboard_home_panel.Controls.Add(this.akt1_panel);
            this.dashboard_home_panel.Controls.Add(this.akt2_panel);
            this.dashboard_home_panel.Controls.Add(this.akt3_panel);

            // Tambah dashboard_home_panel ke content_panel
            this.content_panel.Controls.Add(this.dashboard_home_panel);

            // Tambah semua ke Form
            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.sidebar_panel);
            this.Controls.Add(this.content_panel);

            this.ResumeLayout(false);
        }

        // ── HELPERS ───────────────────────────────────────────

        void buatMenuBtn(System.Windows.Forms.Button btn, string text, int y, bool aktif)
        {
            btn.Text      = text;
            btn.Font      = new System.Drawing.Font("Segoe UI", 9.5F,
                            aktif ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            btn.ForeColor = aktif
                            ? System.Drawing.Color.FromArgb(24, 24, 24)
                            : System.Drawing.Color.FromArgb(160, 160, 160);
            btn.BackColor = aktif
                            ? System.Drawing.Color.FromArgb(91, 200, 245)
                            : System.Drawing.Color.Transparent;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize  = 0;
            btn.FlatAppearance.MouseOverBackColor =
                            aktif
                            ? System.Drawing.Color.FromArgb(91, 200, 245)
                            : System.Drawing.Color.FromArgb(40, 40, 40);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Location  = new System.Drawing.Point(0, y);
            btn.Size      = new System.Drawing.Size(180, 34);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        void buatStatCard(System.Windows.Forms.Panel card,
                          System.Windows.Forms.Label valLbl,
                          System.Windows.Forms.Label txtLbl,
                          int x, int y,
                          string nilai, string keterangan,
                          System.Drawing.Color warnaNilai)
        {
            card.Location  = new System.Drawing.Point(x, y);
            card.Size      = new System.Drawing.Size(200, 80);
            card.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            valLbl.Text      = nilai;
            valLbl.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            valLbl.ForeColor = warnaNilai;
            valLbl.Location  = new System.Drawing.Point(12, 10);
            valLbl.Size      = new System.Drawing.Size(176, 36);

            txtLbl.Text      = keterangan;
            txtLbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            txtLbl.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            txtLbl.Location  = new System.Drawing.Point(12, 50);
            txtLbl.Size      = new System.Drawing.Size(176, 18);

            card.Controls.Add(valLbl);
            card.Controls.Add(txtLbl);
        }

        void buatAktivitasRow(System.Windows.Forms.Panel panel,
                              System.Windows.Forms.Label txtLbl,
                              System.Windows.Forms.Label badge,
                              int y, string teks, string badgeTeks,
                              System.Drawing.Color badgeColor)
        {
            panel.Location  = new System.Drawing.Point(24, y);
            panel.Size      = new System.Drawing.Size(872, 38);
            panel.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            txtLbl.Text      = teks;
            txtLbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            txtLbl.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            txtLbl.Location  = new System.Drawing.Point(12, 10);
            txtLbl.Size      = new System.Drawing.Size(720, 18);

            badge.Text      = badgeTeks;
            badge.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            badge.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            badge.BackColor = badgeColor;
            badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            badge.Location  = new System.Drawing.Point(786, 9);
            badge.Size      = new System.Drawing.Size(70, 20);

            panel.Controls.Add(txtLbl);
            panel.Controls.Add(badge);
        }

        // ── DEKLARASI KONTROL ─────────────────────────────────
        private System.Windows.Forms.Panel  accentPanel;
        private System.Windows.Forms.Panel  sidebar_panel;
        private System.Windows.Forms.Label  menu_title_lbl;
        private System.Windows.Forms.Button menu_dashboard_btn;
        private System.Windows.Forms.Button menu_karyawan_btn;
        private System.Windows.Forms.Button menu_absensi_btn;
        private System.Windows.Forms.Button menu_proses_btn;
        private System.Windows.Forms.Button menu_slip_btn;
        private System.Windows.Forms.Panel  divider_panel;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel  content_panel;
        
        // Container home panel
        private System.Windows.Forms.Panel  dashboard_home_panel;
        
        private System.Windows.Forms.Label  sambut_lbl;
        private System.Windows.Forms.Label  tanggal_lbl;

        private System.Windows.Forms.Panel card_karyawan;
        private System.Windows.Forms.Label stat_karyawan_lbl;
        private System.Windows.Forms.Label statlbl_karyawan;

        private System.Windows.Forms.Panel card_absensi;
        private System.Windows.Forms.Label stat_absensi_lbl;
        private System.Windows.Forms.Label statlbl_absensi;

        private System.Windows.Forms.Panel card_gaji;
        private System.Windows.Forms.Label stat_gaji_lbl;
        private System.Windows.Forms.Label statlbl_gaji;

        private System.Windows.Forms.Panel card_periode;
        private System.Windows.Forms.Label stat_periode_lbl;
        private System.Windows.Forms.Label statlbl_periode;

        private System.Windows.Forms.Label aktivitas_lbl;

        private System.Windows.Forms.Panel akt1_panel;
        private System.Windows.Forms.Label akt1_lbl;
        private System.Windows.Forms.Label akt1_badge;

        private System.Windows.Forms.Panel akt2_panel;
        private System.Windows.Forms.Label akt2_lbl;
        private System.Windows.Forms.Label akt2_badge;

        private System.Windows.Forms.Panel akt3_panel;
        private System.Windows.Forms.Label akt3_lbl;
        private System.Windows.Forms.Label akt3_badge;
    }
}