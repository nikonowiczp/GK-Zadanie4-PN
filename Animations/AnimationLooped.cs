using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace GK_Zadanie4_PN.Animations
{
    internal class AnimationLooped : Animation
    {
        //gets nextMovement matrix and proceeds the animation.
        //Next calls to that functions will retrieve consecutive animation frames

        public override Matrix<double> GetNextFrameMatrixPrivate()
        {
            throw new NotImplementedException();
        }
    }
}
