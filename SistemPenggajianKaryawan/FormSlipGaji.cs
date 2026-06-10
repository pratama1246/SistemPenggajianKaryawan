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
        public FormSlipGaji()
        {
            InitializeComponent();
        }

        private void FormSlipGaji_Load(object sender, EventArgs e)
        {
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

            // Load data karyawan sesuai hak akses
            MuatKaryawanDropdown();

            // Sembunyikan panel slip di awal
            slip_card_panel.Visible = false;
        }

        private void MuatKaryawanDropdown()
        {
            Koneksi server = new Koneksi();

            // Aturan Hak Akses:
            // Jika role adalah Karyawan, hanya tampilkan nama dirinya dan kunci dropdown.
            if (UserSession.role == "Karyawan")
            {
                string qUser = "SELECT karyawan_id FROM users WHERE user_id = @user_id";
                var pUser = new Dictionary<string, object> { { "@user_id", UserSession.user_id } };
                DataTable dtUser = server.eksekusiQueryParam(qUser, pUser);

                if (dtUser.Rows.Count > 0 && dtUser.Rows[0]["karyawan_id"] != DBNull.Value)
                {
                    int karId = Convert.ToInt32(dtUser.Rows[0]["karyawan_id"]);
                    string qKar = "SELECT karyawan_id, nama_karyawan FROM karyawan WHERE karyawan_id = @id";
                    var pKar = new Dictionary<string, object> { { "@id", karId } };
                    DataTable dtKar = server.eksekusiQueryParam(qKar, pKar);

                    karyawan_cmb.DataSource = dtKar;
                    karyawan_cmb.DisplayMember = "nama_karyawan";
                    karyawan_cmb.ValueMember = "karyawan_id";
                    karyawan_cmb.Enabled = false; // Kunci pilihan
                }
            }
            else
            {
                // Admin atau HRD dapat melihat semua karyawan aktif
                string qAll = "SELECT karyawan_id, nama_karyawan FROM karyawan WHERE is_aktif = 1 ORDER BY nama_karyawan ASC";
                DataTable dtAll = server.eksekusiQuery(qAll);

                karyawan_cmb.DataSource = dtAll;
                karyawan_cmb.DisplayMember = "nama_karyawan";
                karyawan_cmb.ValueMember = "karyawan_id";
                karyawan_cmb.Enabled = true;
            }
        }

        private void tampilkan_btn_Click(object sender, EventArgs e)
        {
            if (karyawan_cmb.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih karyawan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int karId = Convert.ToInt32(karyawan_cmb.SelectedValue);
            int bulan = bulan_cmb.SelectedIndex + 1;
            int tahun = Convert.ToInt32(thn_cmb.SelectedItem);

            TampilkanSlip(karId, bulan, tahun);
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
            DataTable dtComp = server.eksekusiQuery("SELECT nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk FROM komponen_gaji");

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

                // Tambahkan Tunjangan Terkait
                foreach (DataRow r in dtComp.Rows)
                {
                    string tipe = r["tipe"].ToString();
                    string berlaku = r["berlaku_untuk"].ToString();
                    if (tipe == "Tambah" && (berlaku == "Semua" || berlaku == jenis))
                    {
                        string compNama = r["nama_komponen"].ToString();
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
                    string tipe = r["tipe"].ToString();
                    string berlaku = r["berlaku_untuk"].ToString();
                    if (tipe == "Potong" && (berlaku == "Semua" || berlaku == jenis))
                    {
                        string compNama = r["nama_komponen"].ToString();
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
    }
}
