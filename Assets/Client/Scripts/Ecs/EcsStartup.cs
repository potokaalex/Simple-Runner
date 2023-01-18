using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            _world = new();
            _systems = new();

            _systems.Add(new JumpSystem(_world));
            _systems.Add(new GravitySystem(_world));
            //_systems.Add(new MoveForwardSystem(_world));
            _systems.Add(new ChangeRoadSystem(_world));
        }

        private void Update()
        {
            _systems.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _systems.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}