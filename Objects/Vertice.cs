using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Objects
{
    public class Vertice
    {
        public Vector<double> modelPosition;

        public Vector<double> modelNormal;

        public Vector<double> modelTangent;

        public Vector<double> modelBinormal;

        public Vector<double> modelTexture;


        public Vertice(double x, double y, double z, double normalX, double normalY, double normalZ, double tangentX, double tangentY, double tangentZ, double binormalX, double binormalY, double binormalZ, double textureX, double textureY, double textureZ)
        {
            modelPosition = Vector.Build.DenseOfArray(new double[] { x, y, z });

            modelNormal = Vector.Build.DenseOfArray( new double[] { normalX, normalY, normalZ });
            
            modelTangent = Vector.Build.DenseOfArray(new double[] {tangentX, tangentY, tangentZ });

            modelBinormal = Vector.Build.DenseOfArray(new double[] {binormalX, binormalY, binormalZ });

            modelTexture = Vector.Build.DenseOfArray(new double[] {textureX, textureY, textureZ });

        }

        public Vertice(Vertice vertice)
        {
            modelPosition = vertice.modelPosition.Clone();
            modelNormal = vertice.modelNormal.Clone();
            modelTangent = vertice.modelTangent.Clone();
            modelBinormal = vertice.modelBinormal.Clone();
            modelTexture = vertice.modelTexture.Clone();
        }
         
        public void MakeScreenCoordinatesFromClipping()
        {
            if(modelPosition.Count != 4)
            {
                throw new Exception("Not a clipping coordinate!");
            }

            if (modelPosition[3] == 0)
            {
                return;
                throw new Exception("Fourth coordinate 0");
            }

            double last = modelPosition[3];
            modelPosition =Vector<double>.Build.DenseOfArray(new double[] {modelPosition[0]/last, modelPosition[1]/last, modelPosition[2]/last});
        }
        public void MoveByMatrix(Matrix<double> moveMatrix)
        {
            throw new NotImplementedException();
        }
    }
}
