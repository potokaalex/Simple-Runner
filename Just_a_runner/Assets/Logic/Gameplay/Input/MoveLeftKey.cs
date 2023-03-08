using Ecs;

namespace InputSystem
{
    public struct MoveLeftKey : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}