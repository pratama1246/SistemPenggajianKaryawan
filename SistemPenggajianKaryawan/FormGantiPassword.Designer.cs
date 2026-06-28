namespace SistemPenggajianKaryawan
{
    partial class FormGantiPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGantiPassword));
            this.panel_left = new System.Windows.Forms.Panel();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.batal_btn = new System.Windows.Forms.Button();
            this.txt_konfirmasi_password = new System.Windows.Forms.TextBox();
            this.showPwKonfirmasi_btn = new System.Windows.Forms.Button();
            this.lbl_konfirmasi_password = new System.Windows.Forms.Label();
            this.txt_password_baru = new System.Windows.Forms.TextBox();
            this.showPwBaru_btn = new System.Windows.Forms.Button();
            this.lbl_password_baru = new System.Windows.Forms.Label();
            this.txt_password_lama = new System.Windows.Forms.TextBox();
            this.showPwLama_btn = new System.Windows.Forms.Button();
            this.lbl_password_lama = new System.Windows.Forms.Label();
            this.judul_lbl = new System.Windows.Forms.Label();
            this.panel_right = new System.Windows.Forms.Panel();
            this.lbl_tips_body = new System.Windows.Forms.Label();
            this.lbl_tips_title = new System.Windows.Forms.Label();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.White;
            this.panel_left.Controls.Add(this.simpan_btn);
            this.panel_left.Controls.Add(this.batal_btn);
            this.panel_left.Controls.Add(this.txt_konfirmasi_password);
            this.panel_left.Controls.Add(this.showPwKonfirmasi_btn);
            this.panel_left.Controls.Add(this.lbl_konfirmasi_password);
            this.panel_left.Controls.Add(this.txt_password_baru);
            this.panel_left.Controls.Add(this.showPwBaru_btn);
            this.panel_left.Controls.Add(this.lbl_password_baru);
            this.panel_left.Controls.Add(this.txt_password_lama);
            this.panel_left.Controls.Add(this.showPwLama_btn);
            this.panel_left.Controls.Add(this.lbl_password_lama);
            this.panel_left.Controls.Add(this.judul_lbl);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(340, 540);
            this.panel_left.TabIndex = 1;
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.simpan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpan_btn.FlatAppearance.BorderSize = 0;
            this.simpan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(23, 310);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(294, 36);
            this.simpan_btn.TabIndex = 9;
            this.simpan_btn.Text = "Simpan Password";
            this.simpan_btn.UseVisualStyleBackColor = false;
            this.simpan_btn.Click += new System.EventHandler(this.simpan_btn_Click);
            // 
            // batal_btn
            // 
            this.batal_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.batal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.batal_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.batal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batal_btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.batal_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.batal_btn.Location = new System.Drawing.Point(23, 356);
            this.batal_btn.Name = "batal_btn";
            this.batal_btn.Size = new System.Drawing.Size(294, 36);
            this.batal_btn.TabIndex = 10;
            this.batal_btn.Text = "Batal";
            this.batal_btn.UseVisualStyleBackColor = false;
            this.batal_btn.Click += new System.EventHandler(this.batal_btn_Click);
            // 
            // txt_konfirmasi_password
            // 
            this.txt_konfirmasi_password.BackColor = System.Drawing.Color.White;
            this.txt_konfirmasi_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_konfirmasi_password.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_konfirmasi_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_konfirmasi_password.Location = new System.Drawing.Point(23, 250);
            this.txt_konfirmasi_password.Name = "txt_konfirmasi_password";
            this.txt_konfirmasi_password.Size = new System.Drawing.Size(256, 25);
            this.txt_konfirmasi_password.TabIndex = 7;
            this.txt_konfirmasi_password.UseSystemPasswordChar = true;
            // 
            // showPwKonfirmasi_btn
            // 
            this.showPwKonfirmasi_btn.BackColor = System.Drawing.Color.White;
            this.showPwKonfirmasi_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwKonfirmasi_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.showPwKonfirmasi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPwKonfirmasi_btn.Location = new System.Drawing.Point(287, 250);
            this.showPwKonfirmasi_btn.Name = "showPwKonfirmasi_btn";
            this.showPwKonfirmasi_btn.Size = new System.Drawing.Size(30, 30);
            this.showPwKonfirmasi_btn.TabIndex = 8;
            this.showPwKonfirmasi_btn.UseVisualStyleBackColor = false;
            this.showPwKonfirmasi_btn.Click += new System.EventHandler(this.showPwKonfirmasi_btn_Click);
            this.showPwKonfirmasi_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.showPwKonfirmasi_btn_Paint);
            // 
            // lbl_konfirmasi_password
            // 
            this.lbl_konfirmasi_password.AutoSize = true;
            this.lbl_konfirmasi_password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_konfirmasi_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lbl_konfirmasi_password.Location = new System.Drawing.Point(20, 227);
            this.lbl_konfirmasi_password.Name = "lbl_konfirmasi_password";
            this.lbl_konfirmasi_password.Size = new System.Drawing.Size(144, 15);
            this.lbl_konfirmasi_password.TabIndex = 6;
            this.lbl_konfirmasi_password.Text = "Konfirmasi Password Baru";
            // 
            // txt_password_baru
            // 
            this.txt_password_baru.BackColor = System.Drawing.Color.White;
            this.txt_password_baru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_password_baru.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_password_baru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_password_baru.Location = new System.Drawing.Point(23, 175);
            this.txt_password_baru.Name = "txt_password_baru";
            this.txt_password_baru.Size = new System.Drawing.Size(256, 25);
            this.txt_password_baru.TabIndex = 5;
            this.txt_password_baru.UseSystemPasswordChar = true;
            // 
            // showPwBaru_btn
            // 
            this.showPwBaru_btn.BackColor = System.Drawing.Color.White;
            this.showPwBaru_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwBaru_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.showPwBaru_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPwBaru_btn.Location = new System.Drawing.Point(287, 175);
            this.showPwBaru_btn.Name = "showPwBaru_btn";
            this.showPwBaru_btn.Size = new System.Drawing.Size(30, 30);
            this.showPwBaru_btn.TabIndex = 6;
            this.showPwBaru_btn.UseVisualStyleBackColor = false;
            this.showPwBaru_btn.Click += new System.EventHandler(this.showPwBaru_btn_Click);
            this.showPwBaru_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.showPwBaru_btn_Paint);
            // 
            // lbl_password_baru
            // 
            this.lbl_password_baru.AutoSize = true;
            this.lbl_password_baru.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_password_baru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lbl_password_baru.Location = new System.Drawing.Point(20, 152);
            this.lbl_password_baru.Name = "lbl_password_baru";
            this.lbl_password_baru.Size = new System.Drawing.Size(84, 15);
            this.lbl_password_baru.TabIndex = 4;
            this.lbl_password_baru.Text = "Password Baru";
            // 
            // txt_password_lama
            // 
            this.txt_password_lama.BackColor = System.Drawing.Color.White;
            this.txt_password_lama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_password_lama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_password_lama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_password_lama.Location = new System.Drawing.Point(23, 100);
            this.txt_password_lama.Name = "txt_password_lama";
            this.txt_password_lama.Size = new System.Drawing.Size(256, 25);
            this.txt_password_lama.TabIndex = 3;
            this.txt_password_lama.UseSystemPasswordChar = true;
            // 
            // showPwLama_btn
            // 
            this.showPwLama_btn.BackColor = System.Drawing.Color.White;
            this.showPwLama_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwLama_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.showPwLama_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPwLama_btn.Location = new System.Drawing.Point(287, 100);
            this.showPwLama_btn.Name = "showPwLama_btn";
            this.showPwLama_btn.Size = new System.Drawing.Size(30, 30);
            this.showPwLama_btn.TabIndex = 4;
            this.showPwLama_btn.UseVisualStyleBackColor = false;
            this.showPwLama_btn.Click += new System.EventHandler(this.showPwLama_btn_Click);
            this.showPwLama_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.showPwLama_btn_Paint);
            // 
            // lbl_password_lama
            // 
            this.lbl_password_lama.AutoSize = true;
            this.lbl_password_lama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_password_lama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lbl_password_lama.Location = new System.Drawing.Point(20, 77);
            this.lbl_password_lama.Name = "lbl_password_lama";
            this.lbl_password_lama.Size = new System.Drawing.Size(89, 15);
            this.lbl_password_lama.TabIndex = 2;
            this.lbl_password_lama.Text = "Password Lama";
            // 
            // judul_lbl
            // 
            this.judul_lbl.AutoSize = true;
            this.judul_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.judul_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.judul_lbl.Location = new System.Drawing.Point(20, 20);
            this.judul_lbl.Name = "judul_lbl";
            this.judul_lbl.Size = new System.Drawing.Size(193, 21);
            this.judul_lbl.TabIndex = 1;
            this.judul_lbl.Text = "Pengamanan Akun User";
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel_right.Controls.Add(this.lbl_tips_body);
            this.panel_right.Controls.Add(this.lbl_tips_title);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(340, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(560, 540);
            this.panel_right.TabIndex = 2;
            // 
            // lbl_tips_body
            // 
            this.lbl_tips_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tips_body.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_tips_body.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lbl_tips_body.Location = new System.Drawing.Point(30, 77);
            this.lbl_tips_body.Name = "lbl_tips_body";
            this.lbl_tips_body.Size = new System.Drawing.Size(500, 319);
            this.lbl_tips_body.TabIndex = 1;
            this.lbl_tips_body.Text = resources.GetString("lbl_tips_body.Text");
            // 
            // lbl_tips_title
            // 
            this.lbl_tips_title.AutoSize = true;
            this.lbl_tips_title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_tips_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lbl_tips_title.Location = new System.Drawing.Point(30, 20);
            this.lbl_tips_title.Name = "lbl_tips_title";
            this.lbl_tips_title.Size = new System.Drawing.Size(190, 20);
            this.lbl_tips_title.TabIndex = 0;
            this.lbl_tips_title.Text = "Panduan Keamanan Sandi";
            // 
            // FormGantiPassword
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_left);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGantiPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ganti Password User";
            this.Load += new System.EventHandler(this.FormGantiPassword_Load);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label judul_lbl;
        private System.Windows.Forms.Label lbl_password_lama;
        private System.Windows.Forms.TextBox txt_password_lama;
        private System.Windows.Forms.Button showPwLama_btn;
        private System.Windows.Forms.Label lbl_password_baru;
        private System.Windows.Forms.TextBox txt_password_baru;
        private System.Windows.Forms.Button showPwBaru_btn;
        private System.Windows.Forms.Label lbl_konfirmasi_password;
        private System.Windows.Forms.TextBox txt_konfirmasi_password;
        private System.Windows.Forms.Button showPwKonfirmasi_btn;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Button batal_btn;
        private System.Windows.Forms.Label lbl_tips_title;
        private System.Windows.Forms.Label lbl_tips_body;
    }
}
