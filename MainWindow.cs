using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GK_Zadanie4_PN.BitmapController;

namespace GK_Zadanie4_PN
{
    public partial class MainWindow : Form
    {
        CubeController controller;
        public MainWindow()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new CubeController(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = controller.GetBitmap();
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.NextTransform();
            pictureBox1.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            controller.SetD((int)numericUpDown1.Value);
        }
    }
}
