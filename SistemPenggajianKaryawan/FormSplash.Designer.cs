namespace SistemPenggajianKaryawan
{
    partial class FormSplash
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.appName_lbl = new System.Windows.Forms.Label();
            this.kampus_lbl = new System.Windows.Forms.Label();
            this.loading_bar = new System.Windows.Forms.ProgressBar();
            this.status_lbl = new System.Windows.Forms.Label();
            this.version_lbl = new System.Windows.Forms.Label();
            this.accentPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.logoPic.Location = new System.Drawing.Point(214, 30);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(90, 90);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 1;
            this.logoPic.TabStop = false;
            // 
            // appName_lbl
            // 
            this.appName_lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.appName_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.appName_lbl.Location = new System.Drawing.Point(60, 135);
            this.appName_lbl.Name = "appName_lbl";
            this.appName_lbl.Size = new System.Drawing.Size(400, 30);
            this.appName_lbl.TabIndex = 2;
            this.appName_lbl.Text = "Sistem Penggajian Karyawan";
            this.appName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kampus_lbl
            // 
            this.kampus_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.kampus_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.kampus_lbl.Location = new System.Drawing.Point(60, 168);
            this.kampus_lbl.Name = "kampus_lbl";
            this.kampus_lbl.Size = new System.Drawing.Size(400, 24);
            this.kampus_lbl.TabIndex = 3;
            this.kampus_lbl.Text = "Politeknik Negeri Cilacap";
            this.kampus_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loading_bar
            // 
            this.loading_bar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.loading_bar.Location = new System.Drawing.Point(110, 240);
            this.loading_bar.Name = "loading_bar";
            this.loading_bar.Size = new System.Drawing.Size(300, 6);
            this.loading_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loading_bar.TabIndex = 5;
            // 
            // status_lbl
            // 
            this.status_lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.status_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.status_lbl.Location = new System.Drawing.Point(60, 255);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(400, 20);
            this.status_lbl.TabIndex = 6;
            this.status_lbl.Text = "Menginisialisasi aplikasi...";
            this.status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // version_lbl
            // 
            this.version_lbl.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.version_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.version_lbl.Location = new System.Drawing.Point(430, 315);
            this.version_lbl.Name = "version_lbl";
            this.version_lbl.Size = new System.Drawing.Size(80, 16);
            this.version_lbl.TabIndex = 7;
            this.version_lbl.Text = "v1.0.0";
            this.version_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // accentPanel
            // 
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.accentPanel.Location = new System.Drawing.Point(0, 0);
            this.accentPanel.Name = "accentPanel";
            this.accentPanel.Size = new System.Drawing.Size(520, 4);
            this.accentPanel.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormSplash
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(520, 340);
            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.logoPic);
            this.Controls.Add(this.appName_lbl);
            this.Controls.Add(this.kampus_lbl);
            this.Controls.Add(this.loading_bar);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.version_lbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.Load += new System.EventHandler(this.FormSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox  logoPic;
        private System.Windows.Forms.Label       appName_lbl;
        private System.Windows.Forms.Label       kampus_lbl;
        private System.Windows.Forms.ProgressBar loading_bar;
        private System.Windows.Forms.Label       status_lbl;
        private System.Windows.Forms.Label       version_lbl;
        private System.Windows.Forms.Panel       accentPanel;
        private System.Windows.Forms.Timer       timer1;
    }
}
