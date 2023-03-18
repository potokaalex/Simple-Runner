using RoadGeneration;
using MovementSystem;
using StateMachine;
using InputSystem;
using DeathSystem;
using Statistics;
using Ecs;

namespace Infrastructure
{
    public class LevelState : IState
    {
        private SystemsFactory _systemsFactory;
        private Systems _systems;
        private GameLoop _gameLoop;

        public LevelState(SystemsFactory systemsFactory, GameLoop gameLoop)
        {
            UnityEngine.Debug.Log("LevelState - regenerated !");

            _systemsFactory = systemsFactory;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {
            SystemsInitialization();

            _gameLoop.OnFixedTick += _systems.FixedTick;
            _gameLoop.OnTick += _systems.Tick;
        }

        public void Exit()
        {
            _gameLoop.OnFixedTick -= _systems.FixedTick;
            _gameLoop.OnTick -= _systems.Tick;
        }

        private void SystemsInitialization()
        {
            _systems = new();

            _systems
                .Add(Core)
                .Add(Gameplay);
        }

        private Systems Core
            => new Systems()
            .Add(_systemsFactory.Create<EntitiesUpdate>())
            .Add(_systemsFactory.Create<InputUpdate>());

        private Systems Gameplay
            => new Systems()
            .Add(_systemsFactory.Create<CharacterScoreCounter>())
            .Add(_systemsFactory.Create<RoadGenerator>())
            .Add(_systemsFactory.Create<DeathHandler>())
            .Add(Movement);

        private Systems Movement
            => new Systems()
            .Add(_systemsFactory.Create<MoveDirectionUpdate>())
            .Add(_systemsFactory.Create<MovePositionUpdate>())
            .Add(_systemsFactory.Create<MoveRightUpdate>())
            .Add(_systemsFactory.Create<MoveLeftUpdate>());
    }
}