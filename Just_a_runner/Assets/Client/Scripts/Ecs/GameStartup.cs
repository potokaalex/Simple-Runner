using UnityEngine;
//using Ecs.Systems;
using MovementSystem;
using InputSystem;
//using InputSystem;
//using CollisionSystem;
//using MapGeneration;
using DeathSystem;
using Zenject;
using RoadGeneration;

namespace Ecs
{
    public class GameStartup : MonoBehaviour //временно управляет updata`ми, в будущем - состояние
    {
        public CharacterMarker CharacterMarker;
        public RoadData RoadData;

        private Systems _updateSystems = new();
        private Systems _fixedUpdateSystems = new();

        //[Inject]
        //private void Constructor()
        //{
        //}

        private void Awake()
        {
            _fixedUpdateSystems
                .Add(new EntitiesUpdate())
                .Add(new EventsRemove())
                .Add(new RoadGenerator(CharacterMarker, RoadData))
                .Add(new Death(CharacterMarker))

                .Add(Movement());

            _updateSystems
                .Add(new InputUpdate());
        }

        private void Update()
        {
            //if (PauseManager.IsPaused)
            //    return;

            _updateSystems.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            //if (PauseManager.IsPaused)
            //    return;

            _fixedUpdateSystems.Update(Time.fixedDeltaTime);
        }

        private Systems Movement()
            => new Systems()
            .Add(new MoveRightUpdate())
            .Add(new MoveLeftUpdate())
            .Add(new RunUpdate());
    }
}