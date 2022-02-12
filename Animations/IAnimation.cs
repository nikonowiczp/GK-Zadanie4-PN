﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace GK_Zadanie4_PN.Animations
{
    internal interface IAnimation
    {
        public Matrix<double> GetNextFrameMatrix();
    }
}
