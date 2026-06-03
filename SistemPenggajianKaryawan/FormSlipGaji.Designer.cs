namespace SistemPenggajianKaryawan
{
    partial class FormSlipGaji
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
            this.bg_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.judul_lbl = new System.Windows.Forms.Label();
            this.panel_body = new System.Windows.Forms.Panel();
            this.periode_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.penghasilan_dgv = new System.Windows.Forms.DataGridView();
            this.pptongan_dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neto_pnl = new System.Windows.Forms.Panel();
            this.gajiditerima_lbl = new System.Windows.Forms.Label();
            this.gajirp_lbl = new System.Windows.Forms.Label();
            this.tpenghasilan_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bg_panel.SuspendLayout();
            this.panel_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penghasilan_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pptongan_dgv)).BeginInit();
            this.neto_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bg_panel
            // 
            this.bg_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.bg_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bg_panel.Controls.Add(this.label2);
            this.bg_panel.Controls.Add(this.periode_lbl);
            this.bg_panel.Controls.Add(this.label1);
            this.bg_panel.Controls.Add(this.judul_lbl);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bg_panel.Location = new System.Drawing.Point(0, 0);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.Size = new System.Drawing.Size(828, 95);
            this.bg_panel.TabIndex = 2;
            this.bg_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.bg_panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Slip Gaji Karyawan";
            // 
            // judul_lbl
            // 
            this.judul_lbl.AutoSize = true;
            this.judul_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.judul_lbl.Location = new System.Drawing.Point(22, 10);
            this.judul_lbl.Name = "judul_lbl";
            this.judul_lbl.Size = new System.Drawing.Size(346, 38);
            this.judul_lbl.TabIndex = 0;
            this.judul_lbl.Text = "Politeknik Negeri Cilacap";
            this.judul_lbl.Click += new System.EventHandler(this.judul_lbl_Click);
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_body.Controls.Add(this.panel1);
            this.panel_body.Controls.Add(this.label7);
            this.panel_body.Controls.Add(this.tpenghasilan_lbl);
            this.panel_body.Controls.Add(this.neto_pnl);
            this.panel_body.Controls.Add(this.pptongan_dgv);
            this.panel_body.Controls.Add(this.penghasilan_dgv);
            this.panel_body.Controls.Add(this.label6);
            this.panel_body.Controls.Add(this.label5);
            this.panel_body.Controls.Add(this.label4);
            this.panel_body.Controls.Add(this.label3);
            this.panel_body.Location = new System.Drawing.Point(2, 3);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(825, 591);
            this.panel_body.TabIndex = 1;
            this.panel_body.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_body_Paint);
            // 
            // periode_lbl
            // 
            this.periode_lbl.AutoSize = true;
            this.periode_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periode_lbl.Location = new System.Drawing.Point(725, 20);
            this.periode_lbl.Name = "periode_lbl";
            this.periode_lbl.Size = new System.Drawing.Size(71, 25);
            this.periode_lbl.TabIndex = 0;
            this.periode_lbl.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mei 2026";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nama    : Nesyabella Halim";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Jabatan : Staff IT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(512, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "NIP    : 240102112";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(512, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Jenis : Karyawan Tetap";
            // 
            // penghasilan_dgv
            // 
            this.penghasilan_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.penghasilan_dgv.BackgroundColor = System.Drawing.Color.White;
            this.penghasilan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.penghasilan_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNama});
            this.penghasilan_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.penghasilan_dgv.Location = new System.Drawing.Point(42, 243);
            this.penghasilan_dgv.Name = "penghasilan_dgv";
            this.penghasilan_dgv.RowHeadersVisible = false;
            this.penghasilan_dgv.RowHeadersWidth = 62;
            this.penghasilan_dgv.RowTemplate.Height = 28;
            this.penghasilan_dgv.Size = new System.Drawing.Size(353, 150);
            this.penghasilan_dgv.TabIndex = 5;
            this.penghasilan_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.penghasilan_dgv_CellContentClick);
            // 
            // pptongan_dgv
            // 
            this.pptongan_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pptongan_dgv.BackgroundColor = System.Drawing.Color.White;
            this.pptongan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pptongan_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.pptongan_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.pptongan_dgv.Location = new System.Drawing.Point(394, 243);
            this.pptongan_dgv.Name = "pptongan_dgv";
            this.pptongan_dgv.RowHeadersVisible = false;
            this.pptongan_dgv.RowHeadersWidth = 62;
            this.pptongan_dgv.RowTemplate.Height = 28;
            this.pptongan_dgv.Size = new System.Drawing.Size(349, 150);
            this.pptongan_dgv.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Potongan";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colNama
            // 
            this.colNama.HeaderText = "Penghasilan";
            this.colNama.MinimumWidth = 8;
            this.colNama.Name = "colNama";
            // 
            // neto_pnl
            // 
            this.neto_pnl.BackColor = System.Drawing.Color.AliceBlue;
            this.neto_pnl.Controls.Add(this.gajirp_lbl);
            this.neto_pnl.Controls.Add(this.gajiditerima_lbl);
            this.neto_pnl.Location = new System.Drawing.Point(42, 449);
            this.neto_pnl.Name = "neto_pnl";
            this.neto_pnl.Size = new System.Drawing.Size(701, 85);
            this.neto_pnl.TabIndex = 7;
            // 
            // gajiditerima_lbl
            // 
            this.gajiditerima_lbl.AutoSize = true;
            this.gajiditerima_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gajiditerima_lbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.gajiditerima_lbl.Location = new System.Drawing.Point(28, 24);
            this.gajiditerima_lbl.Name = "gajiditerima_lbl";
            this.gajiditerima_lbl.Size = new System.Drawing.Size(191, 38);
            this.gajiditerima_lbl.TabIndex = 0;
            this.gajiditerima_lbl.Text = "Gaji Diterima";
            // 
            // gajirp_lbl
            // 
            this.gajirp_lbl.AutoSize = true;
            this.gajirp_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gajirp_lbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.gajirp_lbl.Location = new System.Drawing.Point(491, 22);
            this.gajirp_lbl.Name = "gajirp_lbl";
            this.gajirp_lbl.Size = new System.Drawing.Size(188, 38);
            this.gajirp_lbl.TabIndex = 1;
            this.gajirp_lbl.Text = "Rp 4.500.000";
            // 
            // tpenghasilan_lbl
            // 
            this.tpenghasilan_lbl.AutoSize = true;
            this.tpenghasilan_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpenghasilan_lbl.ForeColor = System.Drawing.Color.DarkGray;
            this.tpenghasilan_lbl.Location = new System.Drawing.Point(42, 416);
            this.tpenghasilan_lbl.Name = "tpenghasilan_lbl";
            this.tpenghasilan_lbl.Size = new System.Drawing.Size(155, 22);
            this.tpenghasilan_lbl.TabIndex = 8;
            this.tpenghasilan_lbl.Text = "Total Penghasilan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(401, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total Potongan";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(42, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 2);
            this.panel1.TabIndex = 10;
            // 
            // FormSlipGaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 594);
            this.Controls.Add(this.bg_panel);
            this.Controls.Add(this.panel_body);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormSlipGaji";
            this.Text = " Slip Gaji";
            this.Load += new System.EventHandler(this.FormSlipGaji_Load);
            this.bg_panel.ResumeLayout(false);
            this.bg_panel.PerformLayout();
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penghasilan_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pptongan_dgv)).EndInit();
            this.neto_pnl.ResumeLayout(false);
            this.neto_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bg_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label judul_lbl;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label periode_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView pptongan_dgv;
        private System.Windows.Forms.DataGridView penghasilan_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel neto_pnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.Label tpenghasilan_lbl;
        private System.Windows.Forms.Label gajirp_lbl;
        private System.Windows.Forms.Label gajiditerima_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}