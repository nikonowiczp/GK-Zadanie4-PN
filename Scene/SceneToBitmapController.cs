using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GK_Zadanie4_PN.BitmapController;
using GK_Zadanie4_PN.Lighting;
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
            currentCamera = new Camera((12,12,-5),(0,0,0));
            Cameras.Add(currentCamera);

            var camera = new Camera((25, 0, 1), (0, 0, 0));
            Cameras.Add(camera);
            var camera2 = new Camera((12, -12, 1), (0, 0, 0));
            Cameras.Add(camera2);
            GenerateProjectionMatrix( Math.PI/4, 1, 20, width/height);

            LightSource light = new LightSource((3,3,0),Color.Yellow);
            lightSources.Add(light);
        }

        Scene scene = new Scene();

        private int Width;
        private int Height;
        private BitmapLowLevelController bitmapLowLevelController;

        public List<Camera> Cameras = new();
        private Camera currentCamera = null;
        public LightingMode lightingMode = LightingMode.Static;
        public List<LightSource> lightSources = new();

        public void SetCamera(int i)
        {
            currentCamera = Cameras[i];
        }

        public void SetLightingMode(LightingMode mode)
        {
            lightingMode = mode;
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
                    clippingTriangles.Add(new HomogenousClippingSpaceTriangle(projectionMatrix, viewMatrix, sceneObj.ModelMatrix, triangle, sceneObj.ObjectColor));
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
                GeneratePixels(triangle);
            }
            Rasterize(clippingTriangles);
            ApplyLighting(clippingTriangles);
            DrawPixels(clippingTriangles);
        }

        private Point GetPointFromVertice(Vertice vertice)
        {
            return new Point((int)vertice.modelPosition[0,0], (int)vertice.modelPosition[1,0]);
        }

        private void Rasterize(List<HomogenousClippingSpaceTriangle> clippingTriangles)
        {

        }

        private void GeneratePixels(HomogenousClippingSpaceTriangle triangle)
        {
            SortedDictionary<int, List<ScanLineAlgorithmCell>> cells = new();
            for(int i = 0; i < 3; i++)
            {
                var edge = GenerateETEdge(triangle, i,(i + 1) % 3);
                if (!cells.ContainsKey(edge.Item1)) cells.Add(edge.Item1, new List<ScanLineAlgorithmCell>());

                cells.GetValueOrDefault(edge.Item1).Add(edge.Item2);
            }

            FillScanLine(cells, triangle);
        }

        private (int, ScanLineAlgorithmCell) GenerateETEdge(HomogenousClippingSpaceTriangle triangle, int i1, int i2)
        {
            Vertice lower = triangle.Vertices[i1].modelPosition[1,0] < triangle.Vertices[i2].modelPosition[1, 0] ? triangle.Vertices[i1] : triangle.Vertices[i2];
            Vertice higher = triangle.Vertices[i1] == lower ? triangle.Vertices[i2] : triangle.Vertices[i1];

            if(lower.modelPosition[1,0] == higher.modelPosition[1,0] && lower.modelPosition[0, 0] > higher.modelPosition[0, 0])
            {
                var tmp = lower;
                lower = higher;
                higher = tmp;
            }

            ScanLineAlgorithmCell cell = new();
            cell.Initialize(lower, higher);
            
            return ((int)lower.modelPosition[1,0], cell);
        }

        private void FillScanLine(SortedDictionary<int, List<ScanLineAlgorithmCell>> cells,HomogenousClippingSpaceTriangle triangle)
        {
            List<ScanLineAlgorithmCell> AET = new();
            var lowestKey = cells.Keys.Min();


            int currentY = lowestKey;

            while(AET.Count != 0 || cells.Count != 0)
            {
                if (cells.ContainsKey(currentY))
                {
                    AET.AddRange(cells[currentY]);
                    cells.Remove(currentY);
                }
                AET.Sort((c1, c2) => c1.currentX.CompareTo(c2.currentX));

                {
                    int currentX = (int)AET[0].currentX;
                    int maxX = (int)AET.Last().currentX;

                    double len = maxX - currentX;
                    double addZ = len == 0 ? 0 : (AET[1].currentZ - AET[0].currentZ)/len;
                    double addNormalX = len == 0 ? 0 : (AET[1].currentNormalX - AET[0].currentNormalX) / len;
                    double addNormalY = len == 0 ? 0 : (AET[1].currentNormalY - AET[0].currentNormalY) / len;
                    double addNormalZ = len == 0 ? 0 : (AET[1].currentNormalZ - AET[0].currentNormalZ) / len;

                    double currentZ = AET[0].currentZ;
                    double currentNormalX = AET[0].currentNormalX;
                    double currentNormalY = AET[0].currentNormalY;
                    double currentNormalZ = AET[0].currentNormalZ;

                    double currentWorldX = AET[0].currentWorldX;
                    double currentWorldY = AET[0].currentWorldY;
                    double currentWorldZ = AET[0].currentWorldZ;

                    double addWorldX = len == 0 ? 0 : (AET[1].currentWorldX - AET[0].currentWorldX) / len;
                    double addWorldY = len == 0 ? 0 : (AET[1].currentWorldY - AET[0].currentWorldY) / len;
                    double addWorldZ = len == 0 ? 0 : (AET[1].currentWorldZ - AET[0].currentWorldZ) / len;
                    for (int x = currentX; x<maxX; x++)
                    {
                        bitmapLowLevelController.SetSinglePixel(x, currentY, triangle.TriangleColor);
                        triangle.Pixels.Add(new SinglePixel((x, currentY, currentZ),(currentWorldX,currentWorldY,currentWorldZ),(currentNormalX,currentNormalY, currentNormalZ), triangle.TriangleColor));
                        currentZ += addZ;
                        currentNormalX += addNormalX;
                        currentNormalY += addNormalY;
                        currentNormalZ += addNormalZ;
                        currentWorldX += addWorldX;
                        currentWorldY += addWorldY;
                        currentWorldZ += addWorldZ;

                    }
                }


                AET.RemoveAll(edge => currentY + 1 >= edge.yMax);
                currentY++;
                foreach(var cell in AET)
                {
                    cell.AddValues();
                }
            }
        }
    
        private void DrawPixels(List<HomogenousClippingSpaceTriangle> clippingTriangles)
        {
            double [,] ZBuffer = new double[Width, Height];
 
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++) ZBuffer[i,j] = double.MinValue;
            }

            foreach(var triangle in clippingTriangles)
            {
                foreach(var pixel in triangle.Pixels)
                {
                    double Z = pixel.Z;
                    int X = (int) pixel.X;
                    int Y = (int) pixel.Y;
                    if(X<Width && X>= 0 && Y < Height && Y>=0 && Z >= ZBuffer[X,Y])
                    {
                        bitmapLowLevelController.SetSinglePixel(X, Y, pixel.GetColor());
                        ZBuffer[X,Y] = Z;
                    }
                }
            }
        }

        private void ApplyLighting(List<HomogenousClippingSpaceTriangle> clippingTriangles)
        {
            foreach(var triangle in clippingTriangles)
            {
                foreach(var pixel in triangle.Pixels)
                {
                    var color = CalculateSingleLight(pixel, triangle);
                    pixel.R = color[0];
                    pixel.G = color[1];
                    pixel.B = color[2];
                }
            }
        }

        private Vector<double> CalculateSingleLight(SinglePixel pixel, HomogenousClippingSpaceTriangle triangle)
        {
            Vector<double> finalColor = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0});
            Vector<double> normal = Vector<double>.Build.DenseOfArray(new double[] { pixel.NormalX, pixel.NormalY, pixel.NormalZ }).Normalize(2);

            for(int i = 0; i < 3; i++)
            {
                finalColor[i] = triangle.Material.KA * pixel.GetColorFromVector(i);
            }

            foreach (var light in lightSources)
            {
                Vector<double> LPixelToLight = Vector<double>.Build.DenseOfArray(new double[] { light.Position[0] - pixel.WorldX, light.Position[1] - pixel.WorldY, light.Position[2] - pixel.WorldZ });
                double toPixelToLight = LPixelToLight.L2Norm();
                LPixelToLight = LPixelToLight.Normalize(2);
                Vector<double> NormalWersor = Vector<double>.Build.DenseOfArray(new double[] { pixel.NormalX, pixel.NormalY, pixel.NormalZ }).Normalize(2);
                Vector<double> ReflectionWersor = (2* (LPixelToLight*NormalWersor)*NormalWersor-LPixelToLight).Normalize(2);
                Vector<double> ObserverWersor = Vector<double>.Build.DenseOfArray(new double[] {currentCamera.CameraPosition.X-pixel.WorldX,currentCamera.CameraPosition.Y-pixel.WorldY, currentCamera.CameraPosition.Z - pixel.WorldZ}).Normalize(2);
                double FirstMulti = triangle.Material.KD *(LPixelToLight*NormalWersor);
                double SecondMulti = triangle.Material.KS * Math.Pow(ReflectionWersor * ObserverWersor, triangle.Material.Shininess);

                double iF = 1 / (1+0.09*toPixelToLight + 0.032*toPixelToLight*toPixelToLight);
                for(int i = 0;i< 3; i++)
                {
                    finalColor[i] += (FirstMulti * light.ColorDiffuse[i] + SecondMulti * light.ColorSpecular[i])*iF;
                }
            }
            for(int i = 0; i < 3; i++)
            {
                if(finalColor[i] <=0)finalColor[i] = 0;
                if(finalColor[i] >255)finalColor[i] = 255;
            }
            return finalColor;
           
        }
        private void ApplyLightingPhong(SinglePixel pixel)
        {
            
        }
        
        private void ApplyLightingGouraud(SinglePixel pixel)
        {

        }

        private void ApplyLightingConstant(SinglePixel pixel)
        {

        }

    }

    enum LightingMode
    {
        Static = 0,
        Geraud = 1,
        Phong = 2
    }
}
