using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EntitiesUpdate : ITickable
    {
        private List<Entity> _entities = World.Entities;

        public void Tick(float deltaTime)
        {
            Debug.Log(_entities.Count);

            for (var i = 0; i < _entities.Count; i++)
                _entities[i].Update();
        }
    }
}