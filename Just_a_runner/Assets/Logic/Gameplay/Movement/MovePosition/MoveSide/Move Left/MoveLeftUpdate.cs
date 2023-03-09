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
            foreach (var entity in _movable.Entities)
            {
                var component = entity.Get<MoveLeft>();

                Move(component, deltaTime, _keys.Entities.Count > 0, component.IsWallCheck);
            }
        }
    }
}