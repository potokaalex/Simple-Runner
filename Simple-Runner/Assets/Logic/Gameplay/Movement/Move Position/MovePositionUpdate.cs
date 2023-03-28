using Ecs;

namespace MovementSystem
{
    public class MovePositionUpdate : MovePositionSystem
    {
        private Filter<MovePosition> _movable = new();

        public override void FixedTick(float deltaTime)
        {
            foreach (var component in _movable.Components)
                Move(component, deltaTime);
        }

        private void Move(MovePosition component, float deltaTime)
        {
            component.PositionReader ??= new(component.Position);

            Update(component, deltaTime);
        }
    }
}