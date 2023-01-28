using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EventUpdate : IFixedUpdateSystem
    {
        private static List<IEventFilter> _filters = new();

        private List<IEvent> _currentEvents = new();
        private List<IEvent> _worldEvents;

        public EventUpdate(EcsWorld world)
        {
            _worldEvents = world.Events;
        }

        public static void AddFilter(IEventFilter filter)
        {
            //Debug.Log("Add-request");

            foreach (var savedFilter in _filters)
                if (savedFilter.GetEventType() == filter.GetEventType())
                    return;

            //Debug.Log("Added");

            _filters.Add(filter);
        }

        public static void RemoveFilter(IEventFilter filter)
            => _filters.Remove(filter);

        public void FixedUpdate(float deltaTime)
        {
            UpdateEvents();
            UpdateFilters();
        }

        private void UpdateEvents()
        {
            foreach (var currentEvent in _currentEvents)
                _worldEvents.Remove(currentEvent);

            _currentEvents.Clear();

            //Debug.Log($"events count: {_currentEvents.Count}");

            foreach (var @event in _worldEvents)
                _currentEvents.Add(@event);
        }

        private void UpdateFilters()
        {
            foreach (var @event in _worldEvents)
            {
                foreach (var filter in _filters)
                {
                    if (filter.GetEventType() != @event.GetType())
                        continue;

                    filter.AddEvent(@event);
                    break;
                }
            }
        }
    }
}