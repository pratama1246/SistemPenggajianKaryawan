namespace SistemPenggajianKaryawan
{
    partial class FormManajemenUser
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
            this.inputUser_lbl = new System.Windows.Forms.Label();
            this.namaLengkap_lbl = new System.Windows.Forms.Label();
            this.nama_txt = new System.Windows.Forms.TextBox();
            this.username_lbl = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.password_lbl = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.showPassword_btn = new System.Windows.Forms.Button();
            this.role_lbl = new System.Windows.Forms.Label();
            this.role_cmb = new System.Windows.Forms.ComboBox();
            this.status_lbl = new System.Windows.Forms.Label();
            this.status_cmb = new System.Windows.Forms.ComboBox();
            this.karyawanLink_lbl = new System.Windows.Forms.Label();
            this.karyawan_cmb = new System.Windows.Forms.ComboBox();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.hapus_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.user_dgv = new System.Windows.Forms.DataGridView();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_left.Controls.Add(this.inputUser_lbl);
            this.panel_left.Controls.Add(this.namaLengkap_lbl);
            this.panel_left.Controls.Add(this.nama_txt);
            this.panel_left.Controls.Add(this.username_lbl);
            this.panel_left.Controls.Add(this.username_txt);
            this.panel_left.Controls.Add(this.password_lbl);
            this.panel_left.Controls.Add(this.password_txt);
            this.panel_left.Controls.Add(this.showPassword_btn);
            this.panel_left.Controls.Add(this.role_lbl);
            this.panel_left.Controls.Add(this.role_cmb);
            this.panel_left.Controls.Add(this.status_lbl);
            this.panel_left.Controls.Add(this.status_cmb);
            this.panel_left.Controls.Add(this.karyawanLink_lbl);
            this.panel_left.Controls.Add(this.karyawan_cmb);
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.hapus_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(320, 520);
            this.panel_left.TabIndex = 1;
            // 
            // inputUser_lbl
            // 
            this.inputUser_lbl.AutoSize = true;
            this.inputUser_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.inputUser_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.inputUser_lbl.Location = new System.Drawing.Point(20, 20);
            this.inputUser_lbl.Name = "inputUser_lbl";
            this.inputUser_lbl.Size = new System.Drawing.Size(82, 17);
            this.inputUser_lbl.TabIndex = 0;
            this.inputUser_lbl.Text = "INPUT USER";
            // 
            // namaLengkap_lbl
            // 
            this.namaLengkap_lbl.AutoSize = true;
            this.namaLengkap_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.namaLengkap_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.namaLengkap_lbl.Location = new System.Drawing.Point(20, 52);
            this.namaLengkap_lbl.Name = "namaLengkap_lbl";
            this.namaLengkap_lbl.Size = new System.Drawing.Size(87, 15);
            this.namaLengkap_lbl.TabIndex = 1;
            this.namaLengkap_lbl.Text = "Nama Lengkap";
            // 
            // nama_txt
            // 
            this.nama_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nama_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nama_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nama_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.nama_txt.Location = new System.Drawing.Point(23, 72);
            this.nama_txt.Name = "nama_txt";
            this.nama_txt.Size = new System.Drawing.Size(277, 25);
            this.nama_txt.TabIndex = 2;
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.username_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.username_lbl.Location = new System.Drawing.Point(20, 112);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(60, 15);
            this.username_lbl.TabIndex = 3;
            this.username_lbl.Text = "Username";
            // 
            // username_txt
            // 
            this.username_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.username_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.username_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.username_txt.Location = new System.Drawing.Point(23, 132);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(277, 25);
            this.username_txt.TabIndex = 4;
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.password_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.password_lbl.Location = new System.Drawing.Point(20, 172);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(57, 15);
            this.password_lbl.TabIndex = 5;
            this.password_lbl.Text = "Password";
            // 
            // password_txt
            // 
            this.password_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.password_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.password_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.password_txt.Location = new System.Drawing.Point(23, 192);
            this.password_txt.Name = "password_txt";
            this.password_txt.UseSystemPasswordChar = true;
            this.password_txt.Size = new System.Drawing.Size(245, 25);
            this.password_txt.TabIndex = 6;
            this.password_txt.TextChanged += new System.EventHandler(this.password_txt_TextChanged);
            // 
            // showPassword_btn
            // 
            this.showPassword_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.showPassword_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPassword_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.showPassword_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword_btn.Location = new System.Drawing.Point(272, 192);
            this.showPassword_btn.Name = "showPassword_btn";
            this.showPassword_btn.Size = new System.Drawing.Size(28, 25);
            this.showPassword_btn.TabIndex = 7;
            this.showPassword_btn.UseVisualStyleBackColor = false;
            this.showPassword_btn.Click += new System.EventHandler(this.showPassword_btn_Click);
            this.showPassword_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.showPassword_btn_Paint);
            // 
            // role_lbl
            // 
            this.role_lbl.AutoSize = true;
            this.role_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.role_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.role_lbl.Location = new System.Drawing.Point(20, 232);
            this.role_lbl.Name = "role_lbl";
            this.role_lbl.Size = new System.Drawing.Size(30, 15);
            this.role_lbl.TabIndex = 7;
            this.role_lbl.Text = "Role";
            // 
            // role_cmb
            // 
            this.role_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.role_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.role_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.role_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.role_cmb.FormattingEnabled = true;
            this.role_cmb.Items.AddRange(new object[] {
            "Admin",
            "HRD",
            "Karyawan"});
            this.role_cmb.Location = new System.Drawing.Point(23, 252);
            this.role_cmb.Name = "role_cmb";
            this.role_cmb.Size = new System.Drawing.Size(277, 25);
            this.role_cmb.TabIndex = 8;
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.status_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.status_lbl.Location = new System.Drawing.Point(20, 292);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(39, 15);
            this.status_lbl.TabIndex = 9;
            this.status_lbl.Text = "Status";
            // 
            // status_cmb
            // 
            this.status_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.status_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.status_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.status_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.status_cmb.FormattingEnabled = true;
            this.status_cmb.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.status_cmb.Location = new System.Drawing.Point(23, 312);
            this.status_cmb.Name = "status_cmb";
            this.status_cmb.Size = new System.Drawing.Size(277, 25);
            this.status_cmb.TabIndex = 10;
            // 
            // karyawanLink_lbl
            // 
            this.karyawanLink_lbl.AutoSize = true;
            this.karyawanLink_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.karyawanLink_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.karyawanLink_lbl.Location = new System.Drawing.Point(20, 353);
            this.karyawanLink_lbl.Name = "karyawanLink_lbl";
            this.karyawanLink_lbl.Size = new System.Drawing.Size(98, 15);
            this.karyawanLink_lbl.TabIndex = 14;
            this.karyawanLink_lbl.Text = "Link ke Karyawan";
            this.karyawanLink_lbl.Visible = false;
            // 
            // karyawan_cmb
            // 
            this.karyawan_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.karyawan_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.karyawan_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.karyawan_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.karyawan_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.karyawan_cmb.FormattingEnabled = true;
            this.karyawan_cmb.Location = new System.Drawing.Point(23, 373);
            this.karyawan_cmb.Name = "karyawan_cmb";
            this.karyawan_cmb.Size = new System.Drawing.Size(277, 25);
            this.karyawan_cmb.TabIndex = 15;
            this.karyawan_cmb.Visible = false;
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpan_btn.FlatAppearance.BorderSize = 0;
            this.simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(23, 460);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(80, 30);
            this.simpan_btn.TabIndex = 11;
            this.simpan_btn.Text = "Simpan";
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
            this.hapus_btn.Location = new System.Drawing.Point(115, 460);
            this.hapus_btn.Name = "hapus_btn";
            this.hapus_btn.Size = new System.Drawing.Size(80, 30);
            this.hapus_btn.TabIndex = 12;
            this.hapus_btn.Text = "Hapus";
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
            this.batal_btn.Location = new System.Drawing.Point(207, 460);
            this.batal_btn.Name = "batal_btn";
            this.batal_btn.Size = new System.Drawing.Size(80, 30);
            this.batal_btn.TabIndex = 13;
            this.batal_btn.Text = "Batal";
            this.batal_btn.UseVisualStyleBackColor = false;
            this.batal_btn.Click += new System.EventHandler(this.batal_btn_Click);
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.cari_txt);
            this.panel_right.Controls.Add(this.user_dgv);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(320, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(580, 520);
            this.panel_right.TabIndex = 2;
            // 
            // cari_txt
            // 
            this.cari_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cari_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.cari_txt.Location = new System.Drawing.Point(20, 20);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(540, 25);
            this.cari_txt.TabIndex = 0;
            this.cari_txt.Text = "🔍 Cari user...";
            this.cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_txt_MouseClick);
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            this.cari_txt.Leave += new System.EventHandler(this.cari_txt_Leave);
            // 
            // user_dgv
            // 
            this.user_dgv.AllowUserToAddRows = false;
            this.user_dgv.AllowUserToDeleteRows = false;
            this.user_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.user_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.user_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_dgv.ColumnHeadersHeight = 34;
            this.user_dgv.EnableHeadersVisualStyles = false;
            this.user_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.user_dgv.Location = new System.Drawing.Point(20, 62);
            this.user_dgv.MultiSelect = false;
            this.user_dgv.Name = "user_dgv";
            this.user_dgv.ReadOnly = true;
            this.user_dgv.RowHeadersVisible = false;
            this.user_dgv.RowHeadersWidth = 51;
            this.user_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.user_dgv.Size = new System.Drawing.Size(540, 430);
            this.user_dgv.TabIndex = 1;
            this.user_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.user_dgv_CellClick);
            this.user_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.user_dgv_CellFormatting);
            this.user_dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.user_dgv_DataError);
            // 
            // FormManajemenUser
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormManajemenUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manajemen User";
            this.Load += new System.EventHandler(this.FormManajemenUser_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Label inputUser_lbl;
        private System.Windows.Forms.Label namaLengkap_lbl;
        private System.Windows.Forms.TextBox nama_txt;
        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Button showPassword_btn;
        private System.Windows.Forms.Label role_lbl;
        private System.Windows.Forms.ComboBox role_cmb;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.ComboBox status_cmb;
        private System.Windows.Forms.Label karyawanLink_lbl;
        private System.Windows.Forms.ComboBox karyawan_cmb;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Button hapus_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.TextBox cari_txt;
        private System.Windows.Forms.DataGridView user_dgv;
    }
}
