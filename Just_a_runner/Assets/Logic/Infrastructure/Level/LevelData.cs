using Infrastructure.Menus;
using RoadGeneration;
using Statistics;
using System;
using Ecs;

namespace Infrastructure
{
    [Serializable]
    public class LevelData
    {
        public CharacterMarker CharacterMarker;



        public RoadData RoadData;

        public CharacterScore CharacterScore = new();
        public Systems Systems = new();
    }
}