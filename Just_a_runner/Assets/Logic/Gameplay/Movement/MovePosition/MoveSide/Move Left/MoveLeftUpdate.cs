using InputSystem;
using Ecs;

namespace MovementSystem
{
    public class MoveLeftUpdate : MoveSideSystem
    {
        private Filter<MoveLeft> _movable = new();
        private Filter<MoveLeftKey> _keys = new();

        public override void FixedTick(float deltaTime)
        {
            foreach (var component in _movable.Components)
                Move(component, deltaTime, _keys.Components.Count > 0, component.IsWallCheck);
        }
    }
}