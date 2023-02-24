using System.Collections.Generic;

namespace Ecs
{
    internal class Filters : Entity
    {
        private List<IComponent> _removedComponents;
        private List<IComponent> _addedComponents;
        private List<Filter> _filters;

        internal Filters()
        {
            _removedComponents = new();
            _addedComponents = new();
            _filters = new();
        }

        internal void UpdateFilters()
        {
            AddComponentsToFilters();
            RemoveComponentsAtFilters();
        }

        internal void AddFilter(Filter filter)
            => _filters.Add(filter);

        internal void AddComponent(IComponent component)
            => _addedComponents.Add(component);

        internal void RemoveComponent(IComponent component)
            => _removedComponents.Add(component);

        private void AddComponentsToFilters()
        {
            if (_addedComponents.Count < 1)
                return;

            foreach (var component in _addedComponents)
                foreach (var filter in _filters)
                    filter.Add(component.Entity);

            _addedComponents.Clear();
        }

        private void RemoveComponentsAtFilters()
        {
            if (_removedComponents.Count < 1)
                return;

            foreach (var component in _removedComponents)
                foreach (var filter in _filters)
                    filter.Remove(component.Entity);

            _removedComponents.Clear();
        }
    }
}