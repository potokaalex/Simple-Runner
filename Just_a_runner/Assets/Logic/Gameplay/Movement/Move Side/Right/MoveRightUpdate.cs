using Ecs;
using InputSystem;

namespace MovementSystem
{
    public class MoveRightUpdate : MoveSideUpdate, IFixedTickable
    {
        private Filter<MoveRight> _movable = new();
        private Filter<MoveRightKey> _keys = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _movable.Entities)
                Move(entity.Get<MoveRight>(), deltaTime);
        }

        public void Move(MoveSide component, float deltaTime)
        {
            if (_keys.Entities.Count > 0)
                StartMove(component);

            UpdateMove(component, deltaTime);
        }
    }
}