namespace SistemPenggajianKaryawan
{
    partial class FormAbsensi
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
            this.components = new System.ComponentModel.Container();
            this.accentPanel = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.info_lbl = new System.Windows.Forms.Label();
            this.absen_keluar_btn = new System.Windows.Forms.Button();
            this.absen_masuk_btn = new System.Windows.Forms.Button();
            this.status_keluar_lbl = new System.Windows.Forms.Label();
            this.status_masuk_lbl = new System.Windows.Forms.Label();
            this.divider_panel2 = new System.Windows.Forms.Panel();
            this.jabatan_lbl = new System.Windows.Forms.Label();
            this.nama_lbl = new System.Windows.Forms.Label();
            this.kode_txt = new System.Windows.Forms.TextBox();
            this.label_scan_kartu = new System.Windows.Forms.Label();
            this.divider_panel1 = new System.Windows.Forms.Panel();
            this.tanggal_lbl = new System.Windows.Forms.Label();
            this.jam_lbl = new System.Windows.Forms.Label();
            this.panel_right = new System.Windows.Forms.Panel();
            this.log_dgv = new System.Windows.Forms.DataGridView();
            this.title_log_lbl = new System.Windows.Forms.Label();
            this.timer_jam = new System.Windows.Forms.Timer(this.components);
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_dgv)).BeginInit();
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
            this.panel_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel_left.Controls.Add(this.info_lbl);
            this.panel_left.Controls.Add(this.absen_keluar_btn);
            this.panel_left.Controls.Add(this.absen_masuk_btn);
            this.panel_left.Controls.Add(this.status_keluar_lbl);
            this.panel_left.Controls.Add(this.status_masuk_lbl);
            this.panel_left.Controls.Add(this.divider_panel2);
            this.panel_left.Controls.Add(this.jabatan_lbl);
            this.panel_left.Controls.Add(this.nama_lbl);
            this.panel_left.Controls.Add(this.kode_txt);
            this.panel_left.Controls.Add(this.label_scan_kartu);
            this.panel_left.Controls.Add(this.divider_panel1);
            this.panel_left.Controls.Add(this.tanggal_lbl);
            this.panel_left.Controls.Add(this.jam_lbl);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 4);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(360, 536);
            this.panel_left.TabIndex = 1;
            // 
            // info_lbl
            // 
            this.info_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.info_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.info_lbl.Location = new System.Drawing.Point(20, 440);
            this.info_lbl.Name = "info_lbl";
            this.info_lbl.Size = new System.Drawing.Size(320, 80);
            this.info_lbl.TabIndex = 12;
            this.info_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // absen_keluar_btn
            // 
            this.absen_keluar_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.absen_keluar_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.absen_keluar_btn.FlatAppearance.BorderSize = 0;
            this.absen_keluar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.absen_keluar_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.absen_keluar_btn.ForeColor = System.Drawing.Color.White;
            this.absen_keluar_btn.Location = new System.Drawing.Point(190, 375);
            this.absen_keluar_btn.Name = "absen_keluar_btn";
            this.absen_keluar_btn.Size = new System.Drawing.Size(150, 40);
            this.absen_keluar_btn.TabIndex = 11;
            this.absen_keluar_btn.Text = "Absen Keluar";
            this.absen_keluar_btn.UseVisualStyleBackColor = false;
            this.absen_keluar_btn.Click += new System.EventHandler(this.absen_keluar_btn_Click);
            // 
            // absen_masuk_btn
            // 
            this.absen_masuk_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.absen_masuk_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.absen_masuk_btn.FlatAppearance.BorderSize = 0;
            this.absen_masuk_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.absen_masuk_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.absen_masuk_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.absen_masuk_btn.Location = new System.Drawing.Point(20, 375);
            this.absen_masuk_btn.Name = "absen_masuk_btn";
            this.absen_masuk_btn.Size = new System.Drawing.Size(150, 40);
            this.absen_masuk_btn.TabIndex = 10;
            this.absen_masuk_btn.Text = "Absen Masuk";
            this.absen_masuk_btn.UseVisualStyleBackColor = false;
            this.absen_masuk_btn.Click += new System.EventHandler(this.absen_masuk_btn_Click);
            // 
            // status_keluar_lbl
            // 
            this.status_keluar_lbl.AutoSize = true;
            this.status_keluar_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.status_keluar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.status_keluar_lbl.Location = new System.Drawing.Point(20, 335);
            this.status_keluar_lbl.Name = "status_keluar_lbl";
            this.status_keluar_lbl.Size = new System.Drawing.Size(107, 19);
            this.status_keluar_lbl.TabIndex = 9;
            this.status_keluar_lbl.Text = "Jam Keluar: —";
            // 
            // status_masuk_lbl
            // 
            this.status_masuk_lbl.AutoSize = true;
            this.status_masuk_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.status_masuk_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.status_masuk_lbl.Location = new System.Drawing.Point(20, 305);
            this.status_masuk_lbl.Name = "status_masuk_lbl";
            this.status_masuk_lbl.Size = new System.Drawing.Size(107, 19);
            this.status_masuk_lbl.TabIndex = 8;
            this.status_masuk_lbl.Text = "Jam Masuk: —";
            // 
            // divider_panel2
            // 
            this.divider_panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.divider_panel2.Location = new System.Drawing.Point(20, 290);
            this.divider_panel2.Name = "divider_panel2";
            this.divider_panel2.Size = new System.Drawing.Size(320, 1);
            this.divider_panel2.TabIndex = 7;
            // 
            // jabatan_lbl
            // 
            this.jabatan_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.jabatan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.jabatan_lbl.Location = new System.Drawing.Point(20, 255);
            this.jabatan_lbl.Name = "jabatan_lbl";
            this.jabatan_lbl.Size = new System.Drawing.Size(320, 25);
            this.jabatan_lbl.TabIndex = 6;
            this.jabatan_lbl.Text = "—";
            // 
            // nama_lbl
            // 
            this.nama_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.nama_lbl.ForeColor = System.Drawing.Color.White;
            this.nama_lbl.Location = new System.Drawing.Point(20, 220);
            this.nama_lbl.Name = "nama_lbl";
            this.nama_lbl.Size = new System.Drawing.Size(320, 30);
            this.nama_lbl.TabIndex = 5;
            this.nama_lbl.Text = "—";
            // 
            // kode_txt
            // 
            this.kode_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.kode_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kode_txt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.kode_txt.ForeColor = System.Drawing.Color.White;
            this.kode_txt.Location = new System.Drawing.Point(20, 175);
            this.kode_txt.Name = "kode_txt";
            this.kode_txt.Size = new System.Drawing.Size(320, 29);
            this.kode_txt.TabIndex = 4;
            this.kode_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kode_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kode_txt_KeyDown);
            // 
            // label_scan_kartu
            // 
            this.label_scan_kartu.AutoSize = true;
            this.label_scan_kartu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label_scan_kartu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.label_scan_kartu.Location = new System.Drawing.Point(20, 150);
            this.label_scan_kartu.Name = "label_scan_kartu";
            this.label_scan_kartu.Size = new System.Drawing.Size(229, 17);
            this.label_scan_kartu.TabIndex = 3;
            this.label_scan_kartu.Text = "SCAN KARTU / INPUT KODE KARYAWAN";
            // 
            // divider_panel1
            // 
            this.divider_panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.divider_panel1.Location = new System.Drawing.Point(20, 130);
            this.divider_panel1.Name = "divider_panel1";
            this.divider_panel1.Size = new System.Drawing.Size(320, 1);
            this.divider_panel1.TabIndex = 2;
            // 
            // tanggal_lbl
            // 
            this.tanggal_lbl.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tanggal_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.tanggal_lbl.Location = new System.Drawing.Point(20, 85);
            this.tanggal_lbl.Name = "tanggal_lbl";
            this.tanggal_lbl.Size = new System.Drawing.Size(320, 25);
            this.tanggal_lbl.TabIndex = 1;
            this.tanggal_lbl.Text = "—";
            this.tanggal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jam_lbl
            // 
            this.jam_lbl.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.jam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.jam_lbl.Location = new System.Drawing.Point(20, 25);
            this.jam_lbl.Name = "jam_lbl";
            this.jam_lbl.Size = new System.Drawing.Size(320, 55);
            this.jam_lbl.TabIndex = 0;
            this.jam_lbl.Text = "00:00:00";
            this.jam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel_right.Controls.Add(this.log_dgv);
            this.panel_right.Controls.Add(this.title_log_lbl);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(360, 4);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(540, 536);
            this.panel_right.TabIndex = 2;
            // 
            // log_dgv
            // 
            this.log_dgv.AllowUserToAddRows = false;
            this.log_dgv.AllowUserToDeleteRows = false;
            this.log_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.log_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.log_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log_dgv.ColumnHeadersHeight = 32;
            this.log_dgv.EnableHeadersVisualStyles = false;
            this.log_dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.log_dgv.Location = new System.Drawing.Point(20, 65);
            this.log_dgv.MultiSelect = false;
            this.log_dgv.Name = "log_dgv";
            this.log_dgv.ReadOnly = true;
            this.log_dgv.RowHeadersVisible = false;
            this.log_dgv.RowHeadersWidth = 51;
            this.log_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.log_dgv.Size = new System.Drawing.Size(500, 450);
            this.log_dgv.TabIndex = 3;
            this.log_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.log_dgv_CellFormatting);
            // 
            // title_log_lbl
            // 
            this.title_log_lbl.AutoSize = true;
            this.title_log_lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.title_log_lbl.ForeColor = System.Drawing.Color.White;
            this.title_log_lbl.Location = new System.Drawing.Point(20, 25);
            this.title_log_lbl.Name = "title_log_lbl";
            this.title_log_lbl.Size = new System.Drawing.Size(211, 25);
            this.title_log_lbl.TabIndex = 0;
            this.title_log_lbl.Text = "LOG ABSENSI HARI INI";
            // 
            // timer_jam
            // 
            this.timer_jam.Enabled = true;
            this.timer_jam.Interval = 1000;
            this.timer_jam.Tick += new System.EventHandler(this.timer_jam_Tick);
            // 
            // FormAbsensi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.accentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAbsensi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self-Service Karyawan";
            this.Load += new System.EventHandler(this.FormAbsensi_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel accentPanel;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Label jam_lbl;
        private System.Windows.Forms.Label tanggal_lbl;
        private System.Windows.Forms.Panel divider_panel1;
        private System.Windows.Forms.Label label_scan_kartu;
        private System.Windows.Forms.TextBox kode_txt;
        private System.Windows.Forms.Label nama_lbl;
        private System.Windows.Forms.Label jabatan_lbl;
        private System.Windows.Forms.Panel divider_panel2;
        private System.Windows.Forms.Label status_masuk_lbl;
        private System.Windows.Forms.Label status_keluar_lbl;
        private System.Windows.Forms.Button absen_masuk_btn;
        private System.Windows.Forms.Button absen_keluar_btn;
        private System.Windows.Forms.Label info_lbl;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label title_log_lbl;
        private System.Windows.Forms.DataGridView log_dgv;
        private System.Windows.Forms.Timer timer_jam;
    }
}