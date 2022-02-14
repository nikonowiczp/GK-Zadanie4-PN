using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Animations
{
    public class AnimationAlongLineLooped : Animation
    {
        public AnimationAlongLineLooped((double X, double Y, double Z) vector, int delay, int duration, bool startImmedietaly = true)
        {
            if (!startImmedietaly) CurrentFrame = 2*duration+1;
            Vector = vector;
            Delay = delay;
            Duration = duration;
        }
        (double X, double Y, double Z) Vector;
        int Delay;
        int Duration;

        int CurrentFrame = 0;
        public override Matrix<double> GetNextFrameMatrixPrivate()
        {
            CurrentFrame++;
            if (CurrentFrame > Delay + 2*Duration+1) CurrentFrame = 0;

            if(CurrentFrame > 2*Duration+1)
            {
                return Matrix<double>.Build.DenseOfArray(new double[,]
                {
                    {1,0,0,0 },
                    {0,1,0,0 },
                    {0,0,1,0 },
                    {0,0,0,1 }
                });
            }
            if(CurrentFrame <= Duration)
            {
                return Matrix<double>.Build.DenseOfArray(new double[,]
                {
                    {1,0,0,Vector.X*CurrentFrame/Duration },
                    {0,1,0,Vector.X*CurrentFrame/Duration },
                    {0,0,1,Vector.X*CurrentFrame/Duration },
                    {0,0,0,1 }
                });
            }

            if (CurrentFrame > Duration)
            {
                return Matrix<double>.Build.DenseOfArray(new double[,]
                {
                    {1,0,0,Vector.X*(2*Duration-CurrentFrame)/Duration },
                    {0,1,0,Vector.X*(2*Duration-CurrentFrame)/Duration },
                    {0,0,1,Vector.X*(2*Duration-CurrentFrame)/Duration },
                    {0,0,0,1 }
                });
            }
            return null;
        }
    }
}
