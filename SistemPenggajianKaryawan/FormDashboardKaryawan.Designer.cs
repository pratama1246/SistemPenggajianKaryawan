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
            this.menu_absensi_btn = new System.Windows.Forms.Button();
            this.menu_slip_btn = new System.Windows.Forms.Button();
            this.menu_rekap_btn = new System.Windows.Forms.Button();
            this.menu_password_btn = new System.Windows.Forms.Button();
            this.divider_panel = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.content_panel = new System.Windows.Forms.Panel();
            this.dashboard_home_panel = new System.Windows.Forms.Panel();
            this.sambut_lbl = new System.Windows.Forms.Label();
            this.tanggal_lbl = new System.Windows.Forms.Label();
            this.profile_panel = new System.Windows.Forms.Panel();
            this.avatar_lbl = new System.Windows.Forms.Label();
            this.profile_nama_lbl = new System.Windows.Forms.Label();
            this.profile_job_lbl = new System.Windows.Forms.Label();
            this.card_hadir = new System.Windows.Forms.Panel();
            this.stat_hadir_lbl = new System.Windows.Forms.Label();
            this.statlbl_hadir = new System.Windows.Forms.Label();
            this.card_alpha = new System.Windows.Forms.Panel();
            this.stat_alpha_lbl = new System.Windows.Forms.Label();
            this.statlbl_alpha = new System.Windows.Forms.Label();
            this.card_gajibulan = new System.Windows.Forms.Panel();
            this.stat_gajibulan_lbl = new System.Windows.Forms.Label();
            this.statlbl_gajibulan = new System.Windows.Forms.Label();
            this.slip_terbaru_lbl = new System.Windows.Forms.Label();
            this.slip1_panel = new System.Windows.Forms.Panel();
            this.slip1_title = new System.Windows.Forms.Label();
            this.slip1_view_btn = new System.Windows.Forms.Button();
            this.slip2_panel = new System.Windows.Forms.Panel();
            this.slip2_title = new System.Windows.Forms.Label();
            this.slip2_view_btn = new System.Windows.Forms.Button();
            this.sidebar_panel.SuspendLayout();
            this.content_panel.SuspendLayout();
            this.dashboard_home_panel.SuspendLayout();
            this.profile_panel.SuspendLayout();
            this.card_hadir.SuspendLayout();
            this.card_alpha.SuspendLayout();
            this.card_gajibulan.SuspendLayout();
            this.slip1_panel.SuspendLayout();
            this.slip2_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // accentPanel
            // 
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.accentPanel.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.sidebar_panel.Controls.Add(this.menu_absensi_btn);
            this.sidebar_panel.Controls.Add(this.menu_slip_btn);
            this.sidebar_panel.Controls.Add(this.menu_rekap_btn);
            this.sidebar_panel.Controls.Add(this.menu_password_btn);
            this.sidebar_panel.Controls.Add(this.divider_panel);
            this.sidebar_panel.Controls.Add(this.logout_btn);
            this.sidebar_panel.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.menu_title_lbl.Text = "MENU";
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
            // menu_absensi_btn
            // 
            this.menu_absensi_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_absensi_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_absensi_btn.FlatAppearance.BorderSize = 0;
            this.menu_absensi_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.menu_absensi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_absensi_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_absensi_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.menu_absensi_btn.Location = new System.Drawing.Point(0, 80);
            this.menu_absensi_btn.Name = "menu_absensi_btn";
            this.menu_absensi_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_absensi_btn.TabIndex = 2;
            this.menu_absensi_btn.Text = "  Absensi";
            this.menu_absensi_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_absensi_btn.UseVisualStyleBackColor = true;
            this.menu_absensi_btn.Click += new System.EventHandler(this.menu_absensi_btn_Click);
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
            this.menu_slip_btn.Location = new System.Drawing.Point(0, 116);
            this.menu_slip_btn.Name = "menu_slip_btn";
            this.menu_slip_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_slip_btn.TabIndex = 3;
            this.menu_slip_btn.Text = "  Slip Gaji";
            this.menu_slip_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_slip_btn.UseVisualStyleBackColor = true;
            this.menu_slip_btn.Click += new System.EventHandler(this.menu_slip_btn_Click);
            // 
            // menu_rekap_btn
            // 
            this.menu_rekap_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_rekap_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_rekap_btn.FlatAppearance.BorderSize = 0;
            this.menu_rekap_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.menu_rekap_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_rekap_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_rekap_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.menu_rekap_btn.Location = new System.Drawing.Point(0, 152);
            this.menu_rekap_btn.Name = "menu_rekap_btn";
            this.menu_rekap_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_rekap_btn.TabIndex = 4;
            this.menu_rekap_btn.Text = "  Rekap Absensi";
            this.menu_rekap_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_rekap_btn.UseVisualStyleBackColor = true;
            this.menu_rekap_btn.Click += new System.EventHandler(this.menu_rekap_btn_Click);
            // 
            // menu_password_btn
            // 
            this.menu_password_btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_password_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_password_btn.FlatAppearance.BorderSize = 0;
            this.menu_password_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.menu_password_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_password_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menu_password_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.menu_password_btn.Location = new System.Drawing.Point(0, 188);
            this.menu_password_btn.Name = "menu_password_btn";
            this.menu_password_btn.Size = new System.Drawing.Size(180, 34);
            this.menu_password_btn.TabIndex = 5;
            this.menu_password_btn.Text = "  Ganti Password";
            this.menu_password_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_password_btn.UseVisualStyleBackColor = true;
            this.menu_password_btn.Click += new System.EventHandler(this.menu_password_btn_Click);
            // 
            // divider_panel
            // 
            this.divider_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.divider_panel.Location = new System.Drawing.Point(10, 236);
            this.divider_panel.Name = "divider_panel";
            this.divider_panel.Size = new System.Drawing.Size(160, 1);
            this.divider_panel.TabIndex = 6;
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
            this.logout_btn.Location = new System.Drawing.Point(0, 248);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(180, 34);
            this.logout_btn.TabIndex = 7;
            this.logout_btn.Text = "  Logout";
            this.logout_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // content_panel
            // 
            this.content_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.content_panel.Controls.Add(this.dashboard_home_panel);
            this.content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.dashboard_home_panel.Controls.Add(this.profile_panel);
            this.dashboard_home_panel.Controls.Add(this.card_hadir);
            this.dashboard_home_panel.Controls.Add(this.card_alpha);
            this.dashboard_home_panel.Controls.Add(this.card_gajibulan);
            this.dashboard_home_panel.Controls.Add(this.slip_terbaru_lbl);
            this.dashboard_home_panel.Controls.Add(this.slip1_panel);
            this.dashboard_home_panel.Controls.Add(this.slip2_panel);
            this.dashboard_home_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard_home_panel.Location = new System.Drawing.Point(0, 0);
            this.dashboard_home_panel.Name = "dashboard_home_panel";
            this.dashboard_home_panel.Size = new System.Drawing.Size(920, 636);
            this.dashboard_home_panel.TabIndex = 0;
            // 
            // sambut_lbl
            // 
            this.sambut_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tanggal_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tanggal_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tanggal_lbl.Location = new System.Drawing.Point(24, 56);
            this.tanggal_lbl.Name = "tanggal_lbl";
            this.tanggal_lbl.Size = new System.Drawing.Size(860, 20);
            this.tanggal_lbl.TabIndex = 1;
            // 
            // profile_panel
            // 
            this.profile_panel.BackColor = System.Drawing.Color.White;
            this.profile_panel.Controls.Add(this.avatar_lbl);
            this.profile_panel.Controls.Add(this.profile_nama_lbl);
            this.profile_panel.Controls.Add(this.profile_job_lbl);
            this.profile_panel.Location = new System.Drawing.Point(30, 90);
            this.profile_panel.Name = "profile_panel";
            this.profile_panel.Size = new System.Drawing.Size(300, 110);
            this.profile_panel.TabIndex = 2;
            // 
            // avatar_lbl
            // 
            this.avatar_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.avatar_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.avatar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.avatar_lbl.Location = new System.Drawing.Point(15, 25);
            this.avatar_lbl.Name = "avatar_lbl";
            this.avatar_lbl.Size = new System.Drawing.Size(60, 60);
            this.avatar_lbl.TabIndex = 0;
            this.avatar_lbl.Text = "AH";
            this.avatar_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.avatar_lbl.Paint += new System.Windows.Forms.PaintEventHandler(this.avatar_lbl_Paint);
            // 
            // profile_nama_lbl
            // 
            this.profile_nama_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.profile_nama_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.profile_nama_lbl.Location = new System.Drawing.Point(90, 30);
            this.profile_nama_lbl.Name = "profile_nama_lbl";
            this.profile_nama_lbl.Size = new System.Drawing.Size(200, 24);
            this.profile_nama_lbl.TabIndex = 1;
            this.profile_nama_lbl.Text = "Ahmad Hidayat";
            // 
            // profile_job_lbl
            // 
            this.profile_job_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.profile_job_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.profile_job_lbl.Location = new System.Drawing.Point(90, 58);
            this.profile_job_lbl.Name = "profile_job_lbl";
            this.profile_job_lbl.Size = new System.Drawing.Size(200, 20);
            this.profile_job_lbl.TabIndex = 2;
            this.profile_job_lbl.Text = "Karyawan Tetap · Staff IT";
            // 
            // card_hadir
            // 
            this.card_hadir.BackColor = System.Drawing.Color.White;
            this.card_hadir.Controls.Add(this.stat_hadir_lbl);
            this.card_hadir.Controls.Add(this.statlbl_hadir);
            this.card_hadir.Location = new System.Drawing.Point(350, 90);
            this.card_hadir.Name = "card_hadir";
            this.card_hadir.Size = new System.Drawing.Size(170, 110);
            this.card_hadir.TabIndex = 3;
            // 
            // stat_hadir_lbl
            // 
            this.stat_hadir_lbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.stat_hadir_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.stat_hadir_lbl.Location = new System.Drawing.Point(15, 15);
            this.stat_hadir_lbl.Name = "stat_hadir_lbl";
            this.stat_hadir_lbl.Size = new System.Drawing.Size(140, 38);
            this.stat_hadir_lbl.TabIndex = 0;
            this.stat_hadir_lbl.Text = "22";
            // 
            // statlbl_hadir
            // 
            this.statlbl_hadir.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_hadir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_hadir.Location = new System.Drawing.Point(15, 65);
            this.statlbl_hadir.Name = "statlbl_hadir";
            this.statlbl_hadir.Size = new System.Drawing.Size(140, 18);
            this.statlbl_hadir.TabIndex = 1;
            this.statlbl_hadir.Text = "Hari hadir";
            // 
            // card_alpha
            // 
            this.card_alpha.BackColor = System.Drawing.Color.White;
            this.card_alpha.Controls.Add(this.stat_alpha_lbl);
            this.card_alpha.Controls.Add(this.statlbl_alpha);
            this.card_alpha.Location = new System.Drawing.Point(540, 90);
            this.card_alpha.Name = "card_alpha";
            this.card_alpha.Size = new System.Drawing.Size(170, 110);
            this.card_alpha.TabIndex = 4;
            // 
            // stat_alpha_lbl
            // 
            this.stat_alpha_lbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.stat_alpha_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.stat_alpha_lbl.Location = new System.Drawing.Point(15, 15);
            this.stat_alpha_lbl.Name = "stat_alpha_lbl";
            this.stat_alpha_lbl.Size = new System.Drawing.Size(140, 38);
            this.stat_alpha_lbl.TabIndex = 0;
            this.stat_alpha_lbl.Text = "0";
            // 
            // statlbl_alpha
            // 
            this.statlbl_alpha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_alpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_alpha.Location = new System.Drawing.Point(15, 65);
            this.statlbl_alpha.Name = "statlbl_alpha";
            this.statlbl_alpha.Size = new System.Drawing.Size(140, 18);
            this.statlbl_alpha.TabIndex = 1;
            this.statlbl_alpha.Text = "Alpha";
            // 
            // card_gajibulan
            // 
            this.card_gajibulan.BackColor = System.Drawing.Color.White;
            this.card_gajibulan.Controls.Add(this.stat_gajibulan_lbl);
            this.card_gajibulan.Controls.Add(this.statlbl_gajibulan);
            this.card_gajibulan.Location = new System.Drawing.Point(730, 90);
            this.card_gajibulan.Name = "card_gajibulan";
            this.card_gajibulan.Size = new System.Drawing.Size(170, 110);
            this.card_gajibulan.TabIndex = 5;
            // 
            // stat_gajibulan_lbl
            // 
            this.stat_gajibulan_lbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.stat_gajibulan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.stat_gajibulan_lbl.Location = new System.Drawing.Point(15, 15);
            this.stat_gajibulan_lbl.Name = "stat_gajibulan_lbl";
            this.stat_gajibulan_lbl.Size = new System.Drawing.Size(140, 38);
            this.stat_gajibulan_lbl.TabIndex = 0;
            this.stat_gajibulan_lbl.Text = "4,2jt";
            // 
            // statlbl_gajibulan
            // 
            this.statlbl_gajibulan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statlbl_gajibulan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.statlbl_gajibulan.Location = new System.Drawing.Point(15, 65);
            this.statlbl_gajibulan.Name = "statlbl_gajibulan";
            this.statlbl_gajibulan.Size = new System.Drawing.Size(140, 18);
            this.statlbl_gajibulan.TabIndex = 1;
            this.statlbl_gajibulan.Text = "Gaji bulan ini";
            // 
            // slip_terbaru_lbl
            // 
            this.slip_terbaru_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slip_terbaru_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.slip_terbaru_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.slip_terbaru_lbl.Location = new System.Drawing.Point(30, 230);
            this.slip_terbaru_lbl.Name = "slip_terbaru_lbl";
            this.slip_terbaru_lbl.Size = new System.Drawing.Size(860, 22);
            this.slip_terbaru_lbl.TabIndex = 6;
            this.slip_terbaru_lbl.Text = "Slip gaji terbaru";
            // 
            // slip1_panel
            // 
            this.slip1_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slip1_panel.BackColor = System.Drawing.Color.White;
            this.slip1_panel.Controls.Add(this.slip1_title);
            this.slip1_panel.Controls.Add(this.slip1_view_btn);
            this.slip1_panel.Location = new System.Drawing.Point(30, 265);
            this.slip1_panel.Name = "slip1_panel";
            this.slip1_panel.Size = new System.Drawing.Size(870, 45);
            this.slip1_panel.TabIndex = 7;
            // 
            // slip1_title
            // 
            this.slip1_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slip1_title.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.slip1_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.slip1_title.Location = new System.Drawing.Point(15, 13);
            this.slip1_title.Name = "slip1_title";
            this.slip1_title.Size = new System.Drawing.Size(600, 20);
            this.slip1_title.TabIndex = 0;
            this.slip1_title.Text = "Slip Gaji Mei 2026";
            // 
            // slip1_view_btn
            // 
            this.slip1_view_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slip1_view_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.slip1_view_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slip1_view_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.slip1_view_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slip1_view_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.slip1_view_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.slip1_view_btn.Location = new System.Drawing.Point(775, 8);
            this.slip1_view_btn.Name = "slip1_view_btn";
            this.slip1_view_btn.Size = new System.Drawing.Size(80, 28);
            this.slip1_view_btn.TabIndex = 1;
            this.slip1_view_btn.Text = "Lihat";
            this.slip1_view_btn.UseVisualStyleBackColor = false;
            this.slip1_view_btn.Click += new System.EventHandler(this.slip1_view_btn_Click);
            // 
            // slip2_panel
            // 
            this.slip2_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slip2_panel.BackColor = System.Drawing.Color.White;
            this.slip2_panel.Controls.Add(this.slip2_title);
            this.slip2_panel.Controls.Add(this.slip2_view_btn);
            this.slip2_panel.Location = new System.Drawing.Point(30, 320);
            this.slip2_panel.Name = "slip2_panel";
            this.slip2_panel.Size = new System.Drawing.Size(870, 45);
            this.slip2_panel.TabIndex = 8;
            // 
            // slip2_title
            // 
            this.slip2_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slip2_title.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.slip2_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.slip2_title.Location = new System.Drawing.Point(15, 13);
            this.slip2_title.Name = "slip2_title";
            this.slip2_title.Size = new System.Drawing.Size(600, 20);
            this.slip2_title.TabIndex = 0;
            this.slip2_title.Text = "Slip Gaji April 2026";
            // 
            // slip2_view_btn
            // 
            this.slip2_view_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slip2_view_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.slip2_view_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slip2_view_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.slip2_view_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slip2_view_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.slip2_view_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.slip2_view_btn.Location = new System.Drawing.Point(775, 8);
            this.slip2_view_btn.Name = "slip2_view_btn";
            this.slip2_view_btn.Size = new System.Drawing.Size(80, 28);
            this.slip2_view_btn.TabIndex = 1;
            this.slip2_view_btn.Text = "Lihat";
            this.slip2_view_btn.UseVisualStyleBackColor = false;
            this.slip2_view_btn.Click += new System.EventHandler(this.slip2_view_btn_Click);
            // 
            // FormDashboardKaryawan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.content_panel);
            this.Controls.Add(this.sidebar_panel);
            this.Controls.Add(this.accentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FormDashboardKaryawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Karyawan - Sistem Penggajian Karyawan";
            this.Load += new System.EventHandler(this.FormDashboardKaryawan_Load);
            this.sidebar_panel.ResumeLayout(false);
            this.content_panel.ResumeLayout(false);
            this.dashboard_home_panel.ResumeLayout(false);
            this.profile_panel.ResumeLayout(false);
            this.card_hadir.ResumeLayout(false);
            this.card_alpha.ResumeLayout(false);
            this.card_gajibulan.ResumeLayout(false);
            this.slip1_panel.ResumeLayout(false);
            this.slip2_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel accentPanel;
        private System.Windows.Forms.Panel sidebar_panel;
        private System.Windows.Forms.Label menu_title_lbl;
        private System.Windows.Forms.Button menu_dashboard_btn;
        private System.Windows.Forms.Button menu_slip_btn;
        private System.Windows.Forms.Button menu_absensi_btn;
        private System.Windows.Forms.Button menu_rekap_btn;
        private System.Windows.Forms.Button menu_password_btn;
        private System.Windows.Forms.Panel divider_panel;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel content_panel;
        private System.Windows.Forms.Panel dashboard_home_panel;
        private System.Windows.Forms.Label sambut_lbl;
        private System.Windows.Forms.Label tanggal_lbl;
        private System.Windows.Forms.Panel profile_panel;
        private System.Windows.Forms.Label avatar_lbl;
        private System.Windows.Forms.Label profile_nama_lbl;
        private System.Windows.Forms.Label profile_job_lbl;
        private System.Windows.Forms.Panel card_hadir;
        private System.Windows.Forms.Label stat_hadir_lbl;
        private System.Windows.Forms.Label statlbl_hadir;
        private System.Windows.Forms.Panel card_alpha;
        private System.Windows.Forms.Label stat_alpha_lbl;
        private System.Windows.Forms.Label statlbl_alpha;
        private System.Windows.Forms.Panel card_gajibulan;
        private System.Windows.Forms.Label stat_gajibulan_lbl;
        private System.Windows.Forms.Label statlbl_gajibulan;
        private System.Windows.Forms.Label slip_terbaru_lbl;
        private System.Windows.Forms.Panel slip1_panel;
        private System.Windows.Forms.Label slip1_title;
        private System.Windows.Forms.Button slip1_view_btn;
        private System.Windows.Forms.Panel slip2_panel;
        private System.Windows.Forms.Label slip2_title;
        private System.Windows.Forms.Button slip2_view_btn;
    }
}