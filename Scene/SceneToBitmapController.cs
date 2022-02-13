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
            currentCamera = new Camera((10,10,-5),(0,0,0));
            Cameras.Add(currentCamera);

            var camera = new Camera((-1, -1, 1), (0, 0, 0));
            Cameras.Add(camera);
            var camera2 = new Camera((10, 0, 1), (0, 0, 0));
            Cameras.Add(camera2);

            GenerateProjectionMatrix( Math.PI/2, 0.5, 1, 16 / 9);
        }

        Scene scene = new Scene();

        private int Width;
        private int Height;
        private BitmapLowLevelController bitmapLowLevelController;

        public List<Camera> Cameras = new();
        private Camera currentCamera = null;

        public void SetCamera(int i)
        {
            currentCamera = Cameras[i];
        }

        private Matrix<double> projectionMatrix;
        

        public void GenerateProjectionMatrix(double fieldOfView, double closerWall, double fartherWall, double aspect)
        {
            projectionMatrix = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                {1/Math.Tan(fieldOfView/2)/aspect, 0, 0, 0 },
                {0, 1/Math.Tan(fieldOfView/2),0,0 },
                {0, 0, (fartherWall+closerWall)/(fartherWall-closerWall), -2*fartherWall*closerWall/(fartherWall-closerWall) },
                {0, 0, 1,0 }
            });
        }
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
                    clippingTriangles.Add(new HomogenousClippingSpaceTriangle(projectionMatrix, viewMatrix, sceneObj.ModelMatrix, triangle));
                }
            }
            DrawClippedTriangles(clippingTriangles);
        }
        private void DrawClippedTriangles(List<HomogenousClippingSpaceTriangle> clippingTriangles)
        {
            foreach (var triangle in clippingTriangles)
            {
                triangle.TranslateVerticesToScreenCoordinates();
                triangle.ScaleToScreen(Width, Height);
                for (int i = 0; i < 3; i++)
                {
                    var point1 = GetPointFromVertice(triangle.Vertices[i]);
                    var point2 = GetPointFromVertice(triangle.Vertices[(i + 1) % 3]);
                    bitmapLowLevelController.DrawLine(point1, point2 , Color.Black);
                }
            }

        }

        private Point GetPointFromVertice(Vertice vertice)
        {
            return new Point((int)vertice.modelPosition[0], (int)vertice.modelPosition[1]);
        }
    }
}
