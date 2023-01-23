using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ecs.Core
{
    public static class EcsWorld
    {
        private static HashSet<EcsComponent> _components = new();
        private static List<IEvent> _events = new();

        public static event ComponentTransfer ComponentAdded;
        public static event ComponentTransfer ComponentRemoved;

        //public static event EventTransfer EventAdded;
        //public static event EventTransfer EventRemoved;

        public static IEnumerable<ComponentType> GetComponentsByType<ComponentType>() where ComponentType : EcsComponent
            => _components.Where(component => component is ComponentType).Select(component => component as ComponentType);

        public static IEnumerable<EventType> GetEventsByType<EventType>()
            => _events.Where(@event => @event is EventType).Select(@event => (EventType)@event);

        public static bool TryAddComponent(EcsComponent component)
        {
            if (!_components.Add(component))
                return false;

            ComponentAdded?.Invoke(component);

            return true;
        }

        public static bool TryRemoveComponent(EcsComponent component)
        {
            if (!_components.Remove(component))
                return false;

            ComponentRemoved?.Invoke(component);

            return true;
        }

        public static void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public static void ClearEvents()
        {
            _events.Clear();
        }
    }
}