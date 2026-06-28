namespace SistemPenggajianKaryawan
{
    partial class FormAbsensi
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
            this.components = new System.ComponentModel.Container();
            this.timer_jam = new System.Windows.Forms.Timer(this.components);
            
            // Container Panels
            this.panel_karyawan_mode = new System.Windows.Forms.Panel();
            this.panel_hrd_mode = new System.Windows.Forms.Panel();

            // ─────────────────────────────────────────────────────────────────
            // KARYAWAN MODE CONTROLS (Existing)
            // ─────────────────────────────────────────────────────────────────
            this.panel_header = new System.Windows.Forms.Panel();
            this.tanggal_lbl = new System.Windows.Forms.Label();
            this.jam_lbl = new System.Windows.Forms.Label();
            this.label_masuk_config = new System.Windows.Forms.Label();
            this.label_keluar_config = new System.Windows.Forms.Label();
            this.panel_left_container = new System.Windows.Forms.Panel();
            this.recent_flow_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_scan_card = new System.Windows.Forms.Panel();
            this.info_lbl = new System.Windows.Forms.Label();
            this.absen_keluar_btn = new System.Windows.Forms.Button();
            this.absen_masuk_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.kode_txt = new System.Windows.Forms.TextBox();
            this.panel_scanner_target = new System.Windows.Forms.Panel();
            this.target_text_lbl = new System.Windows.Forms.Label();
            this.target_icon_lbl = new System.Windows.Forms.Label();
            this.scan_title_lbl = new System.Windows.Forms.Label();
            this.panel_right_container = new System.Windows.Forms.Panel();
            this.panel_log_card = new System.Windows.Forms.Panel();
            this.log_dgv = new System.Windows.Forms.DataGridView();
            this.log_title_lbl = new System.Windows.Forms.Label();
            this.panel_rekap_card = new System.Windows.Forms.Panel();

            // ─────────────────────────────────────────────────────────────────
            // HRD MODE CONTROLS (New)
            // ─────────────────────────────────────────────────────────────────
            this.hrd_panel_left = new System.Windows.Forms.Panel();
            this.hrd_inputTitle_lbl = new System.Windows.Forms.Label();
            this.hrd_tanggal_lbl = new System.Windows.Forms.Label();
            this.hrd_tanggal_dtp = new System.Windows.Forms.DateTimePicker();
            this.hrd_karyawan_lbl = new System.Windows.Forms.Label();
            this.hrd_karyawan_txt = new System.Windows.Forms.TextBox();
            this.hrd_status_lbl = new System.Windows.Forms.Label();
            this.hrd_status_cmb = new System.Windows.Forms.ComboBox();
            this.hrd_masuk_lbl = new System.Windows.Forms.Label();
            this.hrd_masuk_txt = new System.Windows.Forms.TextBox();
            this.hrd_keluar_lbl = new System.Windows.Forms.Label();
            this.hrd_keluar_txt = new System.Windows.Forms.TextBox();
            this.hrd_simpan_btn = new System.Windows.Forms.Button();
            this.hrd_batal_btn = new System.Windows.Forms.Button();
            
            this.hrd_panel_right = new System.Windows.Forms.Panel();
            this.hrd_cari_txt = new System.Windows.Forms.TextBox();
            this.hrd_stat_belum_lbl = new System.Windows.Forms.Label();
            this.hrd_log_dgv = new System.Windows.Forms.DataGridView();

            this.panel_karyawan_mode.SuspendLayout();
            this.panel_header.SuspendLayout();
            this.panel_left_container.SuspendLayout();
            this.panel_scan_card.SuspendLayout();
            this.panel_scanner_target.SuspendLayout();
            this.panel_right_container.SuspendLayout();
            this.panel_log_card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_dgv)).BeginInit();

            this.panel_hrd_mode.SuspendLayout();
            this.hrd_panel_left.SuspendLayout();
            this.hrd_panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrd_log_dgv)).BeginInit();
            
            this.SuspendLayout();

            // 
            // timer_jam
            // 
            this.timer_jam.Enabled = true;
            this.timer_jam.Interval = 1000;
            this.timer_jam.Tick += new System.EventHandler(this.timer_jam_Tick);

            // ─────────────────────────────────────────────────────────────────
            // panel_karyawan_mode
            // ─────────────────────────────────────────────────────────────────
            this.panel_karyawan_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_karyawan_mode.Controls.Add(this.panel_header);
            this.panel_karyawan_mode.Controls.Add(this.panel_left_container);
            this.panel_karyawan_mode.Controls.Add(this.panel_right_container);
            this.panel_karyawan_mode.Location = new System.Drawing.Point(0, 0);
            this.panel_karyawan_mode.Name = "panel_karyawan_mode";
            this.panel_karyawan_mode.Size = new System.Drawing.Size(920, 636);
            this.panel_karyawan_mode.TabIndex = 0;

            // 
            // panel_header
            // 
            this.panel_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_header.BackColor = System.Drawing.Color.White;
            this.panel_header.Controls.Add(this.tanggal_lbl);
            this.panel_header.Controls.Add(this.jam_lbl);
            this.panel_header.Controls.Add(this.label_masuk_config);
            this.panel_header.Controls.Add(this.label_keluar_config);
            this.panel_header.Location = new System.Drawing.Point(15, 15);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(890, 90);
            this.panel_header.TabIndex = 0;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.HeaderCard_Paint);
            // 
            // tanggal_lbl
            // 
            this.tanggal_lbl.AutoSize = true;
            this.tanggal_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.tanggal_lbl.Location = new System.Drawing.Point(20, 52);
            this.tanggal_lbl.Name = "tanggal_lbl";
            this.tanggal_lbl.Size = new System.Drawing.Size(118, 17);
            this.tanggal_lbl.TabIndex = 1;
            this.tanggal_lbl.Text = "Senin, 31 Mei 2026";
            // 
            // jam_lbl
            // 
            this.jam_lbl.AutoSize = true;
            this.jam_lbl.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.jam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.jam_lbl.Location = new System.Drawing.Point(12, 5);
            this.jam_lbl.Name = "jam_lbl";
            this.jam_lbl.Size = new System.Drawing.Size(174, 51);
            this.jam_lbl.TabIndex = 0;
            this.jam_lbl.Text = "08:47:32";
            // 
            // label_masuk_config
            // 
            this.label_masuk_config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_masuk_config.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_masuk_config.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.label_masuk_config.Location = new System.Drawing.Point(520, 20);
            this.label_masuk_config.Name = "label_masuk_config";
            this.label_masuk_config.Size = new System.Drawing.Size(350, 20);
            this.label_masuk_config.TabIndex = 2;
            this.label_masuk_config.Text = "Masuk normal";
            this.label_masuk_config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_keluar_config
            // 
            this.label_keluar_config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_keluar_config.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_keluar_config.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.label_keluar_config.Location = new System.Drawing.Point(520, 45);
            this.label_keluar_config.Name = "label_keluar_config";
            this.label_keluar_config.Size = new System.Drawing.Size(350, 20);
            this.label_keluar_config.TabIndex = 3;
            this.label_keluar_config.Text = "Keluar normal";
            this.label_keluar_config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_left_container
            // 
            this.panel_left_container.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_left_container.Controls.Add(this.recent_flow_panel);
            this.panel_left_container.Controls.Add(this.panel_scan_card);
            this.panel_left_container.Location = new System.Drawing.Point(15, 120);
            this.panel_left_container.Name = "panel_left_container";
            this.panel_left_container.Size = new System.Drawing.Size(500, 500);
            this.panel_left_container.TabIndex = 1;
            // 
            // recent_flow_panel
            // 
            this.recent_flow_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.recent_flow_panel.Location = new System.Drawing.Point(0, 330);
            this.recent_flow_panel.Name = "recent_flow_panel";
            this.recent_flow_panel.Size = new System.Drawing.Size(500, 170);
            this.recent_flow_panel.TabIndex = 1;
            this.recent_flow_panel.WrapContents = false;
            // 
            // panel_scan_card
            // 
            this.panel_scan_card.BackColor = System.Drawing.Color.White;
            this.panel_scan_card.Controls.Add(this.info_lbl);
            this.panel_scan_card.Controls.Add(this.absen_keluar_btn);
            this.panel_scan_card.Controls.Add(this.absen_masuk_btn);
            this.panel_scan_card.Controls.Add(this.clear_btn);
            this.panel_scan_card.Controls.Add(this.kode_txt);
            this.panel_scan_card.Controls.Add(this.panel_scanner_target);
            this.panel_scan_card.Controls.Add(this.scan_title_lbl);
            this.panel_scan_card.Location = new System.Drawing.Point(0, 0);
            this.panel_scan_card.Name = "panel_scan_card";
            this.panel_scan_card.Size = new System.Drawing.Size(500, 315);
            this.panel_scan_card.TabIndex = 0;
            this.panel_scan_card.Paint += new System.Windows.Forms.PaintEventHandler(this.ScanCard_Paint);
            // 
            // info_lbl
            // 
            this.info_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.info_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.info_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.info_lbl.Location = new System.Drawing.Point(20, 242);
            this.info_lbl.Name = "info_lbl";
            this.info_lbl.Size = new System.Drawing.Size(460, 60);
            this.info_lbl.TabIndex = 6;
            this.info_lbl.Text = "Hasil scan absensi akan tampil di sini";
            this.info_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // absen_keluar_btn
            // 
            this.absen_keluar_btn.BackColor = System.Drawing.Color.White;
            this.absen_keluar_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.absen_keluar_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.absen_keluar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.absen_keluar_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.absen_keluar_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.absen_keluar_btn.Location = new System.Drawing.Point(255, 195);
            this.absen_keluar_btn.Name = "absen_keluar_btn";
            this.absen_keluar_btn.Size = new System.Drawing.Size(225, 38);
            this.absen_keluar_btn.TabIndex = 5;
            this.absen_keluar_btn.Text = "Absen Keluar";
            this.absen_keluar_btn.UseVisualStyleBackColor = false;
            this.absen_keluar_btn.Click += new System.EventHandler(this.absen_keluar_btn_Click);
            // 
            // absen_masuk_btn
            // 
            this.absen_masuk_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.absen_masuk_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.absen_masuk_btn.FlatAppearance.BorderSize = 0;
            this.absen_masuk_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.absen_masuk_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.absen_masuk_btn.ForeColor = System.Drawing.Color.White;
            this.absen_masuk_btn.Location = new System.Drawing.Point(20, 195);
            this.absen_masuk_btn.Name = "absen_masuk_btn";
            this.absen_masuk_btn.Size = new System.Drawing.Size(225, 38);
            this.absen_masuk_btn.TabIndex = 4;
            this.absen_masuk_btn.Text = "Absen Masuk";
            this.absen_masuk_btn.UseVisualStyleBackColor = false;
            this.absen_masuk_btn.Click += new System.EventHandler(this.absen_masuk_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.White;
            this.clear_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clear_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.clear_btn.Location = new System.Drawing.Point(434, 150);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(46, 36);
            this.clear_btn.TabIndex = 3;
            this.clear_btn.Text = "X";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // kode_txt
            // 
            this.kode_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.kode_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kode_txt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.kode_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.kode_txt.Location = new System.Drawing.Point(20, 150);
            this.kode_txt.Name = "kode_txt";
            this.kode_txt.Size = new System.Drawing.Size(408, 39);
            this.kode_txt.TabIndex = 2;
            this.kode_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kode_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kode_txt_KeyDown);
            // 
            // panel_scanner_target
            // 
            this.panel_scanner_target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panel_scanner_target.Controls.Add(this.target_text_lbl);
            this.panel_scanner_target.Controls.Add(this.target_icon_lbl);
            this.panel_scanner_target.Location = new System.Drawing.Point(20, 45);
            this.panel_scanner_target.Name = "panel_scanner_target";
            this.panel_scanner_target.Size = new System.Drawing.Size(460, 95);
            this.panel_scanner_target.TabIndex = 1;
            this.panel_scanner_target.Paint += new System.Windows.Forms.PaintEventHandler(this.ScannerTarget_Paint);
            // 
            // target_text_lbl
            // 
            this.target_text_lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.target_text_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.target_text_lbl.Location = new System.Drawing.Point(20, 52);
            this.target_text_lbl.Name = "target_text_lbl";
            this.target_text_lbl.Size = new System.Drawing.Size(420, 36);
            this.target_text_lbl.TabIndex = 1;
            this.target_text_lbl.Text = "Arahkan scanner ke barcode kartu karyawan\r\natau ketik kode manual lalu tekan Ente" +
    "r";
            this.target_text_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // target_icon_lbl
            // 
            this.target_icon_lbl.Font = new System.Drawing.Font("Segoe MDL2 Assets", 24F);
            this.target_icon_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.target_icon_lbl.Location = new System.Drawing.Point(3, 8);
            this.target_icon_lbl.Name = "target_icon_lbl";
            this.target_icon_lbl.Size = new System.Drawing.Size(454, 38);
            this.target_icon_lbl.TabIndex = 0;
            this.target_icon_lbl.Text = "";
            this.target_icon_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scan_title_lbl
            // 
            this.scan_title_lbl.AutoSize = true;
            this.scan_title_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.scan_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.scan_title_lbl.Location = new System.Drawing.Point(20, 15);
            this.scan_title_lbl.Name = "scan_title_lbl";
            this.scan_title_lbl.Size = new System.Drawing.Size(137, 17);
            this.scan_title_lbl.TabIndex = 0;
            this.scan_title_lbl.Text = "Scan Kartu Karyawan";
            // 
            // panel_right_container
            // 
            this.panel_right_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_right_container.Controls.Add(this.panel_log_card);
            this.panel_right_container.Controls.Add(this.panel_rekap_card);
            this.panel_right_container.Location = new System.Drawing.Point(530, 120);
            this.panel_right_container.Name = "panel_right_container";
            this.panel_right_container.Size = new System.Drawing.Size(375, 500);
            this.panel_right_container.TabIndex = 2;
            // 
            // panel_log_card
            // 
            this.panel_log_card.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_log_card.BackColor = System.Drawing.Color.White;
            this.panel_log_card.Controls.Add(this.log_dgv);
            this.panel_log_card.Controls.Add(this.log_title_lbl);
            this.panel_log_card.Location = new System.Drawing.Point(0, 185);
            this.panel_log_card.Name = "panel_log_card";
            this.panel_log_card.Size = new System.Drawing.Size(375, 315);
            this.panel_log_card.TabIndex = 1;
            this.panel_log_card.Paint += new System.Windows.Forms.PaintEventHandler(this.LogCard_Paint);
            // 
            // log_dgv
            // 
            this.log_dgv.AllowUserToAddRows = false;
            this.log_dgv.AllowUserToDeleteRows = false;
            this.log_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_dgv.BackgroundColor = System.Drawing.Color.White;
            this.log_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.log_dgv.Location = new System.Drawing.Point(15, 45);
            this.log_dgv.Name = "log_dgv";
            this.log_dgv.ReadOnly = true;
            this.log_dgv.Size = new System.Drawing.Size(345, 255);
            this.log_dgv.TabIndex = 1;
            // 
            // log_title_lbl
            // 
            this.log_title_lbl.AutoSize = true;
            this.log_title_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.log_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.log_title_lbl.Location = new System.Drawing.Point(20, 15);
            this.log_title_lbl.Name = "log_title_lbl";
            this.log_title_lbl.Size = new System.Drawing.Size(82, 17);
            this.log_title_lbl.TabIndex = 0;
            this.log_title_lbl.Text = "Log Terbaru";
            // 
            // panel_rekap_card
            // 
            this.panel_rekap_card.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_rekap_card.BackColor = System.Drawing.Color.White;
            this.panel_rekap_card.Location = new System.Drawing.Point(0, 0);
            this.panel_rekap_card.Name = "panel_rekap_card";
            this.panel_rekap_card.Size = new System.Drawing.Size(375, 170);
            this.panel_rekap_card.TabIndex = 0;
            this.panel_rekap_card.Paint += new System.Windows.Forms.PaintEventHandler(this.RekapCard_Paint);

            // ─────────────────────────────────────────────────────────────────
            // panel_hrd_mode
            // ─────────────────────────────────────────────────────────────────
            this.panel_hrd_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_hrd_mode.Controls.Add(this.hrd_panel_right);
            this.panel_hrd_mode.Controls.Add(this.hrd_panel_left);
            this.panel_hrd_mode.Location = new System.Drawing.Point(0, 0);
            this.panel_hrd_mode.Name = "panel_hrd_mode";
            this.panel_hrd_mode.Size = new System.Drawing.Size(920, 636);
            this.panel_hrd_mode.TabIndex = 1;
            this.panel_hrd_mode.Visible = false;

            // 
            // hrd_panel_left
            // 
            this.hrd_panel_left.BackColor = System.Drawing.Color.White;
            this.hrd_panel_left.Controls.Add(this.hrd_inputTitle_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_tanggal_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_tanggal_dtp);
            this.hrd_panel_left.Controls.Add(this.hrd_karyawan_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_karyawan_txt);
            this.hrd_panel_left.Controls.Add(this.hrd_status_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_status_cmb);
            this.hrd_panel_left.Controls.Add(this.hrd_masuk_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_masuk_txt);
            this.hrd_panel_left.Controls.Add(this.hrd_keluar_lbl);
            this.hrd_panel_left.Controls.Add(this.hrd_keluar_txt);
            this.hrd_panel_left.Controls.Add(this.hrd_simpan_btn);
            this.hrd_panel_left.Controls.Add(this.hrd_batal_btn);
            this.hrd_panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.hrd_panel_left.Location = new System.Drawing.Point(0, 0);
            this.hrd_panel_left.Name = "hrd_panel_left";
            this.hrd_panel_left.Size = new System.Drawing.Size(320, 636);
            this.hrd_panel_left.TabIndex = 0;
            // 
            // hrd_inputTitle_lbl
            // 
            this.hrd_inputTitle_lbl.AutoSize = true;
            this.hrd_inputTitle_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.hrd_inputTitle_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.hrd_inputTitle_lbl.Location = new System.Drawing.Point(20, 20);
            this.hrd_inputTitle_lbl.Name = "hrd_inputTitle_lbl";
            this.hrd_inputTitle_lbl.Size = new System.Drawing.Size(135, 21);
            this.hrd_inputTitle_lbl.TabIndex = 0;
            this.hrd_inputTitle_lbl.Text = "FILTER & KOREKSI";
            // 
            // hrd_tanggal_lbl
            // 
            this.hrd_tanggal_lbl.AutoSize = true;
            this.hrd_tanggal_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hrd_tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_tanggal_lbl.Location = new System.Drawing.Point(20, 52);
            this.hrd_tanggal_lbl.Name = "hrd_tanggal_lbl";
            this.hrd_tanggal_lbl.Size = new System.Drawing.Size(61, 20);
            this.hrd_tanggal_lbl.TabIndex = 1;
            this.hrd_tanggal_lbl.Text = "Tanggal";
            // 
            // hrd_tanggal_dtp
            // 
            this.hrd_tanggal_dtp.CustomFormat = "dd MMMM yyyy";
            this.hrd_tanggal_dtp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_tanggal_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hrd_tanggal_dtp.Location = new System.Drawing.Point(23, 72);
            this.hrd_tanggal_dtp.Name = "hrd_tanggal_dtp";
            this.hrd_tanggal_dtp.Size = new System.Drawing.Size(277, 30);
            this.hrd_tanggal_dtp.TabIndex = 2;
            this.hrd_tanggal_dtp.ValueChanged += new System.EventHandler(this.hrd_tanggal_dtp_ValueChanged);
            // 
            // hrd_karyawan_lbl
            // 
            this.hrd_karyawan_lbl.AutoSize = true;
            this.hrd_karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hrd_karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_karyawan_lbl.Location = new System.Drawing.Point(20, 112);
            this.hrd_karyawan_lbl.Name = "hrd_karyawan_lbl";
            this.hrd_karyawan_lbl.Size = new System.Drawing.Size(74, 20);
            this.hrd_karyawan_lbl.TabIndex = 3;
            this.hrd_karyawan_lbl.Text = "Karyawan";
            // 
            // hrd_karyawan_txt
            // 
            this.hrd_karyawan_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.hrd_karyawan_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hrd_karyawan_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_karyawan_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.hrd_karyawan_txt.Location = new System.Drawing.Point(23, 132);
            this.hrd_karyawan_txt.Name = "hrd_karyawan_txt";
            this.hrd_karyawan_txt.ReadOnly = true;
            this.hrd_karyawan_txt.Size = new System.Drawing.Size(277, 30);
            this.hrd_karyawan_txt.TabIndex = 4;
            // 
            // hrd_status_lbl
            // 
            this.hrd_status_lbl.AutoSize = true;
            this.hrd_status_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hrd_status_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_status_lbl.Location = new System.Drawing.Point(20, 172);
            this.hrd_status_lbl.Name = "hrd_status_lbl";
            this.hrd_status_lbl.Size = new System.Drawing.Size(49, 20);
            this.hrd_status_lbl.TabIndex = 5;
            this.hrd_status_lbl.Text = "Status";
            // 
            // hrd_status_cmb
            // 
            this.hrd_status_cmb.BackColor = System.Drawing.Color.White;
            this.hrd_status_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hrd_status_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hrd_status_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_status_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.hrd_status_cmb.FormattingEnabled = true;
            this.hrd_status_cmb.Items.AddRange(new object[] {
            "Hadir",
            "Izin",
            "Sakit",
            "Alpha"});
            this.hrd_status_cmb.Location = new System.Drawing.Point(23, 192);
            this.hrd_status_cmb.Name = "hrd_status_cmb";
            this.hrd_status_cmb.Size = new System.Drawing.Size(277, 31);
            this.hrd_status_cmb.TabIndex = 6;
            // 
            // hrd_masuk_lbl
            // 
            this.hrd_masuk_lbl.AutoSize = true;
            this.hrd_masuk_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hrd_masuk_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_masuk_lbl.Location = new System.Drawing.Point(20, 232);
            this.hrd_masuk_lbl.Name = "hrd_masuk_lbl";
            this.hrd_masuk_lbl.Size = new System.Drawing.Size(78, 20);
            this.hrd_masuk_lbl.TabIndex = 7;
            this.hrd_masuk_lbl.Text = "Jam Masuk";
            // 
            // hrd_masuk_txt
            // 
            this.hrd_masuk_txt.BackColor = System.Drawing.Color.White;
            this.hrd_masuk_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hrd_masuk_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_masuk_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.hrd_masuk_txt.Location = new System.Drawing.Point(23, 252);
            this.hrd_masuk_txt.Name = "hrd_masuk_txt";
            this.hrd_masuk_txt.Size = new System.Drawing.Size(277, 30);
            this.hrd_masuk_txt.TabIndex = 8;
            // 
            // hrd_keluar_lbl
            // 
            this.hrd_keluar_lbl.AutoSize = true;
            this.hrd_keluar_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hrd_keluar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_keluar_lbl.Location = new System.Drawing.Point(20, 292);
            this.hrd_keluar_lbl.Name = "hrd_keluar_lbl";
            this.hrd_keluar_lbl.Size = new System.Drawing.Size(81, 20);
            this.hrd_keluar_lbl.TabIndex = 9;
            this.hrd_keluar_lbl.Text = "Jam Keluar";
            // 
            // hrd_keluar_txt
            // 
            this.hrd_keluar_txt.BackColor = System.Drawing.Color.White;
            this.hrd_keluar_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hrd_keluar_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_keluar_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.hrd_keluar_txt.Location = new System.Drawing.Point(23, 312);
            this.hrd_keluar_txt.Name = "hrd_keluar_txt";
            this.hrd_keluar_txt.Size = new System.Drawing.Size(277, 30);
            this.hrd_keluar_txt.TabIndex = 10;
            // 
            // hrd_simpan_btn
            // 
            this.hrd_simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.hrd_simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hrd_simpan_btn.FlatAppearance.BorderSize = 0;
            this.hrd_simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hrd_simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.hrd_simpan_btn.ForeColor = System.Drawing.Color.White;
            this.hrd_simpan_btn.Location = new System.Drawing.Point(23, 440);
            this.hrd_simpan_btn.Name = "hrd_simpan_btn";
            this.hrd_simpan_btn.Size = new System.Drawing.Size(125, 32);
            this.hrd_simpan_btn.TabIndex = 11;
            this.hrd_simpan_btn.Text = "💾 Simpan";
            this.hrd_simpan_btn.UseVisualStyleBackColor = false;
            this.hrd_simpan_btn.Click += new System.EventHandler(this.hrd_simpan_btn_Click);
            // 
            // hrd_batal_btn
            // 
            this.hrd_batal_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.hrd_batal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hrd_batal_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.hrd_batal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hrd_batal_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.hrd_batal_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.hrd_batal_btn.Location = new System.Drawing.Point(175, 440);
            this.hrd_batal_btn.Name = "hrd_batal_btn";
            this.hrd_batal_btn.Size = new System.Drawing.Size(125, 32);
            this.hrd_batal_btn.TabIndex = 12;
            this.hrd_batal_btn.Text = "Batal";
            this.hrd_batal_btn.UseVisualStyleBackColor = false;
            this.hrd_batal_btn.Click += new System.EventHandler(this.hrd_batal_btn_Click);
            // 
            // hrd_panel_right
            // 
            this.hrd_panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.hrd_panel_right.Controls.Add(this.hrd_cari_txt);
            this.hrd_panel_right.Controls.Add(this.hrd_stat_belum_lbl);
            this.hrd_panel_right.Controls.Add(this.hrd_log_dgv);
            this.hrd_panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrd_panel_right.Location = new System.Drawing.Point(320, 0);
            this.hrd_panel_right.Name = "hrd_panel_right";
            this.hrd_panel_right.Size = new System.Drawing.Size(600, 636);
            this.hrd_panel_right.TabIndex = 1;
            // 
            // hrd_cari_txt
            // 
            this.hrd_cari_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hrd_cari_txt.BackColor = System.Drawing.Color.White;
            this.hrd_cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hrd_cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hrd_cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.hrd_cari_txt.Location = new System.Drawing.Point(20, 20);
            this.hrd_cari_txt.Name = "hrd_cari_txt";
            this.hrd_cari_txt.Size = new System.Drawing.Size(390, 30);
            this.hrd_cari_txt.TabIndex = 0;
            this.hrd_cari_txt.Text = "🔍 Cari karyawan...";
            this.hrd_cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hrd_cari_txt_MouseClick);
            this.hrd_cari_txt.TextChanged += new System.EventHandler(this.hrd_cari_txt_TextChanged);
            this.hrd_cari_txt.Leave += new System.EventHandler(this.hrd_cari_txt_Leave);
            // 
            // hrd_stat_belum_lbl
            // 
            this.hrd_stat_belum_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hrd_stat_belum_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.hrd_stat_belum_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.hrd_stat_belum_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.hrd_stat_belum_lbl.Location = new System.Drawing.Point(420, 20);
            this.hrd_stat_belum_lbl.Name = "hrd_stat_belum_lbl";
            this.hrd_stat_belum_lbl.Size = new System.Drawing.Size(140, 30);
            this.hrd_stat_belum_lbl.TabIndex = 1;
            this.hrd_stat_belum_lbl.Text = "Belum absen: 0";
            this.hrd_stat_belum_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hrd_log_dgv
            // 
            this.hrd_log_dgv.AllowUserToAddRows = false;
            this.hrd_log_dgv.AllowUserToDeleteRows = false;
            this.hrd_log_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hrd_log_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hrd_log_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.hrd_log_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hrd_log_dgv.ColumnHeadersHeight = 34;
            this.hrd_log_dgv.EnableHeadersVisualStyles = false;
            this.hrd_log_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.hrd_log_dgv.Location = new System.Drawing.Point(20, 65);
            this.hrd_log_dgv.MultiSelect = false;
            this.hrd_log_dgv.Name = "hrd_log_dgv";
            this.hrd_log_dgv.ReadOnly = true;
            this.hrd_log_dgv.RowHeadersVisible = false;
            this.hrd_log_dgv.RowHeadersWidth = 51;
            this.hrd_log_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hrd_log_dgv.Size = new System.Drawing.Size(540, 435);
            this.hrd_log_dgv.TabIndex = 2;
            this.hrd_log_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hrd_log_dgv_CellClick);
            this.hrd_log_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.hrd_log_dgv_CellFormatting);
            // 
            // FormAbsensi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(920, 636);
            this.Controls.Add(this.panel_hrd_mode);
            this.Controls.Add(this.panel_karyawan_mode);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAbsensi";
            this.Text = "Absensi Karyawan";
            this.Load += new System.EventHandler(this.FormAbsensi_Load);
            
            this.panel_karyawan_mode.ResumeLayout(false);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.panel_left_container.ResumeLayout(false);
            this.panel_scan_card.ResumeLayout(false);
            this.panel_scan_card.PerformLayout();
            this.panel_scanner_target.ResumeLayout(false);
            this.panel_right_container.ResumeLayout(false);
            this.panel_log_card.ResumeLayout(false);
            this.panel_log_card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_dgv)).EndInit();

            this.panel_hrd_mode.ResumeLayout(false);
            this.hrd_panel_left.ResumeLayout(false);
            this.hrd_panel_left.PerformLayout();
            this.hrd_panel_right.ResumeLayout(false);
            this.hrd_panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrd_log_dgv)).EndInit();
            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_jam;
        
        // Container Panels
        private System.Windows.Forms.Panel panel_karyawan_mode;
        private System.Windows.Forms.Panel panel_hrd_mode;

        // Karyawan Mode
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label tanggal_lbl;
        private System.Windows.Forms.Label jam_lbl;
        private System.Windows.Forms.Label label_masuk_config;
        private System.Windows.Forms.Label label_keluar_config;
        private System.Windows.Forms.Panel panel_left_container;
        private System.Windows.Forms.Panel panel_scan_card;
        private System.Windows.Forms.Label scan_title_lbl;
        private System.Windows.Forms.Panel panel_scanner_target;
        private System.Windows.Forms.Label target_text_lbl;
        private System.Windows.Forms.Label target_icon_lbl;
        private System.Windows.Forms.TextBox kode_txt;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button absen_keluar_btn;
        private System.Windows.Forms.Button absen_masuk_btn;
        private System.Windows.Forms.FlowLayoutPanel recent_flow_panel;
        private System.Windows.Forms.Panel panel_right_container;
        private System.Windows.Forms.Panel panel_rekap_card;
        private System.Windows.Forms.Panel panel_log_card;
        private System.Windows.Forms.Label log_title_lbl;
        private System.Windows.Forms.DataGridView log_dgv;
        private System.Windows.Forms.Label info_lbl;

        // HRD Mode
        private System.Windows.Forms.Panel hrd_panel_left;
        private System.Windows.Forms.Label hrd_inputTitle_lbl;
        private System.Windows.Forms.Label hrd_tanggal_lbl;
        private System.Windows.Forms.DateTimePicker hrd_tanggal_dtp;
        private System.Windows.Forms.Label hrd_karyawan_lbl;
        private System.Windows.Forms.TextBox hrd_karyawan_txt;
        private System.Windows.Forms.Label hrd_status_lbl;
        private System.Windows.Forms.ComboBox hrd_status_cmb;
        private System.Windows.Forms.Label hrd_masuk_lbl;
        private System.Windows.Forms.TextBox hrd_masuk_txt;
        private System.Windows.Forms.Label hrd_keluar_lbl;
        private System.Windows.Forms.TextBox hrd_keluar_txt;
        private System.Windows.Forms.Button hrd_simpan_btn;
        private System.Windows.Forms.Button hrd_batal_btn;
        private System.Windows.Forms.Panel hrd_panel_right;
        private System.Windows.Forms.TextBox hrd_cari_txt;
        private System.Windows.Forms.Label hrd_stat_belum_lbl;
        private System.Windows.Forms.DataGridView hrd_log_dgv;
    }
}