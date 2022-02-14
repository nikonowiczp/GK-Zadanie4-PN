using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Lighting
{
    internal class LightSource
    {
        public LightSource((double X,double Y, double Z) position, Color color)
        {
            Position = Vector<double>.Build.DenseOfArray(new double[] { position.X, position.Y, position.Z });
            ColorDiffuse = Vector<double>.Build.DenseOfArray(new double[] { color.R, color.G, color.B });
            ColorSpecular = Vector<double>.Build.DenseOfArray(new double[] { color.R, color.G, color.B });
        }
        public Vector<double> Position = null;

        public Vector<double> ColorDiffuse = null;
        public Vector<double> ColorSpecular = null;
    }
}
