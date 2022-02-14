using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace GK_Zadanie4_PN.Objects
{
    internal class HomogenousClippingSpaceVertice
    {
        public HomogenousClippingSpaceVertice(Vertice vertice)
        {
            modelPosition = vertice.modelPosition.Clone();
            modelNormal = vertice.modelNormal.Clone();
            modelTangent = vertice.modelTangent.Clone();
            modelBinormal = vertice.modelBinormal.Clone();
            modelTexture = vertice.modelTexture.Clone();
        }
        public Matrix<double> modelPosition;

        public Vector<double> modelNormal;

        public Vector<double> modelTangent;

        public Vector<double> modelBinormal;

        public Vector<double> modelTexture;
    }
}
