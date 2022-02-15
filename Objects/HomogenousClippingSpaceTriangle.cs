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

        public Vector<double> GetNormalVector()
        {
            double X = (Vertices[0].modelNormal[0] + Vertices[1].modelNormal[0] + Vertices[2].modelNormal[0]);
            double Y = (Vertices[0].modelNormal[1] + Vertices[1].modelNormal[1] + Vertices[2].modelNormal[1]);
            double Z = (Vertices[0].modelNormal[2] + Vertices[1].modelNormal[2] + Vertices[2].modelNormal[2]);
            return Vector<double>.Build.DenseOfArray(new double[] { X,Y,Z});
        }

        public SinglePixel GetSinglePixel()
        {
            var screenCoordinates = (Vertices[0].modelPosition + Vertices[1].modelPosition + Vertices[2].modelPosition)/3;
            var worldCoordinates = (Vertices[0].worldPosition + Vertices[1].worldPosition + Vertices[2].worldPosition) / 3;
            var normalVector = GetNormalVector();
            SinglePixel singlePixel = new SinglePixel((screenCoordinates[0,0], screenCoordinates[1, 0], screenCoordinates[2, 0] ),
                (worldCoordinates[0,0], worldCoordinates[1, 0], worldCoordinates[2, 0]),
                (normalVector[0], normalVector[1], normalVector[2]),
                TriangleColor);
            return singlePixel;
        }

    }
}
