namespace SistemPenggajianKaryawan
{
    partial class FormLogin
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
            this.panel_left      = new System.Windows.Forms.Panel();
            this.logoPic         = new System.Windows.Forms.PictureBox();
            this.appName_lbl     = new System.Windows.Forms.Label();
            this.kampus_lbl      = new System.Windows.Forms.Label();
            this.panel_right     = new System.Windows.Forms.Panel();
            this.title_lbl       = new System.Windows.Forms.Label();
            this.subtitle_lbl    = new System.Windows.Forms.Label();
            this.username_lbl    = new System.Windows.Forms.Label();
            this.username_txt    = new System.Windows.Forms.TextBox();
            this.password_lbl    = new System.Windows.Forms.Label();
            this.password_txt    = new System.Windows.Forms.TextBox();
            this.login_btn       = new System.Windows.Forms.Button();
            this.error_lbl       = new System.Windows.Forms.Label();
            this.accentPanel     = new System.Windows.Forms.Panel();
            this.version_lbl     = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.ClientSize        = new System.Drawing.Size(780, 460);
            this.BackColor         = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle   = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox       = false;
            this.StartPosition     = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text              = "Login - Sistem Penggajian Karyawan";
            this.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.Load             += new System.EventHandler(this.FormLogin_Load);

            // accentPanel (garis atas biru, konsisten sama splash)
            this.accentPanel.Location  = new System.Drawing.Point(0, 0);
            this.accentPanel.Size      = new System.Drawing.Size(780, 4);
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);

            // panel_left (sisi kiri, dark)
            this.panel_left.Location  = new System.Drawing.Point(0, 4);
            this.panel_left.Size      = new System.Drawing.Size(320, 456);
            this.panel_left.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);

            // logoPic
            this.logoPic.Location  = new System.Drawing.Point(110, 80);
            this.logoPic.Size      = new System.Drawing.Size(100, 100);
            this.logoPic.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.logoPic.Paint    += new System.Windows.Forms.PaintEventHandler(this.logoPic_Paint);

            // appName_lbl
            this.appName_lbl.Text      = "Sistem Penggajian";
            this.appName_lbl.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.appName_lbl.ForeColor = System.Drawing.Color.White;
            this.appName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.appName_lbl.Location  = new System.Drawing.Point(10, 200);
            this.appName_lbl.Size      = new System.Drawing.Size(300, 30);

            // kampus_lbl
            this.kampus_lbl.Text      = "Politeknik Negeri Cilacap";
            this.kampus_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.kampus_lbl.ForeColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.kampus_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kampus_lbl.Location  = new System.Drawing.Point(10, 234);
            this.kampus_lbl.Size      = new System.Drawing.Size(300, 22);

            // panel_right (sisi kanan, form input)
            this.panel_right.Location  = new System.Drawing.Point(320, 4);
            this.panel_right.Size      = new System.Drawing.Size(460, 456);
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            // title_lbl
            this.title_lbl.Text      = "Selamat Datang";
            this.title_lbl.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.title_lbl.ForeColor = System.Drawing.Color.White;
            this.title_lbl.Location  = new System.Drawing.Point(50, 80);
            this.title_lbl.Size      = new System.Drawing.Size(360, 40);

            // subtitle_lbl
            this.subtitle_lbl.Text      = "Masuk ke akun Anda untuk melanjutkan";
            this.subtitle_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.subtitle_lbl.ForeColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.subtitle_lbl.Location  = new System.Drawing.Point(50, 124);
            this.subtitle_lbl.Size      = new System.Drawing.Size(360, 20);

            // username_lbl
            this.username_lbl.Text      = "Username";
            this.username_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.username_lbl.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.username_lbl.Location  = new System.Drawing.Point(50, 180);
            this.username_lbl.Size      = new System.Drawing.Size(360, 20);

            // username_txt
            this.username_txt.Location      = new System.Drawing.Point(50, 202);
            this.username_txt.Size          = new System.Drawing.Size(360, 23);
            this.username_txt.BackColor     = System.Drawing.Color.FromArgb(50, 50, 50);
            this.username_txt.ForeColor     = System.Drawing.Color.White;
            this.username_txt.BorderStyle   = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_txt.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.username_txt.KeyDown      += new System.Windows.Forms.KeyEventHandler(this.username_txt_KeyDown);

            // password_lbl
            this.password_lbl.Text      = "Password";
            this.password_lbl.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.password_lbl.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.password_lbl.Location  = new System.Drawing.Point(50, 248);
            this.password_lbl.Size      = new System.Drawing.Size(360, 20);

            // password_txt
            this.password_txt.Location      = new System.Drawing.Point(50, 270);
            this.password_txt.Size          = new System.Drawing.Size(360, 23);
            this.password_txt.BackColor     = System.Drawing.Color.FromArgb(50, 50, 50);
            this.password_txt.ForeColor     = System.Drawing.Color.White;
            this.password_txt.BorderStyle   = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_txt.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.password_txt.PasswordChar  = '●';
            this.password_txt.KeyDown      += new System.Windows.Forms.KeyEventHandler(this.password_txt_KeyDown);

            // error_lbl
            this.error_lbl.Text      = "";
            this.error_lbl.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.error_lbl.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.error_lbl.Location  = new System.Drawing.Point(50, 302);
            this.error_lbl.Size      = new System.Drawing.Size(360, 20);
            this.error_lbl.Visible   = false;

            // login_btn
            this.login_btn.Text      = "Masuk";
            this.login_btn.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.login_btn.Location  = new System.Drawing.Point(50, 334);
            this.login_btn.Size      = new System.Drawing.Size(360, 38);
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(91, 200, 245);
            this.login_btn.ForeColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.login_btn.Click    += new System.EventHandler(this.login_btn_Click);

            // version_lbl
            this.version_lbl.Text      = "v1.0.0";
            this.version_lbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.version_lbl.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.version_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.version_lbl.Location  = new System.Drawing.Point(350, 428);
            this.version_lbl.Size      = new System.Drawing.Size(60, 16);

            // Tambahin ke panel_left
            this.panel_left.Controls.Add(this.logoPic);
            this.panel_left.Controls.Add(this.appName_lbl);
            this.panel_left.Controls.Add(this.kampus_lbl);

            // Tambahin ke panel_right
            this.panel_right.Controls.Add(this.title_lbl);
            this.panel_right.Controls.Add(this.subtitle_lbl);
            this.panel_right.Controls.Add(this.username_lbl);
            this.panel_right.Controls.Add(this.username_txt);
            this.panel_right.Controls.Add(this.password_lbl);
            this.panel_right.Controls.Add(this.password_txt);
            this.panel_right.Controls.Add(this.error_lbl);
            this.panel_right.Controls.Add(this.login_btn);
            this.panel_right.Controls.Add(this.version_lbl);

            // Tambahin ke Form
            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_right);

            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel      panel_left;
        private System.Windows.Forms.Panel      panel_right;
        private System.Windows.Forms.Panel      accentPanel;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Label      appName_lbl;
        private System.Windows.Forms.Label      kampus_lbl;
        private System.Windows.Forms.Label      title_lbl;
        private System.Windows.Forms.Label      subtitle_lbl;
        private System.Windows.Forms.Label      username_lbl;
        private System.Windows.Forms.TextBox    username_txt;
        private System.Windows.Forms.Label      password_lbl;
        private System.Windows.Forms.TextBox    password_txt;
        private System.Windows.Forms.Label      error_lbl;
        private System.Windows.Forms.Button     login_btn;
        private System.Windows.Forms.Label      version_lbl;
    }
}
