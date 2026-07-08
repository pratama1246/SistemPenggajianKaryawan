namespace SistemPenggajianKaryawan
{
    partial class FormKaryawan
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
            this.panel_left = new System.Windows.Forms.Panel();
            this.inputTitle_lbl = new System.Windows.Forms.Label();
            this.kode_lbl = new System.Windows.Forms.Label();
            this.kode_txt = new System.Windows.Forms.TextBox();
            this.nama_lbl = new System.Windows.Forms.Label();
            this.nama_txt = new System.Windows.Forms.TextBox();
            this.jabatan_lbl = new System.Windows.Forms.Label();
            this.jabatan_txt = new System.Windows.Forms.TextBox();
            this.jenis_lbl = new System.Windows.Forms.Label();
            this.jenis_cmb = new System.Windows.Forms.ComboBox();
            this.gaji_lbl = new System.Windows.Forms.Label();
            this.gaji_txt = new System.Windows.Forms.TextBox();
            this.user_chk = new System.Windows.Forms.CheckBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.username_lbl = new System.Windows.Forms.Label();
            this.user_uname_txt = new System.Windows.Forms.TextBox();
            this.password_lbl = new System.Windows.Forms.Label();
            this.user_pass_txt = new System.Windows.Forms.TextBox();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.hapus_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.btn_filter_semua = new System.Windows.Forms.Button();
            this.btn_filter_tetap = new System.Windows.Forms.Button();
            this.btn_filter_kontrak = new System.Windows.Forms.Button();
            this.btn_filter_harian = new System.Windows.Forms.Button();
            this.karyawan_dgv = new System.Windows.Forms.DataGridView();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karyawan_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.inputTitle_lbl);
            this.panel_left.Controls.Add(this.kode_lbl);
            this.panel_left.Controls.Add(this.kode_txt);
            this.panel_left.Controls.Add(this.nama_lbl);
            this.panel_left.Controls.Add(this.nama_txt);
            this.panel_left.Controls.Add(this.jabatan_lbl);
            this.panel_left.Controls.Add(this.jabatan_txt);
            this.panel_left.Controls.Add(this.jenis_lbl);
            this.panel_left.Controls.Add(this.jenis_cmb);
            this.panel_left.Controls.Add(this.gaji_lbl);
            this.panel_left.Controls.Add(this.gaji_txt);
            this.panel_left.Controls.Add(this.user_chk);
            this.panel_left.Controls.Add(this.userPanel);
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.hapus_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(320, 620);
            this.panel_left.TabIndex = 1;
            // 
            // inputTitle_lbl
            // 
            this.inputTitle_lbl.AutoSize = true;
            this.inputTitle_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.inputTitle_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.inputTitle_lbl.Location = new System.Drawing.Point(20, 20);
            this.inputTitle_lbl.Name = "inputTitle_lbl";
            this.inputTitle_lbl.Size = new System.Drawing.Size(85, 17);
            this.inputTitle_lbl.TabIndex = 0;
            this.inputTitle_lbl.Text = "INPUT DATA";
            // 
            // kode_lbl
            // 
            this.kode_lbl.AutoSize = true;
            this.kode_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kode_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.kode_lbl.Location = new System.Drawing.Point(20, 52);
            this.kode_lbl.Name = "kode_lbl";
            this.kode_lbl.Size = new System.Drawing.Size(88, 15);
            this.kode_lbl.TabIndex = 1;
            this.kode_lbl.Text = "Kode Karyawan";
            // 
            // kode_txt
            // 
            this.kode_txt.BackColor = System.Drawing.Color.White;
            this.kode_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kode_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.kode_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.kode_txt.Location = new System.Drawing.Point(23, 72);
            this.kode_txt.Name = "kode_txt";
            this.kode_txt.ReadOnly = true;
            this.kode_txt.Size = new System.Drawing.Size(277, 25);
            this.kode_txt.TabIndex = 2;
            // 
            // nama_lbl
            // 
            this.nama_lbl.AutoSize = true;
            this.nama_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nama_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.nama_lbl.Location = new System.Drawing.Point(20, 112);
            this.nama_lbl.Name = "nama_lbl";
            this.nama_lbl.Size = new System.Drawing.Size(93, 15);
            this.nama_lbl.TabIndex = 3;
            this.nama_lbl.Text = "Nama Karyawan";
            // 
            // nama_txt
            // 
            this.nama_txt.BackColor = System.Drawing.Color.White;
            this.nama_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nama_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nama_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.nama_txt.Location = new System.Drawing.Point(23, 132);
            this.nama_txt.Name = "nama_txt";
            this.nama_txt.Size = new System.Drawing.Size(277, 25);
            this.nama_txt.TabIndex = 4;
            // 
            // jabatan_lbl
            // 
            this.jabatan_lbl.AutoSize = true;
            this.jabatan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.jabatan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.jabatan_lbl.Location = new System.Drawing.Point(20, 172);
            this.jabatan_lbl.Name = "jabatan_lbl";
            this.jabatan_lbl.Size = new System.Drawing.Size(47, 15);
            this.jabatan_lbl.TabIndex = 5;
            this.jabatan_lbl.Text = "Jabatan";
            // 
            // jabatan_txt
            // 
            this.jabatan_txt.BackColor = System.Drawing.Color.White;
            this.jabatan_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jabatan_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.jabatan_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.jabatan_txt.Location = new System.Drawing.Point(23, 192);
            this.jabatan_txt.Name = "jabatan_txt";
            this.jabatan_txt.Size = new System.Drawing.Size(277, 25);
            this.jabatan_txt.TabIndex = 6;
            // 
            // jenis_lbl
            // 
            this.jenis_lbl.AutoSize = true;
            this.jenis_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.jenis_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.jenis_lbl.Location = new System.Drawing.Point(20, 232);
            this.jenis_lbl.Name = "jenis_lbl";
            this.jenis_lbl.Size = new System.Drawing.Size(86, 15);
            this.jenis_lbl.TabIndex = 7;
            this.jenis_lbl.Text = "Jenis Karyawan";
            // 
            // jenis_cmb
            // 
            this.jenis_cmb.BackColor = System.Drawing.Color.White;
            this.jenis_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jenis_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jenis_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.jenis_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.jenis_cmb.FormattingEnabled = true;
            this.jenis_cmb.Items.AddRange(new object[] {
            "Tetap",
            "Kontrak",
            "Harian"});
            this.jenis_cmb.Location = new System.Drawing.Point(23, 252);
            this.jenis_cmb.Name = "jenis_cmb";
            this.jenis_cmb.Size = new System.Drawing.Size(277, 25);
            this.jenis_cmb.TabIndex = 8;
            // 
            // gaji_lbl
            // 
            this.gaji_lbl.AutoSize = true;
            this.gaji_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gaji_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.gaji_lbl.Location = new System.Drawing.Point(20, 312);
            this.gaji_lbl.Name = "gaji_lbl";
            this.gaji_lbl.Size = new System.Drawing.Size(63, 15);
            this.gaji_lbl.TabIndex = 9;
            this.gaji_lbl.Text = "Gaji Pokok";
            // 
            // gaji_txt
            // 
            this.gaji_txt.BackColor = System.Drawing.Color.White;
            this.gaji_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gaji_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gaji_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.gaji_txt.Location = new System.Drawing.Point(23, 332);
            this.gaji_txt.Name = "gaji_txt";
            this.gaji_txt.Size = new System.Drawing.Size(277, 25);
            this.gaji_txt.TabIndex = 10;
            // 
            // 
            // user_chk
            // 
            this.user_chk.AutoSize = true;
            this.user_chk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.user_chk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.user_chk.Location = new System.Drawing.Point(23, 370);
            this.user_chk.Name = "user_chk";
            this.user_chk.Size = new System.Drawing.Size(182, 19);
            this.user_chk.TabIndex = 11;
            this.user_chk.Text = "Buat Akun Login Karyawan";
            this.user_chk.UseVisualStyleBackColor = true;
            this.user_chk.CheckedChanged += new System.EventHandler(this.user_chk_CheckedChanged);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.username_lbl);
            this.userPanel.Controls.Add(this.user_uname_txt);
            this.userPanel.Controls.Add(this.password_lbl);
            this.userPanel.Controls.Add(this.user_pass_txt);
            this.userPanel.Location = new System.Drawing.Point(23, 395);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(277, 105);
            this.userPanel.TabIndex = 12;
            this.userPanel.Visible = false;
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.username_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.username_lbl.Location = new System.Drawing.Point(0, 5);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(60, 15);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "Username";
            // 
            // user_uname_txt
            // 
            this.user_uname_txt.BackColor = System.Drawing.Color.White;
            this.user_uname_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_uname_txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.user_uname_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.user_uname_txt.Location = new System.Drawing.Point(0, 23);
            this.user_uname_txt.Name = "user_uname_txt";
            this.user_uname_txt.Size = new System.Drawing.Size(277, 24);
            this.user_uname_txt.TabIndex = 1;
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.password_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.password_lbl.Location = new System.Drawing.Point(0, 53);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(57, 15);
            this.password_lbl.TabIndex = 2;
            this.password_lbl.Text = "Password";
            // 
            // user_pass_txt
            // 
            this.user_pass_txt.BackColor = System.Drawing.Color.White;
            this.user_pass_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_pass_txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.user_pass_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.user_pass_txt.Location = new System.Drawing.Point(0, 71);
            this.user_pass_txt.Name = "user_pass_txt";
            this.user_pass_txt.Size = new System.Drawing.Size(277, 24);
            this.user_pass_txt.TabIndex = 3;
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpan_btn.FlatAppearance.BorderSize = 0;
            this.simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(23, 510);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(90, 32);
            this.simpan_btn.TabIndex = 13;
            this.simpan_btn.Text = "💾 Simpan";
            this.simpan_btn.UseVisualStyleBackColor = false;
            this.simpan_btn.Click += new System.EventHandler(this.simpan_btn_Click);
            // 
            // hapus_btn
            // 
            this.hapus_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.hapus_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hapus_btn.FlatAppearance.BorderSize = 0;
            this.hapus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hapus_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.hapus_btn.ForeColor = System.Drawing.Color.White;
            this.hapus_btn.Location = new System.Drawing.Point(121, 510);
            this.hapus_btn.Name = "hapus_btn";
            this.hapus_btn.Size = new System.Drawing.Size(90, 32);
            this.hapus_btn.TabIndex = 14;
            this.hapus_btn.Text = "🗑️ Hapus";
            this.hapus_btn.UseVisualStyleBackColor = false;
            this.hapus_btn.Click += new System.EventHandler(this.hapus_btn_Click);
            // 
            // batal_btn
            // 
            this.batal_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.batal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.batal_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.batal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batal_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.batal_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.batal_btn.Location = new System.Drawing.Point(219, 510);
            this.batal_btn.Name = "batal_btn";
            this.batal_btn.Size = new System.Drawing.Size(80, 32);
            this.batal_btn.TabIndex = 15;
            this.batal_btn.Text = "Batal";
            this.batal_btn.UseVisualStyleBackColor = false;
            this.batal_btn.Click += new System.EventHandler(this.batal_btn_Click);
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.cari_txt);
            this.panel_right.Controls.Add(this.btn_filter_semua);
            this.panel_right.Controls.Add(this.btn_filter_tetap);
            this.panel_right.Controls.Add(this.btn_filter_kontrak);
            this.panel_right.Controls.Add(this.btn_filter_harian);
            this.panel_right.Controls.Add(this.karyawan_dgv);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(320, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(580, 540);
            this.panel_right.TabIndex = 2;
            // 
            // cari_txt
            // 
            this.cari_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cari_txt.BackColor = System.Drawing.Color.White;
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.cari_txt.Location = new System.Drawing.Point(20, 20);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(540, 25);
            this.cari_txt.TabIndex = 0;
            this.cari_txt.Text = "🔍 Cari nama atau kode...";
            this.cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_txt_MouseClick);
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            this.cari_txt.Leave += new System.EventHandler(this.cari_txt_Leave);
            // 
            // btn_filter_semua
            // 
            this.btn_filter_semua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.btn_filter_semua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filter_semua.FlatAppearance.BorderSize = 0;
            this.btn_filter_semua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_semua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_filter_semua.ForeColor = System.Drawing.Color.White;
            this.btn_filter_semua.Location = new System.Drawing.Point(20, 62);
            this.btn_filter_semua.Name = "btn_filter_semua";
            this.btn_filter_semua.Size = new System.Drawing.Size(95, 28);
            this.btn_filter_semua.TabIndex = 1;
            this.btn_filter_semua.Text = "Semua (0)";
            this.btn_filter_semua.UseVisualStyleBackColor = false;
            this.btn_filter_semua.Click += new System.EventHandler(this.btn_filter_semua_Click);
            // 
            // btn_filter_tetap
            // 
            this.btn_filter_tetap.BackColor = System.Drawing.Color.White;
            this.btn_filter_tetap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filter_tetap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btn_filter_tetap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_tetap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_filter_tetap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btn_filter_tetap.Location = new System.Drawing.Point(121, 62);
            this.btn_filter_tetap.Name = "btn_filter_tetap";
            this.btn_filter_tetap.Size = new System.Drawing.Size(95, 28);
            this.btn_filter_tetap.TabIndex = 2;
            this.btn_filter_tetap.Text = "Tetap (0)";
            this.btn_filter_tetap.UseVisualStyleBackColor = false;
            this.btn_filter_tetap.Click += new System.EventHandler(this.btn_filter_tetap_Click);
            // 
            // btn_filter_kontrak
            // 
            this.btn_filter_kontrak.BackColor = System.Drawing.Color.White;
            this.btn_filter_kontrak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filter_kontrak.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.btn_filter_kontrak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_kontrak.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_filter_kontrak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.btn_filter_kontrak.Location = new System.Drawing.Point(222, 62);
            this.btn_filter_kontrak.Name = "btn_filter_kontrak";
            this.btn_filter_kontrak.Size = new System.Drawing.Size(95, 28);
            this.btn_filter_kontrak.TabIndex = 3;
            this.btn_filter_kontrak.Text = "Kontrak (0)";
            this.btn_filter_kontrak.UseVisualStyleBackColor = false;
            this.btn_filter_kontrak.Click += new System.EventHandler(this.btn_filter_kontrak_Click);
            // 
            // btn_filter_harian
            // 
            this.btn_filter_harian.BackColor = System.Drawing.Color.White;
            this.btn_filter_harian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filter_harian.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btn_filter_harian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_harian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_filter_harian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btn_filter_harian.Location = new System.Drawing.Point(323, 62);
            this.btn_filter_harian.Name = "btn_filter_harian";
            this.btn_filter_harian.Size = new System.Drawing.Size(95, 28);
            this.btn_filter_harian.TabIndex = 4;
            this.btn_filter_harian.Text = "Harian (0)";
            this.btn_filter_harian.UseVisualStyleBackColor = false;
            this.btn_filter_harian.Click += new System.EventHandler(this.btn_filter_harian_Click);
            // 
            // karyawan_dgv
            // 
            this.karyawan_dgv.AllowUserToAddRows = false;
            this.karyawan_dgv.AllowUserToDeleteRows = false;
            this.karyawan_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.karyawan_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.karyawan_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.karyawan_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.karyawan_dgv.ColumnHeadersHeight = 34;
            this.karyawan_dgv.EnableHeadersVisualStyles = false;
            this.karyawan_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.karyawan_dgv.Location = new System.Drawing.Point(20, 105);
            this.karyawan_dgv.MultiSelect = false;
            this.karyawan_dgv.Name = "karyawan_dgv";
            this.karyawan_dgv.ReadOnly = true;
            this.karyawan_dgv.RowHeadersVisible = false;
            this.karyawan_dgv.RowHeadersWidth = 51;
            this.karyawan_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.karyawan_dgv.Size = new System.Drawing.Size(540, 410);
            this.karyawan_dgv.TabIndex = 5;
            this.karyawan_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.karyawan_dgv_CellClick);
            this.karyawan_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.karyawan_dgv_CellFormatting);
            // 
            // FormKaryawan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormKaryawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Karyawan";
            this.Load += new System.EventHandler(this.FormKaryawan_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karyawan_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Label inputTitle_lbl;
        private System.Windows.Forms.Label kode_lbl;
        private System.Windows.Forms.TextBox kode_txt;
        private System.Windows.Forms.Label nama_lbl;
        private System.Windows.Forms.TextBox nama_txt;
        private System.Windows.Forms.Label jabatan_lbl;
        private System.Windows.Forms.TextBox jabatan_txt;
        private System.Windows.Forms.Label jenis_lbl;
        private System.Windows.Forms.ComboBox jenis_cmb;
        private System.Windows.Forms.Label gaji_lbl;
        private System.Windows.Forms.TextBox gaji_txt;
        private System.Windows.Forms.CheckBox user_chk;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.TextBox user_uname_txt;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.TextBox user_pass_txt;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Button hapus_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.TextBox cari_txt;
        private System.Windows.Forms.Button btn_filter_semua;
        private System.Windows.Forms.Button btn_filter_tetap;
        private System.Windows.Forms.Button btn_filter_kontrak;
        private System.Windows.Forms.Button btn_filter_harian;
        private System.Windows.Forms.DataGridView karyawan_dgv;
    }
}