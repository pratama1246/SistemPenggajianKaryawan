namespace SistemPenggajianKaryawan
{
    partial class FormProsesGaji
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_left = new System.Windows.Forms.Panel();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.hitung_btn = new System.Windows.Forms.Button();
            this.stat_pengeluaran_lbl = new System.Windows.Forms.Label();
            this.total_pengeluaran_lbl = new System.Windows.Forms.Label();
            this.stat_karyawan_lbl = new System.Windows.Forms.Label();
            this.total_kar_lbl = new System.Windows.Forms.Label();
            this.ringkasan_group_lbl = new System.Windows.Forms.Label();
            this.divider_line = new System.Windows.Forms.Panel();
            this.thn_cmb = new System.Windows.Forms.ComboBox();
            this.tahun_lbl = new System.Windows.Forms.Label();
            this.bulan_cmb = new System.Windows.Forms.ComboBox();
            this.bulan_lbl = new System.Windows.Forms.Label();
            this.periode_group_lbl = new System.Windows.Forms.Label();
            this.status_periode_lbl = new System.Windows.Forms.Label();
            this.status_periode_val_lbl = new System.Windows.Forms.Label();
            this.judul_lbl = new System.Windows.Forms.Label();
            this.gaji_dgv = new System.Windows.Forms.DataGridView();
            this.cari_kalkulasi_txt = new System.Windows.Forms.TextBox();
            this.ekspor_btn = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaji_dgv)).BeginInit();
            this.panel_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.hitung_btn);
            this.panel_left.Controls.Add(this.stat_pengeluaran_lbl);
            this.panel_left.Controls.Add(this.total_pengeluaran_lbl);
            this.panel_left.Controls.Add(this.stat_karyawan_lbl);
            this.panel_left.Controls.Add(this.total_kar_lbl);
            this.panel_left.Controls.Add(this.ringkasan_group_lbl);
            this.panel_left.Controls.Add(this.divider_line);
            this.panel_left.Controls.Add(this.status_periode_lbl);
            this.panel_left.Controls.Add(this.status_periode_val_lbl);
            this.panel_left.Controls.Add(this.thn_cmb);
            this.panel_left.Controls.Add(this.tahun_lbl);
            this.panel_left.Controls.Add(this.bulan_cmb);
            this.panel_left.Controls.Add(this.bulan_lbl);
            this.panel_left.Controls.Add(this.periode_group_lbl);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(280, 520);
            this.panel_left.TabIndex = 1;
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpan_btn.FlatAppearance.BorderSize = 0;
            this.simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(20, 456);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(240, 36);
            this.simpan_btn.TabIndex = 12;
            this.simpan_btn.Text = "Simpan Semua";
            this.simpan_btn.UseVisualStyleBackColor = false;
            this.simpan_btn.Click += new System.EventHandler(this.simpan_btn_Click);
            // 
            // hitung_btn
            // 
            this.hitung_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.hitung_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hitung_btn.FlatAppearance.BorderSize = 0;
            this.hitung_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hitung_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.hitung_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.hitung_btn.Location = new System.Drawing.Point(20, 410);
            this.hitung_btn.Name = "hitung_btn";
            this.hitung_btn.Size = new System.Drawing.Size(240, 36);
            this.hitung_btn.TabIndex = 11;
            this.hitung_btn.Text = "Hitung Gaji";
            this.hitung_btn.UseVisualStyleBackColor = false;
            this.hitung_btn.Click += new System.EventHandler(this.hitung_btn_Click);
            // 
            // stat_pengeluaran_lbl
            // 
            this.stat_pengeluaran_lbl.AutoSize = true;
            this.stat_pengeluaran_lbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.stat_pengeluaran_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.stat_pengeluaran_lbl.Location = new System.Drawing.Point(20, 346);
            this.stat_pengeluaran_lbl.Name = "stat_pengeluaran_lbl";
            this.stat_pengeluaran_lbl.Size = new System.Drawing.Size(60, 30);
            this.stat_pengeluaran_lbl.TabIndex = 10;
            this.stat_pengeluaran_lbl.Text = "Rp 0";
            // 
            // total_pengeluaran_lbl
            // 
            this.total_pengeluaran_lbl.AutoSize = true;
            this.total_pengeluaran_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.total_pengeluaran_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.total_pengeluaran_lbl.Location = new System.Drawing.Point(20, 326);
            this.total_pengeluaran_lbl.Name = "total_pengeluaran_lbl";
            this.total_pengeluaran_lbl.Size = new System.Drawing.Size(102, 15);
            this.total_pengeluaran_lbl.TabIndex = 9;
            this.total_pengeluaran_lbl.Text = "Total Pengeluaran";
            // 
            // stat_karyawan_lbl
            // 
            this.stat_karyawan_lbl.AutoSize = true;
            this.stat_karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.stat_karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.stat_karyawan_lbl.Location = new System.Drawing.Point(20, 276);
            this.stat_karyawan_lbl.Name = "stat_karyawan_lbl";
            this.stat_karyawan_lbl.Size = new System.Drawing.Size(33, 37);
            this.stat_karyawan_lbl.TabIndex = 8;
            this.stat_karyawan_lbl.Text = "0";
            // 
            // total_kar_lbl
            // 
            this.total_kar_lbl.AutoSize = true;
            this.total_kar_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.total_kar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.total_kar_lbl.Location = new System.Drawing.Point(20, 256);
            this.total_kar_lbl.Name = "total_kar_lbl";
            this.total_kar_lbl.Size = new System.Drawing.Size(87, 15);
            this.total_kar_lbl.TabIndex = 7;
            this.total_kar_lbl.Text = "Total Karyawan";
            // 
            // ringkasan_group_lbl
            // 
            this.ringkasan_group_lbl.AutoSize = true;
            this.ringkasan_group_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ringkasan_group_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.ringkasan_group_lbl.Location = new System.Drawing.Point(20, 230);
            this.ringkasan_group_lbl.Name = "ringkasan_group_lbl";
            this.ringkasan_group_lbl.Size = new System.Drawing.Size(82, 17);
            this.ringkasan_group_lbl.TabIndex = 6;
            this.ringkasan_group_lbl.Text = "RINGKASAN";
            // 
            // status_periode_lbl
            // 
            this.status_periode_lbl.AutoSize = true;
            this.status_periode_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.status_periode_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.status_periode_lbl.Location = new System.Drawing.Point(20, 190);
            this.status_periode_lbl.Name = "status_periode_lbl";
            this.status_periode_lbl.Size = new System.Drawing.Size(87, 15);
            this.status_periode_lbl.TabIndex = 13;
            this.status_periode_lbl.Text = "Status Periode:";
            // 
            // status_periode_val_lbl
            // 
            this.status_periode_val_lbl.AutoSize = true;
            this.status_periode_val_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.status_periode_val_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.status_periode_val_lbl.Location = new System.Drawing.Point(120, 190);
            this.status_periode_val_lbl.Name = "status_periode_val_lbl";
            this.status_periode_val_lbl.Size = new System.Drawing.Size(95, 15);
            this.status_periode_val_lbl.TabIndex = 14;
            this.status_periode_val_lbl.Text = "Belum Diproses";
            // 
            // divider_line
            // 
            this.divider_line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.divider_line.Location = new System.Drawing.Point(20, 215);
            this.divider_line.Name = "divider_line";
            this.divider_line.Size = new System.Drawing.Size(240, 1);
            this.divider_line.TabIndex = 5;
            // 
            // thn_cmb
            // 
            this.thn_cmb.BackColor = System.Drawing.Color.White;
            this.thn_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thn_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thn_cmb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.thn_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.thn_cmb.FormattingEnabled = true;
            this.thn_cmb.Location = new System.Drawing.Point(20, 150);
            this.thn_cmb.Name = "thn_cmb";
            this.thn_cmb.Size = new System.Drawing.Size(240, 25);
            this.thn_cmb.TabIndex = 4;
            // 
            // tahun_lbl
            // 
            this.tahun_lbl.AutoSize = true;
            this.tahun_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tahun_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tahun_lbl.Location = new System.Drawing.Point(20, 126);
            this.tahun_lbl.Name = "tahun_lbl";
            this.tahun_lbl.Size = new System.Drawing.Size(40, 15);
            this.tahun_lbl.TabIndex = 3;
            this.tahun_lbl.Text = "Tahun";
            // 
            // bulan_cmb
            // 
            this.bulan_cmb.BackColor = System.Drawing.Color.White;
            this.bulan_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bulan_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bulan_cmb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.bulan_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.bulan_cmb.FormattingEnabled = true;
            this.bulan_cmb.Location = new System.Drawing.Point(20, 80);
            this.bulan_cmb.Name = "bulan_cmb";
            this.bulan_cmb.Size = new System.Drawing.Size(240, 25);
            this.bulan_cmb.TabIndex = 2;
            // 
            // bulan_lbl
            // 
            this.bulan_lbl.AutoSize = true;
            this.bulan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bulan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.bulan_lbl.Location = new System.Drawing.Point(20, 56);
            this.bulan_lbl.Name = "bulan_lbl";
            this.bulan_lbl.Size = new System.Drawing.Size(37, 15);
            this.bulan_lbl.TabIndex = 1;
            this.bulan_lbl.Text = "Bulan";
            // 
            // periode_group_lbl
            // 
            this.periode_group_lbl.AutoSize = true;
            this.periode_group_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.periode_group_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.periode_group_lbl.Location = new System.Drawing.Point(20, 24);
            this.periode_group_lbl.Name = "periode_group_lbl";
            this.periode_group_lbl.Size = new System.Drawing.Size(62, 17);
            this.periode_group_lbl.TabIndex = 0;
            this.periode_group_lbl.Text = "PERIODE";
            // 
            // judul_lbl
            // 
            this.judul_lbl.AutoSize = true;
            this.judul_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.judul_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.judul_lbl.Location = new System.Drawing.Point(20, 24);
            this.judul_lbl.Name = "judul_lbl";
            this.judul_lbl.Size = new System.Drawing.Size(109, 20);
            this.judul_lbl.TabIndex = 0;
            this.judul_lbl.Text = "Hasil Kalkulasi";
            // 
            // gaji_dgv
            // 
            this.gaji_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaji_dgv.BackgroundColor = System.Drawing.Color.White;
            this.gaji_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gaji_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gaji_dgv.Location = new System.Drawing.Point(20, 54);
            this.gaji_dgv.Name = "gaji_dgv";
            this.gaji_dgv.RowHeadersWidth = 51;
            this.gaji_dgv.RowTemplate.Height = 28;
            this.gaji_dgv.Size = new System.Drawing.Size(540, 440);
            this.gaji_dgv.TabIndex = 1;
            // 
            // cari_kalkulasi_txt
            // 
            this.cari_kalkulasi_txt.BackColor = System.Drawing.Color.White;
            this.cari_kalkulasi_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_kalkulasi_txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cari_kalkulasi_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.cari_kalkulasi_txt.Location = new System.Drawing.Point(260, 22);
            this.cari_kalkulasi_txt.Name = "cari_kalkulasi_txt";
            this.cari_kalkulasi_txt.Size = new System.Drawing.Size(180, 23);
            this.cari_kalkulasi_txt.TabIndex = 4;
            this.cari_kalkulasi_txt.Text = "🔍 Cari nama...";
            this.cari_kalkulasi_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_kalkulasi_txt_MouseClick);
            this.cari_kalkulasi_txt.Leave += new System.EventHandler(this.cari_kalkulasi_txt_Leave);
            this.cari_kalkulasi_txt.TextChanged += new System.EventHandler(this.cari_kalkulasi_txt_TextChanged);
            // 
            // ekspor_btn
            // 
            this.ekspor_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.ekspor_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ekspor_btn.FlatAppearance.BorderSize = 0;
            this.ekspor_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ekspor_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ekspor_btn.ForeColor = System.Drawing.Color.White;
            this.ekspor_btn.Location = new System.Drawing.Point(450, 20);
            this.ekspor_btn.Name = "ekspor_btn";
            this.ekspor_btn.Size = new System.Drawing.Size(110, 25);
            this.ekspor_btn.TabIndex = 5;
            this.ekspor_btn.Text = "Ekspor CSV";
            this.ekspor_btn.UseVisualStyleBackColor = false;
            this.ekspor_btn.Click += new System.EventHandler(this.ekspor_btn_Click);
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.cari_kalkulasi_txt);
            this.panel_right.Controls.Add(this.ekspor_btn);
            this.panel_right.Controls.Add(this.gaji_dgv);
            this.panel_right.Controls.Add(this.judul_lbl);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(280, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(580, 520);
            this.panel_right.TabIndex = 2;
            this.panel_right.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_right_Paint);
            // 
            // FormProsesGaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormProsesGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proses Penggajian Karyawan";
            this.Load += new System.EventHandler(this.FormProsesGaji_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaji_dgv)).EndInit();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Label periode_group_lbl;
        private System.Windows.Forms.ComboBox thn_cmb;
        private System.Windows.Forms.Label tahun_lbl;
        private System.Windows.Forms.ComboBox bulan_cmb;
        private System.Windows.Forms.Label bulan_lbl;
        private System.Windows.Forms.Panel divider_line;
        private System.Windows.Forms.Label total_kar_lbl;
        private System.Windows.Forms.Label ringkasan_group_lbl;
        private System.Windows.Forms.Label stat_karyawan_lbl;
        private System.Windows.Forms.Label stat_pengeluaran_lbl;
        private System.Windows.Forms.Label total_pengeluaran_lbl;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Button hitung_btn;
        private System.Windows.Forms.Label judul_lbl;
        private System.Windows.Forms.DataGridView gaji_dgv;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label status_periode_lbl;
        private System.Windows.Forms.Label status_periode_val_lbl;
        private System.Windows.Forms.TextBox cari_kalkulasi_txt;
        private System.Windows.Forms.Button ekspor_btn;
    }
}