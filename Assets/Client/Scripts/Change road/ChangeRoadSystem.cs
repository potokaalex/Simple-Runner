using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

public class ChangeRoadSystem : IFixedUpdateSystem, IUpdateSystem
{
    private EcsComponentFilter<ChangeRoad> _changeRoad;

    public ChangeRoadSystem(EcsWorld world)
    {
        _changeRoad = new(world);
    }

    public void Update(float deltaTime)
    {
        Vector3 direction;

        if (Input.GetKeyDown(KeyCode.A))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            direction = Vector3.right;
        else
            return;

        foreach (var component in _changeRoad.Components)
        {
            component.AnimationVelocity ??= new(component.VelocityCurve);

            if (component.AnimationVelocity.LastKeyTime > component.AnimationVelocity.Time)
                return; //fuzzy control

            component.AnimationVelocity.Reset();
            component.Direction = direction;
        }
    }

    public void FixedUpdate(float deltaTime)
    {
        foreach (var component in _changeRoad.Components)
        {
            if (component.AnimationVelocity == null)
                return;

            component.transform.position += component.Direction * component.AnimationVelocity.GetIncrement();
            component.AnimationVelocity.Move(deltaTime);
        }
    }
}
