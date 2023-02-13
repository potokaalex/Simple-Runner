using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Systems;
using MovementSystem;
using InputSystem;
using CollisionSystem;
using MapGeneration;

namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        //[SerializeField] private InfiniteRoad _infiniteRoad;

        private EcsWorld _world = new();
        private EcsSystems _systems = new();

        private void Awake()
        {
            _systems
                //senders:
                .Add(new InputUpdate()) //[Core]
                .Add(new CharacterDeathDetector())
                .Add(new CollisionDetectors())

                //handlers:
                .Add(new EventUpdate(_world)) //[Core]
                .Add(new ComponentUpdate()) //[Core]

                //.Add(new Spawner())
                //.Add(new ChunksGeneration())
                //.Add(new SingletonChecker())

                .Add(Movement());
        }

        private void Update()
        {
            foreach (var system in _systems.UpdateSystems)
                system.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            foreach (var system in _systems.FixedUpdateSystems)
                system.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            foreach (var system in _systems.LateUpdateSystems)
                system.LateUpdate(Time.fixedDeltaTime); //fixed time ?!?!
        }

        private EcsSystems Movement()
            => new EcsSystems()
            //.Add(new SurfaceHandlersUpdate())
            .Add(new MoveRightUpdate())
            .Add(new MoveLeftUpdate())
            .Add(new RunUpdate())
            .Add(new JumpUpdate());

        private EcsSystems Collision() //?!?!
            => new EcsSystems()
            .Add(new CollisionDetectors());

        /*
        private void OnDisable()
        {
            _world.Components.Clear();
            _world.Events.Clear();
        }
        */

    }

    public class JumpUpdate : IFixedUpdateSystem // its shuldn`t exist !
    {
        public void FixedUpdate(float deltaTime) { }
    }
}