using RoadGeneration;
using UnityEngine;
using Ecs;

namespace Statistics
{
    public class CharacterScoreCounter : IFixedTickable
    {
        private Filter<CharacterMarker> _characters = new();
        private CharacterScore _score;
        private Vector3 _startingPosition;

        public CharacterScoreCounter(StatisticsData data)
        {
            var road = GetRoad();

            _score = data.CharacterScore;

            _startingPosition = (road == null || road.ActiveChunks.Count == 0)
                ? Vector3.zero
                : road.ActiveChunks[0].transform.position;
        }

        public void FixedTick(float deltaTime)
        {
            foreach (var character in _characters.Components)
                Count(character.transform.position);
        }

        private Road GetRoad()
        {
            foreach (var entity in World.Entities)
                if (entity.Contains<Road>())
                    return entity.Get<Road>();

            return null;
        }

        private void Count(Vector3 characterPosition)
        {
            var score = (characterPosition - _startingPosition).z - 1;

            if (score < 0)
                return;

            _score.CurrentScore = new((uint)score);
        }
    }
}