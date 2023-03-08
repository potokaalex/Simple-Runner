using System.Collections.Generic;

namespace Ecs
{
    public class Filter<ComponentType1, ComponentType2, ComponentType3> : Filter
        where ComponentType1 : IComponent
        where ComponentType2 : IComponent
        where ComponentType3 : IComponent
    {
        private List<Entity> _entities = new();

        public Filter()
        {
            foreach (var entity in World.Entities)
                Add(entity);

            World.Filters.Add(this);
        }

        public List<Entity> Entities
            => _entities;

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
            if (!_entities.Contains(entity))
                return;

            if (entity.Contains<ComponentType1>()
                && entity.Contains<ComponentType2>()
                && entity.Contains<ComponentType3>())
                return;

            _entities.Remove(entity);
        }
    }
}