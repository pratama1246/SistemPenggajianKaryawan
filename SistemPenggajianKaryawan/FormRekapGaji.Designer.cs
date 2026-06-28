using System.Windows.Forms;

namespace SistemPenggajianKaryawan
{
    partial class FormRekapGaji
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
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.cari_lbl = new System.Windows.Forms.Label();
            this.tampilkan_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
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
            this.panel_left.Controls.Add(this.cari_txt);
            this.panel_left.Controls.Add(this.cari_lbl);
            this.panel_left.Controls.Add(this.tampilkan_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Controls.Add(this.stat_pengeluaran_lbl);
            this.panel_left.Controls.Add(this.total_pengeluaran_lbl);
            this.panel_left.Controls.Add(this.stat_karyawan_lbl);
            this.panel_left.Controls.Add(this.total_kar_lbl);
            this.panel_left.Controls.Add(this.ringkasan_group_lbl);
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
            // cari_txt
            // 
            this.cari_txt.BackColor = System.Drawing.Color.White;
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cari_txt.Location = new System.Drawing.Point(23, 210);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(237, 25);
            this.cari_txt.TabIndex = 15;
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            // 
            // cari_lbl
            // 
            this.cari_lbl.AutoSize = true;
            this.cari_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cari_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.cari_lbl.Location = new System.Drawing.Point(20, 187);
            this.cari_lbl.Name = "cari_lbl";
            this.cari_lbl.Size = new System.Drawing.Size(82, 15);
            this.cari_lbl.TabIndex = 14;
            this.cari_lbl.Text = "Cari Karyawan";
            // 
            // tampilkan_btn
            // 
            this.tampilkan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.tampilkan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tampilkan_btn.FlatAppearance.BorderSize = 0;
            this.tampilkan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tampilkan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tampilkan_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tampilkan_btn.Location = new System.Drawing.Point(23, 440);
            this.tampilkan_btn.Name = "tampilkan_btn";
            this.tampilkan_btn.Size = new System.Drawing.Size(237, 36);
            this.tampilkan_btn.TabIndex = 11;
            this.tampilkan_btn.Text = "Filter Data";
            this.tampilkan_btn.UseVisualStyleBackColor = false;
            this.tampilkan_btn.Click += new System.EventHandler(this.tampilkan_btn_Click);
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
            // stat_pengeluaran_lbl
            // 
            this.stat_pengeluaran_lbl.AutoSize = true;
            this.stat_pengeluaran_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.stat_pengeluaran_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.stat_pengeluaran_lbl.Location = new System.Drawing.Point(20, 380);
            this.stat_pengeluaran_lbl.Name = "stat_pengeluaran_lbl";
            this.stat_pengeluaran_lbl.Size = new System.Drawing.Size(52, 25);
            this.stat_pengeluaran_lbl.TabIndex = 10;
            this.stat_pengeluaran_lbl.Text = "Rp 0";
            // 
            // total_pengeluaran_lbl
            // 
            this.total_pengeluaran_lbl.AutoSize = true;
            this.total_pengeluaran_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.total_pengeluaran_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.total_pengeluaran_lbl.Location = new System.Drawing.Point(20, 357);
            this.total_pengeluaran_lbl.Name = "total_pengeluaran_lbl";
            this.total_pengeluaran_lbl.Size = new System.Drawing.Size(102, 15);
            this.total_pengeluaran_lbl.TabIndex = 9;
            this.total_pengeluaran_lbl.Text = "Total Pengeluaran";
            // 
            // stat_karyawan_lbl
            // 
            this.stat_karyawan_lbl.AutoSize = true;
            this.stat_karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.stat_karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.stat_karyawan_lbl.Location = new System.Drawing.Point(20, 312);
            this.stat_karyawan_lbl.Name = "stat_karyawan_lbl";
            this.stat_karyawan_lbl.Size = new System.Drawing.Size(28, 32);
            this.stat_karyawan_lbl.TabIndex = 8;
            this.stat_karyawan_lbl.Text = "0";
            // 
            // total_kar_lbl
            // 
            this.total_kar_lbl.AutoSize = true;
            this.total_kar_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.total_kar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.total_kar_lbl.Location = new System.Drawing.Point(20, 289);
            this.total_kar_lbl.Name = "total_kar_lbl";
            this.total_kar_lbl.Size = new System.Drawing.Size(101, 15);
            this.total_kar_lbl.TabIndex = 7;
            this.total_kar_lbl.Text = "Karyawan Dibayar";
            // 
            // ringkasan_group_lbl
            // 
            this.ringkasan_group_lbl.AutoSize = true;
            this.ringkasan_group_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ringkasan_group_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.ringkasan_group_lbl.Location = new System.Drawing.Point(20, 260);
            this.ringkasan_group_lbl.Name = "ringkasan_group_lbl";
            this.ringkasan_group_lbl.Size = new System.Drawing.Size(82, 17);
            this.ringkasan_group_lbl.TabIndex = 6;
            this.ringkasan_group_lbl.Text = "RINGKASAN";
            // 
            // divider_line
            // 
            this.divider_line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.divider_line.Location = new System.Drawing.Point(20, 250);
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
            this.periode_group_lbl.Size = new System.Drawing.Size(92, 17);
            this.periode_group_lbl.TabIndex = 0;
            this.periode_group_lbl.Text = "FILTER REKAP";
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
            this.judul_lbl.Size = new System.Drawing.Size(232, 21);
            this.judul_lbl.TabIndex = 0;
            this.judul_lbl.Text = "Histori Penggajian Karyawan";
            // 
            // FormRekapGaji
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRekapGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rekap Penggajian Karyawan";
            this.Load += new System.EventHandler(this.FormRekapGaji_Load);
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
        private System.Windows.Forms.Label ringkasan_group_lbl;
        private System.Windows.Forms.Label total_kar_lbl;
        private System.Windows.Forms.Label stat_karyawan_lbl;
        private System.Windows.Forms.Label total_pengeluaran_lbl;
        private System.Windows.Forms.Label stat_pengeluaran_lbl;
        private System.Windows.Forms.Button tampilkan_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.DataGridView rekap_dgv;
        private System.Windows.Forms.Label cari_lbl;
        private System.Windows.Forms.TextBox cari_txt;
    }
}
