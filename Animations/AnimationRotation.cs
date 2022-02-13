using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Animations
{
    public class AnimationRotation : Animation
    {
        public AnimationRotation(double frames)
        {
            addedAngle = 2*Math.PI/frames;
        }
        public override Matrix<double> GetNextFrameMatrixPrivate()
        {
            currentAngle += addedAngle;
            if (currentAngle >= 2 * Math.PI) currentAngle -= 2 * Math.PI;
            return DenseMatrix.OfArray(new double[,] {
                    {Math.Cos(currentAngle),0,  -1*Math.Sin(currentAngle),  0},
                    {0,                     1,  0,                          0},
                    {Math.Sin(currentAngle),0,  Math.Cos(currentAngle),     0},
                    {0,                     0,  0,                          1}});
        }

        private double currentAngle = 0;
        private double addedAngle;
    }
}
