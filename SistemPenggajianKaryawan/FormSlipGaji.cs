using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan
{
    public partial class FormSlipGaji : Form
    {
        public static int PreSelectedBulan = 0;
        public static int PreSelectedTahun = 0;

        private int selectedKaryawanId = -1;
        private int loggedInKaryawanId = 0;
        private bool isCariPlaceholder = true;
        private const string PlaceholderText = "🔍 Cari nama/kode...";

        public FormSlipGaji()
        {
            InitializeComponent();
        }

        private void FormSlipGaji_Load(object sender, EventArgs e)
        {
            // Cek role keamanan
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Akses ditolak. Silakan login terlebih dahulu.", "Error Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Inisialisasi dropdown bulan
            string[] namaBulan = {
                "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                "Juli", "Agustus", "September", "Oktober", "November", "Desember"
            };
            bulan_cmb.Items.Clear();
            bulan_cmb.Items.AddRange(namaBulan);
            bulan_cmb.SelectedIndex = DateTime.Now.Month - 1;

            // Inisialisasi dropdown tahun
            thn_cmb.Items.Clear();
            int tahunSekarang = DateTime.Now.Year;
            for (int i = tahunSekarang; i >= tahunSekarang - 5; i--)
            {
                thn_cmb.Items.Add(i.ToString());
            }
            thn_cmb.SelectedIndex = 0;

            // Sembunyikan panel slip di awal (sebelum setup akses)
            slip_card_panel.Visible = false;

            // Load data karyawan sesuai hak akses (auto-load slip untuk Karyawan di sini)
            SetupKaryawanAccess();

            // Handle pre-selected slip redirection
            if (PreSelectedBulan > 0 && PreSelectedTahun > 0)
            {
                if (PreSelectedBulan >= 1 && PreSelectedBulan <= 12)
                {
                    bulan_cmb.SelectedIndex = PreSelectedBulan - 1;
                }

                string yearStr = PreSelectedTahun.ToString();
                int yearIndex = thn_cmb.Items.IndexOf(yearStr);
                if (yearIndex >= 0)
                {
                    thn_cmb.SelectedIndex = yearIndex;
                }
                else
                {
                    thn_cmb.Items.Add(yearStr);
                    thn_cmb.SelectedItem = yearStr;
                }

                int targetId = (UserSession.role == "Karyawan") ? loggedInKaryawanId : selectedKaryawanId;
                if (targetId > 0)
                {
                    TampilkanSlip(targetId, PreSelectedBulan, PreSelectedTahun);
                }

                // Reset
                PreSelectedBulan = 0;
                PreSelectedTahun = 0;
            }
        }

        private void SetupKaryawanAccess()
        {
            Koneksi server = new Koneksi();

            if (UserSession.role == "Karyawan")
            {
                // Sembunyikan search dan grid
                cari_txt.Visible = false;
                karyawan_dgv.Visible = false;

                // Ambil link karyawan_id dari tabel users
                string qUser = "SELECT karyawan_id FROM users WHERE user_id = @user_id";
                var pUser = new Dictionary<string, object> { { "@user_id", UserSession.user_id } };
                DataTable dtUser = server.eksekusiQueryParam(qUser, pUser);

                if (dtUser.Rows.Count > 0 && dtUser.Rows[0]["karyawan_id"] != DBNull.Value)
                {
                    loggedInKaryawanId = Convert.ToInt32(dtUser.Rows[0]["karyawan_id"]);
                    selectedKaryawanId = loggedInKaryawanId;

                    string qKar = "SELECT nama_karyawan FROM karyawan WHERE karyawan_id = @id";
                    var pKar = new Dictionary<string, object> { { "@id", loggedInKaryawanId } };
                    DataTable dtKar = server.eksekusiQueryParam(qKar, pKar);

                    if (dtKar.Rows.Count > 0)
                    {
                        karyawan_lbl.Text = "Karyawan: " + dtKar.Rows[0]["nama_karyawan"].ToString();
                        karyawan_lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        karyawan_lbl.ForeColor = Color.FromArgb(45, 55, 72);
                    }

                    // Auto-load slip bulan/tahun saat ini untuk karyawan yang login
                    int bulanDefault = DateTime.Now.Month;
                    int tahunDefault = DateTime.Now.Year;
                    TampilkanSlip(loggedInKaryawanId, bulanDefault, tahunDefault);
                }
            }
            else
            {
                // Admin atau HRD dapat mencari dan memilih karyawan dari grid
                karyawan_lbl.Text = "Pilih Karyawan";
                cari_txt.Visible = true;
                karyawan_dgv.Visible = true;

                // Setup DGV visual
                SetupKaryawanGridVisual();

                // Muat semua karyawan
                MuatKaryawanGrid();
            }
        }

        private void SetupKaryawanGridVisual()
        {
            karyawan_dgv.ReadOnly = true;
            karyawan_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            karyawan_dgv.MultiSelect = false;
            karyawan_dgv.AllowUserToAddRows = false;
            karyawan_dgv.AllowUserToDeleteRows = false;
            karyawan_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            karyawan_dgv.EnableHeadersVisualStyles = false;
            karyawan_dgv.BorderStyle = BorderStyle.None;
            karyawan_dgv.RowHeadersVisible = false;

            karyawan_dgv.BackgroundColor = Color.White;
            karyawan_dgv.GridColor = Color.FromArgb(241, 245, 249);

            karyawan_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            karyawan_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            karyawan_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            karyawan_dgv.ColumnHeadersHeight = 28;
        }

        private void MuatKaryawanGrid(string searchKeyword = "")
        {
            Koneksi server = new Koneksi();
            DataTable dt;

            if (string.IsNullOrEmpty(searchKeyword))
            {
                string qAll = "SELECT karyawan_id, kode_karyawan, nama_karyawan FROM karyawan WHERE is_aktif = 1 ORDER BY nama_karyawan ASC";
                dt = server.eksekusiQuery(qAll);
            }
            else
            {
                string qSearch = "SELECT karyawan_id, kode_karyawan, nama_karyawan FROM karyawan WHERE is_aktif = 1 AND (nama_karyawan LIKE @search OR kode_karyawan LIKE @search) ORDER BY nama_karyawan ASC";
                var p = new Dictionary<string, object> { { "@search", "%" + searchKeyword + "%" } };
                dt = server.eksekusiQueryParam(qSearch, p);
            }

            karyawan_dgv.DataSource = dt;

            if (karyawan_dgv.Columns.Count > 0)
            {
                if (karyawan_dgv.Columns.Contains("karyawan_id"))
                    karyawan_dgv.Columns["karyawan_id"].Visible = false;

                if (karyawan_dgv.Columns.Contains("kode_karyawan"))
                {
                    karyawan_dgv.Columns["kode_karyawan"].HeaderText = "Kode";
                    karyawan_dgv.Columns["kode_karyawan"].FillWeight = 40;
                }

                if (karyawan_dgv.Columns.Contains("nama_karyawan"))
                {
                    karyawan_dgv.Columns["nama_karyawan"].HeaderText = "Nama Karyawan";
                    karyawan_dgv.Columns["nama_karyawan"].FillWeight = 60;
                }
            }

            selectedKaryawanId = -1;
            karyawan_dgv.ClearSelection();
        }

        // Event handlers untuk pencarian & placeholder
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
            string keyword = (isCariPlaceholder || string.IsNullOrWhiteSpace(cari_txt.Text)) ? "" : cari_txt.Text.Trim();
            MuatKaryawanGrid(keyword);
        }

        private void karyawan_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = karyawan_dgv.Rows[e.RowIndex];
                selectedKaryawanId = Convert.ToInt32(row.Cells["karyawan_id"].Value);

                // Auto-load slip ketika baris di-klik
                int bulan = bulan_cmb.SelectedIndex + 1;
                int tahun = Convert.ToInt32(thn_cmb.SelectedItem);
                TampilkanSlip(selectedKaryawanId, bulan, tahun);
            }
        }

        private void karyawan_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Zebra striping
            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // Alice Blue
                : Color.FromArgb(176, 196, 222); // Light Steel Blue
            e.CellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            e.CellStyle.SelectionBackColor = Color.FromArgb(91, 200, 245);
            e.CellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
        }

        private void tampilkan_btn_Click(object sender, EventArgs e)
        {
            int targetId = (UserSession.role == "Karyawan") ? loggedInKaryawanId : selectedKaryawanId;

            if (targetId <= 0)
            {
                MessageBox.Show("Silakan pilih karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun = Convert.ToInt32(thn_cmb.SelectedItem);

            TampilkanSlip(targetId, bulan, tahun);
        }

        private void TampilkanSlip(int karId, int bulan, int tahun)
        {
            // Kosongkan daftar sebelumnya
            pnl_pendapatan_list.Controls.Clear();
            pnl_pendapatan_list.RowStyles.Clear();
            pnl_pendapatan_list.RowCount = 0;

            pnl_potongan_list.Controls.Clear();
            pnl_potongan_list.RowStyles.Clear();
            pnl_potongan_list.RowCount = 0;

            Koneksi server = new Koneksi();

            // 1. Ambil data spesifik karyawan
            string qEmp = "SELECT kode_karyawan, nama_karyawan, jabatan, jenis, gaji_pokok FROM karyawan WHERE karyawan_id = @id";
            var pEmp = new Dictionary<string, object> { { "@id", karId } };
            DataTable dtEmp = server.eksekusiQueryParam(qEmp, pEmp);
            if (dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("Data karyawan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nama = dtEmp.Rows[0]["nama_karyawan"].ToString();
            string kode = dtEmp.Rows[0]["kode_karyawan"].ToString();
            string jabatan = dtEmp.Rows[0]["jabatan"].ToString();
            string jenis = dtEmp.Rows[0]["jenis"].ToString();
            decimal gapok = Convert.ToDecimal(dtEmp.Rows[0]["gaji_pokok"]);

            // Set detail profil karyawan
            emp_name_lbl.Text = nama;
            emp_details_lbl.Text = kode + " · " + jabatan + " · " + jenis;

            // Set inisial avatar
            string[] nameParts = nama.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string initials = "";
            if (nameParts.Length > 0) initials += nameParts[0][0];
            if (nameParts.Length > 1) initials += nameParts[1][0];
            avatar_lbl.Text = initials.ToUpper();

            // 2. Ambil data absensi
            string qAbs = @"
                SELECT 
                    COALESCE(SUM(CASE WHEN status = 'Hadir' THEN 1 ELSE 0 END), 0) AS hadir,
                    COALESCE(SUM(CASE WHEN status = 'Izin' THEN 1 ELSE 0 END), 0) AS izin,
                    COALESCE(SUM(CASE WHEN status = 'Sakit' THEN 1 ELSE 0 END), 0) AS sakit,
                    COALESCE(SUM(CASE WHEN status = 'Alpha' THEN 1 ELSE 0 END), 0) AS alpha,
                    COALESCE(SUM(CASE WHEN status = 'Hadir' AND jam_keluar > '17:00:00' THEN TIME_TO_SEC(TIMEDIFF(jam_keluar, '17:00:00')) / 3600.0 ELSE 0 END), 0) AS lembur
                FROM absensi 
                WHERE karyawan_id = @id AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun";
            var pAbs = new Dictionary<string, object>
            {
                { "@id", karId },
                { "@bulan", bulan },
                { "@tahun", tahun }
            };
            DataTable dtAbs = server.eksekusiQueryParam(qAbs, pAbs);

            int hadir = 0, izin = 0, sakit = 0, alpha = 0;
            decimal lembur = 0;
            if (dtAbs.Rows.Count > 0)
            {
                hadir = Convert.ToInt32(dtAbs.Rows[0]["hadir"]);
                izin = Convert.ToInt32(dtAbs.Rows[0]["izin"]);
                sakit = Convert.ToInt32(dtAbs.Rows[0]["sakit"]);
                alpha = Convert.ToInt32(dtAbs.Rows[0]["alpha"]);
                lembur = Convert.ToDecimal(dtAbs.Rows[0]["lembur"]);
            }

            // 3. Ambil komponen gaji
            DataTable dtComp = server.eksekusiQuery("SELECT nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk FROM komponen_gaji WHERE is_aktif = 1");

            decimal totalTunjangan = 0;
            decimal totalPotongan = 0;

            // Helper untuk menambahkan baris detail slip ke layout list
            Action<TableLayoutPanel, string, string, Color> addRowToList = (panel, name, value, foreColor) =>
            {
                panel.RowCount++;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));

                Label lblName = new Label();
                lblName.Text = name;
                lblName.Font = new Font("Segoe UI", 9F);
                lblName.ForeColor = Color.FromArgb(45, 55, 72);
                lblName.Dock = DockStyle.Fill;
                lblName.TextAlign = ContentAlignment.MiddleLeft;

                Label lblVal = new Label();
                lblVal.Text = value;
                lblVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblVal.ForeColor = foreColor;
                lblVal.Dock = DockStyle.Fill;
                lblVal.TextAlign = ContentAlignment.MiddleRight;

                panel.Controls.Add(lblName, 0, panel.RowCount - 1);
                panel.Controls.Add(lblVal, 1, panel.RowCount - 1);
            };

            // Hitung itemized breakdown sesuai Jenis Karyawan (Polymorphism secara implisit)
            if (jenis == "Tetap" || jenis == "Kontrak")
            {
                // Tambahkan Gaji Pokok
                addRowToList(pnl_pendapatan_list, "Gaji Pokok", string.Format("Rp {0:N0}", gapok), Color.FromArgb(45, 55, 72));

                // Tambahkan Tunjangan Makan otomatis (10k per hari hadir)
                decimal nominalMakan = 10000m * hadir;
                totalTunjangan += nominalMakan;
                addRowToList(pnl_pendapatan_list, "Tunjangan Makan", string.Format("+ Rp {0:N0}", nominalMakan), Color.FromArgb(76, 175, 80));

                // Tambahkan Tunjangan Terkait
                foreach (DataRow r in dtComp.Rows)
                {
                    string compNama = r["nama_komponen"].ToString();
                    if (compNama.ToLower().Contains("makan")) continue;

                    string tipe = r["tipe"].ToString();
                    string berlaku = r["berlaku_untuk"].ToString();
                    if (tipe == "Tambah" && (berlaku == "Semua" || berlaku == jenis))
                    {
                        string jenisNilai = r["jenis_nilai"].ToString();
                        decimal nilai = Convert.ToDecimal(r["nilai"]);
                        decimal nominal = jenisNilai == "Persen" ? gapok * (nilai / 100) : nilai;

                        totalTunjangan += nominal;
                        addRowToList(pnl_pendapatan_list, compNama, string.Format("+ Rp {0:N0}", nominal), Color.FromArgb(76, 175, 80));
                    }
                }

                // Tambahkan Potongan Terkait
                foreach (DataRow r in dtComp.Rows)
                {
                    string compNama = r["nama_komponen"].ToString();
                    if (compNama.ToLower().Contains("makan")) continue;

                    string tipe = r["tipe"].ToString();
                    string berlaku = r["berlaku_untuk"].ToString();
                    if (tipe == "Potong" && (berlaku == "Semua" || berlaku == jenis))
                    {
                        string jenisNilai = r["jenis_nilai"].ToString();
                        decimal nilai = Convert.ToDecimal(r["nilai"]);
                        decimal nominal = jenisNilai == "Persen" ? gapok * (nilai / 100) : nilai;

                        totalPotongan += nominal;
                        addRowToList(pnl_potongan_list, compNama, string.Format("- Rp {0:N0}", nominal), Color.FromArgb(205, 92, 92));
                    }
                }

                // Tambahkan Potongan Alpha jika ada
                if (alpha > 0)
                {
                    decimal cutAlpha = (gapok / 22) * alpha;
                    totalPotongan += cutAlpha;
                    addRowToList(pnl_potongan_list, $"Potongan Absensi ({alpha} Alpha)", string.Format("- Rp {0:N0}", cutAlpha), Color.FromArgb(205, 92, 92));
                }
            }
            else if (jenis == "Harian")
            {
                decimal upahPerHari = gapok;
                decimal upahPerJam = upahPerHari / 8;
                decimal totalHadir = upahPerHari * hadir;
                decimal totalLembur = upahPerJam * 1.5m * lembur;

                // Tambahkan Upah Hadir
                addRowToList(pnl_pendapatan_list, $"Upah Kerja ({hadir} Hari)", string.Format("Rp {0:N0}", totalHadir), Color.FromArgb(45, 55, 72));

                // Tambahkan Upah Lembur jika ada
                if (lembur > 0)
                {
                    totalTunjangan = totalLembur;
                    addRowToList(pnl_pendapatan_list, $"Upah Lembur ({lembur} Jam)", string.Format("+ Rp {0:N0}", totalLembur), Color.FromArgb(76, 175, 80));
                }

                gapok = totalHadir; // gunakan upah hadir sebagai basis perhitungan gaji bersih
            }

            // Hitung Gaji Bersih
            decimal netto = gapok + totalTunjangan - totalPotongan;
            if (netto < 0) netto = 0;

            // Set nilai ringkasan ke UI
            netto_val_lbl.Text = string.Format("Rp {0:N0}", netto);
            period_lbl.Text = "Periode: " + bulan_cmb.SelectedItem.ToString() + " " + tahun;

            // Tampilkan card slip
            slip_card_panel.Visible = true;
        }

        private void cetak_btn_Click(object sender, EventArgs e)
        {
            if (!slip_card_panel.Visible)
            {
                MessageBox.Show("Silakan tampilkan slip gaji terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDialog pd = new PrintDialog();
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            pd.Document = doc;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Ambil screenshot dari panel slip_card_panel
            Bitmap bmp = new Bitmap(slip_card_panel.Width, slip_card_panel.Height);
            slip_card_panel.DrawToBitmap(bmp, new Rectangle(0, 0, slip_card_panel.Width, slip_card_panel.Height));
            
            // Gambar bitmap ke kertas cetakan dengan margin
            e.Graphics.DrawImage(bmp, new Point(100, 100));
        }

        private void accentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void slip_container_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
