using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class Entity
    {
        private List<IComponent> _removedComponents = new();
        private List<IComponent> _addedComponents = new();
        private List<IComponent> _getComponentsBuffer = new();
        private List<IComponent> _components = new();
        private GameObject _gameObject;
        private bool _isDestroyed;

        internal Entity()
        {
            World.Entities.Add(this);
        }

        public Entity(IComponent component, GameObject gameObject) : this()
        {
            _gameObject = gameObject;
            Add(component);
        }

        public GameObject GameObject
            => _gameObject;

        public int Count()
            => _components.Count;

        public int Count<ComponentType>() where ComponentType : IComponent
        {
            var count = 0;

            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType)
                    count++;

            return count;
        }

        public bool Contains<ComponentType>() where ComponentType : IComponent
        {
            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType)
                    return true;

            return false;
        }

        public ComponentType Get<ComponentType>() where ComponentType : IComponent
        {
            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType desiredComponent)
                    return desiredComponent;

            return default;
        }

        public void Get<ComponentType>(out List<IComponent> components) where ComponentType : IComponent
        {
            _getComponentsBuffer.Clear();

            var componentsCount = Count<ComponentType>();
            components = _getComponentsBuffer;

            if (componentsCount < 1)
                return;

            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType desiredComponent)
                    _getComponentsBuffer.Add(desiredComponent);
        }

        public void Add(IComponent component)
            => _addedComponents.Add(component);

        public void Remove(IComponent component)
            => _removedComponents.Add(component);

        public void Destroy()
        {
            foreach (var component in _components)
                _removedComponents.Add(component);

            _isDestroyed = true;
        }

        internal void Update()
        {
            UpdateAdditions();
            UpdateDeletions();

            if (_isDestroyed)
            {
                World.Entities.Remove(this);
                Object.Destroy(_gameObject);
            }
        }

        private void UpdateAdditions()
        {
            if (_addedComponents.Count < 1)
                return;

            for (var a = 0; a < _addedComponents.Count; a++)
            {
                _components.Add(_addedComponents[a]);

                for (var b = 0; b < World.Filters.Count; b++)
                    World.Filters[b].Add(_addedComponents[a].Entity);
            }

            _addedComponents.Clear();
        }

        private void UpdateDeletions()
        {
            if (_removedComponents.Count < 1)
                return;

            for (var a = 0; a < _removedComponents.Count; a++)
            {
                _components.Remove(_removedComponents[a]);

                for (var b = 0; b < World.Filters.Count; b++)
                    World.Filters[b].Remove(_removedComponents[a].Entity);
            }

            _removedComponents.Clear();
        }
    }
}