using System.Collections.Generic;
using System;
using UnityEngine;

namespace Ecs
{
    public class FilterE
    {
        public List<IEvent> Events = new();
    }

    public interface IFilter
    {
        public void Add(object @object);

        public void Remove(object @object);

        public Type GetFilterType();
    }

    public class Filter
    {
        private Filter() { }

        public static Filter<FilterType> Create<FilterType>()
        {
            var filterType = typeof(FilterType);

            if (filterType is IEvent)
                return EventUpdate.GetFilter<FilterType>();

            //if (filterType.Equals(typeof(EcsComponent)))
            //   return ComponentUpdate.GetFilter(typeof(FilterType));

            Debug.Log(filterType is IEvent);

            return null;
        }
    }

    public class Filter<T> : IFilter
    {
        private Type _filterType = typeof(T);
        private List<T> _objects;

        public Type GetFilterType() => _filterType;

        public IEnumerator<T> GetEnumerator() => _objects.GetEnumerator();

        public void Add(object @object)
        {
            if (@object is T eventAsEventType)
                if (!_objects.Contains(eventAsEventType))
                    _objects.Add(eventAsEventType);
        }

        public void Remove(object @object)
        {
            if (@object is T eventAsEventType)
                _objects.Remove(eventAsEventType);
        }

        public Filter() { }
    }

    public class EventFilter<EventType> where EventType : IEvent
    {
        private Filter _filter;

        public EventFilter()
        {
           // _filter = EventUpdate.GetFilter(typeof(EventType));
        }

        public IEnumerator<EventType> GetEnumerator() => null;// _objects.GetEnumerator();

        public void Add(object @object)
        {

        }

        public void Remove(object @object)
        {

        }
    }
}

//фильтр...
//фильтр - ссылка на массив компонентов какого-то типа.