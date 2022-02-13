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
using GK_Zadanie4_PN.Scene;
namespace GK_Zadanie4_PN
{
    public partial class MainWindow : Form
    {
        CubeController controller;
        SceneToBitmapController sceneController;
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
            //controller = new CubeController(pictureBox1.Width, pictureBox1.Height);
            sceneController = new SceneToBitmapController(pictureBox1.Width, pictureBox1.Height);

            //pictureBox1.Image = controller.GetBitmap();
            pictureBox1.Image = sceneController.GetBitmap();
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //controller.NextTransform();
            sceneController.GenerateNextFrame();
            pictureBox1.Refresh();
        }


        private void camera1Button_Click(object sender, EventArgs e)
        {
            sceneController.SetCamera(0);
        }

        private void camera2Button_Click(object sender, EventArgs e)
        {
            sceneController.SetCamera(1);
        }

        private void camera3Button_Click(object sender, EventArgs e)
        {
            sceneController.SetCamera(2);
        }
    }
}
