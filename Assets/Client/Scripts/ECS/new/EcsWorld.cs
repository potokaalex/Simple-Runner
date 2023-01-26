using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Ecs.Core;
using Slider;

namespace Ecs
{
    public class EcsWorld : MonoBehaviour //Даёт доступ ко всем компонентам и событиям.
    {
        private List<EcsComponent> _currentComponents = new();

        //private List<EcsComponent> _currentComponents = new();

        private List<EcsComponent> _addedComponents = new();
        private List<EcsComponent> _removedComponents = new();

        private List<IEvent> _currentEvents = new();
        private List<IEvent> _newEvents = new();

        public static EcsWorld FindWorld() => FindObjectOfType<EcsWorld>();

        public IEnumerable<ComponentType> GetComponentsByType<ComponentType>() where ComponentType : EcsComponent
            => _currentComponents.Where(component => component is ComponentType).Select(component => component as ComponentType);

        //

        public void AddComponent(EcsComponent component)
        {
            if (_addedComponents.Contains(component))
                return;

            _addedComponents.Add(component);

            AddEvent(new ComponentAdded(component));

            return;
        }

        public void RemoveComponent(EcsComponent component)
        {
            if (_removedComponents.Contains(component))
                return;

            _removedComponents.Add(component);

            AddEvent(new ComponentAdded(component));
        }

        public void UpdateComponents()
        {
            if (_addedComponents.Count > 1)
                Add();

            if (_removedComponents.Count > 1)
                Remove();

            void Add()
            {
                foreach (var component in _addedComponents)
                    if (!_currentComponents.Contains(component))
                        _currentComponents.Add(component);

                _addedComponents.Clear();
            }

            void Remove()
            {
                foreach (var component in _removedComponents)
                    _currentComponents.Remove(component);

                _removedComponents.Clear();
            }
        }

        //events
        public IEnumerable<EventType> GetEventsByType<EventType>()
            => _currentEvents.Where(@event => @event is EventType).Select(@event => (EventType)@event);

        public void AddEvent(IEvent @event)
        {
            //Debug.Log("Event ADDED");

            _newEvents.Add(@event);
        }

        public void UpdateEvents()
        {
            _currentEvents.Clear();

            foreach (var @event in _newEvents)
                _currentEvents.Add(@event);

            _newEvents.Clear();
        }
    }


    public struct ComponentAdded : IEvent
    {
        public EcsComponent Component;

        public ComponentAdded(EcsComponent component)
        {
            Component = component;
        }
    }

    public struct ComponentRemoved : IEvent
    {
        public EcsComponent Component;

        public ComponentRemoved(EcsComponent component)
        {
            Component = component;
        }
    }
}