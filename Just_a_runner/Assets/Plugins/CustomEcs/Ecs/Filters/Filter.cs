using System.Runtime.CompilerServices;
using System.Collections.Generic;

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
        private List<Entity> _entities = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Filter()
        {
            foreach (var entity in World.Entities)
                Add(entity);

            World.Filters.Add(this);
        }

        public int Count
            => _entities.Count;

        public Entity this[int index]
            => _entities[index];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<Entity> GetEnumerator()
            => _entities.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Add(Entity entity)
        {
            if (_entities.Contains(entity))
                return;

            if (entity.Contains<ComponentType1>()
                && entity.Contains<ComponentType2>()
                && entity.Contains<ComponentType3>())
                _entities.Add(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Remove(Entity entity)
        {
            if (!_entities.Contains(entity))
                return;

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