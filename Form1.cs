using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goruntuIslemeProjesi
{
    public partial class Form1 : Form
    {
        Bitmap resim = new Bitmap(300, 300);

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
            Graphics.FromImage(resim).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color renk = new Color();
            renk = Color.FromArgb(184, 61, 186);

            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    Color c = resim.GetPixel(i, j);
                    if (c != renk)
                    {
                        resim.SetPixel(i, j, Color.Black);
                    }

                }
            }
            pictureBox1.Image = resim;
            this.Refresh();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (resim != null)
            {
                Color renk = resim.GetPixel(e.X, e.Y);
                panel1.BackColor = renk;
                txtX.Text = Convert.ToString(e.X);
                txtY.Text = Convert.ToString(e.Y);

                txtO.Text = renk.Name;
            }
            this.Refresh();
        }

        private void bntDonSol_Click(object sender, EventArgs e)
        {
            resim.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = resim;
        }

        private void Döndür_Click(object sender, EventArgs e)
        {
            resim.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = resim;
        }
    }
}
