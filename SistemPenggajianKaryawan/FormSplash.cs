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
            LoadLogo();
        }

        private void LoadLogo()
        {
            try
            {
                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SistemPenggajianKaryawan.Resources.Politeknik_Negeri_Cilacap.png"))
                {
                    if (stream != null)
                    {
                        logoPic.Image = new Bitmap(stream);
                    }
                }
            }
            catch { }
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
    }
}
