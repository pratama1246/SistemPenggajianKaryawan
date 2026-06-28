using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace SistemPenggajianKaryawan
{
    public class FormQRPreview : Form
    {
        private string kodeKaryawan;
        private string namaKaryawan;
        private PictureBox picQR;
        private Button btnDownload;
        private Button btnClose;

        public FormQRPreview(string kode, string nama)
        {
            this.kodeKaryawan = kode;
            this.namaKaryawan = nama;
            InitializeComponent();
            GenerateAndShowQR();
        }

        private void InitializeComponent()
        {
            this.Text = "Preview QR Code Karyawan";
            this.Size = new Size(320, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(244, 246, 249); // bg-base
            this.Font = new Font("Segoe UI", 9F);

            // Accent Bar
            Panel accentBar = new Panel();
            accentBar.Location = new Point(0, 0);
            accentBar.Size = new Size(320, 4);
            accentBar.BackColor = Color.FromArgb(91, 200, 245); // primary
            this.Controls.Add(accentBar);

            // Header Container (White Card)
            Panel cardPanel = new Panel();
            cardPanel.Location = new Point(15, 15);
            cardPanel.Size = new Size(275, 305);
            cardPanel.BackColor = Color.White;
            cardPanel.Paint += Card_Paint;
            this.Controls.Add(cardPanel);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "KARTU ABSENSI QR";
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 55, 72); // text-primary
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(10, 15);
            lblTitle.Size = new Size(255, 22);
            cardPanel.Controls.Add(lblTitle);

            Label lblSub = new Label();
            lblSub.Text = "POLITEKNIK NEGERI CILACAP";
            lblSub.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSub.ForeColor = Color.FromArgb(91, 200, 245); // primary
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            lblSub.Location = new Point(10, 37);
            lblSub.Size = new Size(255, 15);
            cardPanel.Controls.Add(lblSub);

            // PictureBox for QR
            picQR = new PictureBox();
            picQR.Location = new Point(47, 65);
            picQR.Size = new Size(180, 180);
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.BackColor = Color.White;
            cardPanel.Controls.Add(picQR);

            // Employee Info Label
            Label lblInfo = new Label();
            lblInfo.Text = $"{namaKaryawan}\r\n({kodeKaryawan})";
            lblInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(74, 85, 104);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Location = new Point(10, 252);
            lblInfo.Size = new Size(255, 45);
            cardPanel.Controls.Add(lblInfo);

            // Button Download
            btnDownload = new Button();
            btnDownload.Text = "Unduh PNG";
            btnDownload.Location = new Point(15, 335);
            btnDownload.Size = new Size(130, 32);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.BackColor = Color.FromArgb(30, 144, 255); // primary-dark
            btnDownload.ForeColor = Color.White;
            btnDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.Click += btnDownload_Click;
            this.Controls.Add(btnDownload);

            // Button Close
            btnClose = new Button();
            btnClose.Text = "Tutup";
            btnClose.Location = new Point(160, 335);
            btnClose.Size = new Size(130, 32);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.FromArgb(74, 85, 104);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Control ctrl = (Control)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle bounds = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawRectangle(pen, bounds);
            }
        }

        private void GenerateAndShowQR()
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 200,
                        Height = 200,
                        Margin = 1
                    }
                };
                Bitmap qrBitmap = writer.Write(kodeKaryawan);
                picQR.Image = qrBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal men-generate QR Code: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (picQR.Image == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = $"QR_Code_{kodeKaryawan.Replace(".", "_")}";
                sfd.Title = "Simpan QR Code Karyawan";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picQR.Image.Save(sfd.FileName, ImageFormat.Png);
                        MessageBox.Show("QR Code berhasil disimpan ke komputer.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menyimpan gambar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
