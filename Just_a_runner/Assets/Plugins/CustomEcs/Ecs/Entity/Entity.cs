using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class Entity
    {
        private List<IComponent> _components;
        private GameObject _gameObject;

        internal Entity()
        {
            World.Entities.Add(this);
        }

        public Entity(IComponent component, GameObject gameObject) : this()
        {
            _components.Add(component);
            _gameObject = gameObject;
        }

        public GameObject GameObject
            => _gameObject;

        public int Count()
            => _components.Count;

        public int Count<ComponentType>() where ComponentType : IComponent
        {
            int count = 0;

            foreach (var component in _components)
                if (component is ComponentType)
                    count++;

            return count;
        }

        public bool Contains<ComponentType>() where ComponentType : IComponent
        {
            foreach (var component in _components)
                if (component is ComponentType)
                    return true;

            return false;
        }

        public ComponentType Get<ComponentType>() where ComponentType : IComponent
        {
            foreach (var component in _components)
                if (component is ComponentType desiredComponent)
                    return desiredComponent;

            return default;
        }

        public void Get<ComponentType>(out ComponentType[] components) where ComponentType : IComponent
        {
            var componentsCount = Count<ComponentType>();
            components = new ComponentType[componentsCount];

            if (componentsCount < 1)
                return;

            var i = 0;

            foreach (var component in _components)
                if (component is ComponentType desiredComponent)
                    components[i++] = desiredComponent;
        }

        public void Add(IComponent component)
        {
            _components.Add(component);

            World.Filters.Add(component);
        }

        public void Remove(IComponent component)
        {
            _components.Remove(component);

            World.Filters.Remove(component);

            if (_components.Count < 1)
                World.Entities.Remove(this);
        }
    }
}