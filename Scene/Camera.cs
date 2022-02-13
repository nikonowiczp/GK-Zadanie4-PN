using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Scene
{
    internal class Camera
    {
        Matrix<double> ViewMatrix { get; set; }

        public (double X, double Y, double Z) CameraPosition;
        public (double X, double Y, double Z) LookingAt;
        public Camera((double X, double Y, double Z) cameraPosition, (double X, double Y, double Z) lookingAt)
        {
            CameraPosition = cameraPosition;
            LookingAt= lookingAt;
            UpdateViewMatrix();
        }
        public Matrix<double> GetCameraMatrix()
        {
            return ViewMatrix;
        }
        public void UpdateViewMatrix()
        {
            Vector<double> upWorld = Vector.Build.DenseOfArray(new double[] { 0, 1, 0 });
            Vector<double> dVector = Vector.Build.DenseOfArray(new double[] { CameraPosition.X - LookingAt.X, CameraPosition.Y - LookingAt.Y, CameraPosition.Z - LookingAt.Z });
            dVector = dVector.Normalize(2);

            Vector<double> rightVector = Cross(upWorld, dVector);
            rightVector = rightVector.Normalize(2);
            Vector<double> upVector = Cross(dVector, rightVector);
            upVector = upVector.Normalize(2);

            var firstView = DenseMatrix.OfArray(new double[,] {
            {rightVector[0],rightVector[1],rightVector[2],0},
            {upVector[0],upVector[1],upVector[2],0},
            {dVector[0],dVector[1],dVector[2],0},
            {0,0,0,1}});
            var secondView = DenseMatrix.OfArray(new double[,] {
            {1,0,0,-1*LookingAt.X},
            {0,1,0,-1*LookingAt.Y},
            {0,0,1,-1*LookingAt.Z},
            {0,0,0,1}});
            ViewMatrix = firstView * secondView;
        }
        public void NextFrame()
        {

        }

        private Vector<double> Cross(Vector<double> left, Vector<double> right)
        {
            if ((left.Count != 3 || right.Count != 3))
            {
                string message = "Vectors must have a length of 3.";
                throw new Exception(message);
            }
            Vector<double> result = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 });
            result[0] = left[1] * right[2] - left[2] * right[1];
            result[1] = -left[0] * right[2] + left[2] * right[0];
            result[2] = left[0] * right[1] - left[1] * right[0];

            return result;
        }
    }
}
