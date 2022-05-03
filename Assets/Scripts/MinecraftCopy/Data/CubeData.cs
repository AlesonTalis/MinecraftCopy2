using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinecraftCopy.Data
{
    public class FaceData
    {
        public int faceDirection;

        public Vector3[] vertices;
        public int[] triangles;

        public Vector3[] normals;
        public Vector2[] uvs;
    }

    public class CubeData
    {
        public FaceData[] faces = new FaceData[]
        {
            new FaceData()
            {
                faceDirection = 0,// top
                vertices = new Vector3[]
                {
                    new Vector3(-1,1,1), new Vector3(1,1,1),

                    new Vector3(-1,1,-1), new Vector3(1,1,-1)
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            },
            new FaceData()
            {
                faceDirection=1,// bottom
                vertices = new Vector3[]
                {
                    new Vector3(1,-1,1), new Vector3(-1,-1,1),

                    new Vector3(1,-1,-1), new Vector3(-1,-1,-1)
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            },
            new FaceData()
            {
                faceDirection=2,// front
                vertices = new Vector3[]
                {
                    new Vector3(1,1,1), new Vector3(-1,1,1),
                    new Vector3(1,-1,1), new Vector3(-1,-1,1),
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            },
            new FaceData()
            {
                faceDirection=3,// back
                vertices = new Vector3[]
                {
                    new Vector3(-1,1,-1), new Vector3(1,1,-1),
                    new Vector3(-1,-1,-1), new Vector3(1,-1,-1),
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            },
            new FaceData()
            {
                faceDirection=4,//right
                vertices = new Vector3[]
                {
                    new Vector3(1,1,-1), new Vector3(1,1,1),
                    new Vector3(1,-1,-1), new Vector3(1,-1,1),
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            },
            new FaceData()
            {
                faceDirection=5,// left
                vertices = new Vector3[]
                {
                    new Vector3(-1,1,1), new Vector3(-1,1,-1),
                    new Vector3(-1,-1,1), new Vector3(-1,-1,-1),
                },
                triangles = new int[]
                {
                    0,3,2,
                    0,1,3
                }
            }
        };

        public (Vector3[] vertices, int[] triangles, Vector2[] uv) GetMeshData()
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uv = new List<Vector2>();

            int tIndex = 0;

            for(int i = 0; i < faces.Length; i++)
            {
                if (triangles.Count > 0) tIndex = triangles.Max() + 1;

                for(int t = 0; t < faces[i].triangles.Length; t++)
                {
                    triangles.Add(faces[i].triangles[t] + tIndex);
                }

                vertices.AddRange(faces[i].vertices);
                //uv.AddRange(faces[i].uvs);
            }

            // tamanho correto do cubo
            for (int v = 0; v < vertices.Count; v++)
            {
                vertices[v] *= 0.5f;
            }

            return (vertices.ToArray(), triangles.ToArray(), uv.ToArray());
        }
    }
}
