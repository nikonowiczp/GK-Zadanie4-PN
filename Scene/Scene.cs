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
            var sceneObject = new SceneObject();

            var material = new Material(0.5,0.5,0.5,20);
            Vertice vertice11 = new Vertice(-1, -1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice12 = new Vertice(1, -1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice13 = new Vertice(-1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle triangle1 = new MeshTriangle(vertice11, vertice12, vertice13, material);
            sceneObject.MeshTriangles.Add(triangle1);

            Vertice vertice21 = new Vertice(1, -1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice22 = new Vertice(-1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice23 = new Vertice(1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle triangle2 = new MeshTriangle(vertice21, vertice22, vertice23, material);
            sceneObject.MeshTriangles.Add(triangle2);

            Vertice vertice31 = new Vertice(-1, -1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice32 = new Vertice(1, -1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice33 = new Vertice(-1, 1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle triangle3 = new MeshTriangle(vertice31, vertice32, vertice33, material);
            sceneObject.MeshTriangles.Add(triangle3);

            Vertice vertice41 = new Vertice(1, -1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice42 = new Vertice(-1, 1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice43 = new Vertice(1, 1, -1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle triangle4 = new MeshTriangle(vertice41, vertice42, vertice43, material);
            sceneObject.MeshTriangles.Add(triangle4);

            MeshTriangle triangle5 = new MeshTriangle(vertice11, vertice31, vertice13, material);
            sceneObject.MeshTriangles.Add(triangle5);
            MeshTriangle triangle6 = new MeshTriangle(vertice13, vertice31, vertice33, material);
            sceneObject.MeshTriangles.Add(triangle6);

            MeshTriangle triangle7 = new MeshTriangle(vertice13, vertice23, vertice33, material);
            sceneObject.MeshTriangles.Add(triangle7);
            MeshTriangle triangle8 = new MeshTriangle(vertice33, vertice43, vertice23, material);
            sceneObject.MeshTriangles.Add(triangle8);

            MeshTriangle triangle9 = new MeshTriangle(vertice12, vertice23, vertice43, material);
            sceneObject.MeshTriangles.Add(triangle9);
            MeshTriangle triangle10 = new MeshTriangle(vertice43, vertice32, vertice12, material);
            sceneObject.MeshTriangles.Add(triangle10);

            MeshTriangle triangle11 = new MeshTriangle(vertice11, vertice12, vertice31, material);
            sceneObject.MeshTriangles.Add(triangle11);
            MeshTriangle triangle12 = new MeshTriangle(vertice31, vertice32, vertice12, material);
            sceneObject.MeshTriangles.Add(triangle12);


            sceneObject.modelAnimation = new AnimationRotation(60);
            sceneObject.originalModelMatrix = DenseMatrix.OfArray(new double[,] {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1}});
            sceneObject.ObjectColor = Color.Green;

            var sceneObject2 = new SceneObject();
            sceneObject2.MeshTriangles.Add(triangle1);
            sceneObject2.MeshTriangles.Add(triangle2);
            sceneObject2.MeshTriangles.Add(triangle3);
            sceneObject2.MeshTriangles.Add(triangle4);
            sceneObject2.MeshTriangles.Add(triangle5);
            sceneObject2.MeshTriangles.Add(triangle6);
            sceneObject2.MeshTriangles.Add(triangle7);
            sceneObject2.MeshTriangles.Add(triangle8);
            sceneObject2.MeshTriangles.Add(triangle9);
            sceneObject2.MeshTriangles.Add(triangle10);
            sceneObject2.MeshTriangles.Add(triangle11);
            sceneObject2.MeshTriangles.Add(triangle12);
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

            
            SceneObjects.Add(sceneObject2);
            SceneObjects.Add(sceneObject);

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
