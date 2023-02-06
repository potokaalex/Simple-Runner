using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace WorldGeneration
{
    public class Road : EcsComponent
    {
        public List<RoadTile> DisabledTiles;
        public List<RoadTile> EnabledTiles;
        public RoadTile[] PresetTiles;
        public Transform Character;
        public float Length;
    }
}