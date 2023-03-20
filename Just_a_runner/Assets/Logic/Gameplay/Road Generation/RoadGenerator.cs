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
            var chunks = road.ActiveChunks;

            if (chunks.Count == 0)
                GenerateChunkAhead(road);
            else if (DistanceToCharacter(chunks[chunks.Count - 1]) < road.DistanceToGenerateNewChunk)
                GenerateChunkAhead(road);
            else if (DistanceToCharacter(chunks[0]) > road.DistanceToRemoveOldChunk)
                RemoveFirstChunk(chunks);

            float DistanceToCharacter(Chunk chunk)
                => (chunk.transform.position - characterPosition).magnitude;
        }

        private void GenerateChunkAhead(Road road)
        {
            if (road.PresetChunks.Length < 1)
                return;

            var chunk = GetRandomChunk(road.PresetChunks);

            var lastChunk = road.ActiveChunks.Count == 0 ? null
                : road.ActiveChunks[road.ActiveChunks.Count - 1];

            var lastChunkPosition = lastChunk == null ? Vector3.zero
                : lastChunk.transform.position + lastChunk.Length * Vector3.forward;

            road.ActiveChunks.Add(_factory.Create(chunk, lastChunkPosition, road.transform)); //
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

    public class ChunkFactory // + pool ?
    {


        public Chunk Create(Chunk original, Vector3 position, Transform parent)
        {
            return Object.Instantiate(original, position, Quaternion.identity, parent);
        }
    }
}