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

        private void RemoveFirstChunk(Road road)
        {
            if (road.EnabledChunks.Count < 1)
                return;

            DisableChunk(road.EnabledChunks[0], road);
        }

        private void GenerateChunkAhead(Road road)
        {
            if (road.PresetChunks.Length < 1)
                return;

            var chunk = GetChunk(road);

            if (road.EnabledChunks.Count < 2)
                return;

            var chunkBeforeLast = road.EnabledChunks[road.EnabledChunks.Count - 2];
            var chunkPosition =
                chunkBeforeLast.transform.position + chunkBeforeLast.Length * Vector3.forward;

            chunk.transform.position = chunkPosition;
        }

        private Chunk GetChunk(Road road)
        {
            var randomChunk = road.PresetChunks[Random.Range(0, road.PresetChunks.Length)];

            foreach (var chunk in road.DisabledChunks)
                if (chunk.ID == randomChunk.ID)
                    return EnableChunk(chunk, road);

            return EnableChunk(_factory.Create(randomChunk, Vector3.zero, road.transform), road);
        }

        private Chunk DisableChunk(Chunk chunk, Road road)
        {
            chunk.gameObject.SetActive(false);

            road.EnabledChunks.Remove(chunk);
            road.DisabledChunks.Add(chunk);

            return chunk;
        }

        private Chunk EnableChunk(Chunk chunk, Road road)
        {
            chunk.gameObject.SetActive(true);
            chunk.transform.position = Vector3.zero;

            road.DisabledChunks.Remove(chunk);
            road.EnabledChunks.Add(chunk);

            return chunk;
        }
    }
}