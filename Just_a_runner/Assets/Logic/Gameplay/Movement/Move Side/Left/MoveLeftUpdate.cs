using Ecs;
using InputSystem;

namespace MovementSystem
{
    public class MoveLeftUpdate : MoveSideUpdate, IFixedTickable
    {
        private Filter<MoveLeft> _movable = new();
        private Filter<MoveLeftKey> _keys = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _movable.Entities)
                Move(entity.Get<MoveLeft>(), deltaTime);
        }

        public void Move(MoveSide component, float deltaTime)
        {
            if (_keys.Entities.Count > 0)
                StartMove(component);

            UpdateMove(component, deltaTime);
        }
    }
}