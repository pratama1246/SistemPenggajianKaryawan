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
            this.BackColor         = System.Drawing.Color.FromArgb(244, 246, 249);
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
            this.sidebar_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Menu title
            this.menu_title_lbl.Text      = "MENU HRD";
            this.menu_title_lbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.menu_title_lbl.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.menu_title_lbl.Location  = new System.Drawing.Point(14, 20);
            this.menu_title_lbl.Size      = new System.Drawing.Size(152, 18);

            // 
            // menu_dashboard_btn
            // 
            this.menu_dashboard_btn.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.menu_dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_dashboard_btn.FlatAppearance.BorderSize = 0;
            this.menu_dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.menu_dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_dashboard_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.menu_dashboard_btn.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.menu_dashboard_btn.Location = new System.Drawing.Point(0, 44);
            this.menu_dashboard_btn.Name = "menu_dashboard_btn";
            this.menu_dashboard_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_dashboard_btn.Text = "  Dashboard";
            this.menu_dashboard_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_dashboard_btn.UseVisualStyleBackColor = false;
            this.menu_dashboard_btn.Click += new System.EventHandler(this.menu_dashboard_btn_Click);

            // 
            // menu_karyawan_btn
            // 
            this.menu_karyawan_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_karyawan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_karyawan_btn.FlatAppearance.BorderSize = 0;
            this.menu_karyawan_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(237, 242, 247);
            this.menu_karyawan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_karyawan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_karyawan_btn.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.menu_karyawan_btn.Location = new System.Drawing.Point(0, 80);
            this.menu_karyawan_btn.Name = "menu_karyawan_btn";
            this.menu_karyawan_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_karyawan_btn.Text = "  Data Karyawan";
            this.menu_karyawan_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_karyawan_btn.UseVisualStyleBackColor = true;
            this.menu_karyawan_btn.Click += new System.EventHandler(this.menu_karyawan_btn_Click);

            // 
            // menu_absensi_btn
            // 
            this.menu_absensi_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_absensi_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_absensi_btn.FlatAppearance.BorderSize = 0;
            this.menu_absensi_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(237, 242, 247);
            this.menu_absensi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_absensi_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_absensi_btn.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.menu_absensi_btn.Location = new System.Drawing.Point(0, 116);
            this.menu_absensi_btn.Name = "menu_absensi_btn";
            this.menu_absensi_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_absensi_btn.Text = "  Input Absensi";
            this.menu_absensi_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_absensi_btn.UseVisualStyleBackColor = true;
            this.menu_absensi_btn.Click += new System.EventHandler(this.menu_absensi_btn_Click);

            // 
            // menu_proses_btn
            // 
            this.menu_proses_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_proses_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_proses_btn.FlatAppearance.BorderSize = 0;
            this.menu_proses_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(237, 242, 247);
            this.menu_proses_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_proses_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_proses_btn.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.menu_proses_btn.Location = new System.Drawing.Point(0, 152);
            this.menu_proses_btn.Name = "menu_proses_btn";
            this.menu_proses_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_proses_btn.Text = "  Proses Gaji";
            this.menu_proses_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_proses_btn.UseVisualStyleBackColor = true;
            this.menu_proses_btn.Click += new System.EventHandler(this.menu_proses_btn_Click);

            // 
            // menu_slip_btn
            // 
            this.menu_slip_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_slip_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_slip_btn.FlatAppearance.BorderSize = 0;
            this.menu_slip_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(237, 242, 247);
            this.menu_slip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_slip_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_slip_btn.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.menu_slip_btn.Location = new System.Drawing.Point(0, 188);
            this.menu_slip_btn.Name = "menu_slip_btn";
            this.menu_slip_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_slip_btn.Text = "  Cetak Slip Gaji";
            this.menu_slip_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_slip_btn.UseVisualStyleBackColor = true;
            this.menu_slip_btn.Click += new System.EventHandler(this.menu_slip_btn_Click);

            // Divider
            this.divider_panel.Location  = new System.Drawing.Point(10, 236);
            this.divider_panel.Size      = new System.Drawing.Size(160, 1);
            this.divider_panel.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Transparent;
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(237, 242, 247);
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.logout_btn.ForeColor = System.Drawing.Color.FromArgb(205, 92, 92);
            this.logout_btn.Location = new System.Drawing.Point(0, 248);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(180, 34);
            this.logout_btn.Text = "  Logout";
            this.logout_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);

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
            this.content_panel.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            // ── CONTAINER PANEL HOME ──────────────────────────
            this.dashboard_home_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard_home_panel.Location = new System.Drawing.Point(0, 0);
            this.dashboard_home_panel.Size = new System.Drawing.Size(920, 636);
            this.dashboard_home_panel.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            // Sambutan
            this.sambut_lbl.Text      = "Selamat datang, HRD";
            this.sambut_lbl.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sambut_lbl.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.sambut_lbl.Location  = new System.Drawing.Point(24, 24);
            this.sambut_lbl.Size      = new System.Drawing.Size(860, 30);

            this.tanggal_lbl.Text      = "";
            this.tanggal_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.tanggal_lbl.Location  = new System.Drawing.Point(24, 56);
            this.tanggal_lbl.Size      = new System.Drawing.Size(860, 20);

            // ── STAT CARDS ────────────────────────────────────
            // card_karyawan
            this.card_karyawan.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.card_karyawan.Location = new System.Drawing.Point(24, 90);
            this.card_karyawan.Size = new System.Drawing.Size(200, 80);
            this.card_karyawan.Controls.Add(this.stat_karyawan_lbl);
            this.card_karyawan.Controls.Add(this.statlbl_karyawan);
            // stat_karyawan_lbl
            this.stat_karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.stat_karyawan_lbl.Location = new System.Drawing.Point(12, 10);
            this.stat_karyawan_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_karyawan_lbl.Text = "24";
            // statlbl_karyawan
            this.statlbl_karyawan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_karyawan.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.statlbl_karyawan.Location = new System.Drawing.Point(12, 50);
            this.statlbl_karyawan.Size = new System.Drawing.Size(176, 18);
            this.statlbl_karyawan.Text = "Total Karyawan";

            // card_absensi
            this.card_absensi.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.card_absensi.Location = new System.Drawing.Point(248, 90);
            this.card_absensi.Size = new System.Drawing.Size(200, 80);
            this.card_absensi.Controls.Add(this.stat_absensi_lbl);
            this.card_absensi.Controls.Add(this.statlbl_absensi);
            // stat_absensi_lbl
            this.stat_absensi_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_absensi_lbl.ForeColor = System.Drawing.Color.FromArgb(245, 166, 35);
            this.stat_absensi_lbl.Location = new System.Drawing.Point(12, 10);
            this.stat_absensi_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_absensi_lbl.Text = "22";
            // statlbl_absensi
            this.statlbl_absensi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_absensi.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.statlbl_absensi.Location = new System.Drawing.Point(12, 50);
            this.statlbl_absensi.Size = new System.Drawing.Size(176, 18);
            this.statlbl_absensi.Text = "Absensi Masuk";

            // card_gaji
            this.card_gaji.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.card_gaji.Location = new System.Drawing.Point(472, 90);
            this.card_gaji.Size = new System.Drawing.Size(200, 80);
            this.card_gaji.Controls.Add(this.stat_gaji_lbl);
            this.card_gaji.Controls.Add(this.statlbl_gaji);
            // stat_gaji_lbl
            this.stat_gaji_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_gaji_lbl.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.stat_gaji_lbl.Location = new System.Drawing.Point(12, 10);
            this.stat_gaji_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_gaji_lbl.Text = "18";
            // statlbl_gaji
            this.statlbl_gaji.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_gaji.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.statlbl_gaji.Location = new System.Drawing.Point(12, 50);
            this.statlbl_gaji.Size = new System.Drawing.Size(176, 18);
            this.statlbl_gaji.Text = "Gaji Diproses";

            // card_periode
            this.card_periode.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.card_periode.Location = new System.Drawing.Point(696, 90);
            this.card_periode.Size = new System.Drawing.Size(200, 80);
            this.card_periode.Controls.Add(this.stat_periode_lbl);
            this.card_periode.Controls.Add(this.statlbl_periode);
            // stat_periode_lbl
            this.stat_periode_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_periode_lbl.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.stat_periode_lbl.Location = new System.Drawing.Point(12, 10);
            this.stat_periode_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_periode_lbl.Text = "Mei";
            // statlbl_periode
            this.statlbl_periode.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_periode.ForeColor = System.Drawing.Color.FromArgb(113, 128, 150);
            this.statlbl_periode.Location = new System.Drawing.Point(12, 50);
            this.statlbl_periode.Size = new System.Drawing.Size(176, 18);
            this.statlbl_periode.Text = "Periode Aktif";

            // ── AKTIVITAS TERBARU ─────────────────────────────
            this.aktivitas_lbl.Text      = "Aktivitas Terbaru";
            this.aktivitas_lbl.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.aktivitas_lbl.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.aktivitas_lbl.Location  = new System.Drawing.Point(24, 196);
            this.aktivitas_lbl.Size      = new System.Drawing.Size(860, 22);

            // akt1_panel
            this.akt1_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.akt1_panel.Location = new System.Drawing.Point(24, 236);
            this.akt1_panel.Size = new System.Drawing.Size(872, 38);
            this.akt1_panel.Controls.Add(this.akt1_lbl);
            this.akt1_panel.Controls.Add(this.akt1_badge);
            // akt1_lbl
            this.akt1_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt1_lbl.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.akt1_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt1_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt1_lbl.Text = "Absensi bulan Mei 2026 telah diperbarui";
            // akt1_badge
            this.akt1_badge.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.akt1_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt1_badge.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.akt1_badge.Location = new System.Drawing.Point(786, 9);
            this.akt1_badge.Size = new System.Drawing.Size(70, 20);
            this.akt1_badge.Text = "Selesai";
            this.akt1_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // akt2_panel
            this.akt2_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.akt2_panel.Location = new System.Drawing.Point(24, 284);
            this.akt2_panel.Size = new System.Drawing.Size(872, 38);
            this.akt2_panel.Controls.Add(this.akt2_lbl);
            this.akt2_panel.Controls.Add(this.akt2_badge);
            // akt2_lbl
            this.akt2_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt2_lbl.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.akt2_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt2_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt2_lbl.Text = "Karyawan baru: Ahmad Ridwan ditambahkan";
            // akt2_badge
            this.akt2_badge.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.akt2_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt2_badge.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.akt2_badge.Location = new System.Drawing.Point(786, 9);
            this.akt2_badge.Size = new System.Drawing.Size(70, 20);
            this.akt2_badge.Text = "Info";
            this.akt2_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // akt3_panel
            this.akt3_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.akt3_panel.Location = new System.Drawing.Point(24, 332);
            this.akt3_panel.Size = new System.Drawing.Size(872, 38);
            this.akt3_panel.Controls.Add(this.akt3_lbl);
            this.akt3_panel.Controls.Add(this.akt3_badge);
            // akt3_lbl
            this.akt3_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt3_lbl.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.akt3_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt3_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt3_lbl.Text = "Slip gaji Mei 2026 siap dicetak";
            // akt3_badge
            this.akt3_badge.BackColor = System.Drawing.Color.FromArgb(245, 166, 35);
            this.akt3_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt3_badge.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.akt3_badge.Location = new System.Drawing.Point(786, 9);
            this.akt3_badge.Size = new System.Drawing.Size(70, 20);
            this.akt3_badge.Text = "Update";
            this.akt3_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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