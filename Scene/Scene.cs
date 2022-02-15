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
            var sceneObject = SceneGenerator.GenerateCube();
            sceneObject.modelAnimation = new AnimationRotation(60);
            sceneObject.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            sceneObject.ObjectColor = Color.Green;

            var sceneObject2 = SceneGenerator.GenerateCube();
            sceneObject2.originalModelMatrix= sceneObject.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}});
            sceneObject2.originalModelMatrix = sceneObject2.originalModelMatrix * DenseMatrix.OfArray(new double[,]
            {
                {1,0,0,0 },
                {0,1,0,2 },
                {0,0,1,0 },
                {0,0,0,1 }
            });
            sceneObject2.modelAnimation = new AnimationAlongLineLooped((2, 0, 0), 30, 30, false);
            sceneObject2.modelAnimation.AddInnerAnimation(new AnimationRotation(30));
            sceneObject2.ObjectColor = Color.Red;

            var sceneObject3 = SceneGenerator.GenerateSphere(1,10,10);
            sceneObject3.ObjectColor = Color.Pink;
            sceneObject3.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,2},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            sceneObject3.modelAnimation = new AnimationAlongLineLooped((2, 0, 0), 10, 10, false);
            SceneObjects.Add(sceneObject);
            SceneObjects.Add(sceneObject2);
            SceneObjects.Add(sceneObject3);

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
