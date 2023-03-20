using RoadGeneration;
using MovementSystem;
using DeathSystem;
using InputSystem;
using Statistics;
using Zenject;
using Ecs;

//using 
// can i move LevelData to factory, and then resolve all data? 

//level facking static (but non) data...

namespace Infrastructure.Installers
{
    public class SystemsInitialization : IInitializable
    {
        private LevelData _data;

        public SystemsInitialization(LevelData data)
        {
            _data = data;
        }

        public void Initialize()
        {
            _data.Systems
                .Add(Core)
                .Add(Gameplay);
        }

        private Systems Core
            => new Systems()
            .Add(new EntitiesUpdate())
            .Add(new InputUpdate());

        private Systems Gameplay
            => new Systems()
            //.Add(new CharacterScoreCounter())
            .Add(new RoadGenerator())
            //.Add(new DeathHandler())
            .Add(Movement);

        private Systems Movement
            => new Systems()
            .Add(new MoveDirectionUpdate())
            .Add(new MovePositionUpdate())
            .Add(new MoveRightUpdate())
            .Add(new MoveLeftUpdate());
    }
}