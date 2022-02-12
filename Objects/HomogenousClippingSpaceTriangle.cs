using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Objects
{
    public class HomogenousClippingSpaceTriangle
    {
        public Vertice[] Vertices = new Vertice[3];
        public HomogenousClippingSpaceTriangle(Matrix<double> projectionMatrix, Matrix<double> viewMatrix, Matrix<double> modelMatrix, MeshTriangle triangle)
        {
            var MultiplyMatrix = projectionMatrix * viewMatrix * modelMatrix;
            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = new Vertice(triangle.Vertices[i]);
                Vertices[i].modelPosition = MultiplyMatrix * Vector<double>.Build.DenseOfArray(new double[] { Vertices[i].modelPosition[0], Vertices[i].modelPosition[1], Vertices[i].modelPosition[2], 1}) ;
            }
        }

    }
}
