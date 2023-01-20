using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Core;
using Ecs.Systems;


namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsSystems _systems = new();

        private void Awake()
        {
            _systems.Add(new CollisionDetectionSystem())
                .Add(new DeadByCollisionSystem())
                .Add(new GravitySystem())
                .Add(MovementSystems());
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
            //EcsEvents.Clear();
        }

        private EcsSystems MovementSystems()
            => new EcsSystems()
            .Add(new JumpSystem())
            .Add(new MoveForwardSystem())
            .Add(new ChangeRoadSystem());
    }
}