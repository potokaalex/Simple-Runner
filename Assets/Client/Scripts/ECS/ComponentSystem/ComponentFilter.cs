using System.Collections.Generic;
using System;

namespace Ecs
{
    public class ComponentFilter<ComponentType> : IComponentFilter where ComponentType : EcsComponent
    {
        private List<ComponentType> _components = new();

        public ComponentFilter()
        {
            ComponentUpdate.AddFilter(this);
        }

        public IEnumerator<ComponentType> GetEnumerator() => _components.GetEnumerator();

        public void AddComponent(EcsComponent component)
        {
            if (component is ComponentType componentAsComponentType)
                if (!_components.Contains(componentAsComponentType))
                    _components.Add(componentAsComponentType);
        }

        public void RemoveComponent(EcsComponent component)
        {
            if (component is ComponentType componentAsComponentType)
                _components.Remove(componentAsComponentType);
        }

        public Type GetComponentType() => typeof(ComponentType);
    }
}