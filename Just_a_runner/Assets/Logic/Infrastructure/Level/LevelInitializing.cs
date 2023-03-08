using Infrastructure.StateMachine;
using RoadGeneration;
using MovementSystem;
using StateMachine;
using InputSystem;
using DeathSystem;
using Zenject;
using Ecs;

namespace Infrastructure
{
    public class LevelInitializing : IInitializable
    {
        private SystemsFactory _systemsFactory;
        private Systems _systems;

        private GlobalStateMachine _stateMachine;
        private StateFactory _stateFactory;

        public LevelInitializing(
            SystemsFactory systemsFactory,
            GlobalStateMachine stateMachine,
            StateFactory stateFactory,
            Systems systems)
        {
            _systemsFactory = systemsFactory;
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _systems = systems;
        }

        public void Initialize()
        {
            SystemsCompilation();
            StartingLevelState();
        }

        private Systems Core
            => new Systems()
            .Add(_systemsFactory.Create<EntitiesUpdate>())
            .Add(_systemsFactory.Create<InputUpdate>());

        private Systems Gameplay
            => new Systems()
            .Add(_systemsFactory.Create<RoadGenerator>())
            .Add(_systemsFactory.Create<DeathHandler>())

            .Add(_systemsFactory.Create<MoveRightUpdate>())
            .Add(_systemsFactory.Create<MoveLeftUpdate>())
            .Add(_systemsFactory.Create<RunUpdate>());

        private void SystemsCompilation()
        {
            _systems
                .Add(Core)
                .Add(Gameplay);
        }

        private void StartingLevelState()
        {
            _stateMachine.Add(_stateFactory.Create<LevelState>());
            _stateMachine.SwitchTo<LevelState>();
        }
    }
}