using Ecs;

namespace MovementSystem
{
    public class MovePositionUpdate : MovePositionSystem
    {
        private Filter<MovePosition> _movable = new();

        public override void FixedTick(float deltaTime)
        {
            foreach (var entity in _movable.Entities)
                Move(entity.Get<MovePosition>(), deltaTime);
        }

        private void Move(MovePosition component, float deltaTime)
        {
            component.PositionReader ??= new(component.Position);

            UpdatePosition(component, deltaTime);
        }
    }
}