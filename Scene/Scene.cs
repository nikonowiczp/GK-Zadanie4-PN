using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GK_Zadanie4_PN.Objects;
using GK_Zadanie4_PN.BitmapController;
using GK_Zadanie4_PN.Animations;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Scene
{
    internal class Scene
    {
        public Scene()
        {
            var cubeMoving = SceneGenerator.GenerateCube();
            //cubeMoving.modelAnimation = new AnimationRotation(120);
            cubeMoving.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
                {1,0,0,0},
                {0,1,0,1},
                {0,0,1,0},
                {0,0,0,1}});
            cubeMoving.VectorMoveX = 8;
            cubeMoving.ObjectColor = Color.Red;
            cubeMoving.modelAnimation = new AnimationRotation(120);
            cubeMoving.dontCut = true;
            
            var cubeMoving2 = SceneGenerator.GenerateCube();
            //cubeMoving.modelAnimation = new AnimationRotation(120);
            cubeMoving2.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
                {1,0,0,0},
                {0,1,0,1},
                {0,0,1,0},
                {0,0,0,1}});
            cubeMoving2.VectorMoveX = 8;
            cubeMoving2.ObjectColor = Color.Red;
            cubeMoving2.modelAnimation = new AnimationRotation(120);
            for (int i = 0; i < 6; i++) cubeMoving2.modelAnimation.GetNextFrameMatrix();
            cubeMoving2.dontCut = true;
            cubeMoving2.movingAlongCameraNumber = 2;
            cubeMoving2.observingCameraNumber = 1;
            cubeMoving2.movingAlongLightNumber = 1;

            var sphere = SceneGenerator.GenerateSphere(2,20,30);
            sphere.ObjectColor = Color.Pink;
            sphere.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1.5,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            sphere.VectorMoveY = 2;
            sphere.modelAnimation = new AnimationRotation(125);

            var sphere2 = SceneGenerator.GenerateSphere(1, 10, 10);
            sphere2.ObjectColor = Color.Pink;
            sphere2.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1.5,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            sphere2.VectorMoveY = 4;
            sphere2.modelAnimation = new AnimationRotation(135);

            var floor1 = SceneGenerator.GenerateFloor(20,32);
            floor1.ObjectColor = Color.DarkGreen;
            floor1.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            floor1.dontCut = true;
            
            SceneObjects.Add(sphere);
            SceneObjects.Add(sphere2);
            SceneObjects.Add(floor1);

            SceneObjects.Add(cubeMoving);
            SceneObjects.Add(cubeMoving2);

        }
        public List<SceneObject> SceneObjects = new List<SceneObject>();

        public void AddObject(SceneObject sceneObject)
        {
            SceneObjects.Add(sceneObject);
        }

        public void GenerateNextFrame()
        {
            foreach(var sceneObject in SceneObjects)
            {
                sceneObject.GenerateNextFrame();
            }
        }

    }
}
