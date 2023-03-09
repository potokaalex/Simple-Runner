using Ecs;

namespace MovementSystem
{
    public abstract class MovePositionSystem : IFixedTickable
    {
        public abstract void FixedTick(float deltaTime);

        private protected void UpdatePosition(MovePositionPattern component, float deltaTime)
        {
            if (component.PositionReader == null)
                return;

            var velocity = component.PositionReader.GetIncrement();

            component.transform.position += component.Direction.normalized * velocity;
            component.PositionReader.Move(deltaTime);
        }
    }
}