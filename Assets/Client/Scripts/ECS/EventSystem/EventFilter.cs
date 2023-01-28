using System.Collections.Generic;
using System;

namespace Ecs
{
    public class EventFilter<EventType> : IEventFilter where EventType : IEvent
    {
        private List<EventType> _events = new();

        public EventFilter()
        {
            EventUpdate.AddFilter(this);
        }

        public IEnumerator<EventType> GetEnumerator() => _events.GetEnumerator();

        public void AddEvent(IEvent @event)
        {
            if (@event is EventType eventAsEventType)
                if (_events.Contains(eventAsEventType))
                    _events.Add(eventAsEventType);
        }

        public void RemoveEvent(IEvent @event)
        {
            if (@event is EventType eventAsEventType)
                _events.Remove(eventAsEventType);
        }

        public Type GetEventType() => typeof(EventType);
    }
}
