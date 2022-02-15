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
            _position = Vector<double>.Build.DenseOfArray(new double[] { position.X, position.Y, position.Z });
            ColorDiffuse = Vector<double>.Build.DenseOfArray(new double[] { color.R, color.G, color.B });
            ColorSpecular = Vector<double>.Build.DenseOfArray(new double[] { color.R, color.G, color.B });
        }
        public Vector<double> Position = null;
        private Vector<double> _position = null;

        public Vector<double> ColorDiffuse = null;
        public Vector<double> ColorSpecular = null;

        public bool isMoving = false;
        public bool isDirectional = false;
        public double alpha = 0;
        public Vector<double> LookingAt = null;
        public Vector<double> _lookingAt = null;
        public Vector<double> Direction = null;
        public void SetDirectionVector()
        {
            Direction = Vector<double>.Build.DenseOfArray(new double[] { Position[0]-LookingAt[0], Position[1]-LookingAt[1], Position[2] - LookingAt[2]}).Normalize(2);
        }
        public void UpdateMovingLightSource(Matrix<double> modelMatrix)
        {
            var position = modelMatrix * Vector<double>.Build.DenseOfArray(new double[] { _position[0], _position[1], _position[2], 1 }).ToColumnMatrix();
            var lookingAt = modelMatrix * Vector<double>.Build.DenseOfArray(new double[] { _lookingAt[0], _lookingAt[1], _lookingAt[2], 1 }).ToColumnMatrix();

            Position = Vector<double>.Build.DenseOfArray(new double[] { position[0,0], position[1,0], position[2,0] });
            LookingAt = Vector<double>.Build.DenseOfArray(new double[] { lookingAt[0, 0], lookingAt[1, 0], lookingAt[2, 0] });
            SetDirectionVector();
        }
    }
}
