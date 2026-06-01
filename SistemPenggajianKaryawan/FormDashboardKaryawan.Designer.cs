namespace SistemPenggajianKaryawan
{
    partial class FormDashboardKaryawan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.accentPanel = new System.Windows.Forms.Panel();
            this.sidebar_panel = new System.Windows.Forms.Panel();
            this.menu_title_lbl = new System.Windows.Forms.Label();
            this.menu_dashboard_btn = new System.Windows.Forms.Button();
            this.menu_slip_btn = new System.Windows.Forms.Button();
            this.divider_panel = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.content_panel = new System.Windows.Forms.Panel();
            this.dashboard_home_panel = new System.Windows.Forms.Panel();
            this.sambut_lbl = new System.Windows.Forms.Label();
            this.tanggal_lbl = new System.Windows.Forms.Label();
            this.card_kode = new System.Windows.Forms.Panel();
            this.stat_kode_lbl = new System.Windows.Forms.Label();
            this.statlbl_kode = new System.Windows.Forms.Label();
            this.card_jabatan = new System.Windows.Forms.Panel();
            this.stat_jabatan_lbl = new System.Windows.Forms.Label();
            this.statlbl_jabatan = new System.Windows.Forms.Label();
            this.card_jenis = new System.Windows.Forms.Panel();
            this.stat_jenis_lbl = new System.Windows.Forms.Label();
            this.statlbl_jenis = new System.Windows.Forms.Label();
            this.card_gapok = new System.Windows.Forms.Panel();
            this.stat_gapok_lbl = new System.Windows.Forms.Label();
            this.statlbl_gapok = new System.Windows.Forms.Label();
            this.aktivitas_lbl = new System.Windows.Forms.Label();
            this.akt1_panel = new System.Windows.Forms.Panel();
            this.akt1_lbl = new System.Windows.Forms.Label();
            this.akt1_badge = new System.Windows.Forms.Label();
            this.akt2_panel = new System.Windows.Forms.Panel();
            this.akt2_lbl = new System.Windows.Forms.Label();
            this.akt2_badge = new System.Windows.Forms.Label();
            this.akt3_panel = new System.Windows.Forms.Panel();
            this.akt3_lbl = new System.Windows.Forms.Label();
            this.akt3_badge = new System.Windows.Forms.Label();
            this.sidebar_panel.SuspendLayout();
            this.content_panel.SuspendLayout();
            this.dashboard_home_panel.SuspendLayout();
            this.card_kode.SuspendLayout();
            this.card_jabatan.SuspendLayout();
            this.card_jenis.SuspendLayout();
            this.card_gapok.SuspendLayout();
            this.akt1_panel.SuspendLayout();
            this.akt2_panel.SuspendLayout();
            this.akt3_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // accentPanel
            // 
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.accentPanel.Location = new System.Drawing.Point(0, 0);
            this.accentPanel.Name = "accentPanel";
            this.accentPanel.Size = new System.Drawing.Size(1100, 4);
            this.accentPanel.TabIndex = 0;
            // 
            // sidebar_panel
            // 
            this.sidebar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebar_panel.Controls.Add(this.menu_title_lbl);
            this.sidebar_panel.Controls.Add(this.menu_dashboard_btn);
            this.sidebar_panel.Controls.Add(this.menu_slip_btn);
            this.sidebar_panel.Controls.Add(this.divider_panel);
            this.sidebar_panel.Controls.Add(this.logout_btn);
            this.sidebar_panel.Location = new System.Drawing.Point(0, 4);
            this.sidebar_panel.Name = "sidebar_panel";
            this.sidebar_panel.Size = new System.Drawing.Size(180, 636);
            this.sidebar_panel.TabIndex = 1;
            // 
            // menu_title_lbl
            // 
            this.menu_title_lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.menu_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.menu_title_lbl.Location = new System.Drawing.Point(14, 20);
            this.menu_title_lbl.Name = "menu_title_lbl";
            this.menu_title_lbl.Size = new System.Drawing.Size(152, 18);
            this.menu_title_lbl.TabIndex = 0;
            this.menu_title_lbl.Text = "MENU KARYAWAN";
            // 
            // menu_dashboard_btn
            // 
            this.menu_dashboard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.menu_dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_dashboard_btn.FlatAppearance.BorderSize = 0;
            this.menu_dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.menu_dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_dashboard_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.menu_dashboard_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.menu_dashboard_btn.Location = new System.Drawing.Point(0, 44);
            this.menu_dashboard_btn.Name = "menu_dashboard_btn";
            this.menu_dashboard_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_dashboard_btn.TabIndex = 1;
            this.menu_dashboard_btn.Text = "  Dashboard";
            this.menu_dashboard_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_dashboard_btn.UseVisualStyleBackColor = false;
            this.menu_dashboard_btn.Click += new System.EventHandler(this.menu_dashboard_btn_Click);
            // 
            // menu_slip_btn
            // 
            this.menu_slip_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_slip_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_slip_btn.FlatAppearance.BorderSize = 0;
            this.menu_slip_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.menu_slip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_slip_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_slip_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.menu_slip_btn.Location = new System.Drawing.Point(0, 80);
            this.menu_slip_btn.Name = "menu_slip_btn";
            this.menu_slip_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_slip_btn.TabIndex = 2;
            this.menu_slip_btn.Text = "  Lihat Slip Gaji";
            this.menu_slip_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_slip_btn.UseVisualStyleBackColor = true;
            this.menu_slip_btn.Click += new System.EventHandler(this.menu_slip_btn_Click);
            // 
            // divider_panel
            // 
            this.divider_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.divider_panel.Location = new System.Drawing.Point(10, 136);
            this.divider_panel.Name = "divider_panel";
            this.divider_panel.Size = new System.Drawing.Size(160, 1);
            this.divider_panel.TabIndex = 3;
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Transparent;
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.logout_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.logout_btn.Location = new System.Drawing.Point(0, 148);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(180, 34);
            this.logout_btn.TabIndex = 4;
            this.logout_btn.Text = "  Logout";
            this.logout_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // content_panel
            // 
            this.content_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.content_panel.Controls.Add(this.dashboard_home_panel);
            this.content_panel.Location = new System.Drawing.Point(180, 4);
            this.content_panel.Name = "content_panel";
            this.content_panel.Size = new System.Drawing.Size(920, 636);
            this.content_panel.TabIndex = 2;
            // 
            // dashboard_home_panel
            // 
            this.dashboard_home_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dashboard_home_panel.Controls.Add(this.sambut_lbl);
            this.dashboard_home_panel.Controls.Add(this.tanggal_lbl);
            this.dashboard_home_panel.Controls.Add(this.card_kode);
            this.dashboard_home_panel.Controls.Add(this.card_jabatan);
            this.dashboard_home_panel.Controls.Add(this.card_jenis);
            this.dashboard_home_panel.Controls.Add(this.card_gapok);
            this.dashboard_home_panel.Controls.Add(this.aktivitas_lbl);
            this.dashboard_home_panel.Controls.Add(this.akt1_panel);
            this.dashboard_home_panel.Controls.Add(this.akt2_panel);
            this.dashboard_home_panel.Controls.Add(this.akt3_panel);
            this.dashboard_home_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard_home_panel.Location = new System.Drawing.Point(0, 0);
            this.dashboard_home_panel.Name = "dashboard_home_panel";
            this.dashboard_home_panel.Size = new System.Drawing.Size(920, 636);
            this.dashboard_home_panel.TabIndex = 0;
            // 
            // sambut_lbl
            // 
            this.sambut_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sambut_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.sambut_lbl.Location = new System.Drawing.Point(24, 24);
            this.sambut_lbl.Name = "sambut_lbl";
            this.sambut_lbl.Size = new System.Drawing.Size(860, 30);
            this.sambut_lbl.TabIndex = 0;
            this.sambut_lbl.Text = "Selamat datang, Karyawan";
            // 
            // tanggal_lbl
            // 
            this.tanggal_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tanggal_lbl.Location = new System.Drawing.Point(24, 56);
            this.tanggal_lbl.Name = "tanggal_lbl";
            this.tanggal_lbl.Size = new System.Drawing.Size(860, 20);
            this.tanggal_lbl.TabIndex = 1;
            // 
            // card_kode
            // 
            this.card_kode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.card_kode.Controls.Add(this.stat_kode_lbl);
            this.card_kode.Controls.Add(this.statlbl_kode);
            this.card_kode.Location = new System.Drawing.Point(24, 90);
            this.card_kode.Name = "card_kode";
            this.card_kode.Size = new System.Drawing.Size(200, 80);
            this.card_kode.TabIndex = 2;
            // 
            // stat_kode_lbl
            // 
            this.stat_kode_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_kode_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.stat_kode_lbl.Location = new System.Drawing.Point(8, 10);
            this.stat_kode_lbl.Name = "stat_kode_lbl";
            this.stat_kode_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_kode_lbl.TabIndex = 0;
            this.stat_kode_lbl.Text = "-";
            // 
            // statlbl_kode
            // 
            this.statlbl_kode.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_kode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_kode.Location = new System.Drawing.Point(12, 50);
            this.statlbl_kode.Name = "statlbl_kode";
            this.statlbl_kode.Size = new System.Drawing.Size(176, 18);
            this.statlbl_kode.TabIndex = 1;
            this.statlbl_kode.Text = "Kode Karyawan";
            // 
            // card_jabatan
            // 
            this.card_jabatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.card_jabatan.Controls.Add(this.stat_jabatan_lbl);
            this.card_jabatan.Controls.Add(this.statlbl_jabatan);
            this.card_jabatan.Location = new System.Drawing.Point(248, 90);
            this.card_jabatan.Name = "card_jabatan";
            this.card_jabatan.Size = new System.Drawing.Size(200, 80);
            this.card_jabatan.TabIndex = 3;
            // 
            // stat_jabatan_lbl
            // 
            this.stat_jabatan_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_jabatan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.stat_jabatan_lbl.Location = new System.Drawing.Point(8, 10);
            this.stat_jabatan_lbl.Name = "stat_jabatan_lbl";
            this.stat_jabatan_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_jabatan_lbl.TabIndex = 0;
            this.stat_jabatan_lbl.Text = "-";
            // 
            // statlbl_jabatan
            // 
            this.statlbl_jabatan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_jabatan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_jabatan.Location = new System.Drawing.Point(12, 50);
            this.statlbl_jabatan.Name = "statlbl_jabatan";
            this.statlbl_jabatan.Size = new System.Drawing.Size(176, 18);
            this.statlbl_jabatan.TabIndex = 1;
            this.statlbl_jabatan.Text = "Jabatan";
            // 
            // card_jenis
            // 
            this.card_jenis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.card_jenis.Controls.Add(this.stat_jenis_lbl);
            this.card_jenis.Controls.Add(this.statlbl_jenis);
            this.card_jenis.Location = new System.Drawing.Point(472, 90);
            this.card_jenis.Name = "card_jenis";
            this.card_jenis.Size = new System.Drawing.Size(200, 80);
            this.card_jenis.TabIndex = 4;
            // 
            // stat_jenis_lbl
            // 
            this.stat_jenis_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_jenis_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.stat_jenis_lbl.Location = new System.Drawing.Point(8, 10);
            this.stat_jenis_lbl.Name = "stat_jenis_lbl";
            this.stat_jenis_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_jenis_lbl.TabIndex = 0;
            this.stat_jenis_lbl.Text = "-";
            this.stat_jenis_lbl.Click += new System.EventHandler(this.stat_jenis_lbl_Click);
            // 
            // statlbl_jenis
            // 
            this.statlbl_jenis.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_jenis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_jenis.Location = new System.Drawing.Point(12, 50);
            this.statlbl_jenis.Name = "statlbl_jenis";
            this.statlbl_jenis.Size = new System.Drawing.Size(176, 18);
            this.statlbl_jenis.TabIndex = 1;
            this.statlbl_jenis.Text = "Status Karyawan";
            // 
            // card_gapok
            // 
            this.card_gapok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.card_gapok.Controls.Add(this.stat_gapok_lbl);
            this.card_gapok.Controls.Add(this.statlbl_gapok);
            this.card_gapok.Location = new System.Drawing.Point(696, 90);
            this.card_gapok.Name = "card_gapok";
            this.card_gapok.Size = new System.Drawing.Size(200, 80);
            this.card_gapok.TabIndex = 5;
            // 
            // stat_gapok_lbl
            // 
            this.stat_gapok_lbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.stat_gapok_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.stat_gapok_lbl.Location = new System.Drawing.Point(8, 10);
            this.stat_gapok_lbl.Name = "stat_gapok_lbl";
            this.stat_gapok_lbl.Size = new System.Drawing.Size(176, 36);
            this.stat_gapok_lbl.TabIndex = 0;
            this.stat_gapok_lbl.Text = "-";
            // 
            // statlbl_gapok
            // 
            this.statlbl_gapok.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_gapok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_gapok.Location = new System.Drawing.Point(12, 50);
            this.statlbl_gapok.Name = "statlbl_gapok";
            this.statlbl_gapok.Size = new System.Drawing.Size(176, 18);
            this.statlbl_gapok.TabIndex = 1;
            this.statlbl_gapok.Text = "Gaji Pokok";
            // 
            // aktivitas_lbl
            // 
            this.aktivitas_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.aktivitas_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.aktivitas_lbl.Location = new System.Drawing.Point(24, 196);
            this.aktivitas_lbl.Name = "aktivitas_lbl";
            this.aktivitas_lbl.Size = new System.Drawing.Size(860, 22);
            this.aktivitas_lbl.TabIndex = 6;
            this.aktivitas_lbl.Text = "Aktivitas Gaji Terbaru";
            // 
            // akt1_panel
            // 
            this.akt1_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.akt1_panel.Controls.Add(this.akt1_lbl);
            this.akt1_panel.Controls.Add(this.akt1_badge);
            this.akt1_panel.Location = new System.Drawing.Point(24, 236);
            this.akt1_panel.Name = "akt1_panel";
            this.akt1_panel.Size = new System.Drawing.Size(872, 38);
            this.akt1_panel.TabIndex = 7;
            // 
            // akt1_lbl
            // 
            this.akt1_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt1_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.akt1_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt1_lbl.Name = "akt1_lbl";
            this.akt1_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt1_lbl.TabIndex = 0;
            this.akt1_lbl.Text = "Slip gaji bulan ini sudah diterbitkan";
            // 
            // akt1_badge
            // 
            this.akt1_badge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.akt1_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt1_badge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.akt1_badge.Location = new System.Drawing.Point(786, 9);
            this.akt1_badge.Name = "akt1_badge";
            this.akt1_badge.Size = new System.Drawing.Size(70, 20);
            this.akt1_badge.TabIndex = 1;
            this.akt1_badge.Text = "Tersedia";
            this.akt1_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // akt2_panel
            // 
            this.akt2_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.akt2_panel.Controls.Add(this.akt2_lbl);
            this.akt2_panel.Controls.Add(this.akt2_badge);
            this.akt2_panel.Location = new System.Drawing.Point(24, 284);
            this.akt2_panel.Name = "akt2_panel";
            this.akt2_panel.Size = new System.Drawing.Size(872, 38);
            this.akt2_panel.TabIndex = 8;
            // 
            // akt2_lbl
            // 
            this.akt2_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt2_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.akt2_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt2_lbl.Name = "akt2_lbl";
            this.akt2_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt2_lbl.TabIndex = 0;
            this.akt2_lbl.Text = "Kehadiran absensi terdaftar aktif";
            // 
            // akt2_badge
            // 
            this.akt2_badge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.akt2_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt2_badge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.akt2_badge.Location = new System.Drawing.Point(786, 9);
            this.akt2_badge.Name = "akt2_badge";
            this.akt2_badge.Size = new System.Drawing.Size(70, 20);
            this.akt2_badge.TabIndex = 1;
            this.akt2_badge.Text = "Hadir";
            this.akt2_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // akt3_panel
            // 
            this.akt3_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.akt3_panel.Controls.Add(this.akt3_lbl);
            this.akt3_panel.Controls.Add(this.akt3_badge);
            this.akt3_panel.Location = new System.Drawing.Point(24, 332);
            this.akt3_panel.Name = "akt3_panel";
            this.akt3_panel.Size = new System.Drawing.Size(872, 38);
            this.akt3_panel.TabIndex = 9;
            // 
            // akt3_lbl
            // 
            this.akt3_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.akt3_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.akt3_lbl.Location = new System.Drawing.Point(12, 10);
            this.akt3_lbl.Name = "akt3_lbl";
            this.akt3_lbl.Size = new System.Drawing.Size(720, 18);
            this.akt3_lbl.TabIndex = 0;
            this.akt3_lbl.Text = "Status kepegawaian Anda";
            // 
            // akt3_badge
            // 
            this.akt3_badge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.akt3_badge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.akt3_badge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.akt3_badge.Location = new System.Drawing.Point(786, 9);
            this.akt3_badge.Name = "akt3_badge";
            this.akt3_badge.Size = new System.Drawing.Size(70, 20);
            this.akt3_badge.TabIndex = 1;
            this.akt3_badge.Text = "Aktif";
            this.akt3_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDashboardKaryawan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.sidebar_panel);
            this.Controls.Add(this.content_panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDashboardKaryawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Karyawan - Sistem Penggajian Karyawan";
            this.Load += new System.EventHandler(this.FormDashboardKaryawan_Load);
            this.sidebar_panel.ResumeLayout(false);
            this.content_panel.ResumeLayout(false);
            this.dashboard_home_panel.ResumeLayout(false);
            this.card_kode.ResumeLayout(false);
            this.card_jabatan.ResumeLayout(false);
            this.card_jenis.ResumeLayout(false);
            this.card_gapok.ResumeLayout(false);
            this.akt1_panel.ResumeLayout(false);
            this.akt2_panel.ResumeLayout(false);
            this.akt3_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel accentPanel;
        private System.Windows.Forms.Panel sidebar_panel;
        private System.Windows.Forms.Label menu_title_lbl;
        private System.Windows.Forms.Button menu_dashboard_btn;
        private System.Windows.Forms.Button menu_slip_btn;
        private System.Windows.Forms.Panel divider_panel;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel content_panel;
        private System.Windows.Forms.Panel dashboard_home_panel;
        private System.Windows.Forms.Label sambut_lbl;
        private System.Windows.Forms.Label tanggal_lbl;
        private System.Windows.Forms.Panel card_kode;
        private System.Windows.Forms.Label stat_kode_lbl;
        private System.Windows.Forms.Label statlbl_kode;
        private System.Windows.Forms.Panel card_jabatan;
        private System.Windows.Forms.Label stat_jabatan_lbl;
        private System.Windows.Forms.Label statlbl_jabatan;
        private System.Windows.Forms.Panel card_jenis;
        private System.Windows.Forms.Label stat_jenis_lbl;
        private System.Windows.Forms.Label statlbl_jenis;
        private System.Windows.Forms.Panel card_gapok;
        private System.Windows.Forms.Label stat_gapok_lbl;
        private System.Windows.Forms.Label statlbl_gapok;
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