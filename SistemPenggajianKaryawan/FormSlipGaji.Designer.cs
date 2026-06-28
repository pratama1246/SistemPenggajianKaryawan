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
            this.panel_left = new System.Windows.Forms.Panel();
            this.cetak_btn = new System.Windows.Forms.Button();
            this.tampilkan_btn = new System.Windows.Forms.Button();
            this.thn_cmb = new System.Windows.Forms.ComboBox();
            this.tahun_lbl = new System.Windows.Forms.Label();
            this.bulan_cmb = new System.Windows.Forms.ComboBox();
            this.bulan_lbl = new System.Windows.Forms.Label();
            this.karyawan_dgv = new System.Windows.Forms.DataGridView();
            this.cari_txt = new System.Windows.Forms.TextBox();
            this.karyawan_lbl = new System.Windows.Forms.Label();
            this.filter_title_lbl = new System.Windows.Forms.Label();
            this.panel_right = new System.Windows.Forms.Panel();
            this.slip_container_panel = new System.Windows.Forms.Panel();
            this.slip_card_panel = new System.Windows.Forms.Panel();
            this.slip_flow_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.slip_title_lbl = new System.Windows.Forms.Label();
            this.company_lbl = new System.Windows.Forms.Label();
            this.period_lbl = new System.Windows.Forms.Label();
            this.line1_pnl = new System.Windows.Forms.Panel();
            this.emp_row_pnl = new System.Windows.Forms.Panel();
            this.avatar_lbl = new System.Windows.Forms.Label();
            this.emp_name_lbl = new System.Windows.Forms.Label();
            this.emp_details_lbl = new System.Windows.Forms.Label();
            this.line2_pnl = new System.Windows.Forms.Panel();
            this.pendapatan_title_lbl = new System.Windows.Forms.Label();
            this.pnl_pendapatan_list = new System.Windows.Forms.TableLayoutPanel();
            this.potongan_title_lbl = new System.Windows.Forms.Label();
            this.pnl_potongan_list = new System.Windows.Forms.TableLayoutPanel();
            this.line3_pnl = new System.Windows.Forms.Panel();
            this.netto_row_pnl = new System.Windows.Forms.Panel();
            this.netto_title_lbl = new System.Windows.Forms.Label();
            this.netto_val_lbl = new System.Windows.Forms.Label();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karyawan_dgv)).BeginInit();
            this.panel_right.SuspendLayout();
            this.slip_container_panel.SuspendLayout();
            this.slip_card_panel.SuspendLayout();
            this.slip_flow_pnl.SuspendLayout();
            this.emp_row_pnl.SuspendLayout();
            this.netto_row_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.cetak_btn);
            this.panel_left.Controls.Add(this.tampilkan_btn);
            this.panel_left.Controls.Add(this.thn_cmb);
            this.panel_left.Controls.Add(this.tahun_lbl);
            this.panel_left.Controls.Add(this.bulan_cmb);
            this.panel_left.Controls.Add(this.bulan_lbl);
            this.panel_left.Controls.Add(this.karyawan_dgv);
            this.panel_left.Controls.Add(this.cari_txt);
            this.panel_left.Controls.Add(this.karyawan_lbl);
            this.panel_left.Controls.Add(this.filter_title_lbl);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(280, 649);
            this.panel_left.TabIndex = 1;
            // 
            // cetak_btn
            // 
            this.cetak_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.cetak_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cetak_btn.FlatAppearance.BorderSize = 0;
            this.cetak_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cetak_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cetak_btn.ForeColor = System.Drawing.Color.White;
            this.cetak_btn.Location = new System.Drawing.Point(20, 500);
            this.cetak_btn.Name = "cetak_btn";
            this.cetak_btn.Size = new System.Drawing.Size(240, 36);
            this.cetak_btn.TabIndex = 9;
            this.cetak_btn.Text = "Cetak PDF";
            this.cetak_btn.UseVisualStyleBackColor = false;
            this.cetak_btn.Click += new System.EventHandler(this.cetak_btn_Click);
            // 
            // tampilkan_btn
            // 
            this.tampilkan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.tampilkan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tampilkan_btn.FlatAppearance.BorderSize = 0;
            this.tampilkan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tampilkan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tampilkan_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tampilkan_btn.Location = new System.Drawing.Point(20, 455);
            this.tampilkan_btn.Name = "tampilkan_btn";
            this.tampilkan_btn.Size = new System.Drawing.Size(240, 36);
            this.tampilkan_btn.TabIndex = 8;
            this.tampilkan_btn.Text = "Tampilkan";
            this.tampilkan_btn.UseVisualStyleBackColor = false;
            this.tampilkan_btn.Click += new System.EventHandler(this.tampilkan_btn_Click);
            // 
            // thn_cmb
            // 
            this.thn_cmb.BackColor = System.Drawing.Color.White;
            this.thn_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thn_cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thn_cmb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.thn_cmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.thn_cmb.FormattingEnabled = true;
            this.thn_cmb.Location = new System.Drawing.Point(20, 405);
            this.thn_cmb.Name = "thn_cmb";
            this.thn_cmb.Size = new System.Drawing.Size(240, 25);
            this.thn_cmb.TabIndex = 7;
            // 
            // tahun_lbl
            // 
            this.tahun_lbl.AutoSize = true;
            this.tahun_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tahun_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.tahun_lbl.Location = new System.Drawing.Point(20, 380);
            this.tahun_lbl.Name = "tahun_lbl";
            this.tahun_lbl.Size = new System.Drawing.Size(40, 15);
            this.tahun_lbl.TabIndex = 6;
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
            this.bulan_cmb.Location = new System.Drawing.Point(20, 335);
            this.bulan_cmb.Name = "bulan_cmb";
            this.bulan_cmb.Size = new System.Drawing.Size(240, 25);
            this.bulan_cmb.TabIndex = 5;
            // 
            // bulan_lbl
            // 
            this.bulan_lbl.AutoSize = true;
            this.bulan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bulan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.bulan_lbl.Location = new System.Drawing.Point(20, 310);
            this.bulan_lbl.Name = "bulan_lbl";
            this.bulan_lbl.Size = new System.Drawing.Size(37, 15);
            this.bulan_lbl.TabIndex = 4;
            this.bulan_lbl.Text = "Bulan";
            // 
            // karyawan_dgv
            // 
            this.karyawan_dgv.AllowUserToAddRows = false;
            this.karyawan_dgv.AllowUserToDeleteRows = false;
            this.karyawan_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.karyawan_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.karyawan_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.karyawan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.karyawan_dgv.Location = new System.Drawing.Point(20, 120);
            this.karyawan_dgv.MultiSelect = false;
            this.karyawan_dgv.Name = "karyawan_dgv";
            this.karyawan_dgv.ReadOnly = true;
            this.karyawan_dgv.RowHeadersVisible = false;
            this.karyawan_dgv.RowHeadersWidth = 62;
            this.karyawan_dgv.RowTemplate.Height = 28;
            this.karyawan_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.karyawan_dgv.Size = new System.Drawing.Size(240, 180);
            this.karyawan_dgv.TabIndex = 3;
            this.karyawan_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.karyawan_dgv_CellClick);
            this.karyawan_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.karyawan_dgv_CellFormatting);
            // 
            // cari_txt
            // 
            this.cari_txt.BackColor = System.Drawing.Color.White;
            this.cari_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cari_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.cari_txt.Location = new System.Drawing.Point(20, 80);
            this.cari_txt.Name = "cari_txt";
            this.cari_txt.Size = new System.Drawing.Size(240, 24);
            this.cari_txt.TabIndex = 2;
            this.cari_txt.Text = "🔍 Cari nama/kode...";
            this.cari_txt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cari_txt_MouseClick);
            this.cari_txt.TextChanged += new System.EventHandler(this.cari_txt_TextChanged);
            this.cari_txt.Leave += new System.EventHandler(this.cari_txt_Leave);
            // 
            // karyawan_lbl
            // 
            this.karyawan_lbl.AutoSize = true;
            this.karyawan_lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.karyawan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.karyawan_lbl.Location = new System.Drawing.Point(20, 56);
            this.karyawan_lbl.Name = "karyawan_lbl";
            this.karyawan_lbl.Size = new System.Drawing.Size(58, 15);
            this.karyawan_lbl.TabIndex = 1;
            this.karyawan_lbl.Text = "Karyawan";
            // 
            // filter_title_lbl
            // 
            this.filter_title_lbl.AutoSize = true;
            this.filter_title_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.filter_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.filter_title_lbl.Location = new System.Drawing.Point(20, 24);
            this.filter_title_lbl.Name = "filter_title_lbl";
            this.filter_title_lbl.Size = new System.Drawing.Size(48, 17);
            this.filter_title_lbl.TabIndex = 0;
            this.filter_title_lbl.Text = "FILTER";
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.slip_container_panel);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(280, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(741, 649);
            this.panel_right.TabIndex = 2;
            // 
            // slip_container_panel
            // 
            this.slip_container_panel.Controls.Add(this.slip_card_panel);
            this.slip_container_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slip_container_panel.Location = new System.Drawing.Point(0, 0);
            this.slip_container_panel.Name = "slip_container_panel";
            this.slip_container_panel.Padding = new System.Windows.Forms.Padding(20);
            this.slip_container_panel.Size = new System.Drawing.Size(741, 649);
            this.slip_container_panel.TabIndex = 0;
            this.slip_container_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.slip_container_panel_Paint);
            // 
            // slip_card_panel
            // 
            this.slip_card_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.slip_card_panel.BackColor = System.Drawing.Color.White;
            this.slip_card_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slip_card_panel.Controls.Add(this.slip_flow_pnl);
            this.slip_card_panel.Location = new System.Drawing.Point(100, 20);
            this.slip_card_panel.Name = "slip_card_panel";
            this.slip_card_panel.Size = new System.Drawing.Size(540, 476);
            this.slip_card_panel.TabIndex = 0;
            // 
            // slip_flow_pnl
            // 
            this.slip_flow_pnl.Controls.Add(this.slip_title_lbl);
            this.slip_flow_pnl.Controls.Add(this.company_lbl);
            this.slip_flow_pnl.Controls.Add(this.period_lbl);
            this.slip_flow_pnl.Controls.Add(this.line1_pnl);
            this.slip_flow_pnl.Controls.Add(this.emp_row_pnl);
            this.slip_flow_pnl.Controls.Add(this.line2_pnl);
            this.slip_flow_pnl.Controls.Add(this.pendapatan_title_lbl);
            this.slip_flow_pnl.Controls.Add(this.pnl_pendapatan_list);
            this.slip_flow_pnl.Controls.Add(this.potongan_title_lbl);
            this.slip_flow_pnl.Controls.Add(this.pnl_potongan_list);
            this.slip_flow_pnl.Controls.Add(this.line3_pnl);
            this.slip_flow_pnl.Controls.Add(this.netto_row_pnl);
            this.slip_flow_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slip_flow_pnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.slip_flow_pnl.Location = new System.Drawing.Point(0, 0);
            this.slip_flow_pnl.Name = "slip_flow_pnl";
            this.slip_flow_pnl.Padding = new System.Windows.Forms.Padding(20);
            this.slip_flow_pnl.Size = new System.Drawing.Size(538, 474);
            this.slip_flow_pnl.TabIndex = 0;
            this.slip_flow_pnl.WrapContents = false;
            // 
            // slip_title_lbl
            // 
            this.slip_title_lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.slip_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.slip_title_lbl.Location = new System.Drawing.Point(20, 20);
            this.slip_title_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.slip_title_lbl.Name = "slip_title_lbl";
            this.slip_title_lbl.Size = new System.Drawing.Size(498, 24);
            this.slip_title_lbl.TabIndex = 0;
            this.slip_title_lbl.Text = "SLIP GAJI";
            this.slip_title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // company_lbl
            // 
            this.company_lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.company_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.company_lbl.Location = new System.Drawing.Point(20, 44);
            this.company_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.company_lbl.Name = "company_lbl";
            this.company_lbl.Size = new System.Drawing.Size(498, 18);
            this.company_lbl.TabIndex = 1;
            this.company_lbl.Text = "Politeknik Negeri Cilacap";
            this.company_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // period_lbl
            // 
            this.period_lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.period_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.period_lbl.Location = new System.Drawing.Point(20, 62);
            this.period_lbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.period_lbl.Name = "period_lbl";
            this.period_lbl.Size = new System.Drawing.Size(498, 16);
            this.period_lbl.TabIndex = 2;
            this.period_lbl.Text = "Periode: Mei 2026";
            this.period_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1_pnl
            // 
            this.line1_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.line1_pnl.Location = new System.Drawing.Point(20, 91);
            this.line1_pnl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 8);
            this.line1_pnl.Name = "line1_pnl";
            this.line1_pnl.Size = new System.Drawing.Size(498, 1);
            this.line1_pnl.TabIndex = 3;
            // 
            // emp_row_pnl
            // 
            this.emp_row_pnl.Controls.Add(this.avatar_lbl);
            this.emp_row_pnl.Controls.Add(this.emp_name_lbl);
            this.emp_row_pnl.Controls.Add(this.emp_details_lbl);
            this.emp_row_pnl.Location = new System.Drawing.Point(20, 100);
            this.emp_row_pnl.Margin = new System.Windows.Forms.Padding(0);
            this.emp_row_pnl.Name = "emp_row_pnl";
            this.emp_row_pnl.Size = new System.Drawing.Size(498, 48);
            this.emp_row_pnl.TabIndex = 4;
            // 
            // avatar_lbl
            // 
            this.avatar_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.avatar_lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.avatar_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.avatar_lbl.Location = new System.Drawing.Point(0, 4);
            this.avatar_lbl.Name = "avatar_lbl";
            this.avatar_lbl.Size = new System.Drawing.Size(40, 40);
            this.avatar_lbl.TabIndex = 0;
            this.avatar_lbl.Text = "AH";
            this.avatar_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emp_name_lbl
            // 
            this.emp_name_lbl.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.emp_name_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.emp_name_lbl.Location = new System.Drawing.Point(50, 4);
            this.emp_name_lbl.Name = "emp_name_lbl";
            this.emp_name_lbl.Size = new System.Drawing.Size(448, 20);
            this.emp_name_lbl.TabIndex = 1;
            this.emp_name_lbl.Text = "Ahmad Hidayat";
            // 
            // emp_details_lbl
            // 
            this.emp_details_lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.emp_details_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.emp_details_lbl.Location = new System.Drawing.Point(50, 24);
            this.emp_details_lbl.Name = "emp_details_lbl";
            this.emp_details_lbl.Size = new System.Drawing.Size(448, 16);
            this.emp_details_lbl.TabIndex = 2;
            this.emp_details_lbl.Text = "KRY-001 · Staff IT · Tetap";
            // 
            // line2_pnl
            // 
            this.line2_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.line2_pnl.Location = new System.Drawing.Point(20, 153);
            this.line2_pnl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 8);
            this.line2_pnl.Name = "line2_pnl";
            this.line2_pnl.Size = new System.Drawing.Size(498, 1);
            this.line2_pnl.TabIndex = 5;
            // 
            // pendapatan_title_lbl
            // 
            this.pendapatan_title_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pendapatan_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pendapatan_title_lbl.Location = new System.Drawing.Point(20, 167);
            this.pendapatan_title_lbl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pendapatan_title_lbl.Name = "pendapatan_title_lbl";
            this.pendapatan_title_lbl.Size = new System.Drawing.Size(498, 16);
            this.pendapatan_title_lbl.TabIndex = 6;
            this.pendapatan_title_lbl.Text = "PENDAPATAN";
            // 
            // pnl_pendapatan_list
            // 
            this.pnl_pendapatan_list.AutoSize = true;
            this.pnl_pendapatan_list.ColumnCount = 2;
            this.pnl_pendapatan_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pnl_pendapatan_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnl_pendapatan_list.Location = new System.Drawing.Point(20, 188);
            this.pnl_pendapatan_list.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnl_pendapatan_list.Name = "pnl_pendapatan_list";
            this.pnl_pendapatan_list.RowCount = 1;
            this.pnl_pendapatan_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnl_pendapatan_list.Size = new System.Drawing.Size(0, 20);
            this.pnl_pendapatan_list.TabIndex = 7;
            // 
            // potongan_title_lbl
            // 
            this.potongan_title_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.potongan_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.potongan_title_lbl.Location = new System.Drawing.Point(20, 221);
            this.potongan_title_lbl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.potongan_title_lbl.Name = "potongan_title_lbl";
            this.potongan_title_lbl.Size = new System.Drawing.Size(498, 16);
            this.potongan_title_lbl.TabIndex = 8;
            this.potongan_title_lbl.Text = "POTONGAN";
            // 
            // pnl_potongan_list
            // 
            this.pnl_potongan_list.AutoSize = true;
            this.pnl_potongan_list.ColumnCount = 2;
            this.pnl_potongan_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pnl_potongan_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnl_potongan_list.Location = new System.Drawing.Point(20, 242);
            this.pnl_potongan_list.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnl_potongan_list.Name = "pnl_potongan_list";
            this.pnl_potongan_list.RowCount = 1;
            this.pnl_potongan_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnl_potongan_list.Size = new System.Drawing.Size(0, 20);
            this.pnl_potongan_list.TabIndex = 9;
            // 
            // line3_pnl
            // 
            this.line3_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.line3_pnl.Location = new System.Drawing.Point(20, 275);
            this.line3_pnl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.line3_pnl.Name = "line3_pnl";
            this.line3_pnl.Size = new System.Drawing.Size(498, 2);
            this.line3_pnl.TabIndex = 10;
            // 
            // netto_row_pnl
            // 
            this.netto_row_pnl.Controls.Add(this.netto_title_lbl);
            this.netto_row_pnl.Controls.Add(this.netto_val_lbl);
            this.netto_row_pnl.Location = new System.Drawing.Point(20, 287);
            this.netto_row_pnl.Margin = new System.Windows.Forms.Padding(0);
            this.netto_row_pnl.Name = "netto_row_pnl";
            this.netto_row_pnl.Size = new System.Drawing.Size(498, 24);
            this.netto_row_pnl.TabIndex = 11;
            // 
            // netto_title_lbl
            // 
            this.netto_title_lbl.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.netto_title_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.netto_title_lbl.Location = new System.Drawing.Point(0, 2);
            this.netto_title_lbl.Name = "netto_title_lbl";
            this.netto_title_lbl.Size = new System.Drawing.Size(200, 20);
            this.netto_title_lbl.TabIndex = 0;
            this.netto_title_lbl.Text = "GAJI BERSIH";
            // 
            // netto_val_lbl
            // 
            this.netto_val_lbl.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.netto_val_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.netto_val_lbl.Location = new System.Drawing.Point(248, 2);
            this.netto_val_lbl.Name = "netto_val_lbl";
            this.netto_val_lbl.Size = new System.Drawing.Size(250, 20);
            this.netto_val_lbl.TabIndex = 1;
            this.netto_val_lbl.Text = "Rp 0";
            this.netto_val_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormSlipGaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1021, 649);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSlipGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slip Gaji Karyawan";
            this.Load += new System.EventHandler(this.FormSlipGaji_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karyawan_dgv)).EndInit();
            this.panel_right.ResumeLayout(false);
            this.slip_container_panel.ResumeLayout(false);
            this.slip_card_panel.ResumeLayout(false);
            this.slip_flow_pnl.ResumeLayout(false);
            this.slip_flow_pnl.PerformLayout();
            this.emp_row_pnl.ResumeLayout(false);
            this.netto_row_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label filter_title_lbl;
        private System.Windows.Forms.Label karyawan_lbl;
        private System.Windows.Forms.TextBox cari_txt;
        private System.Windows.Forms.DataGridView karyawan_dgv;
        private System.Windows.Forms.Label bulan_lbl;
        private System.Windows.Forms.ComboBox bulan_cmb;
        private System.Windows.Forms.Label tahun_lbl;
        private System.Windows.Forms.ComboBox thn_cmb;
        private System.Windows.Forms.Button tampilkan_btn;
        private System.Windows.Forms.Button cetak_btn;
        private System.Windows.Forms.Panel slip_container_panel;
        private System.Windows.Forms.Panel slip_card_panel;
        private System.Windows.Forms.FlowLayoutPanel slip_flow_pnl;
        private System.Windows.Forms.Label slip_title_lbl;
        private System.Windows.Forms.Label company_lbl;
        private System.Windows.Forms.Label period_lbl;
        private System.Windows.Forms.Panel line1_pnl;
        private System.Windows.Forms.Panel emp_row_pnl;
        private System.Windows.Forms.Label avatar_lbl;
        private System.Windows.Forms.Label emp_name_lbl;
        private System.Windows.Forms.Label emp_details_lbl;
        private System.Windows.Forms.Panel line2_pnl;
        private System.Windows.Forms.Label pendapatan_title_lbl;
        private System.Windows.Forms.TableLayoutPanel pnl_pendapatan_list;
        private System.Windows.Forms.Label potongan_title_lbl;
        private System.Windows.Forms.TableLayoutPanel pnl_potongan_list;
        private System.Windows.Forms.Panel line3_pnl;
        private System.Windows.Forms.Panel netto_row_pnl;
        private System.Windows.Forms.Label netto_title_lbl;
        private System.Windows.Forms.Label netto_val_lbl;
    }
}