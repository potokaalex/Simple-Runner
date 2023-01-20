using UnityEngine;
using Ecs;

namespace Ecs.Systems
{
    public class MoveForwardSystem : IFixedUpdateSystem
    {
        private ComponentFilter<MoveForward> _moveForward = new();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveForward)
            {
                if (component.AnimationVelocity == null)
                    component.AnimationVelocity = new(component.VelocityCurve);

                var velocity = component.AnimationVelocity.GetValue() + component.AdditionalVelocity;

                component.transform.position += Vector3.forward * velocity * deltaTime;
                component.AnimationVelocity.Move(deltaTime);
            }
        }
    }
}
