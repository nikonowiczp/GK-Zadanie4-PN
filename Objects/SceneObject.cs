using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using GK_Zadanie4_PN.Animations;

namespace GK_Zadanie4_PN.Objects
{
    internal class SceneObject
    {
        public List<MeshTriangle> MeshTriangles= new();
        public Matrix<double> originalModelMatrix;

        public Matrix<double> ModelMatrix;

        
        public IAnimation modelAnimation;

        public void GenerateNextFrame()
        {
            if (modelAnimation == null)
            {
                ModelMatrix = originalModelMatrix;
                return;
            }
            
            var nextMatrix = modelAnimation.GetNextFrameMatrix();
            ModelMatrix = originalModelMatrix*nextMatrix;
        }
    }
}
