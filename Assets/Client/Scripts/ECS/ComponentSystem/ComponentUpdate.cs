using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class ComponentUpdate : IFixedUpdateSystem
    {
        private static List<EcsComponent> _currentComponents = new();
        private static List<Filter> _filters = new();

        private Filter<ComponentAdded> _addeds = Filter.Create<ComponentAdded>();
        private Filter<ComponentRemoved> _removeds = Filter.Create<ComponentRemoved>();

        public static Filter<FilterType> GetFilter<FilterType>()
        {
            foreach (var savedFilter in _filters)
                if (savedFilter.GetFilterType() == typeof(FilterType))
                    return savedFilter as Filter<FilterType>;

            var newFilter = new Filter<FilterType>();

            foreach (var @event in _currentComponents)
                newFilter.Add(@event);

            _filters.Add(newFilter);

            return newFilter;
        }

        public static void RemoveFilter(Filter filter)
            => _filters.Remove(filter);

        public void FixedUpdate(float deltaTime)
        {
            foreach (var added in _addeds)
                AddComponent(added.Component);

            foreach (var removed in _removeds)
                RemoveComponent(removed.Component);
        }

        private void AddComponent(EcsComponent component)
        {
            _currentComponents.Add(component);

            foreach (var filter in _filters)
                filter.Add(component);
        }

        private void RemoveComponent(EcsComponent component)
        {
            _currentComponents.Remove(component);

            foreach (var filter in _filters)
                filter.Remove(component);
        }
    }
}