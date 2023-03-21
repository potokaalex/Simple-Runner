using System.Collections.Generic;
using RoadGeneration;
using StateMachines;
using Ecs;
using Statistics;
using MovementSystem;

namespace Infrastructure
{
    public class RestartingState : IState
    {
        private ScoreIndicator _scoreIndicator;
        private SystemsInitialization _systems;
        private CharacterMarker _character;
        private Road _road;

        private IStateMachine _stateMachine;

        public RestartingState(
            IStateMachine stateMachine,
            SystemsInitialization systems,
            ScoreIndicator scoreIndicator)
        {
            _scoreIndicator = scoreIndicator;
            _stateMachine = stateMachine;
            _systems = systems;

            World.TryGetComponent(out _character);
            World.TryGetComponent(out _road);
        }

        public void Enter()
        {
            DisableChunks();

            _character.transform.position = _character.StartPosition;
            _character.Entity.Get<MoveDirection>().Reset();
            _scoreIndicator.ClearScore();
            _systems.Initialize();
            _stateMachine.SwitchTo<GameplayState>();
        }

        private void DisableChunks()
        {
            foreach (var chunk in _road.EnabledChunks)
            {
                chunk.gameObject.SetActive(false);
                _road.DisabledChunks.Add(chunk);
            }

            _road.EnabledChunks.Clear();
        }
    }
}