using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GK_Zadanie4_PN.BitmapController;
using GK_Zadanie4_PN.Objects;
using MathNet.Numerics.LinearAlgebra;

namespace GK_Zadanie4_PN.Scene
{
    internal class SceneToBitmapController
    {
        public SceneToBitmapController(int width, int height)
        {
            Width = width;
            Height = height;

            bitmapLowLevelController = new BitmapLowLevelController(Width, Height);
        }

        Scene scene = new Scene();

        private int Width;
        private int Height;
        private BitmapLowLevelController bitmapLowLevelController;

        public List<Camera> Cameras = new();
        private Camera currentCamera = null;

        private Matrix<double> projectionMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,10},
        {0,0,0,1}});
        public Bitmap GetBitmap()
        {
            return bitmapLowLevelController.Bitmap;
        }

        public void GenerateNextFrame()
        {
            scene.GenerateNextFrame();
            
            var viewMatrix = currentCamera.GetCameraMatrix();
            bitmapLowLevelController.CleanBitmap();

            List<HomogenousClippingSpaceTriangle> clippingTriangles = new();
            foreach(var sceneObj in scene.SceneObjects)
            {
                foreach(var triangle in sceneObj.MeshTriangles)
                {
                    clippingTriangles.Add(new HomogenousClippingSpaceTriangle(projectionMatrix, viewMatrix, sceneObj.ModelMatrix, triangle);
                }
            }
        }
        private void DrawClippedTriangles(List<HomogenousClippingSpaceTriangle> clippingTriangles)
        {
            foreach (var triangle in clippingTriangles)
            {
                for (int i = 0; i < 3; i++)
                {

                }
            }
        }

    }
}
