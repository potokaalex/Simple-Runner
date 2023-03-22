using System.Collections.Generic;

namespace Ecs
{
    public class Filter<ComponentType1>
        : Filter<ComponentType1, IComponent, IComponent>
        where ComponentType1 : IComponent
    {
        private List<ComponentType1> _components = new();

        public List<ComponentType1> Components
            => _components;

        public override void Add(IComponent component)
        {
            if (component is not ComponentType1 desiredComponent)
                return;

            _components.Add(desiredComponent);

            if(!Entities.Contains(desiredComponent.Entity))
                Entities.Add(desiredComponent.Entity);
        }

        public override void Remove(IComponent component)
        {
            if (component is not ComponentType1 desiredComponent)
                return;

            _components.Remove(desiredComponent);

            if (!desiredComponent.Entity.Contains<ComponentType1>())
                Entities.Remove(desiredComponent.Entity);
        }
    }
}
