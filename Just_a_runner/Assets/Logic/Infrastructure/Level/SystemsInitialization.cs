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
        private SystemsFactory _factory;
        private Systems _systems;

        public SystemsInitialization(SystemsFactory factory, Systems systems)
        {
            _factory = factory;
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
            .Add(_factory.Create<EntitiesUpdate>())
            .Add(_factory.Create<InputUpdate>());

        private Systems Gameplay
            => new Systems()
            .Add(_factory.Create<CharacterScoreCounter>())
            .Add(_factory.Create<RoadGenerator>())
            .Add(_factory.Create<DeathHandler>())
            .Add(Movement);

        private Systems Movement
            => new Systems()
            .Add(_factory.Create<MoveDirectionUpdate>())
            .Add(_factory.Create<MovePositionUpdate>())
            .Add(_factory.Create<MoveRightUpdate>())
            .Add(_factory.Create<MoveLeftUpdate>());
    }
}