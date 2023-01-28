using System;

namespace Ecs
{
    public interface IComponentFilter
    {
        public Type GetComponentType();

        public void AddComponent(EcsComponent component);

        public void RemoveComponent(EcsComponent component);
    }
}
