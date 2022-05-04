using System;
using UnityEngine;

namespace MinecraftCopy.Data
{
    public class SubChunkData
    {
        public ushort[,,] chunkBlocks;

        public int chunkYOffset;

        public void PopulateWithBlock(ushort blockId, int s, bool insideOnly = false)
        {
            chunkBlocks = new ushort[s, s, s];

            int _s = s - 1;

            Func<int, int, int, bool> borderDetect = (x, y, z) => {
                return (x == 0 || y == 0 || z == 0) || (x == _s || y == _s || z == _s);
            };

            //int solid = 0;
            //int air = 0;

            for (int x = 0; x < s; x++)
            {
                for (int y = 0; y < s; y++)
                {
                    for (int z = 0; z < s; z++)
                    {
                        chunkBlocks[x, y, z] = insideOnly ? 
                            borderDetect(x, y, z) ? (ushort)0 : blockId : blockId;

                        //if (chunkBlocks[x, y, z] == 1) solid++; else air++;
                    }
                }
            }

            //Debug.Log($"solid {solid}, air {air}");
        }
    }

    public class ChunkData
    {
        public string chunkId;
        public Vector3Int chunkOffset;

        public SubChunkData[] subChunks;

        int chunkSize;
        public int chunkRealSize { get; private set; }
        int chunkHeight;

        public ChunkData() { }

        public ChunkData(Vector3Int chunkOffset, int chunkSize = 16, int chunkHeight = 8)
        {
            this.chunkOffset = chunkOffset;
            this.chunkSize = chunkSize;
            chunkRealSize = chunkSize + 2;
            this.chunkHeight = chunkHeight;

            subChunks = new SubChunkData[chunkSize];

            // populate with empty blocks
            for (int i = 0; i < subChunks.Length; i++)
            {
                subChunks[i] = new SubChunkData();
                subChunks[i].chunkYOffset = i * chunkSize;
                subChunks[i].PopulateWithBlock(1, chunkRealSize, true);
            }
        }
    }
}
