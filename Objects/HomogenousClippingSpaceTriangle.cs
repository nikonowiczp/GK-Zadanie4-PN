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
                var vec = Vector<double>.Build.DenseOfArray(new double[] { Vertices[i].modelPosition[0], Vertices[i].modelPosition[1], Vertices[i].modelPosition[2], 1 });
                var vec2 = vec.ToRowMatrix();
                Vertices[i].modelPosition = MultiplyMatrix * vec2;
            }
        }

        public void TranslateVerticesToScreenCoordinates()
        {
            foreach (var vertex in Vertices) vertex.MakeScreenCoordinatesFromClipping();
        }

        public void ScaleToScreen(double width, double height)
        {
            foreach(var vertex in Vertices)
            {
                vertex.modelPosition[0] = (vertex.modelPosition[0]+1) * width/2;
                //TODO powinno być -1, ale z nim nie dziala
                vertex.modelPosition[1] = (vertex.modelPosition[1] + 1) * height / 2;
                vertex.modelPosition[2] = (vertex.modelPosition[2] + 1) / 2;
            }
        }
    }
}
