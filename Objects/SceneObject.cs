using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using GK_Zadanie4_PN.Animations;
using System.Drawing;

namespace GK_Zadanie4_PN.Objects
{
    public class SceneObject
    {
        public List<MeshTriangle> MeshTriangles= new();
        public Matrix<double> originalModelMatrix;

        public Matrix<double> ModelMatrix;

        public Color ObjectColor = Color.Aqua;

        public double VectorMoveX;
        public double VectorMoveY;
        public double VectorMoveZ;

        public int observingCameraNumber = -1;
        public int movingAlongCameraNumber = -1;
        public int movingAlongLightNumber = -1;
        public IAnimation modelAnimation;
        //to jest rozwiazanie ktore ma dzialac dla dokladnie mojego przypdaku. Nie jest to dobre rozwiązanie.
        public MovementAlongCircle circleAnimation = null;

        public bool dontCut = false;
        public void GenerateNextFrame()
        {
            if(circleAnimation != null)
            {
                var nextMatrixRotation = modelAnimation.GetNextFrameMatrix();
                var nextVector = circleAnimation.GetNextVector();
                VectorMoveX = nextVector.X;
                VectorMoveY = nextVector.Y;
                VectorMoveZ = nextVector.Z;
                ModelMatrix = originalModelMatrix * nextMatrixRotation;
                return;
            }
            if (modelAnimation == null)
            {
                ModelMatrix = originalModelMatrix;
                return;
            }
            
            var nextMatrix = modelAnimation.GetNextFrameMatrix();
            ModelMatrix = originalModelMatrix *nextMatrix * Matrix<double>.Build.DenseOfArray(new double[,]
                {
                    {1,0,0,VectorMoveX },
                    {0,1,0,VectorMoveY },
                    {0,0,1,VectorMoveZ },
                    {0,0,0,1 }
                });
        }
    }
}
