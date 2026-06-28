namespace SistemPenggajianKaryawan
{
    partial class FormRekapAbsensi
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
            this.filter_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.lbl_hadir_title = new System.Windows.Forms.Label();
            this.lbl_hadir_val = new System.Windows.Forms.Label();
            this.lbl_izin_title = new System.Windows.Forms.Label();
            this.lbl_izin_val = new System.Windows.Forms.Label();
            this.lbl_sakit_title = new System.Windows.Forms.Label();
            this.lbl_sakit_val = new System.Windows.Forms.Label();
            this.lbl_alpha_title = new System.Windows.Forms.Label();
            this.lbl_alpha_val = new System.Windows.Forms.Label();
            this.rekap_group_lbl = new System.Windows.Forms.Label();
            this.divider_line = new System.Windows.Forms.Panel();
            this.thn_cmb = new System.Windows.Forms.ComboBox();
            this.tahun_lbl = new System.Windows.Forms.Label();
            this.bulan_cmb = new System.Windows.Forms.ComboBox();
            this.bulan_lbl = new System.Windows.Forms.Label();
            this.periode_group_lbl = new System.Windows.Forms.Label();
            this.panel_right = new System.Windows.Forms.Panel();
            this.rekap_dgv = new System.Windows.Forms.DataGridView();
            this.judul_lbl = new System.Windows.Forms.Label();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rekap_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.filter_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Controls.Add(this.lbl_hadir_title);
            this.panel_left.Controls.Add(this.lbl_hadir_val);
            this.panel_left.Controls.Add(this.lbl_izin_title);
            this.panel_left.Controls.Add(this.lbl_izin_val);
            this.panel_left.Controls.Add(this.lbl_sakit_title);
            this.panel_left.Controls.Add(this.lbl_sakit_val);
            this.panel_left.Controls.Add(this.lbl_alpha_title);
            this.panel_left.Controls.Add(this.lbl_alpha_val);
            this.panel_left.Controls.Add(this.rekap_group_lbl);
            this.panel_left.Controls.Add(this.divider_line);
            this.panel_left.Controls.Add(this.thn_cmb);
            this.panel_left.Controls.Add(this.tahun_lbl);
            this.panel_left.Controls.Add(this.bulan_cmb);
            this.panel_left.Controls.Add(this.bulan_lbl);
            this.panel_left.Controls.Add(this.periode_group_lbl);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(280, 540);
            this.panel_left.TabIndex = 1;
            // 
            // filter_btn
            // 
            this.filter_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.filter_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filter_btn.FlatAppearance.BorderSize = 0;
            this.filter_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filter_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.filter_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.filter_btn.Location = new System.Drawing.Point(23, 440);
            this.filter_btn.Name = "filter_btn";
            this.filter_btn.Size = new System.Drawing.Size(237, 36);
            this.filter_btn.TabIndex = 11;
            this.filter_btn.Text = "Filter Data";
            this.filter_btn.UseVisualStyleBackColor = false;
            this.filter_btn.Click += new System.EventHandler(this.filter_btn_Click);
            // 
            // batal_btn
            // 
            this.batal_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.batal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.batal_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.batal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batal_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.batal_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.batal_btn.Location = new System.Drawing.Point(23, 486);
            this.batal_btn.Name = "batal_btn";
            this.batal_btn.Size = new System.Drawing.Size(237, 36);
            this.batal_btn.TabIndex = 12;
            this.batal_btn.Text = "Reset Filter";
            this.batal_btn.UseVisualStyleBackColor = false;
            this.batal_btn.Click += new System.EventHandler(this.batal_btn_Click);
            // 
            // lbl_hadir_title
            // 
            this.lbl_hadir_title.AutoSize = true;
            this.lbl_hadir_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_hadir_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lbl_hadir_title.Location = new System.Drawing.Point(20, 240);
            this.lbl_hadir_title.Name = "lbl_hadir_title";
            this.lbl_hadir_title.Size = new System.Drawing.Size(43, 15);
            this.lbl_hadir_title.TabIndex = 13;
            this.lbl_hadir_title.Text = "Hadir :";
            // 
            // lbl_hadir_val
            // 
            this.lbl_hadir_val.AutoSize = true;
            this.lbl_hadir_val.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_hadir_val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lbl_hadir_val.Location = new System.Drawing.Point(100, 240);
            this.lbl_hadir_val.Name = "lbl_hadir_val";
            this.lbl_hadir_val.Size = new System.Drawing.Size(15, 17);
            this.lbl_hadir_val.TabIndex = 14;
            this.lbl_hadir_val.Text = "0";
            // 
            // lbl_izin_title
            // 
            this.lbl_izin_title.AutoSize = true;
            this.lbl_izin_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_izin_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.lbl_izin_title.Location = new System.Drawing.Point(20, 275);
            this.lbl_izin_title.Name = "lbl_izin_title";
            this.lbl_izin_title.Size = new System.Drawing.Size(33, 15);
            this.lbl_izin_title.TabIndex = 15;
            this.lbl_izin_title.Text = "Izin :";
            // 
            // lbl_izin_val
            // 
            this.lbl_izin_val.AutoSize = true;
            this.lbl_izin_val.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_izin_val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lbl_izin_val.Location = new System.Drawing.Point(100, 275);
            this.lbl_izin_val.Name = "lbl_izin_val";
            this.lbl_izin_val.Size = new System.Drawing.Size(15, 17);
            this.lbl_izin_val.TabIndex = 16;
            this.lbl_izin_val.Text = "0";
            // 
            // lbl_sakit_title
            // 
            this.lbl_sakit_title.AutoSize = true;
            this.lbl_sakit_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_sakit_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.lbl_sakit_title.Location = new System.Drawing.Point(20, 310);
            this.lbl_sakit_title.Name = "lbl_sakit_title";
            this.lbl_sakit_title.Size = new System.Drawing.Size(41, 15);
            this.lbl_sakit_title.TabIndex = 17;
            this.lbl_sakit_title.Text = "Sakit :";
            // 
            // lbl_sakit_val
            // 
            this.lbl_sakit_val.AutoSize = true;
            this.lbl_sakit_val.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_sakit_val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lbl_sakit_val.Location = new System.Drawing.Point(100, 310);
            this.lbl_sakit_val.Name = "lbl_sakit_val";
            this.lbl_sakit_val.Size = new System.Drawing.Size(15, 17);
            this.lbl_sakit_val.TabIndex = 18;
            this.lbl_sakit_val.Text = "0";
            // 
            // lbl_alpha_title
            // 
            this.lbl_alpha_title.AutoSize = true;
            this.lbl_alpha_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_alpha_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lbl_alpha_title.Location = new System.Drawing.Point(20, 345);
            this.lbl_alpha_title.Name = "lbl_alpha_title";
            this.lbl_alpha_title.Size = new System.Drawing.Size(44, 15);
            this.lbl_alpha_title.TabIndex = 19;
            this.lbl_alpha_title.Text = "Alpha :";
            // 
            // lbl_alpha_val
            // 
            this.lbl_alpha_val.AutoSize = true;
            this.lbl_alpha_val.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_alpha_val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lbl_alpha_val.Location = new System.Drawing.Point(100, 345);
            this.lbl_alpha_val.Name = "lbl_alpha_val";
            this.lbl_alpha_val.Size = new System.Drawing.Size(15, 17);
            this.lbl_alpha_val.TabIndex = 20;
            this.lbl_alpha_val.Text = "0";
            // 
            // rekap_group_lbl
            // 
            this.rekap_group_lbl.AutoSize = true;
            this.rekap_group_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rekap_group_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.rekap_group_lbl.Location = new System.Drawing.Point(20, 205);
            this.rekap_group_lbl.Name = "rekap_group_lbl";
            this.rekap_group_lbl.Size = new System.Drawing.Size(161, 17);
            this.rekap_group_lbl.TabIndex = 6;
            this.rekap_group_lbl.Text = "RINGKASAN KEHADIRAN";
            // 
            // divider_line
            // 
            this.divider_line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.divider_line.Location = new System.Drawing.Point(20, 190);
            this.divider_line.Name = "divider_line";
            this.divider_line.Size = new System.Drawing.Size(240, 1);
            this.divider_line.TabIndex = 5;
            // 
            // thn_cmb
            // 
            this.thn_cmb.BackColor = System.Drawing.Color.White;
            this.thn_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thn_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thn_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.thn_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.thn_cmb.FormattingEnabled = true;
            this.thn_cmb.Location = new System.Drawing.Point(23, 145);
            this.thn_cmb.Name = "thn_cmb";
            this.thn_cmb.Size = new System.Drawing.Size(237, 25);
            this.thn_cmb.TabIndex = 4;
            // 
            // tahun_lbl
            // 
            this.tahun_lbl.AutoSize = true;
            this.tahun_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tahun_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tahun_lbl.Location = new System.Drawing.Point(20, 122);
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
            this.bulan_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bulan_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.bulan_cmb.FormattingEnabled = true;
            this.bulan_cmb.Location = new System.Drawing.Point(23, 80);
            this.bulan_cmb.Name = "bulan_cmb";
            this.bulan_cmb.Size = new System.Drawing.Size(237, 25);
            this.bulan_cmb.TabIndex = 2;
            // 
            // bulan_lbl
            // 
            this.bulan_lbl.AutoSize = true;
            this.bulan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bulan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.bulan_lbl.Location = new System.Drawing.Point(20, 57);
            this.bulan_lbl.Name = "bulan_lbl";
            this.bulan_lbl.Size = new System.Drawing.Size(37, 15);
            this.bulan_lbl.TabIndex = 1;
            this.bulan_lbl.Text = "Bulan";
            // 
            // periode_group_lbl
            // 
            this.periode_group_lbl.AutoSize = true;
            this.periode_group_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.periode_group_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.periode_group_lbl.Location = new System.Drawing.Point(20, 20);
            this.periode_group_lbl.Name = "periode_group_lbl";
            this.periode_group_lbl.Size = new System.Drawing.Size(106, 17);
            this.periode_group_lbl.TabIndex = 0;
            this.periode_group_lbl.Text = "FILTER PERIODE";
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.rekap_dgv);
            this.panel_right.Controls.Add(this.judul_lbl);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(280, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(620, 540);
            this.panel_right.TabIndex = 2;
            // 
            // rekap_dgv
            // 
            this.rekap_dgv.AllowUserToAddRows = false;
            this.rekap_dgv.AllowUserToDeleteRows = false;
            this.rekap_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rekap_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rekap_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.rekap_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rekap_dgv.ColumnHeadersHeight = 34;
            this.rekap_dgv.Location = new System.Drawing.Point(20, 60);
            this.rekap_dgv.MultiSelect = false;
            this.rekap_dgv.Name = "rekap_dgv";
            this.rekap_dgv.ReadOnly = true;
            this.rekap_dgv.RowHeadersVisible = false;
            this.rekap_dgv.RowHeadersWidth = 51;
            this.rekap_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rekap_dgv.Size = new System.Drawing.Size(580, 460);
            this.rekap_dgv.TabIndex = 1;
            this.rekap_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.rekap_dgv_CellFormatting);
            // 
            // judul_lbl
            // 
            this.judul_lbl.AutoSize = true;
            this.judul_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.judul_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.judul_lbl.Location = new System.Drawing.Point(20, 20);
            this.judul_lbl.Name = "judul_lbl";
            this.judul_lbl.Size = new System.Drawing.Size(212, 21);
            this.judul_lbl.TabIndex = 0;
            this.judul_lbl.Text = "Riwayat Kehadiran Pribadi";
            // 
            // FormRekapAbsensi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRekapAbsensi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rekap Absensi Bulanan";
            this.Load += new System.EventHandler(this.FormRekapAbsensi_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rekap_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label judul_lbl;
        private System.Windows.Forms.Label periode_group_lbl;
        private System.Windows.Forms.ComboBox thn_cmb;
        private System.Windows.Forms.Label tahun_lbl;
        private System.Windows.Forms.ComboBox bulan_cmb;
        private System.Windows.Forms.Label bulan_lbl;
        private System.Windows.Forms.Panel divider_line;
        private System.Windows.Forms.Label rekap_group_lbl;
        private System.Windows.Forms.Label lbl_hadir_title;
        private System.Windows.Forms.Label lbl_hadir_val;
        private System.Windows.Forms.Label lbl_izin_title;
        private System.Windows.Forms.Label lbl_izin_val;
        private System.Windows.Forms.Label lbl_sakit_title;
        private System.Windows.Forms.Label lbl_sakit_val;
        private System.Windows.Forms.Label lbl_alpha_title;
        private System.Windows.Forms.Label lbl_alpha_val;
        private System.Windows.Forms.Button filter_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.DataGridView rekap_dgv;
    }
}
