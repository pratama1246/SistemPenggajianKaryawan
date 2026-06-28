using System;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormGantiPassword : Form
    {
        private User_serv userService = new User_serv();

        public FormGantiPassword()
        {
            InitializeComponent();
        }

        private void FormGantiPassword_Load(object sender, EventArgs e)
        {
            // Hak akses keamanan: Harus login
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Akses ditolak. Silakan login terlebih dahulu.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bersihkan();
        }

        private void bersihkan()
        {
            txt_password_lama.Clear();
            txt_password_baru.Clear();
            txt_konfirmasi_password.Clear();
            txt_password_lama.Focus();
        }

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            // 1. Validasi field kosong
            if (string.IsNullOrWhiteSpace(txt_password_lama.Text))
            {
                MessageBox.Show("Password Lama tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_password_lama.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_password_baru.Text))
            {
                MessageBox.Show("Password Baru tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_password_baru.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_konfirmasi_password.Text))
            {
                MessageBox.Show("Konfirmasi Password Baru tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_konfirmasi_password.Focus();
                return;
            }

            // 2. Validasi panjang minimal password baru
            if (txt_password_baru.Text.Length < 6)
            {
                MessageBox.Show("Password baru minimal harus terdiri dari 6 karakter.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_password_baru.Focus();
                return;
            }

            // 3. Validasi kecocokan password baru dengan konfirmasinya
            if (txt_password_baru.Text != txt_konfirmasi_password.Text)
            {
                MessageBox.Show("Konfirmasi password baru tidak cocok.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_konfirmasi_password.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                // 4. Verifikasi apakah password lama benar
                if (!userService.verifikasiPasswordLama(UserSession.user_id, txt_password_lama.Text))
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Password lama yang Anda masukkan salah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_password_lama.Focus();
                    return;
                }

                // 5. Eksekusi ganti password
                if (userService.gantiPassword(UserSession.user_id, txt_password_baru.Text) > 0)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Sandi akun Anda berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Gagal menyimpan password baru.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bersihkan();
        }

        private void showPwLama_btn_Click(object sender, EventArgs e)
        {
            txt_password_lama.UseSystemPasswordChar = !txt_password_lama.UseSystemPasswordChar;
            showPwLama_btn.Invalidate();
        }

        private void showPwLama_btn_Paint(object sender, PaintEventArgs e)
        {
            DrawEyeIcon(e.Graphics, showPwLama_btn, txt_password_lama.UseSystemPasswordChar);
        }

        private void showPwBaru_btn_Click(object sender, EventArgs e)
        {
            txt_password_baru.UseSystemPasswordChar = !txt_password_baru.UseSystemPasswordChar;
            showPwBaru_btn.Invalidate();
        }

        private void showPwBaru_btn_Paint(object sender, PaintEventArgs e)
        {
            DrawEyeIcon(e.Graphics, showPwBaru_btn, txt_password_baru.UseSystemPasswordChar);
        }

        private void showPwKonfirmasi_btn_Click(object sender, EventArgs e)
        {
            txt_konfirmasi_password.UseSystemPasswordChar = !txt_konfirmasi_password.UseSystemPasswordChar;
            showPwKonfirmasi_btn.Invalidate();
        }

        private void showPwKonfirmasi_btn_Paint(object sender, PaintEventArgs e)
        {
            DrawEyeIcon(e.Graphics, showPwKonfirmasi_btn, txt_konfirmasi_password.UseSystemPasswordChar);
        }

        private void DrawEyeIcon(System.Drawing.Graphics g, Button btn, bool masked)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            int w = btn.Width;
            int h = btn.Height;
            
            float cx = w / 2f;
            float cy = h / 2f;
            
            using (Pen pen = new Pen(Color.FromArgb(113, 128, 150), 1.5f))
            using (Brush brush = new SolidBrush(Color.FromArgb(113, 128, 150)))
            {
                // Draw pupil
                g.FillEllipse(brush, cx - 2.5f, cy - 2.5f, 5, 5);
                
                // Draw upper and lower eyelid curves
                g.DrawArc(pen, cx - 8.5f, cy - 9f, 17, 13, 25, 130);
                g.DrawArc(pen, cx - 8.5f, cy - 4f, 17, 13, 205, 130);
                
                if (!masked)
                {
                    // Draw a slash across the eye when revealed
                    using (Pen slashPen = new Pen(Color.FromArgb(205, 92, 92), 1.5f))
                    {
                        g.DrawLine(slashPen, cx - 7, cy - 5, cx + 7, cy + 5);
                    }
                }
            }
        }
    }
}
