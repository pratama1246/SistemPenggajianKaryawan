using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public class FormAuthExit : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblError;
        private Button btnVerify;
        private Button btnCancel;
        private Auth_serv auth = new Auth_serv();

        public FormAuthExit()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Otorisasi Keluar Kiosk";
            this.Size = new Size(380, 260);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(244, 246, 249); // bg-base
            this.Font = new Font("Segoe UI", 9F);

            // Accent Bar
            Panel accentBar = new Panel();
            accentBar.Location = new Point(0, 0);
            accentBar.Size = new Size(380, 4);
            accentBar.BackColor = Color.FromArgb(91, 200, 245); // primary
            this.Controls.Add(accentBar);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Verifikasi Admin / HRD";
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 55, 72); // text-primary
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(340, 25);
            this.Controls.Add(lblTitle);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Masukkan username dan password admin untuk keluar.";
            lblSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblSubtitle.ForeColor = Color.FromArgb(113, 128, 150); // text-secondary
            lblSubtitle.Location = new Point(20, 40);
            lblSubtitle.Size = new Size(340, 20);
            this.Controls.Add(lblSubtitle);

            // Username Label & TextBox
            Label lblUser = new Label();
            lblUser.Text = "Username";
            lblUser.Location = new Point(20, 65);
            lblUser.Size = new Size(340, 18);
            lblUser.ForeColor = Color.FromArgb(74, 85, 104);
            this.Controls.Add(lblUser);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(20, 85);
            txtUsername.Size = new Size(325, 25);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 9.5F);
            this.Controls.Add(txtUsername);

            // Password Label & TextBox
            Label lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.Location = new Point(20, 115);
            lblPass.Size = new Size(340, 18);
            lblPass.ForeColor = Color.FromArgb(74, 85, 104);
            this.Controls.Add(lblPass);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(20, 135);
            txtPassword.Size = new Size(325, 25);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            this.Controls.Add(txtPassword);

            // Error Label
            lblError = new Label();
            lblError.Location = new Point(20, 163);
            lblError.Size = new Size(340, 18);
            lblError.ForeColor = Color.FromArgb(220, 38, 38);
            lblError.Font = new Font("Segoe UI", 8F);
            lblError.Text = "";
            this.Controls.Add(lblError);

            // Cancel Button
            btnCancel = new Button();
            btnCancel.Text = "Batal";
            btnCancel.Location = new Point(255, 185);
            btnCancel.Size = new Size(90, 30);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;
            this.Controls.Add(btnCancel);

            // Verify Button
            btnVerify = new Button();
            btnVerify.Text = "Verifikasi";
            btnVerify.Location = new Point(155, 185);
            btnVerify.Size = new Size(90, 30);
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.BackColor = Color.FromArgb(30, 144, 255); // primary-dark / Simpan
            btnVerify.ForeColor = Color.White;
            btnVerify.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVerify.Cursor = Cursors.Hand;
            btnVerify.Click += btnVerify_Click;
            this.Controls.Add(btnVerify);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                VerifyCredentials();
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            VerifyCredentials();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void VerifyCredentials()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Username dan password tidak boleh kosong.";
                return;
            }

            try
            {
                DataTable dt = auth.login(username, password);
                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["role"].ToString();
                    if (role == "Admin" || role == "HRD")
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lblError.Text = "Akses ditolak. Harus akun Admin atau HRD.";
                    }
                }
                else
                {
                    lblError.Text = "Username atau password salah.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Gagal memverifikasi: " + ex.Message;
            }
        }
    }
}
