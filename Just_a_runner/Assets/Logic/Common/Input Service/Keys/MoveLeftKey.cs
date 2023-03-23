using Ecs;

namespace InputService
{
    public struct MoveLeftKey : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}
