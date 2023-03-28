using Ecs;

namespace InputService
{
    public struct RestartKey : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}
