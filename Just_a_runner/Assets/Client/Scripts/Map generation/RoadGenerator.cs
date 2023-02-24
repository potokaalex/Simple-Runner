using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace MapGeneration
{
    public class RoadGenerator
    {
        public void GenerateChunkAhead(Chunk[] presetChunks, List<Chunk> activeChunks)
        {
            if (presetChunks.Length < 1)
                return;

            var chunk = GetRandomChunk(presetChunks);
            var chunkPosition = activeChunks.Count < 1 ? Vector3.zero : activeChunks.Last().transform.position + activeChunks.Last().Length * Vector3.forward;

            activeChunks.Add(Object.Instantiate(chunk, chunkPosition, Quaternion.identity));
        }

        public void RemoveOldChunk(List<Chunk> activeChunks)
        {
            if (activeChunks.Count < 1)
                return;

            var oldChunk = activeChunks[0];

            activeChunks.Remove(oldChunk);
            Object.Destroy(oldChunk.gameObject);
        }

        private Chunk GetRandomChunk(Chunk[] chunks)
        {
            return chunks[Random.Range(0, chunks.Length)];
        }
    }
}