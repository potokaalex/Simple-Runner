using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

//namespace Assets.Client.Scripts.Movement
//{
public class MoveUpdate : IFixedUpdateSystem
{
    private EcsWorld _world = EcsWorld.FindWorld();

    public void FixedUpdate(float deltaTime)
    {
        var moveForwardComponents = _world.GetComponentsByType<MoveForward>();

        foreach (var component in moveForwardComponents)
            Move(component, deltaTime);
    }

    private void MoveForward() { }

    private void Move(MoveForward component, float deltaTime)
    {
        if (component.AccelerationReader == null)
            component.AccelerationReader = new(component.Acceleration);

        var velocity = component.Velocity * deltaTime;

        component.transform.position += Vector3.forward * velocity;

        component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
        component.AccelerationReader.Move(deltaTime);
    }
    /*
    private void Move(Move component, float deltaTime)
    {
        if (component.AccelerationReader == null)
            component.AccelerationReader = new(component.AnimationAcceleration);

        var velocity = component.Velocity * deltaTime;

        component.transform.position += component.NormalizedDirection.normalized * velocity;

        component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
        component.AccelerationReader.Move(deltaTime);
    }
    */
}
//}
