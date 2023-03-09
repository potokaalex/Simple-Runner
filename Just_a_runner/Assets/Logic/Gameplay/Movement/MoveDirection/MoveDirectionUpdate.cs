using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class MoveDirectionUpdate : IFixedTickable
    {
        private Filter<MoveDirection> _running = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _running.Entities)
                UpdateMove(entity.Get<MoveDirection>(), deltaTime);
        }

        private void UpdateMove(MoveDirection component, float deltaTime)
        {
            component.AccelerationReader ??= new(component.Acceleration);

            component.transform.position += component.Velocity * deltaTime * (component.transform.rotation * Vector3.forward);

            component.Velocity += component.AccelerationReader.GetIncrement();
            component.AccelerationReader.Move(deltaTime);
        }
    }
}