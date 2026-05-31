using System.Drawing;
using System.Windows.Forms;

namespace SistemPenggajianKaryawan
{
    public partial class FormSplash : Form
    {
        private int _progressValue = 0;

        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, System.EventArgs e)
        {
            timer1.Interval = 30;
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _progressValue += 2;
            loading_bar.Value = _progressValue;

            if (_progressValue <= 30)
                status_lbl.Text = "Menginisialisasi aplikasi...";
            else if (_progressValue <= 60)
                status_lbl.Text = "Memuat komponen...";
            else if (_progressValue <= 85)
                status_lbl.Text = "Menyiapkan koneksi database...";
            else
                status_lbl.Text = "Hampir selesai...";

            if (_progressValue >= 100)
            {
                timer1.Stop();
                FormLogin login = new FormLogin();
                this.Hide();
                login.ShowDialog();
                this.Close();
            }
        }

        // Overrides CreateParams to add a native drop shadow effect to our borderless form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        private void logoPic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw outer subtle glowing ring matching the primary color #5BC8F5
            using (var pen = new Pen(Color.FromArgb(91, 200, 245), 1.5f))
            {
                e.Graphics.DrawEllipse(pen, 5, 5, 80, 80);
            }

            // Draw three modern stylized building pillars representing PNC
            // Left pillar (Blue #5BC8F5)
            using (var brush = new SolidBrush(Color.FromArgb(91, 200, 245)))
            {
                e.Graphics.FillRectangle(brush, 28, 25, 10, 40);
            }
            // Middle pillar (Neutral gray #C8C8C8)
            using (var brush = new SolidBrush(Color.FromArgb(200, 200, 200)))
            {
                e.Graphics.FillRectangle(brush, 40, 20, 10, 45);
            }
            // Right pillar (Amber #F5A623)
            using (var brush = new SolidBrush(Color.FromArgb(245, 166, 35)))
            {
                e.Graphics.FillRectangle(brush, 52, 30, 10, 35);
            }

            // Connect pillars at the bottom with a solid base
            using (var brush = new SolidBrush(Color.FromArgb(91, 200, 245)))
            {
                e.Graphics.FillRectangle(brush, 25, 65, 40, 4);
            }
        }
    }
}
