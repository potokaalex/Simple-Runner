using Ecs;
using InputSystem;

namespace MovementSystem
{
    public class MoveLeftUpdate : MoveSideUpdate, ITickable
    {
        private Filter<MoveLeft> _movable = new();
        private Filter<KeyDown_A> _keys = new();

        public void Tick(float deltaTime)
        {
            foreach (var entity in _movable)
                Move(entity.Get<MoveLeft>(), deltaTime);
        }

        public void Move(MoveSide component, float deltaTime)
        {
            if (_keys.Count > 0)
                StartMove(component);

            UpdateMove(component, deltaTime);
        }
    }
}