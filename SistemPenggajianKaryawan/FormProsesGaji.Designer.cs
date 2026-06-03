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
            this.header_pnl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.proses_lbl = new System.Windows.Forms.Label();
            this.bgheader_pnl = new System.Windows.Forms.Panel();
            this.hitung_btn = new System.Windows.Forms.Button();
            this.thn_cmb = new System.Windows.Forms.ComboBox();
            this.bulan_cmb = new System.Windows.Forms.ComboBox();
            this.periode_lbl = new System.Windows.Forms.Label();
            this.panelbwh_dgv = new System.Windows.Forms.DataGridView();
            this.judul_lbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.header_pnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bgheader_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelbwh_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // header_pnl
            // 
            this.header_pnl.BackColor = System.Drawing.Color.SteelBlue;
            this.header_pnl.Controls.Add(this.panel1);
            this.header_pnl.Controls.Add(this.proses_lbl);
            this.header_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_pnl.Location = new System.Drawing.Point(0, 0);
            this.header_pnl.Name = "header_pnl";
            this.header_pnl.Size = new System.Drawing.Size(800, 53);
            this.header_pnl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 53);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(238, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proses Gaji Bulanan";
            // 
            // proses_lbl
            // 
            this.proses_lbl.AutoSize = true;
            this.proses_lbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proses_lbl.ForeColor = System.Drawing.Color.White;
            this.proses_lbl.Location = new System.Drawing.Point(238, 2);
            this.proses_lbl.Name = "proses_lbl";
            this.proses_lbl.Size = new System.Drawing.Size(315, 45);
            this.proses_lbl.TabIndex = 0;
            this.proses_lbl.Text = "Proses Gaji Bulanan";
            // 
            // bgheader_pnl
            // 
            this.bgheader_pnl.BackColor = System.Drawing.Color.White;
            this.bgheader_pnl.Controls.Add(this.hitung_btn);
            this.bgheader_pnl.Controls.Add(this.thn_cmb);
            this.bgheader_pnl.Controls.Add(this.bulan_cmb);
            this.bgheader_pnl.Controls.Add(this.periode_lbl);
            this.bgheader_pnl.ForeColor = System.Drawing.Color.Black;
            this.bgheader_pnl.Location = new System.Drawing.Point(27, 83);
            this.bgheader_pnl.Name = "bgheader_pnl";
            this.bgheader_pnl.Size = new System.Drawing.Size(742, 61);
            this.bgheader_pnl.TabIndex = 1;
            // 
            // hitung_btn
            // 
            this.hitung_btn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hitung_btn.Location = new System.Drawing.Point(582, 18);
            this.hitung_btn.Name = "hitung_btn";
            this.hitung_btn.Size = new System.Drawing.Size(123, 29);
            this.hitung_btn.TabIndex = 5;
            this.hitung_btn.Text = "Hitung ";
            this.hitung_btn.UseVisualStyleBackColor = true;
            // 
            // thn_cmb
            // 
            this.thn_cmb.FormattingEnabled = true;
            this.thn_cmb.Items.AddRange(new object[] {
            "2026",
            "2025",
            "2024",
            "2023",
            "2022"});
            this.thn_cmb.Location = new System.Drawing.Point(249, 18);
            this.thn_cmb.Name = "thn_cmb";
            this.thn_cmb.Size = new System.Drawing.Size(93, 28);
            this.thn_cmb.TabIndex = 4;
            // 
            // bulan_cmb
            // 
            this.bulan_cmb.FormattingEnabled = true;
            this.bulan_cmb.Items.AddRange(new object[] {
            "Mei ",
            "Juni ",
            "Juli",
            "Agustus"});
            this.bulan_cmb.Location = new System.Drawing.Point(104, 19);
            this.bulan_cmb.Name = "bulan_cmb";
            this.bulan_cmb.Size = new System.Drawing.Size(139, 28);
            this.bulan_cmb.TabIndex = 3;
            // 
            // periode_lbl
            // 
            this.periode_lbl.AutoSize = true;
            this.periode_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periode_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.periode_lbl.Location = new System.Drawing.Point(13, 18);
            this.periode_lbl.Name = "periode_lbl";
            this.periode_lbl.Size = new System.Drawing.Size(85, 25);
            this.periode_lbl.TabIndex = 2;
            this.periode_lbl.Text = "Periode :";
            // 
            // panelbwh_dgv
            // 
            this.panelbwh_dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelbwh_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelbwh_dgv.Location = new System.Drawing.Point(27, 181);
            this.panelbwh_dgv.Name = "panelbwh_dgv";
            this.panelbwh_dgv.RowHeadersWidth = 62;
            this.panelbwh_dgv.RowTemplate.Height = 28;
            this.panelbwh_dgv.Size = new System.Drawing.Size(742, 279);
            this.panelbwh_dgv.TabIndex = 2;
            // 
            // judul_lbl
            // 
            this.judul_lbl.AutoSize = true;
            this.judul_lbl.BackColor = System.Drawing.Color.White;
            this.judul_lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.judul_lbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.judul_lbl.Location = new System.Drawing.Point(53, 203);
            this.judul_lbl.Name = "judul_lbl";
            this.judul_lbl.Size = new System.Drawing.Size(217, 21);
            this.judul_lbl.TabIndex = 3;
            this.judul_lbl.Text = "HASIL PERHITUNGAN GAJI ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(57, 239);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 3);
            this.panel2.TabIndex = 4;
            // 
            // FormProsesGaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.judul_lbl);
            this.Controls.Add(this.panelbwh_dgv);
            this.Controls.Add(this.bgheader_pnl);
            this.Controls.Add(this.header_pnl);
            this.Name = "FormProsesGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProsesGaji";
            this.header_pnl.ResumeLayout(false);
            this.header_pnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bgheader_pnl.ResumeLayout(false);
            this.bgheader_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelbwh_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel header_pnl;
        private System.Windows.Forms.Label proses_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel bgheader_pnl;
        private System.Windows.Forms.Label periode_lbl;
        private System.Windows.Forms.ComboBox bulan_cmb;
        private System.Windows.Forms.ComboBox thn_cmb;
        private System.Windows.Forms.Button hitung_btn;
        private System.Windows.Forms.DataGridView panelbwh_dgv;
        private System.Windows.Forms.Label judul_lbl;
        private System.Windows.Forms.Panel panel2;
    }
}