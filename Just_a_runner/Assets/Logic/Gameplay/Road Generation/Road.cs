using System.Collections.Generic;
using Ecs;

namespace RoadGeneration
{
    public class Road : EcsComponent
    {
        public List<Chunk> EnabledChunks;
        public List<Chunk> DisabledChunks;
        public Chunk[] PresetChunks;

        public float DistanceToGenerateNewChunk;
        public float DistanceToRemoveOldChunk;
    }
}
