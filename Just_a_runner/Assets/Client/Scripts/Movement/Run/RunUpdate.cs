using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class RunUpdate : ITickable
    {
        private Filter<Run> _running = new();

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < _running.Count; i++)
                UpdateMove(_running[i].Get<Run>(), deltaTime);
        }

        private void UpdateMove(Run component, float deltaTime)
        {
            component.AccelerationReader ??= new(component.Acceleration);

            component.transform.position += component.Velocity * deltaTime * (component.transform.rotation * Vector3.forward);

            component.Velocity += component.AccelerationReader.GetIncrement();
            component.AccelerationReader.Move(deltaTime);
        }
    }
}