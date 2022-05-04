using MinecraftCopy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinecraftCopy.Gen
{

    public static class GenerateMesh
    {
        public static readonly CubeData _cubeData = new CubeData();

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

        public static Mesh[] GenerateSingleChunk(ChunkData chunkData)
        {
            Mesh[] meshes = new Mesh[chunkData.subChunks.Length];

            for (int i = 0; i < chunkData.subChunks.Length; i++)
            {
                Mesh m = new Mesh();

                List<Vector3> vertices = new List<Vector3>();
                List<int> triangles = new List<int>();

                for(int x = 1; x < chunkData.chunkRealSize - 1; x++)
                {
                    int tIndex = 0;
                    for (int y = 1; y < chunkData.chunkRealSize - 1; y++)
                    {
                        for (int z = 1; z < chunkData.chunkRealSize - 1; z++)
                        {
                            var blockThis = chunkData.subChunks[i].chunkBlocks[x, y, z];

                            for (int f = 0; f < CubeData.faceDirections.Length; f++)
                            {
                                var blockOther = chunkData.subChunks[i].chunkBlocks[
                                    x + CubeData.faceDirections[f].x,
                                    y + CubeData.faceDirections[f].y, 
                                    z + CubeData.faceDirections[f].z];

                                if (blockThis==1&&blockOther==0)
                                {
                                    var face = _cubeData.GetCubeFace(f, new Vector3(x, y, z), tIndex);

                                    vertices.AddRange(face.vertices);
                                    triangles.AddRange(face.triangles);

                                    tIndex = triangles.Max() + 1;

                                    //Debug.Log($"{i} {x} {y} {z} {f} {blockThis} {blockOther}");
                                }
                            }
                        }
                    }
                }

                m.vertices = vertices.ToArray();
                m.triangles = triangles.ToArray();

                m.RecalculateNormals();

                meshes[i] = m;
            }

            return meshes;
        }
    }
}
