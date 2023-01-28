using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Systems;
using Movement;

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

                .Add(Movement())

                .Add(new SliderUpdateSystem());
            //.Add(new CollisionDetectionSystem())
            //.Add(new DeadByCollisionSystem())
            //.Add(new GravitySystem())
            //.Add(MovementSystems());

            //component removed system
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
                system.LateUpdate(Time.fixedDeltaTime);
        }

        private EcsSystems Movement()
            => new EcsSystems()
            .Add(new MoveUpdate())
            .Add(new JumpUpdate());
        //.Add(new MovementSystem());
        //.Add(new MoveForwardSystem())
        //.Add(new ChangeRoadSystem());

    }

    public class JumpUpdate : IFixedUpdateSystem
    {
        public void FixedUpdate(float deltaTime)
        {
            //throw new System.NotImplementedException();
        }
    }

    public class MoveRight : EcsComponent
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }

    public class MoveLeft : EcsComponent
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }
}