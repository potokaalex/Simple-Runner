using UnityEngine;
using Ecs;

public class MoveForwardSystem : IFixedUpdateSystem
{
    private EcsComponentFilter<MoveForward> _moveForward;

    public MoveForwardSystem(EcsWorld world)
    {
        _moveForward = new(world);
    }

    public void FixedUpdate(float deltaTime)
    {
        foreach (var component in _moveForward.Components)
        {
            if (component.AnimationVelocity == null)
                component.AnimationVelocity = new(component.VelocityCurve);

            var velocity = component.AnimationVelocity.GetValue() + component.AdditionalVelocity;

            component.transform.position += Vector3.forward * velocity * deltaTime;
            component.AnimationVelocity.Move(deltaTime);
        }
    }
}
