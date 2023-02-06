//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpawnSystem;
using Ecs;
using UnityEngine;

namespace WorldGeneration
{
    public class RoadGeneration : IFixedUpdateSystem
    {
        private const float _minRoadLength = 30;

        private Filter<Road> _roads = Filter.Create<Road>();

        private const float _m = 15;

        public void FixedUpdate(float deltaTime)
        {
            foreach (var road in _roads)
            {
                if (road.PresetTiles.Length < 1)
                    break;

                if (road.EnabledTiles.Count < 1 || (road.Character.position - road.EnabledTiles.Last().transform.position).magnitude < 15)
                    CreateSpawnRequest(GetRandomTile(road.PresetTiles));
            }
        }

        private RoadTile GetRandomTile(RoadTile[] presetTiles)
        {
            var tileIndex = Random.Range(0, presetTiles.Length);

            return presetTiles[tileIndex];
        }

        private void CreateSpawnRequest(RoadTile tile, Transform transform)
        {

        }
    }
}
