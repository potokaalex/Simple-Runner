using System.Collections.Generic;
using UnityEngine;

namespace RoadGeneration
{
    public class RoadData : MonoBehaviour
    {
        [SerializeField] private List<Chunk> _activeChunks;
        [SerializeField] private Chunk[] _presetChunks;

        [SerializeField] private float _distanceToGenerateNewChunk; //= 100
        [SerializeField] private float _distanceToRemoveOldChunk; //= 25

        public Chunk FirstChunk
                => (ActiveChunks.Count < 1) ? null : ActiveChunks[0];

        public Chunk LastChunk
                => (ActiveChunks.Count < 1) ? null : ActiveChunks[ActiveChunks.Count - 1];

        public Chunk[] PresetChunks
            => _presetChunks;

        public List<Chunk> ActiveChunks
            => _activeChunks;

        public float DistanceToGenerateNewChunk
            => _distanceToGenerateNewChunk;

        public float DistanceToRemoveOldChunk
            => _distanceToRemoveOldChunk;
    }
}