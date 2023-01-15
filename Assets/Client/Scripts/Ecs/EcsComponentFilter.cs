using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EcsComponentFilter<ComponentType> where ComponentType : EcsComponent
    {
        public HashSet<ComponentType> Components;

        public EcsComponentFilter(EcsWorld world)
        {
            Components = new(Object.FindObjectsOfType<ComponentType>());

            world.TryAddFilter(this as EcsComponentFilter<EcsComponent>);
        }
    }
}