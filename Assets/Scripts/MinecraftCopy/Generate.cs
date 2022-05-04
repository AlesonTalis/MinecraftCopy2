using MinecraftCopy.Gen;
using System.Collections;
using UnityEngine;

namespace MinecraftCopy
{
    public class Generate : MonoBehaviour
    {
        [SerializeField]
        private MeshFilter meshFilter;


        public void GenerateSingleCube()
        {
            meshFilter.mesh = GenerateMesh.GenerateSingleCube(new Data.CubeData());
        }

        public void GenerateSingleChunk()
        {
            meshFilter.mesh = GenerateMesh.GenerateSingleChunk(new Data.ChunkData(Vector3Int.zero))[2];
        }
    }
}