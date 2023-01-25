using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Ecs.Core;

namespace Ecs
{
    public class EcsWorld : MonoBehaviour
    {
        private HashSet<EcsComponent> _components = new();
        private List<IEvent> _events = new();

        //public event ComponentTransfer ComponentAdded;
        //public event ComponentTransfer ComponentRemoved;

        //public static event EventTransfer EventAdded;
        //public static event EventTransfer EventRemoved;

        public static EcsWorld FindWorld() => FindObjectOfType<EcsWorld>();

        public IEnumerable<ComponentType> GetComponentsByType<ComponentType>() where ComponentType : EcsComponent
            => _components.Where(component => component is ComponentType).Select(component => component as ComponentType);

        public IEnumerable<EventType> GetEventsByType<EventType>()
            => _events.Where(@event => @event is EventType).Select(@event => (EventType)@event);

        public bool TryAddComponent(EcsComponent component)
        {
            if (!_components.Add(component))
                return false;

            ComponentAdded?.Invoke(component);

            return true;
        }

        public bool TryRemoveComponent(EcsComponent component)
        {
            if (!_components.Remove(component))
                return false;

            ComponentRemoved?.Invoke(component);

            return true;
        }

        public void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}