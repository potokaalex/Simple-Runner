using System.Collections.Generic;
using Ecs.Core;
using UnityEngine;

namespace Ecs
{
    public class ComponentFilter<ComponentType> where ComponentType : EcsComponent //old concept
    {
        private HashSet<ComponentType> _components;
        private EcsWorld _world;

        public ComponentFilter()
        {
            _world = EcsWorld.FindWorld();

            _components = new(_world.GetComponentsByType<ComponentType>());

            //EcsWorld.ComponentAdded += AddComponent;
            //EcsWorld.ComponentRemoved += RemoveComponent;
        }

        public IEnumerator<ComponentType> GetEnumerator() => _world.GetComponentsByType<ComponentType>().GetEnumerator();

        private void AddComponent(EcsComponent component)
        {
            if (component is not ComponentType)
                return;

            _components.Add(component as ComponentType);
        }

        private void RemoveComponent(EcsComponent component)
        {
            if (component is not ComponentType)
                return;

            _components.Remove(component as ComponentType);
        }
    }

    /*
    public class ComponentFilterUpdate // служит для обнавления информации в фильтрах
    {
        private HashSet<ComponentFilter<EcsComponent>> _filters;

        public ComponentFilter<ComponentType> GetFilter<ComponentType>() where ComponentType : EcsComponent
        {
            var filter = new ComponentFilter<ComponentType>();

            _filters.Add(filter);
        }
    }
    */
}