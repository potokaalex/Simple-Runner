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

        public CharacterScoreCounter(CharacterMarker character, CharacterScore score, RoadData roadData)
        {
            _character = character;
            _score = score;

            _startingPosition = roadData.FirstChunk == null
                ? Vector3.zero
                : roadData.FirstChunk.transform.position;
        }

        public void FixedTick(float deltaTime)
        {
            foreach (var character in _characters.Components)
            {
                Count();
            }

            var score = (_character.transform.position - _startingPosition).z - 1;

            if (score < 0)
                return;

            _score.CurrentScore = new((uint)score);
        }

        private void Count()
        {

        }
    }
}