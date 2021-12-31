using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Zadanie4_PN.BitmapController;
using System.Drawing.Imaging;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN
{
    class CubeController
    {
        BitmapLowLevelController controller;
        
        int Width = -1;
        int Height = -1;
        (double,double,double,double)[,] Cube;
        Point[,] CubePoints = new Point[2, 4];

        
        int D = 20;
        double CubeA = 2;
        double alfa = 0;

        Matrix<double> P;

        Matrix<double> T;
        Matrix<double> R;
        Matrix<double> M;
        public CubeController(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            controller = new BitmapLowLevelController(Width, Height);
            Cube = new (double, double, double, double)[,]
                {
                    {(-1*CubeA,CubeA,-1*CubeA,1)      ,(CubeA,CubeA,-1*CubeA,1)    ,(CubeA,CubeA,CubeA,1)    ,(-1*CubeA,CubeA,CubeA,1) },
                    {(-1*CubeA,-1*CubeA,-1*CubeA,1)   ,(CubeA,-1*CubeA,-1*CubeA,1) ,(CubeA,-1*CubeA,CubeA,1) ,(-1*CubeA,-1*CubeA,CubeA,1) }
                };
            
        }

        public void NextTransform()
        {
            alfa += Math.PI / 8;
            if (alfa >= Math.PI * 2) alfa -= Math.PI * 2;
            UpdateMatrixes();
            CalculatePoints();
            DrawCube();
        }

        public Bitmap GetBitmap()
        {
            return controller.Bitmap;
        }
        public void SetD(int value)
        {
            D = value;
        }
        private void DrawCube()
        {
            controller.CleanBitmap();
            for(int i = 0; i < 4; i++)
            {
                int next = i == 3 ? 0 : i+1;
                controller.DrawLine(CubePoints[0,i], CubePoints[0,next], Color.Black);
            }
            for (int i = 0; i < 4; i++)
            {
                int next = i == 3 ? 0 : i + 1;
                controller.DrawLine(CubePoints[1,i], CubePoints[1,next], Color.Black);
            }
            for (int i = 0; i < 4; i++)
            {
                controller.DrawLine(CubePoints[0,i], CubePoints[ 1,i], Color.Black);
            }
        }

        private void CalculatePoints()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    CubePoints[i, j] = CalculatePoint(i, j);
                }
            }
        }
        private Point CalculatePoint(int i, int j)
        {
            var point = Cube[i, j];
            var V = Vector<double>.Build.DenseOfArray(new double[] { point.Item1, point.Item2, point.Item3, point.Item4 });
            var vec = M * V;
            var array = vec.ToArray();
            for (int k = 0 ; k < 4 ; k++){
                array[k] /= array[3];
            }
            Point point2 = new Point((int)((double)Width * (1 + array[0]) / 2), (int)((double)Height * (1 - array[1]) / 2));
            return point2;
        }
        private void UpdateMatrixes()
        {
            P = DenseMatrix.OfArray(new double[,] {
        {(double)Height/(double)Width,0,0,0},
        {0,1,0,0},
        {0,0,0,1},
        {0,0,-1,0}});
            T = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,D},
        {0,0,0,1}});
            R = DenseMatrix.OfArray(new double[,] {
        {Math.Cos(alfa),0,  -1*Math.Sin(alfa),0},
        {0,             1,  0,                0},
        {Math.Sin(alfa),0,  Math.Cos(alfa),   0},
        {0,             0,  0,                1}});
            M = P * T * R;
        }
    }
}
