using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace RoadGeneration
{
    public class RoadGenerator : IFixedTickable
    {
        private Filter<CharacterMarker> _characters = new();
        private Filter<Road> _roads = new();
        private ChunkFactory _factory = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var road in _roads.Components)
                foreach (var character in _characters.Components)
                    Generate(road, character.transform.position);
        }

        private void Generate(Road road, Vector3 characterPosition)
        {
            var chunks = road.EnabledChunks;

            if (chunks.Count == 0)
                GenerateChunkAhead(road);
            else if (DistanceToCharacter(chunks[chunks.Count - 1]) < road.DistanceToGenerateNewChunk)
                GenerateChunkAhead(road);
            else if (DistanceToCharacter(chunks[0]) > road.DistanceToRemoveOldChunk)
                RemoveFirstChunk(road);

            float DistanceToCharacter(Chunk chunk)
                => (chunk.transform.position - characterPosition).magnitude;
        }

        private void GenerateChunkAhead(Road road)
        {
            if (road.PresetChunks.Length < 1)
                return;

            var chunk = GetChunk(road);

            var lastChunk = road.EnabledChunks.Count == 0 ? null
                : road.EnabledChunks[road.EnabledChunks.Count - 1];

            var chunkPosition = lastChunk == null ? Vector3.zero
                : lastChunk.transform.position + lastChunk.Length * Vector3.forward;

            chunk.transform.position = chunkPosition;
            road.EnabledChunks.Add(chunk);
        }

        private void RemoveFirstChunk(Road road)
        {
            if (road.EnabledChunks.Count < 1)
                return;

            var firstChunk = road.EnabledChunks[0];

            road.DisabledChunks.Add(firstChunk);
            road.EnabledChunks.Remove(firstChunk);
        }

        private Chunk GetChunk(Road road)
        {
            var randomChunk = road.PresetChunks[Random.Range(0, road.PresetChunks.Length)];

            foreach (var chunk in road.DisabledChunks)
            {
                if (chunk.ID == randomChunk.ID)
                {
                    road.DisabledChunks.Remove(chunk);
                    return chunk;
                }
            }

            return _factory.Create(randomChunk, Vector3.zero, road.transform);
        }
    }
}