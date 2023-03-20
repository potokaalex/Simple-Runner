using System.Collections.Generic;
using Ecs;

namespace RoadGeneration
{
    public class Road : EcsComponent
    {
        public List<Chunk> ActiveChunks;
        public Chunk[] PresetChunks;

        public float DistanceToGenerateNewChunk; //= 100
        public float DistanceToRemoveOldChunk; //= 25
    }
}