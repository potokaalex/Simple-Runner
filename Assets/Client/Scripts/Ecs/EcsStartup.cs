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
            var eventSystem = new EventSystem();

            _systems
                .Add(new CollisionDetectionSystem(eventSystem))
                .Add(new DeadByCollisionSystem(eventSystem))
                .Add(new GravitySystem())
                .Add(MovementSystems(eventSystem))
                .Add(eventSystem);
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

        private EcsSystems MovementSystems(EventSystem eventSystem)
            => new EcsSystems()
            .Add(new JumpSystem(eventSystem))
            .Add(new MoveForwardSystem())
            .Add(new ChangeRoadSystem());
    }
}