using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace RoadGeneration
{
    public class RoadGenerator : ITickable
    {
        private Transform _character;
        private RoadData _roadData;

        public RoadGenerator(CharacterMarker characterMarker, RoadData roadData)
        {
            _character = characterMarker.transform;
            _roadData = roadData;
        }

        public void Tick(float deltaTime)
        {
            if ((_roadData.LastChunkPosition - _character.position).magnitude < _roadData.DistanceToGenerateNewChunk)
                Generate(_roadData, _character.position, _roadData.FirstChunkPosition, _roadData.LastChunkPosition);
        }

        private void Generate(RoadData roadData, Vector3 characterPosition, Vector3 firstChunkPosition, Vector3 lastChunkPosition)
        {
            GenerateChunkAhead(roadData.PresetChunks, roadData.ActiveChunks);

            if ((characterPosition - firstChunkPosition).magnitude > roadData.DistanceToRemoveOldChunk)
                RemoveFirstChunk(roadData.ActiveChunks);
        }

        private void GenerateChunkAhead(Chunk[] presetChunks, List<Chunk> activeChunks)
        {
            if (presetChunks.Length < 1)
                return;

            var chunk = GetRandomChunk(presetChunks);
            var chunkPosition = activeChunks.Count < 1 ? Vector3.zero : activeChunks.Last().transform.position + activeChunks.Last().Length * Vector3.forward;

            activeChunks.Add(Object.Instantiate(chunk, chunkPosition, Quaternion.identity));
        }

        private void RemoveFirstChunk(List<Chunk> activeChunks)
        {
            if (activeChunks.Count < 1)
                return;

            var firstChunk = activeChunks[0];

            activeChunks.Remove(firstChunk);
            firstChunk.Entity.Destroy();
        }

        private Chunk GetRandomChunk(Chunk[] chunks)
            => chunks[Random.Range(0, chunks.Length)];
    }
}