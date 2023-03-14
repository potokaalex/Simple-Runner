using Ecs;

namespace InputSystem
{
    public struct MoveRightKey : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}