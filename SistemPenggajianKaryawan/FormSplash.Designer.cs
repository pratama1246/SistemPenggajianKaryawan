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

            this.logoPic     = new System.Windows.Forms.PictureBox();
            this.appName_lbl = new System.Windows.Forms.Label();
            this.kampus_lbl  = new System.Windows.Forms.Label();
            this.matkul_lbl  = new System.Windows.Forms.Label();
            this.loading_bar = new System.Windows.Forms.ProgressBar();
            this.status_lbl  = new System.Windows.Forms.Label();
            this.version_lbl = new System.Windows.Forms.Label();
            this.accentPanel = new System.Windows.Forms.Panel();
            this.timer1      = new System.Windows.Forms.Timer(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize        = new System.Drawing.Size(520, 340);
            this.BackColor         = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle   = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition     = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text              = "Loading...";
            this.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.Load             += new System.EventHandler(this.FormSplash_Load);

            // accentPanel
            this.accentPanel.Location  = new System.Drawing.Point(0, 0);
            this.accentPanel.Size      = new System.Drawing.Size(520, 4);
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);

            // logoPic
            this.logoPic.Location  = new System.Drawing.Point(214, 30);
            this.logoPic.Size      = new System.Drawing.Size(90, 90);
            this.logoPic.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.logoPic.Paint    += new System.Windows.Forms.PaintEventHandler(this.logoPic_Paint);

            // appName_lbl
            this.appName_lbl.Text      = "Sistem Penggajian Karyawan";
            this.appName_lbl.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.appName_lbl.ForeColor = System.Drawing.Color.White;
            this.appName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName_lbl.Location  = new System.Drawing.Point(60, 135);
            this.appName_lbl.Size      = new System.Drawing.Size(400, 30);

            // kampus_lbl
            this.kampus_lbl.Text      = "Politeknik Negeri Cilacap";
            this.kampus_lbl.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.kampus_lbl.ForeColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.kampus_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kampus_lbl.Location  = new System.Drawing.Point(60, 168);
            this.kampus_lbl.Size      = new System.Drawing.Size(400, 24);

            // matkul_lbl
            this.matkul_lbl.Text      = "Pemrograman Berorientasi Objek  -  2025";
            this.matkul_lbl.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.matkul_lbl.ForeColor = System.Drawing.Color.FromArgb(245, 166, 35);
            this.matkul_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.matkul_lbl.Location  = new System.Drawing.Point(60, 194);
            this.matkul_lbl.Size      = new System.Drawing.Size(400, 20);

            // loading_bar
            this.loading_bar.Location  = new System.Drawing.Point(110, 240);
            this.loading_bar.Size      = new System.Drawing.Size(300, 6);
            this.loading_bar.Minimum   = 0;
            this.loading_bar.Maximum   = 100;
            this.loading_bar.Value     = 0;
            this.loading_bar.Style     = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loading_bar.ForeColor = System.Drawing.Color.FromArgb(91, 200, 245);

            // status_lbl
            this.status_lbl.Text      = "Menginisialisasi aplikasi...";
            this.status_lbl.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.status_lbl.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.status_lbl.Location  = new System.Drawing.Point(60, 255);
            this.status_lbl.Size      = new System.Drawing.Size(400, 20);

            // version_lbl
            this.version_lbl.Text      = "v1.0.0";
            this.version_lbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.version_lbl.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.version_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.version_lbl.Location  = new System.Drawing.Point(430, 315);
            this.version_lbl.Size      = new System.Drawing.Size(80, 16);

            // timer1
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.logoPic);
            this.Controls.Add(this.appName_lbl);
            this.Controls.Add(this.kampus_lbl);
            this.Controls.Add(this.matkul_lbl);
            this.Controls.Add(this.loading_bar);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.version_lbl);

            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox  logoPic;
        private System.Windows.Forms.Label       appName_lbl;
        private System.Windows.Forms.Label       kampus_lbl;
        private System.Windows.Forms.Label       matkul_lbl;
        private System.Windows.Forms.ProgressBar loading_bar;
        private System.Windows.Forms.Label       status_lbl;
        private System.Windows.Forms.Label       version_lbl;
        private System.Windows.Forms.Panel       accentPanel;
        private System.Windows.Forms.Timer       timer1;
    }
}
