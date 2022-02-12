using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Scene
{
    internal class Camera
    {
        Matrix<double> ViewMatrix { get; set; }
        public Camera()
        {
            ViewMatrix = DenseMatrix.OfArray(new double[,] {
            {1,0,0,0},
            {0,1,0,0},
        {0,0,1,20},
        {0,0,0,1}});
        }
        public Matrix<double> GetCameraMatrix()
        {
            return ViewMatrix;
        }
        public void NextFrame()
        {

        }
    }
}
