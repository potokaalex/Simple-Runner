using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EcsWorld
    {
        private static List<EcsComponent> _components = new();
        private static List<IEvent> _events = new();

        public List<EcsComponent> Components => _components;

        public List<IEvent> Events => _events;

        public static void AddComponent(EcsComponent component)
        {
            if (_components.Contains(component))
                return;

            Debug.Log("Component Added");

            _components.Add(component);

            AddEvent(new ComponentAdded(component));
        }

        public static void RemoveComponent(EcsComponent component)
        {
            if (_components.Remove(component))
                AddEvent(new ComponentRemoved(component));
        }

        public static void AddEvent(IEvent @event)
            => _events.Add(@event);
    }
}

/*
public static IEnumerable<ComponentType> GetComponentsByType<ComponentType>() where ComponentType : EcsComponent
    => _components.Where(component => component is ComponentType).Select(component => component as ComponentType);

public static IEnumerable<EventType> GetEventsByType<EventType>()
    => _events.Where(@event => @event is EventType).Select(@event => (EventType)@event);
*/