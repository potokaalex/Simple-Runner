using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace Map
{
    public class ChunksGeneration : IFixedUpdateSystem
    {
        private const float DistanceToGenerateNewChunk = 100;
        private const float DistanceToRemoveOldChunk = 15;

        private Filter<Map> _roads = Filter.Create<Map>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var map in _roads)
            {
                var characterPosition = map.Character.position;
                var lastChunkPosition = Vector3.zero;
                var firstChunkPosition = Vector3.zero;

                if (map.ActiveChunks.Count > 1)
                {
                    firstChunkPosition = map.ActiveChunks[0].transform.position;
                    lastChunkPosition = map.ActiveChunks.Last().transform.position;
                }

                if ((lastChunkPosition - characterPosition).magnitude < DistanceToGenerateNewChunk)
                {
                    GenerateNewChunk(map);

                    if ((characterPosition - firstChunkPosition).magnitude > DistanceToRemoveOldChunk)
                        RemoveOldChunk(map);
                }
            }
        }

        private void GenerateNewChunk(Map map)
        {
            if (map.PresetChunks.Length < 1)
                return;

            var chunkIndex = Random.Range(0, map.PresetChunks.Length);
            var chunk = map.PresetChunks[chunkIndex];
            var chunkPosition = Vector3.zero;

            if (map.ActiveChunks.Count > 1)
            {
                var lastChunk = map.ActiveChunks.Last();

                chunkPosition = lastChunk.transform.position + lastChunk.Length * Vector3.forward;
            }

            map.ActiveChunks.Add(Object.Instantiate(chunk, chunkPosition, Quaternion.identity));
        }

        private void RemoveOldChunk(Map map)
        {
            var oldChunk = map.ActiveChunks[0];

            map.ActiveChunks.Remove(oldChunk);

            Object.Destroy(oldChunk.gameObject);
        }
    }
}