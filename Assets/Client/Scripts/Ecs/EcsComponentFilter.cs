using System.Collections.Generic;
using Ecs.Core;
using UnityEngine;

namespace Ecs
{
    public class ComponentFilter<ComponentType> where ComponentType : EcsComponent
    {
        private HashSet<ComponentType> _components = new();

        public ComponentFilter()
        {
            var components = EcsWorld.GetComponents();

            foreach (var component in components)
                if (component is ComponentType)
                    _components.Add(component as ComponentType);

            EcsWorld.ComponentAdded += AddComponent;
            EcsWorld.ComponentRemoved += RemoveComponent;
        }

        public IEnumerator<ComponentType> GetEnumerator() => _components.GetEnumerator();

        public void Destroy()
        {
            EcsWorld.ComponentAdded -= AddComponent;
            EcsWorld.ComponentRemoved -= RemoveComponent;
        }

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
}