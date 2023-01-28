using System;

namespace Ecs
{
    public interface IEventFilter
    {
        public Type GetEventType();

        public void AddEvent(IEvent @event);

        public void RemoveEvent(IEvent @event);
    }
}
