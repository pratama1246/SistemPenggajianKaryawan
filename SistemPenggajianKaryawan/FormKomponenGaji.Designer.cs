namespace SistemPenggajianKaryawan
{
    partial class FormKomponenGaji
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.accentPanel = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.inputKomponen_lbl = new System.Windows.Forms.Label();
            this.namaKomponen_lbl = new System.Windows.Forms.Label();
            this.nama_txt = new System.Windows.Forms.TextBox();
            this.tipe_lbl = new System.Windows.Forms.Label();
            this.tipe_cmb = new System.Windows.Forms.ComboBox();
            this.jenisNilai_lbl = new System.Windows.Forms.Label();
            this.jenisNilai_cmb = new System.Windows.Forms.ComboBox();
            this.nilai_lbl = new System.Windows.Forms.Label();
            this.nilai_txt = new System.Windows.Forms.TextBox();
            this.berlaku_lbl = new System.Windows.Forms.Label();
            this.berlaku_cmb = new System.Windows.Forms.ComboBox();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.hapus_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.komponen_dgv = new System.Windows.Forms.DataGridView();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.komponen_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // accentPanel
            // 
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.accentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.accentPanel.Location = new System.Drawing.Point(0, 0);
            this.accentPanel.Name = "accentPanel";
            this.accentPanel.Size = new System.Drawing.Size(900, 4);
            this.accentPanel.TabIndex = 0;
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_left.Controls.Add(this.inputKomponen_lbl);
            this.panel_left.Controls.Add(this.namaKomponen_lbl);
            this.panel_left.Controls.Add(this.nama_txt);
            this.panel_left.Controls.Add(this.tipe_lbl);
            this.panel_left.Controls.Add(this.tipe_cmb);
            this.panel_left.Controls.Add(this.jenisNilai_lbl);
            this.panel_left.Controls.Add(this.jenisNilai_cmb);
            this.panel_left.Controls.Add(this.nilai_lbl);
            this.panel_left.Controls.Add(this.nilai_txt);
            this.panel_left.Controls.Add(this.berlaku_lbl);
            this.panel_left.Controls.Add(this.berlaku_cmb);
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.hapus_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 4);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(320, 516);
            this.panel_left.TabIndex = 1;
            // 
            // inputKomponen_lbl
            // 
            this.inputKomponen_lbl.AutoSize = true;
            this.inputKomponen_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.inputKomponen_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.inputKomponen_lbl.Location = new System.Drawing.Point(20, 20);
            this.inputKomponen_lbl.Name = "inputKomponen_lbl";
            this.inputKomponen_lbl.Size = new System.Drawing.Size(157, 21);
            this.inputKomponen_lbl.TabIndex = 0;
            this.inputKomponen_lbl.Text = "INPUT KOMPONEN";
            // 
            // namaKomponen_lbl
            // 
            this.namaKomponen_lbl.AutoSize = true;
            this.namaKomponen_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.namaKomponen_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.namaKomponen_lbl.Location = new System.Drawing.Point(20, 52);
            this.namaKomponen_lbl.Name = "namaKomponen_lbl";
            this.namaKomponen_lbl.Size = new System.Drawing.Size(126, 20);
            this.namaKomponen_lbl.TabIndex = 1;
            this.namaKomponen_lbl.Text = "Nama Komponen";
            // 
            // nama_txt
            // 
            this.nama_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nama_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nama_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nama_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.nama_txt.Location = new System.Drawing.Point(23, 72);
            this.nama_txt.Name = "nama_txt";
            this.nama_txt.Size = new System.Drawing.Size(277, 30);
            this.nama_txt.TabIndex = 2;
            // 
            // tipe_lbl
            // 
            this.tipe_lbl.AutoSize = true;
            this.tipe_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tipe_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tipe_lbl.Location = new System.Drawing.Point(20, 112);
            this.tipe_lbl.Name = "tipe_lbl";
            this.tipe_lbl.Size = new System.Drawing.Size(38, 20);
            this.tipe_lbl.TabIndex = 3;
            this.tipe_lbl.Text = "Tipe";
            // 
            // tipe_cmb
            // 
            this.tipe_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tipe_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipe_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tipe_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tipe_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.tipe_cmb.FormattingEnabled = true;
            this.tipe_cmb.Items.AddRange(new object[] {
            "Tambah",
            "Potong"});
            this.tipe_cmb.Location = new System.Drawing.Point(23, 132);
            this.tipe_cmb.Name = "tipe_cmb";
            this.tipe_cmb.Size = new System.Drawing.Size(277, 31);
            this.tipe_cmb.TabIndex = 4;
            // 
            // jenisNilai_lbl
            // 
            this.jenisNilai_lbl.AutoSize = true;
            this.jenisNilai_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.jenisNilai_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.jenisNilai_lbl.Location = new System.Drawing.Point(20, 172);
            this.jenisNilai_lbl.Name = "jenisNilai_lbl";
            this.jenisNilai_lbl.Size = new System.Drawing.Size(75, 20);
            this.jenisNilai_lbl.TabIndex = 5;
            this.jenisNilai_lbl.Text = "Jenis Nilai";
            // 
            // jenisNilai_cmb
            // 
            this.jenisNilai_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.jenisNilai_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jenisNilai_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jenisNilai_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.jenisNilai_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.jenisNilai_cmb.FormattingEnabled = true;
            this.jenisNilai_cmb.Items.AddRange(new object[] {
            "Nominal",
            "Persen"});
            this.jenisNilai_cmb.Location = new System.Drawing.Point(23, 192);
            this.jenisNilai_cmb.Name = "jenisNilai_cmb";
            this.jenisNilai_cmb.Size = new System.Drawing.Size(277, 31);
            this.jenisNilai_cmb.TabIndex = 6;
            this.jenisNilai_cmb.SelectedIndexChanged += new System.EventHandler(this.jenisNilai_cmb_SelectedIndexChanged);
            // 
            // nilai_lbl
            // 
            this.nilai_lbl.AutoSize = true;
            this.nilai_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nilai_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.nilai_lbl.Location = new System.Drawing.Point(20, 232);
            this.nilai_lbl.Name = "nilai_lbl";
            this.nilai_lbl.Size = new System.Drawing.Size(40, 20);
            this.nilai_lbl.TabIndex = 7;
            this.nilai_lbl.Text = "Nilai";
            // 
            // nilai_txt
            // 
            this.nilai_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nilai_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nilai_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nilai_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.nilai_txt.Location = new System.Drawing.Point(23, 252);
            this.nilai_txt.Name = "nilai_txt";
            this.nilai_txt.Size = new System.Drawing.Size(277, 30);
            this.nilai_txt.TabIndex = 8;
            this.nilai_txt.Text = "0";
            // 
            // berlaku_lbl
            // 
            this.berlaku_lbl.AutoSize = true;
            this.berlaku_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.berlaku_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.berlaku_lbl.Location = new System.Drawing.Point(20, 292);
            this.berlaku_lbl.Name = "berlaku_lbl";
            this.berlaku_lbl.Size = new System.Drawing.Size(100, 20);
            this.berlaku_lbl.TabIndex = 9;
            this.berlaku_lbl.Text = "Berlaku Untuk";
            // 
            // berlaku_cmb
            // 
            this.berlaku_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.berlaku_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.berlaku_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.berlaku_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.berlaku_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.berlaku_cmb.FormattingEnabled = true;
            this.berlaku_cmb.Items.AddRange(new object[] {
            "Semua",
            "Tetap",
            "Kontrak",
            "Harian"});
            this.berlaku_cmb.Location = new System.Drawing.Point(23, 312);
            this.berlaku_cmb.Name = "berlaku_cmb";
            this.berlaku_cmb.Size = new System.Drawing.Size(277, 31);
            this.berlaku_cmb.TabIndex = 10;
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
            this.panel_right.Controls.Add(this.komponen_dgv);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(320, 4);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(580, 516);
            this.panel_right.TabIndex = 2;
            // 
            // cari_txt
            // 
            this.cari_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.cari_txt.Location = new System.Drawing.Point(20, 20);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(540, 30);
            this.cari_txt.TabIndex = 0;
            this.cari_txt.Text = "🔍 Cari komponen...";
            this.cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_txt_MouseClick);
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            this.cari_txt.Leave += new System.EventHandler(this.cari_txt_Leave);
            // 
            // komponen_dgv
            // 
            this.komponen_dgv.AllowUserToAddRows = false;
            this.komponen_dgv.AllowUserToDeleteRows = false;
            this.komponen_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.komponen_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.komponen_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.komponen_dgv.ColumnHeadersHeight = 34;
            this.komponen_dgv.EnableHeadersVisualStyles = false;
            this.komponen_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.komponen_dgv.Location = new System.Drawing.Point(20, 62);
            this.komponen_dgv.MultiSelect = false;
            this.komponen_dgv.Name = "komponen_dgv";
            this.komponen_dgv.ReadOnly = true;
            this.komponen_dgv.RowHeadersVisible = false;
            this.komponen_dgv.RowHeadersWidth = 51;
            this.komponen_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.komponen_dgv.Size = new System.Drawing.Size(540, 430);
            this.komponen_dgv.TabIndex = 1;
            this.komponen_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.komponen_dgv_CellClick);
            this.komponen_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.komponen_dgv_CellFormatting);
            // 
            // FormKomponenGaji
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.accentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormKomponenGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Komponen Gaji";
            this.Load += new System.EventHandler(this.FormKomponenGaji_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.komponen_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel       accentPanel;
        private System.Windows.Forms.Panel       panel_left;
        private System.Windows.Forms.Label       inputKomponen_lbl;
        private System.Windows.Forms.Label       namaKomponen_lbl;
        private System.Windows.Forms.TextBox     nama_txt;
        private System.Windows.Forms.Label       tipe_lbl;
        private System.Windows.Forms.ComboBox    tipe_cmb;
        private System.Windows.Forms.Label       jenisNilai_lbl;
        private System.Windows.Forms.ComboBox    jenisNilai_cmb;
        private System.Windows.Forms.Label       nilai_lbl;
        private System.Windows.Forms.TextBox     nilai_txt;
        private System.Windows.Forms.Label       berlaku_lbl;
        private System.Windows.Forms.ComboBox    berlaku_cmb;
        private System.Windows.Forms.Button      simpan_btn;
        private System.Windows.Forms.Button      hapus_btn;
        private System.Windows.Forms.Button      batal_btn;
        private System.Windows.Forms.Panel       panel_right;
        private System.Windows.Forms.TextBox     cari_txt;
        private System.Windows.Forms.DataGridView komponen_dgv;
    }
}
