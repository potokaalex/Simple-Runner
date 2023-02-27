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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Entity()
        {
            World.Entities.Add(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Entity(IComponent component, GameObject gameObject) : this()
        {
            _gameObject = gameObject;
            Add(component);
        }

        public GameObject GameObject
            => _gameObject;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count()
            => _components.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count<ComponentType>() where ComponentType : IComponent
        {
            var count = 0;

            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType)
                    count++;

            return count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains<ComponentType>() where ComponentType : IComponent
        {
            for (var i = 0; i < _components.Count; i++)
                if (_components[i] is ComponentType)
                    return true;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(IComponent component)
            => _addedComponents.Add(component);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(IComponent component)
            => _removedComponents.Add(component);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateAdditions()
        {
            if (_addedComponents.Count < 1)
                return;

            for (var ai = 0; ai < _addedComponents.Count; ai++)
            {
                _components.Add(_addedComponents[ai]);

                for (var fi = 0; fi < World.Filters.Count; fi++)
                    World.Filters[fi].Add(_addedComponents[ai].Entity);
            }

            _addedComponents.Clear();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateDeletions()
        {
            if (_removedComponents.Count < 1)
                return;

            for (var ai = 0; ai < _removedComponents.Count; ai++)
            {
                _components.Remove(_removedComponents[ai]);

                for (var fi = 0; fi < World.Filters.Count; fi++)
                    World.Filters[fi].Remove(_removedComponents[ai].Entity);
            }

            _removedComponents.Clear();
        }
    }
}