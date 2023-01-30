using System;
using System.Collections.Generic;

namespace Ecs
{
    public class Filter<FilterType> : Filter
    {
        private Type _filterType = typeof(FilterType);
        private List<FilterType> _objects = new();

        public Filter() { }

        public IEnumerator<FilterType> GetEnumerator() => _objects.GetEnumerator();

        public override Type GetFilterType() => _filterType;

        public override void Add(object @object)
        {
            if (@object is FilterType objectAsFilterType)
                if (!_objects.Contains(objectAsFilterType))
                    _objects.Add(objectAsFilterType);
        }

        public override void Remove(object @object)
        {
            if (@object is FilterType objectAsFilterType)
                _objects.Remove(objectAsFilterType);
        }
    }
}
