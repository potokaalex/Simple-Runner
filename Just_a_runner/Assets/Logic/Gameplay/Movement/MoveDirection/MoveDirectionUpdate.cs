using Ecs;

namespace MovementSystem
{
    public class MoveDirectionUpdate : IFixedTickable
    {
        private Filter<MoveDirection> _movable = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var component in _movable.Components)
                UpdateMove(component, deltaTime);
        }

        private void UpdateMove(MoveDirection component, float deltaTime)
        {
            component.AccelerationReader ??= new(component.Acceleration);

            component.transform.position += component.Velocity * deltaTime *
                (component.transform.rotation * component.Direction);

            component.Velocity += component.AccelerationReader.GetIncrement();
            component.AccelerationReader.Move(deltaTime);
        }
    }
}