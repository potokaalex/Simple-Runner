using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Systems;
using MovementSystem;
using InputSystem;
using CollisionSystem;

namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world = new();
        private EcsSystems _systems = new();

        private void Awake()
        {
            _systems
                .Add(new EventUpdate(_world))
                .Add(new ComponentUpdate())
                .Add(new InputUpdate())

                .Add(new CollisionDetectorsUpdate())

                .Add(Movement());

            //.Add(new SliderUpdateSystem());
            //.Add(new CollisionDetectionSystem())
            //.Add(new DeadByCollisionSystem())
            //.Add(new GravitySystem())
            //.Add(MovementSystems());
            //.Add(new Test());
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
            .Add(new SurfaceHandlersUpdate())
            .Add(new MoveRightUpdate())
            .Add(new MoveLeftUpdate())
            .Add(new RunUpdate())
            .Add(new JumpUpdate());

        private EcsSystems Collision() //?!?!
            => new EcsSystems()
            .Add(new CollisionDetectorsUpdate());

    }

    public class JumpUpdate : IFixedUpdateSystem
    {
        public void FixedUpdate(float deltaTime)
        {
            //throw new System.NotImplementedException();
        }
    }
}