using System.Collections.Generic;
using System;

namespace Ecs
{
    public abstract class Filter
    {
        public abstract void Add(Entity entity);

        public abstract void Remove(Entity entity);
    }

    public class Filter<ComponentType1, ComponentType2, ComponentType3> : Filter
        where ComponentType1 : IComponent
        where ComponentType2 : IComponent
        where ComponentType3 : IComponent
    {
        private List<Entity> _entities;

        public Filter()
        {
            foreach (var entity in World.Entities)
                Add(entity);

            World.Filters.AddFilter(this);
        }

        public int Count
            => _entities.Count;

        public Entity this[int index]
            => _entities[index];

        public IEnumerator<Entity> GetEnumerator()
            => _entities.GetEnumerator();

        public override void Add(Entity entity)
        {
            if (_entities.Contains(entity))
                return;

            if (entity.Contains<ComponentType1>()
                && entity.Contains<ComponentType2>()
                && entity.Contains<ComponentType3>())
                _entities.Add(entity);
        }

        public override void Remove(Entity entity)
        {
            if (entity.Contains<ComponentType1>()
                && entity.Contains<ComponentType2>()
                && entity.Contains<ComponentType3>())
                return;

            _entities.Remove(entity);
        }
    }

    public class Filter<ComponentType1, ComponentType2>
        : Filter<ComponentType1, ComponentType2, IComponent>
        where ComponentType1 : IComponent
        where ComponentType2 : IComponent
    { }

    public class Filter<ComponentType1>
        : Filter<ComponentType1, IComponent, IComponent>
        where ComponentType1 : IComponent
    { }
}