using UnityEngine;

namespace RoadGeneration
{
    public class ChunkFactory
    {
        public Chunk Create(Chunk original, Vector3 position, Transform parent)
            => Object.Instantiate(original, position, Quaternion.identity, parent);
    }
}
