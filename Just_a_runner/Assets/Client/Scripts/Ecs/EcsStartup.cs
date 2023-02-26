using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Ecs.Systems;
using MovementSystem;
using InputSystem;
//using InputSystem;
//using CollisionSystem;
//using MapGeneration;

namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        //[SerializeField] private InfiniteRoad _infiniteRoad;

        private Systems _updateSystems = new();
        private Systems _fixedUpdateSystems = new();

        private void Awake()
        {
            _fixedUpdateSystems
                .Add(new ComponentsUpdate())
                .Add(new EventsRemove())
                //.Add(new RaycastersUpdate())

                .Add(Movement());

            _updateSystems
                .Add(new InputUpdate());

            /*
        _systems
            //senders:
            .Add(new FiltersUpdate())
            //.Add(new InputUpdate()) //[Core]
            .Add(new CharacterDeathDetector())
            //.Add(new CollisionDetectors())

            //handlers:
            //.Add(new EventUpdate(_world)) //[Core]
            //.Add(new ComponentUpdate()) //[Core]

            //.Add(new Spawner())
            //.Add(new ChunksGeneration())
            //.Add(new SingletonChecker())

            .Add(Movement());
            */
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

        //private Systems Collision() //?!?!
        //   => new Systems()
        //   .Add(new CollisionDetectors());


        //private void OnDisable()
        //{
        //    _world.Components.Clear();
        //    _world.Events.Clear();
        //}
    }
}