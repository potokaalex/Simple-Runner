using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace Map
{
    public class Map : EcsComponent
    {
        public List<Chunk> ActiveChunks;
        public Chunk[] PresetChunks;
        public Transform Character;
    }
}