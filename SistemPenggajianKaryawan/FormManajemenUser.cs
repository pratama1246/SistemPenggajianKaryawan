using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;
using SistemPenggajianKaryawan.Service;

namespace SistemPenggajianKaryawan
{
    public partial class FormManajemenUser : Form
    {
        private User_serv userServ = new User_serv();
        private int selectedUserId = -1; // -1 = mode tambah baru
        private bool isCariPlaceholder = true;
        private const string PlaceholderText = "🔍 Cari user...";

        public FormManajemenUser()
        {
            InitializeComponent();
        }

        private void FormManajemenUser_Load(object sender, EventArgs e)
        {
            // Cek role keamanan
            if (UserSession.role != "Admin")
            {
                MessageBox.Show("Akses ditolak. Hanya Admin yang dapat membuka form ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            setupDataGridView();
            bersihkan();
            tampilGrid();
            MuatKaryawanComboBox();

            // Event: tampilkan/sembunyikan ComboBox karyawan sesuai role
            role_cmb.SelectedIndexChanged += role_cmb_SelectedIndexChanged;
            karyawan_cmb.SelectedIndexChanged += karyawan_cmb_SelectedIndexChanged;
        }

        // ─────────────────────────────────────────────────────────────────────
        // SETUP DATA GRID VIEW
        // ─────────────────────────────────────────────────────────────────────
        private void setupDataGridView()
        {
            user_dgv.EnableHeadersVisualStyles = false;
            user_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // #4682B4
            user_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            user_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            user_dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            user_dgv.ColumnHeadersHeight = 34;
            user_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            user_dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245); // Primary cyan
            user_dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            user_dgv.GridColor = Color.FromArgb(226, 232, 240); // Subtle border
        }

        // ─────────────────────────────────────────────────────────────────────
        // DATA ACCESS & DISP
        // ─────────────────────────────────────────────────────────────────────
        private void tampilGrid()
        {
            string keyword = (isCariPlaceholder || string.IsNullOrWhiteSpace(cari_txt.Text))
                ? "" : cari_txt.Text.Trim();

            DataTable dt = string.IsNullOrEmpty(keyword)
                ? userServ.viewAll()
                : userServ.search(keyword);

            user_dgv.DataSource = dt;
            renameHeaders();
            warnaiBaris();
        }

        private void renameHeaders()
        {
            if (user_dgv.Columns.Count == 0) return;
            if (user_dgv.Columns["user_id"] != null) user_dgv.Columns["user_id"].Visible = false;
            if (user_dgv.Columns["password"] != null) user_dgv.Columns["password"].Visible = false;
            if (user_dgv.Columns["nama"] != null) user_dgv.Columns["nama"].HeaderText = "Nama";
            if (user_dgv.Columns["username"] != null) user_dgv.Columns["username"].HeaderText = "Username";
            if (user_dgv.Columns["role"] != null) user_dgv.Columns["role"].HeaderText = "Role";
            if (user_dgv.Columns["is_active"] != null) user_dgv.Columns["is_active"].HeaderText = "Status";
        }

        private void warnaiBaris()
        {
            foreach (DataGridViewRow row in user_dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Jangan warnai kolom yang diformat khusus (role & status) agar warna badge-nya tidak terganggu
                    string colName = user_dgv.Columns[cell.ColumnIndex].Name;
                    if (colName != "role" && colName != "is_active")
                    {
                        cell.Style.BackColor = row.Index % 2 == 0
                            ? Color.FromArgb(240, 248, 255)   // Alice Blue
                            : Color.FromArgb(176, 196, 222);  // Light Steel Blue
                    }
                }
            }
        }

        private void bersihkan()
        {
            selectedUserId = -1;
            nama_txt.Clear();
            username_txt.Clear();
            password_txt.Clear();
            role_cmb.SelectedIndex = 0; // Default: Admin
            status_cmb.SelectedIndex = 0; // Default: Aktif
            karyawan_cmb.SelectedIndex = -1;
            karyawanLink_lbl.Visible = false;
            karyawan_cmb.Visible = false;
            nama_txt.Focus();
            user_dgv.ClearSelection();
        }

        private void MuatKaryawanComboBox()
        {
            Koneksi server = new Koneksi();
            // Ambil karyawan yang belum punya akun user (karyawan_id belum terhubung ke users)
            // Tapi tetap sertakan semua agar bisa dipakai saat edit
            string q = "SELECT karyawan_id, CONCAT(kode_karyawan, ' - ', nama_karyawan) AS label " +
                       "FROM karyawan WHERE is_aktif = 1 ORDER BY nama_karyawan ASC";
            DataTable dt = server.eksekusiQuery(q);

            karyawan_cmb.Items.Clear();
            karyawan_cmb.Items.Add(new KaryawanItem { Id = 0, Label = "-- Pilih Karyawan --" });

            foreach (DataRow row in dt.Rows)
            {
                karyawan_cmb.Items.Add(new KaryawanItem
                {
                    Id = Convert.ToInt32(row["karyawan_id"]),
                    Label = row["label"].ToString()
                });
            }

            karyawan_cmb.DisplayMember = "Label";
            karyawan_cmb.ValueMember = "Id";
            karyawan_cmb.SelectedIndex = 0;
        }

        private void role_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isKaryawan = role_cmb.Text == "Karyawan";
            karyawanLink_lbl.Visible = isKaryawan;
            karyawan_cmb.Visible = isKaryawan;

            if (selectedUserId == -1)
            {
                if (isKaryawan)
                {
                    // Set default selection to first employee if it exists and none selected yet
                    if (karyawan_cmb.Items.Count > 1 && karyawan_cmb.SelectedIndex <= 0)
                    {
                        karyawan_cmb.SelectedIndex = 1;
                    }
                }
                else
                {
                    // Reset fields if changing back to Admin/HRD
                    nama_txt.Clear();
                    username_txt.Clear();
                    password_txt.Clear();
                    karyawan_cmb.SelectedIndex = 0;
                }
            }
        }

        private void karyawan_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auto-fill username & password default only for new employee account creation (selectedUserId == -1)
            if (selectedUserId == -1 && role_cmb.Text == "Karyawan")
            {
                KaryawanItem selectedKar = karyawan_cmb.SelectedItem as KaryawanItem;
                if (selectedKar != null && selectedKar.Id > 0)
                {
                    string label = selectedKar.Label;
                    string[] parts = label.Split(new string[] { " - " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string kode = parts[0].Trim();
                        string nama = parts[1].Trim();

                        nama_txt.Text = nama;
                        // Clean username: remove spaces, lowercase, alphanumeric only
                        string cleanUsername = System.Text.RegularExpressions.Regex.Replace(nama, @"[^a-zA-Z0-9]", "").ToLower();
                        username_txt.Text = cleanUsername;
                        password_txt.Text = "karyawan123";
                    }
                }
                else
                {
                    // Clear if reset to default placeholder
                    nama_txt.Clear();
                    username_txt.Clear();
                    password_txt.Clear();
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENT HANDLERS
        // ─────────────────────────────────────────────────────────────────────
        private void user_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = user_dgv.Rows[e.RowIndex];
            if (row.Cells["user_id"].Value == null) return;

            selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);

            nama_txt.Text = row.Cells["nama"].Value?.ToString() ?? "";
            username_txt.Text = row.Cells["username"].Value?.ToString() ?? "";
            string encryptedPw = row.Cells["password"].Value?.ToString() ?? "";
            password_txt.Text = userServ.decryptPassword(encryptedPw);
            role_cmb.Text = row.Cells["role"].Value?.ToString() ?? "Admin";

            int statusVal = Convert.ToInt32(row.Cells["is_active"].Value);
            status_cmb.SelectedIndex = statusVal == 1 ? 0 : 1; // 0 = Aktif, 1 = Tidak Aktif

            // Load karyawan_id yang terhubung (jika ada)
            if (role_cmb.Text == "Karyawan")
            {
                Koneksi server = new Koneksi();
                string q = "SELECT karyawan_id FROM users WHERE user_id = @uid";
                var p = new Dictionary<string, object> { { "@uid", selectedUserId } };
                DataTable dtUid = server.eksekusiQueryParam(q, p);

                if (dtUid.Rows.Count > 0 && dtUid.Rows[0]["karyawan_id"] != DBNull.Value)
                {
                    int linkedId = Convert.ToInt32(dtUid.Rows[0]["karyawan_id"]);
                    foreach (KaryawanItem item in karyawan_cmb.Items)
                    {
                        if (item.Id == linkedId)
                        {
                            karyawan_cmb.SelectedItem = item;
                            break;
                        }
                    }
                }
            }

            nama_txt.Focus();
        }

        private void user_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || user_dgv.Columns.Count == 0) return;

            string colName = user_dgv.Columns[e.ColumnIndex].Name;

            e.CellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245);
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);

            // Mewarnai badge Role
            if (colName == "role" && e.Value != null)
            {
                string val = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (val == "Admin")
                {
                    e.CellStyle.BackColor = Color.FromArgb(226, 240, 253); // Light Blue-Grey
                    e.CellStyle.ForeColor = Color.FromArgb(30, 144, 255); // Dodger Blue
                    e.CellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else if (val == "HRD")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Light Yellow/Amber
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);   // Dark Amber
                    e.CellStyle.SelectionBackColor = Color.FromArgb(217, 119, 6);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else if (val == "Karyawan")
                {
                    e.CellStyle.BackColor = Color.FromArgb(226, 232, 240); // Slate-Grey
                    e.CellStyle.ForeColor = Color.FromArgb(74, 85, 104);   // Slate-Dark
                    e.CellStyle.SelectionBackColor = Color.FromArgb(74, 85, 104);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }

            // Mewarnai badge Status
            if (colName == "is_active" && e.Value != null)
            {
                int val = Convert.ToInt32(e.Value);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (val == 1)
                {
                    e.Value = "Aktif";
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Light Green
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);   // Green
                    e.CellStyle.SelectionBackColor = Color.FromArgb(22, 163, 74);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.Value = "Tidak Aktif";
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Light Red
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);   // Red
                    e.CellStyle.SelectionBackColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                e.FormattingApplied = true;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // CARI TEXT BOX PLACEHOLDER
        // ─────────────────────────────────────────────────────────────────────
        private void cari_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCariPlaceholder)
            {
                cari_txt.Text = "";
                cari_txt.ForeColor = Color.FromArgb(45, 55, 72);
                isCariPlaceholder = false;
            }
        }

        private void cari_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cari_txt.Text))
            {
                cari_txt.Text = PlaceholderText;
                cari_txt.ForeColor = Color.FromArgb(160, 174, 192);
                isCariPlaceholder = true;
            }
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        // ─────────────────────────────────────────────────────────────────────
        // TOMBOL AKSI
        // ─────────────────────────────────────────────────────────────────────
        private void simpan_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nama_txt.Text))
            {
                MessageBox.Show("Nama Lengkap tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nama_txt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username_txt.Text))
            {
                MessageBox.Show("Username tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                username_txt.Focus();
                return;
            }

            // Validasi duplikasi username
            if (userServ.jikaAda(username_txt.Text.Trim(), selectedUserId))
            {
                MessageBox.Show("Username sudah digunakan oleh user lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                username_txt.Focus();
                return;
            }

            userServ.nama = nama_txt.Text.Trim();
            userServ.username = username_txt.Text.Trim();
            userServ.role = role_cmb.Text;
            userServ.is_active = status_cmb.Text == "Aktif" ? 1 : 0;

            // Set karyawan_id jika role = Karyawan
            if (role_cmb.Text == "Karyawan")
            {
                KaryawanItem selectedKar = karyawan_cmb.SelectedItem as KaryawanItem;
                if (selectedKar == null || selectedKar.Id == 0)
                {
                    MessageBox.Show("Pilih karyawan yang akan di-link ke akun ini.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    karyawan_cmb.Focus();
                    return;
                }
                userServ.karyawan_id = selectedKar.Id;
            }
            else
            {
                userServ.karyawan_id = null;
            }

            if (selectedUserId < 0)
            {
                // Mode Insert Baru
                if (string.IsNullOrWhiteSpace(password_txt.Text))
                {
                    MessageBox.Show("Password wajib diisi untuk membuat user baru.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    password_txt.Focus();
                    return;
                }

                userServ.password = userServ.hashPassword(password_txt.Text);

                if (userServ.Save() > 0)
                {
                    MessageBox.Show("Data user berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mode Update/Edit
                bool updatePw = !string.IsNullOrWhiteSpace(password_txt.Text);
                if (updatePw)
                {
                    userServ.password = userServ.hashPassword(password_txt.Text);
                }

                if (MessageBox.Show("Yakin ingin mengubah data user ini?", "Konfirmasi Edit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (userServ.update(selectedUserId, updatePw) > 0)
                    {
                        MessageBox.Show("Data user berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bersihkan();
                        tampilGrid();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengubah data user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void hapus_btn_Click(object sender, EventArgs e)
        {
            if (selectedUserId < 0)
            {
                MessageBox.Show("Pilih data user yang ingin dihapus pada tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cegah penghapusan diri sendiri
            if (selectedUserId == UserSession.user_id)
            {
                MessageBox.Show("Anda tidak diperbolehkan menghapus akun Anda sendiri yang sedang aktif digunakan.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah user pernah memproses gaji (FK constraint di tabel penggajian)
            if (userServ.sudahProsesGaji(selectedUserId))
            {
                MessageBox.Show(
                    "User ini tidak dapat dihapus karena memiliki histori penggajian yang pernah diproses.\n" +
                    "Data histori penggajian harus dijaga integritas-nya.",
                    "Tidak Dapat Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data user ini dari database?", "Konfirmasi Hapus",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (userServ.delete(selectedUserId) > 0)
                {
                    MessageBox.Show("Data user berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan();
                    tampilGrid();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            bersihkan();
        }

        private void user_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Abort standard dialog popup for formatting or constraint errors
            e.ThrowException = false;
        }

        private void showPassword_btn_Click(object sender, EventArgs e)
        {
            password_txt.UseSystemPasswordChar = !password_txt.UseSystemPasswordChar;
            showPassword_btn.Invalidate();
        }

        private void showPassword_btn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            int w = showPassword_btn.Width;
            int h = showPassword_btn.Height;
            
            float cx = w / 2f;
            float cy = h / 2f;
            
            using (Pen pen = new Pen(Color.FromArgb(113, 128, 150), 1.5f))
            using (Brush brush = new SolidBrush(Color.FromArgb(113, 128, 150)))
            {
                // Draw pupil
                e.Graphics.FillEllipse(brush, cx - 2.5f, cy - 2.5f, 5, 5);
                
                // Draw upper and lower eyelid curves
                e.Graphics.DrawArc(pen, cx - 8.5f, cy - 9f, 17, 13, 25, 130);
                e.Graphics.DrawArc(pen, cx - 8.5f, cy - 4f, 17, 13, 205, 130);
                
                if (!password_txt.UseSystemPasswordChar)
                {
                    // Draw a slash across the eye when revealed
                    using (Pen slashPen = new Pen(Color.FromArgb(205, 92, 92), 1.5f))
                    {
                        e.Graphics.DrawLine(slashPen, cx - 7, cy - 5, cx + 7, cy + 5);
                    }
                }
            }
        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {
            // Tombol reveal selalu muncul selama ada teks yang diisi di kolom password
            showPassword_btn.Visible = password_txt.Text.Length > 0;
        }
    }

    // Helper class untuk item ComboBox karyawan
    internal class KaryawanItem
    {
        public int    Id    { get; set; }
        public string Label { get; set; }
        public override string ToString() => Label;
    }
}
