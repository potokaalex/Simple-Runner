using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ecs
{
    public class EventUpdate : IFixedUpdateSystem
    {
        private static List<IFilter> _filters = new(); //IEventFilter - массив событий по ти

        private List<IEvent> _currentEvents = new();
        private List<IEvent> _worldEvents;

        public EventUpdate(EcsWorld world)
        {
            _worldEvents = world.Events;
        }

        public static Filter<FilterType> GetFilter<FilterType>()
        {
            var filterType = typeof(FilterType);

            foreach (var savedFilter in _filters)
                if (savedFilter.GetFilterType() == filterType)
                    return savedFilter as Filter<FilterType>;

            var newFilter = new Filter<FilterType>();

            _filters.Add(newFilter);

            return newFilter;
        }

        public static void RemoveFilter(IFilter filter)
            => _filters.Remove(filter);

        public void FixedUpdate(float deltaTime)
        {
            RemoveEvents();
            _currentEvents.Clear();
            AddEvents();
        }

        private void AddEvents()
        {
            foreach (var @event in _worldEvents)
            {
                _currentEvents.Add(@event);

                foreach (var filter in _filters)
                    filter.Add(@event);
            }
        }

        private void RemoveEvents()
        {
            foreach (var currentEvent in _currentEvents)
            {
                _worldEvents.Remove(currentEvent);

                foreach (var filter in _filters)
                    filter.Remove(currentEvent);
            }
        }
    }
}