using System;

namespace Ecs
{
    public abstract class Filter
    {
        public static Filter<FilterType> Create<FilterType>()
        {
            var filterType = typeof(FilterType);

            if (typeof(IEvent).IsAssignableFrom(filterType))
                return EventUpdate.GetFilter<FilterType>();

            if (typeof(EcsComponent).IsAssignableFrom(filterType))
                return ComponentUpdate.GetFilter<FilterType>();

            return null;
        }

        public abstract Type GetFilterType();

        public abstract void Add(object @object);

        public abstract void Remove(object @object);
    }
}
