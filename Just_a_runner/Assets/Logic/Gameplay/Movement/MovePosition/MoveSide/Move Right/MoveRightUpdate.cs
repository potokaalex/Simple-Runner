using InputSystem;
using Ecs;

namespace MovementSystem
{
    public class MoveRightUpdate : MoveSideSystem
    {
        private Filter<MoveRight> _movable = new();
        private Filter<MoveRightKey> _keys = new();

        public override void FixedTick(float deltaTime)
        {
            foreach (var entity in _movable.Entities)
            {
                var component = entity.Get<MoveRight>();

                Move(component, deltaTime, _keys.Entities.Count > 0, component.IsWallCheck);
            }
        }
    }
}