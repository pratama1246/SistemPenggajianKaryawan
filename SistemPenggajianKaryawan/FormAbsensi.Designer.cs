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
            this.accentPanel = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.periodeKaryawan_lbl = new System.Windows.Forms.Label();
            this.bulan_lbl = new System.Windows.Forms.Label();
            this.bulan_cmb = new System.Windows.Forms.ComboBox();
            this.tahun_lbl = new System.Windows.Forms.Label();
            this.tahun_txt = new System.Windows.Forms.TextBox();
            this.karyawan_lbl = new System.Windows.Forms.Label();
            this.karyawan_cmb = new System.Windows.Forms.ComboBox();
            this.divider_panel = new System.Windows.Forms.Panel();
            this.dataKehadiran_lbl = new System.Windows.Forms.Label();
            this.hadir_lbl = new System.Windows.Forms.Label();
            this.hadir_txt = new System.Windows.Forms.TextBox();
            this.izin_lbl = new System.Windows.Forms.Label();
            this.izin_txt = new System.Windows.Forms.TextBox();
            this.sakit_lbl = new System.Windows.Forms.Label();
            this.sakit_txt = new System.Windows.Forms.TextBox();
            this.alpha_lbl = new System.Windows.Forms.Label();
            this.alpha_txt = new System.Windows.Forms.TextBox();
            this.lembur_lbl = new System.Windows.Forms.Label();
            this.lembur_txt = new System.Windows.Forms.TextBox();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.belumInput_lbl = new System.Windows.Forms.Label();
            this.absensi_dgv = new System.Windows.Forms.DataGridView();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.absensi_dgv)).BeginInit();
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
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.periodeKaryawan_lbl);
            this.panel_left.Controls.Add(this.bulan_lbl);
            this.panel_left.Controls.Add(this.bulan_cmb);
            this.panel_left.Controls.Add(this.tahun_lbl);
            this.panel_left.Controls.Add(this.tahun_txt);
            this.panel_left.Controls.Add(this.karyawan_lbl);
            this.panel_left.Controls.Add(this.karyawan_cmb);
            this.panel_left.Controls.Add(this.divider_panel);
            this.panel_left.Controls.Add(this.dataKehadiran_lbl);
            this.panel_left.Controls.Add(this.hadir_lbl);
            this.panel_left.Controls.Add(this.hadir_txt);
            this.panel_left.Controls.Add(this.izin_lbl);
            this.panel_left.Controls.Add(this.izin_txt);
            this.panel_left.Controls.Add(this.sakit_lbl);
            this.panel_left.Controls.Add(this.sakit_txt);
            this.panel_left.Controls.Add(this.alpha_lbl);
            this.panel_left.Controls.Add(this.alpha_txt);
            this.panel_left.Controls.Add(this.lembur_lbl);
            this.panel_left.Controls.Add(this.lembur_txt);
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 4);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(350, 536);
            this.panel_left.TabIndex = 1;
            this.panel_left.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_left_Paint);
            // 
            // periodeKaryawan_lbl
            // 
            this.periodeKaryawan_lbl.AutoSize = true;
            this.periodeKaryawan_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.periodeKaryawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.periodeKaryawan_lbl.Location = new System.Drawing.Point(20, 20);
            this.periodeKaryawan_lbl.Name = "periodeKaryawan_lbl";
            this.periodeKaryawan_lbl.Size = new System.Drawing.Size(174, 21);
            this.periodeKaryawan_lbl.TabIndex = 0;
            this.periodeKaryawan_lbl.Text = "PERIODE & KARYAWAN";
            // 
            // bulan_lbl
            // 
            this.bulan_lbl.AutoSize = true;
            this.bulan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bulan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.bulan_lbl.Location = new System.Drawing.Point(20, 50);
            this.bulan_lbl.Name = "bulan_lbl";
            this.bulan_lbl.Size = new System.Drawing.Size(46, 20);
            this.bulan_lbl.TabIndex = 1;
            this.bulan_lbl.Text = "Bulan";
            // 
            // bulan_cmb
            // 
            this.bulan_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bulan_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bulan_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bulan_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bulan_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.bulan_cmb.FormattingEnabled = true;
            this.bulan_cmb.Items.AddRange(new object[] {
            "Januari",
            "Februari",
            "Maret",
            "April",
            "Mei",
            "Juni",
            "Juli",
            "Agustus",
            "September",
            "Oktober",
            "November",
            "Desember"});
            this.bulan_cmb.Location = new System.Drawing.Point(23, 70);
            this.bulan_cmb.Name = "bulan_cmb";
            this.bulan_cmb.Size = new System.Drawing.Size(307, 31);
            this.bulan_cmb.TabIndex = 2;
            this.bulan_cmb.SelectedIndexChanged += new System.EventHandler(this.bulan_cmb_SelectedIndexChanged);
            // 
            // tahun_lbl
            // 
            this.tahun_lbl.AutoSize = true;
            this.tahun_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tahun_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.tahun_lbl.Location = new System.Drawing.Point(20, 108);
            this.tahun_lbl.Name = "tahun_lbl";
            this.tahun_lbl.Size = new System.Drawing.Size(47, 20);
            this.tahun_lbl.TabIndex = 3;
            this.tahun_lbl.Text = "Tahun";
            // 
            // tahun_txt
            // 
            this.tahun_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tahun_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tahun_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tahun_txt.ForeColor = System.Drawing.Color.White;
            this.tahun_txt.Location = new System.Drawing.Point(23, 128);
            this.tahun_txt.Name = "tahun_txt";
            this.tahun_txt.Size = new System.Drawing.Size(307, 30);
            this.tahun_txt.TabIndex = 4;
            this.tahun_txt.TextChanged += new System.EventHandler(this.tahun_txt_TextChanged);
            // 
            // karyawan_lbl
            // 
            this.karyawan_lbl.AutoSize = true;
            this.karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.karyawan_lbl.Location = new System.Drawing.Point(20, 168);
            this.karyawan_lbl.Name = "karyawan_lbl";
            this.karyawan_lbl.Size = new System.Drawing.Size(73, 20);
            this.karyawan_lbl.TabIndex = 5;
            this.karyawan_lbl.Text = "Karyawan";
            // 
            // karyawan_cmb
            // 
            this.karyawan_cmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.karyawan_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.karyawan_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.karyawan_cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.karyawan_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.karyawan_cmb.FormattingEnabled = true;
            this.karyawan_cmb.Location = new System.Drawing.Point(23, 188);
            this.karyawan_cmb.Name = "karyawan_cmb";
            this.karyawan_cmb.Size = new System.Drawing.Size(307, 31);
            this.karyawan_cmb.TabIndex = 6;
            this.karyawan_cmb.SelectedIndexChanged += new System.EventHandler(this.karyawan_cmb_SelectedIndexChanged);
            // 
            // divider_panel
            // 
            this.divider_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.divider_panel.Location = new System.Drawing.Point(20, 230);
            this.divider_panel.Name = "divider_panel";
            this.divider_panel.Size = new System.Drawing.Size(310, 1);
            this.divider_panel.TabIndex = 7;
            // 
            // dataKehadiran_lbl
            // 
            this.dataKehadiran_lbl.AutoSize = true;
            this.dataKehadiran_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dataKehadiran_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.dataKehadiran_lbl.Location = new System.Drawing.Point(20, 245);
            this.dataKehadiran_lbl.Name = "dataKehadiran_lbl";
            this.dataKehadiran_lbl.Size = new System.Drawing.Size(148, 21);
            this.dataKehadiran_lbl.TabIndex = 8;
            this.dataKehadiran_lbl.Text = "DATA KEHADIRAN";
            // 
            // hadir_lbl
            // 
            this.hadir_lbl.AutoSize = true;
            this.hadir_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hadir_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.hadir_lbl.Location = new System.Drawing.Point(20, 275);
            this.hadir_lbl.Name = "hadir_lbl";
            this.hadir_lbl.Size = new System.Drawing.Size(46, 20);
            this.hadir_lbl.TabIndex = 9;
            this.hadir_lbl.Text = "Hadir";
            // 
            // hadir_txt
            // 
            this.hadir_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hadir_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hadir_txt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.hadir_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.hadir_txt.Location = new System.Drawing.Point(23, 295);
            this.hadir_txt.Name = "hadir_txt";
            this.hadir_txt.Size = new System.Drawing.Size(145, 30);
            this.hadir_txt.TabIndex = 10;
            this.hadir_txt.Text = "0";
            // 
            // izin_lbl
            // 
            this.izin_lbl.AutoSize = true;
            this.izin_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.izin_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.izin_lbl.Location = new System.Drawing.Point(182, 275);
            this.izin_lbl.Name = "izin_lbl";
            this.izin_lbl.Size = new System.Drawing.Size(32, 20);
            this.izin_lbl.TabIndex = 11;
            this.izin_lbl.Text = "Izin";
            // 
            // izin_txt
            // 
            this.izin_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.izin_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.izin_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.izin_txt.ForeColor = System.Drawing.Color.White;
            this.izin_txt.Location = new System.Drawing.Point(185, 295);
            this.izin_txt.Name = "izin_txt";
            this.izin_txt.Size = new System.Drawing.Size(145, 30);
            this.izin_txt.TabIndex = 12;
            this.izin_txt.Text = "0";
            // 
            // sakit_lbl
            // 
            this.sakit_lbl.AutoSize = true;
            this.sakit_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sakit_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.sakit_lbl.Location = new System.Drawing.Point(20, 335);
            this.sakit_lbl.Name = "sakit_lbl";
            this.sakit_lbl.Size = new System.Drawing.Size(41, 20);
            this.sakit_lbl.TabIndex = 13;
            this.sakit_lbl.Text = "Sakit";
            // 
            // sakit_txt
            // 
            this.sakit_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.sakit_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sakit_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sakit_txt.ForeColor = System.Drawing.Color.White;
            this.sakit_txt.Location = new System.Drawing.Point(23, 355);
            this.sakit_txt.Name = "sakit_txt";
            this.sakit_txt.Size = new System.Drawing.Size(145, 30);
            this.sakit_txt.TabIndex = 14;
            this.sakit_txt.Text = "0";
            // 
            // alpha_lbl
            // 
            this.alpha_lbl.AutoSize = true;
            this.alpha_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.alpha_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.alpha_lbl.Location = new System.Drawing.Point(182, 335);
            this.alpha_lbl.Name = "alpha_lbl";
            this.alpha_lbl.Size = new System.Drawing.Size(48, 20);
            this.alpha_lbl.TabIndex = 15;
            this.alpha_lbl.Text = "Alpha";
            // 
            // alpha_txt
            // 
            this.alpha_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.alpha_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alpha_txt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.alpha_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.alpha_txt.Location = new System.Drawing.Point(185, 355);
            this.alpha_txt.Name = "alpha_txt";
            this.alpha_txt.Size = new System.Drawing.Size(145, 30);
            this.alpha_txt.TabIndex = 16;
            this.alpha_txt.Text = "0";
            // 
            // lembur_lbl
            // 
            this.lembur_lbl.AutoSize = true;
            this.lembur_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lembur_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.lembur_lbl.Location = new System.Drawing.Point(20, 395);
            this.lembur_lbl.Name = "lembur_lbl";
            this.lembur_lbl.Size = new System.Drawing.Size(98, 20);
            this.lembur_lbl.TabIndex = 17;
            this.lembur_lbl.Text = "Lembur (jam)";
            // 
            // lembur_txt
            // 
            this.lembur_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lembur_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lembur_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lembur_txt.ForeColor = System.Drawing.Color.White;
            this.lembur_txt.Location = new System.Drawing.Point(23, 415);
            this.lembur_txt.Name = "lembur_txt";
            this.lembur_txt.Size = new System.Drawing.Size(307, 30);
            this.lembur_txt.TabIndex = 18;
            this.lembur_txt.Text = "0";
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpan_btn.FlatAppearance.BorderSize = 0;
            this.simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(23, 470);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(145, 35);
            this.simpan_btn.TabIndex = 19;
            this.simpan_btn.Text = "Simpan";
            this.simpan_btn.UseVisualStyleBackColor = false;
            this.simpan_btn.Click += new System.EventHandler(this.simpan_btn_Click);
            // 
            // batal_btn
            // 
            this.batal_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.batal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.batal_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.batal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batal_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.batal_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.batal_btn.Location = new System.Drawing.Point(185, 470);
            this.batal_btn.Name = "batal_btn";
            this.batal_btn.Size = new System.Drawing.Size(145, 35);
            this.batal_btn.TabIndex = 20;
            this.batal_btn.Text = "Batal";
            this.batal_btn.UseVisualStyleBackColor = false;
            this.batal_btn.Click += new System.EventHandler(this.batal_btn_Click);
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.White;
            this.panel_right.Controls.Add(this.cari_txt);
            this.panel_right.Controls.Add(this.belumInput_lbl);
            this.panel_right.Controls.Add(this.absensi_dgv);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(350, 4);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(550, 536);
            this.panel_right.TabIndex = 2;
            // 
            // cari_txt
            // 
            this.cari_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cari_txt.ForeColor = System.Drawing.Color.White;
            this.cari_txt.Location = new System.Drawing.Point(20, 20);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(370, 30);
            this.cari_txt.TabIndex = 0;
            this.cari_txt.Text = "🔍 Cari karyawan...";
            this.cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_txt_MouseClick);
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            this.cari_txt.Leave += new System.EventHandler(this.cari_txt_Leave);
            // 
            // belumInput_lbl
            // 
            this.belumInput_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(23)))));
            this.belumInput_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.belumInput_lbl.ForeColor = System.Drawing.Color.Black;
            this.belumInput_lbl.Location = new System.Drawing.Point(405, 18);
            this.belumInput_lbl.Name = "belumInput_lbl";
            this.belumInput_lbl.Size = new System.Drawing.Size(125, 27);
            this.belumInput_lbl.TabIndex = 1;
            this.belumInput_lbl.Text = "Belum Input: 0";
            this.belumInput_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // absensi_dgv
            // 
            this.absensi_dgv.AllowUserToAddRows = false;
            this.absensi_dgv.AllowUserToDeleteRows = false;
            this.absensi_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.absensi_dgv.BackgroundColor = System.Drawing.Color.LightYellow;
            this.absensi_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.absensi_dgv.ColumnHeadersHeight = 32;
            this.absensi_dgv.EnableHeadersVisualStyles = false;
            this.absensi_dgv.GridColor = System.Drawing.Color.White;
            this.absensi_dgv.Location = new System.Drawing.Point(20, 65);
            this.absensi_dgv.MultiSelect = false;
            this.absensi_dgv.Name = "absensi_dgv";
            this.absensi_dgv.ReadOnly = true;
            this.absensi_dgv.RowHeadersVisible = false;
            this.absensi_dgv.RowHeadersWidth = 51;
            this.absensi_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.absensi_dgv.Size = new System.Drawing.Size(510, 450);
            this.absensi_dgv.TabIndex = 2;
            this.absensi_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.absensi_dgv_CellClick);
            this.absensi_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.absensi_dgv_CellFormatting);
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
            this.Text = "Input Absensi Bulanan";
            this.Load += new System.EventHandler(this.FormAbsensi_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.absensi_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel accentPanel;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Label periodeKaryawan_lbl;
        private System.Windows.Forms.Label bulan_lbl;
        private System.Windows.Forms.ComboBox bulan_cmb;
        private System.Windows.Forms.Label tahun_lbl;
        private System.Windows.Forms.TextBox tahun_txt;
        private System.Windows.Forms.Label karyawan_lbl;
        private System.Windows.Forms.ComboBox karyawan_cmb;
        private System.Windows.Forms.Panel divider_panel;
        private System.Windows.Forms.Label dataKehadiran_lbl;
        private System.Windows.Forms.Label hadir_lbl;
        private System.Windows.Forms.TextBox hadir_txt;
        private System.Windows.Forms.Label izin_lbl;
        private System.Windows.Forms.TextBox izin_txt;
        private System.Windows.Forms.Label sakit_lbl;
        private System.Windows.Forms.TextBox sakit_txt;
        private System.Windows.Forms.Label alpha_lbl;
        private System.Windows.Forms.TextBox alpha_txt;
        private System.Windows.Forms.Label lembur_lbl;
        private System.Windows.Forms.TextBox lembur_txt;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.TextBox cari_txt;
        private System.Windows.Forms.Label belumInput_lbl;
        private System.Windows.Forms.DataGridView absensi_dgv;
    }
}