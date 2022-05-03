using MinecraftCopy.Data;
using System;
using UnityEngine;

namespace MinecraftCopy.Gen
{

    public static class GenerateMesh
    {
        public static Mesh GenerateSingleCube(CubeData cubeData)
        {
            Mesh m = new Mesh();

            var meshData = cubeData.GetMeshData();

            m.vertices = meshData.vertices;
            m.triangles = meshData.triangles;
            //m.uv = meshData.uv;

            m.RecalculateBounds();
            m.RecalculateNormals();

            return m;
        }
    }
}
