using Ecs;

namespace InputService
{
    public struct MoveRightKey : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}
