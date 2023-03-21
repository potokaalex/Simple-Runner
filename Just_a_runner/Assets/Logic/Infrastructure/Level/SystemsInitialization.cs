using RoadGeneration;
using MovementSystem;
using DeathSystem;
using InputSystem;
using Statistics;
using Zenject;
using Ecs;

namespace Infrastructure.Installers
{
    public class SystemsInitialization : IInitializable
    {
        private SystemsFactory _systemsFactory;
        private Systems _systems;

        public SystemsInitialization(SystemsFactory systemsFactory, Systems systems)
        {
            _systemsFactory = systemsFactory;
            _systems = systems;
        }

        public void Initialize()
        {
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