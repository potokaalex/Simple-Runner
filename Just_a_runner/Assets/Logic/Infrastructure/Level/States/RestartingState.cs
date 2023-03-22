using RoadGeneration;
using StateMachines;
using UnityEngine;
using Character;
using Ecs;

namespace Infrastructure
{
    public class RestartingState : IState
    {
        private SystemsInitialization _systems;
        private GameObject _characterPrefab;
        private Score _score;

        private IStateMachine _stateMachine;

        public RestartingState(
            SystemsInitialization systems,
            IStateMachine stateMachine,
            DataProvider data)
        {
            _characterPrefab = data.CharacterData.Prefab;
            _score = data.CharacterData.Score;
            _systems = systems;

            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            World.TryGetComponent<Road>(out var road);
            DisableChunks(road);

            World.TryGetComponent<CharacterMarker>(out var character);
            RebuidCharacter(character);

            _score.CurrentScore = new(0);
            _systems.Initialize();
            _stateMachine.SwitchTo<GameplayState>();
        }

        private void RebuidCharacter(CharacterMarker character)
        {
            if (character != null)
                character.Entity.Destroy();

            Object.Instantiate(_characterPrefab);
        }

        private void DisableChunks(Road road)
        {
            if (road == null)
                return;

            foreach (var chunk in road.EnabledChunks)
            {
                chunk.gameObject.SetActive(false);
                road.DisabledChunks.Add(chunk);
            }

            road.EnabledChunks.Clear();
        }
    }
}
