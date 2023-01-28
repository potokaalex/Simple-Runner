using System.Collections.Generic;

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
            foreach (var savedFilter in _filters)
                if (savedFilter.GetEventType() == filter.GetEventType())
                    return;

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