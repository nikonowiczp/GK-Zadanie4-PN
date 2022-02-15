using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Zadanie4_PN.BitmapController;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Objects
{
    public class HomogenousClippingSpaceTriangle
    {
        public Vertice[] Vertices = new Vertice[3];
        public List<SinglePixel> Pixels = new();
        public Color TriangleColor = Color.Green;
        
        public Material Material;
        public HomogenousClippingSpaceTriangle(Matrix<double> projectionMatrix, Matrix<double> viewMatrix, Matrix<double> modelMatrix, MeshTriangle triangle, Color color)
        {
            TriangleColor = color;
            Material = triangle.Material;
            var MultiplyMatrix = projectionMatrix * viewMatrix * modelMatrix;
            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = new Vertice(triangle.Vertices[i]);
                var vec = Vector<double>.Build.DenseOfArray(new double[] { Vertices[i].modelPosition[0,0], Vertices[i].modelPosition[1,0], Vertices[i].modelPosition[2,0], 1 });
                var vec2 = vec.ToColumnMatrix();
                Vertices[i].worldPosition = modelMatrix * vec2;
                Vertices[i].modelPosition = MultiplyMatrix * vec2;
                Vertices[i].modelNormal = modelMatrix * Vertices[i].modelNormal;

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
                vertex.modelPosition[0,0] = (vertex.modelPosition[0,0]+1) * width/2;
                //TODO powinno być -1, ale z nim nie dziala
                vertex.modelPosition[1,0] = (vertex.modelPosition[1,0] + 1) * height / 2;
                vertex.modelPosition[2,0] = (vertex.modelPosition[2,0] + 1) / 2;
            }
        }

        public void GeneratePixelsFromBottom()
        {

        }
    }
}
