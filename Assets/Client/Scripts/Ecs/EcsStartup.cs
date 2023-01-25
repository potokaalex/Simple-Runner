using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Core;
using Ecs.Systems;
using Movement;

namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsSystems _systems = new();

        private void Awake()
        {
            //var eventSystem = new EventSystem();

            _systems
                //event loading system

                .Add(new SliderUpdateSystem());
                //.Add(new CollisionDetectionSystem())
                //.Add(new DeadByCollisionSystem())
                //.Add(new GravitySystem())
                //.Add(MovementSystems());

                //event cleaning system
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
            Debug.Log("Event CLEAR");

            foreach (var system in _systems.LateUpdateSystems)
                system.LateUpdate(Time.fixedDeltaTime);

            EcsWorld.ClearEvents();
        }

        private EcsSystems MovementSystems()
            => new EcsSystems();
        //.Add(new MovementSystem());
        //.Add(new MoveForwardSystem())
        //.Add(new ChangeRoadSystem());
    }
}