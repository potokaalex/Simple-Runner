using System.Collections.Generic;
using UnityEngine;
using Ecs;

//namespace ComponentUpdate
//{
    public class ComponentUpdate : IFixedUpdateSystem
    {
        private EcsWorld _world = EcsWorld.FindWorld();

        public void FixedUpdate(float deltaTime)
            => _world.UpdateComponents();
    }
//}
