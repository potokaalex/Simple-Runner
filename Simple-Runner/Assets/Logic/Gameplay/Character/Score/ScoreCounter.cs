using Infrastructure;
using UnityEngine;
using Ecs;

namespace Character
{
    public class ScoreCounter : IFixedTickable
    {
        private Filter<CharacterMarker> _characters = new();
        private Score _score;

        public ScoreCounter(DataProvider data)
            => _score = data.CharacterData.Score;

        public void FixedTick(float deltaTime)
        {
            foreach (var character in _characters.Components)
                Count(character.transform.position);
        }

        private void Count(Vector3 currentPosition)
        {
            var score = currentPosition.z - 1;

            if (score < 0)
                return;

            _score.CurrentScore = new((uint)score);
        }
    }
}
