﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace MapGeneration
{
    public class Map : MonoBehaviour // why not ecs ??
    {
        [SerializeField] private Chunk[] _presetChunks;
        [SerializeField] private List<Chunk> _activeChunks;

        private const float DistanceToGenerateNewChunk = 100;
        private const float DistanceToRemoveOldChunk = 25;

        private RoadGenerator _generator = new();
        private Transform _character;

       // private void Start()
        //    => _character = Singleton<CharacterMarker>.Instance.transform;

        private void FixedUpdate()
        {
            var oldChunkPosition = _activeChunks.Count < 1 ? Vector3.zero : _activeChunks[0].transform.position;
            var lastChunkPosition = _activeChunks.Count < 1 ? Vector3.zero : _activeChunks.Last().transform.position;

            if ((lastChunkPosition - _character.position).magnitude < DistanceToGenerateNewChunk)
            {
                _generator.GenerateChunkAhead(_presetChunks, _activeChunks);

                if ((_character.position - oldChunkPosition).magnitude > DistanceToRemoveOldChunk)
                    _generator.RemoveOldChunk(_activeChunks);
            }
        }
    }
}