using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EntitiesUpdate : ITickable
    {
        public void Tick(float deltaTime)
        {
            for (var i = 0; i < World.Entities.Count; i++)
                World.Entities[i].Update();
        }
    }
}