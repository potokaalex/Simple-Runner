using RoadGeneration;
using MovementSystem;
using DeathSystem;
using Character;
using Ecs;

namespace Infrastructure
{
    public class SystemsInitialization
    {
        private SystemsFactory _systemsFactory;
        private Systems _systems;

        public SystemsInitialization(SystemsFactory systemsFactory, DataProvider data)
        {
            _systemsFactory = systemsFactory;
            _systems = data.Systems;
        }

        public void Initialize()
        {
            _systems.Clear();

            _systems
                .Add(Core)
                .Add(Gameplay);
        }

        private Systems Core
            => new Systems()
            .Add(_systemsFactory.Create<EntitiesUpdate>());

        private Systems Gameplay
            => new Systems()
            .Add(_systemsFactory.Create<ScoreCounter>())
            .Add(_systemsFactory.Create<RoadGenerator>())
            .Add(_systemsFactory.Create<DeathHandler>())
            .Add(Movement);

        private Systems Movement
            => new Systems()
            .Add(_systemsFactory.Create<CameraFollowing>()) //
            .Add(_systemsFactory.Create<MoveDirectionUpdate>())
            .Add(_systemsFactory.Create<MovePositionUpdate>())
            .Add(_systemsFactory.Create<MoveRightUpdate>())
            .Add(_systemsFactory.Create<MoveLeftUpdate>());
    }
}
