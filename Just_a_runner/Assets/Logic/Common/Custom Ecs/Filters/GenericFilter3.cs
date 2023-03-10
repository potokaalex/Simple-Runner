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
            {
                entity.Get<IComponent>(out var components);

                foreach (var component in components)
                    Add(component);
            }

            World.Filters.Add(this);
        }

        public List<Entity> Entities
            => _entities;

        public override void Add(IComponent component)
        {
            if (_entities.Contains(component.Entity))
                return;

            if (component.Entity.Contains<ComponentType1>()
                && component.Entity.Contains<ComponentType2>()
                && component.Entity.Contains<ComponentType3>())
                _entities.Add(component.Entity);
        }

        public override void Remove(IComponent component)
        {
            if (!_entities.Contains(component.Entity))
                return;

            if (component.Entity.Contains<ComponentType1>()
                && component.Entity.Contains<ComponentType2>()
                && component.Entity.Contains<ComponentType3>())
                return;

            _entities.Remove(component.Entity);
        }
    }
}