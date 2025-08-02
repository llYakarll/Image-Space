using System.Drawing.Drawing2D;
using static System.Windows.Forms.DataFormats;

namespace Image_Space
{
    public partial class Form1 : Form
    {
        Bitmap? bitmap;
        Bitmap? originalBitmap;
        public Form1()
        {
            InitializeComponent();
        }



        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (DialogResult.OK == ofd.ShowDialog())
            {
                string path = ofd.FileName;
                bitmap = new Bitmap(path);
                originalBitmap =new Bitmap(bitmap);

                mainPicture.Image = bitmap;


                MessageBox.Show("Resim iceri aktarildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                string path = saveFileDialog.FileName;
                MessageBox.Show(path);
                mainPicture.Image.Save(path);


                MessageBox.Show("Resim Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void demonic_Button_Click(object sender, EventArgs e)
        {
            applyGradient(242, 0, 6, 40, 20, 50);

        }



        private void dramatic_Button_Click(object sender, EventArgs e)
        {
            applyGradient(242, 0, 6, 145, 5, 237);

        }

        private void freezing_Button_Click(object sender, EventArgs e)
        {
            applyGradient(0, 128, 192, 14, 18, 177);

        }

        private void futuristic_Button_Click(object sender, EventArgs e)
        {
            applyGradient(164, 28, 116, 158, 0, 191);

        }

        private void holy_Button_Click(object sender, EventArgs e)
        {
            applyGradient(241, 189, 201, 255, 255, 0);

        }

        private void natural_Button_Click(object sender, EventArgs e)
        {
            applyGradient(80, 255, 75, 0, 64, 0);

        }

        private void dark_Button_Click(object sender, EventArgs e)
        {
            applyGradient(0, 0, 0, 40, 64, 40);

        }

        private void sunny_Button_Click(object sender, EventArgs e)
        {
            applyGradient(255, 255, 128, 255, 255, 0);

        }

        public void applyGradient(int r1, int g1, int b1, int r2, int g2, int b2)
        {
            // Graphics
            Graphics graphics = Graphics.FromImage(bitmap);

            //Linear Gradient Brush
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(bitmap.Width, 0), Color.FromArgb(50, r1, g1, b1), Color.FromArgb(50, r2, g2, b2));

            // Aplly Gradient
            graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            // Bitmap To PÝctureBox
            mainPicture.Image = bitmap;
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximize_Button_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (originalBitmap != null)
            {
                bitmap.Dispose();
                bitmap = new Bitmap(originalBitmap);
                mainPicture.Image = bitmap;

            }
        }
    }
}
