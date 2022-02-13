using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Animations
{
    public abstract class Animation : IAnimation
    {
        private IAnimation inner = null;
        public void AddInnerAnimation(IAnimation innerAnimation)
        {
            if(inner== null)
            {
                inner = innerAnimation;
            }
            else
            {
                inner.AddInnerAnimation(innerAnimation);
            }
        }

        public Matrix<double> GetNextFrameMatrix()
        {
            if (inner == null) return GetNextFrameMatrixPrivate();

            return GetNextFrameMatrixPrivate()*inner.GetNextFrameMatrix();
        }

        public abstract Matrix<double> GetNextFrameMatrixPrivate();
    }
}
