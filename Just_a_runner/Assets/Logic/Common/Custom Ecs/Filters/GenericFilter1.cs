using System.Collections.Generic;

namespace Ecs
{
    public class Filter<ComponentType1>
        : Filter<ComponentType1, IComponent, IComponent>
        where ComponentType1 : IComponent
    {
        public override void Add(Entity entity)
        {
            if (Entities.Contains(entity))
                return;

            if (entity.Contains<ComponentType1>())
                Entities.Add(entity);
        }

        public override void Remove(Entity entity)
        {
            if (entity.Contains<ComponentType1>())
                return;

            Entities.Remove(entity);
        }
    }
}