using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

public class GravitySystem : IFixedUpdateSystem
{
    private const float GravityForce = 9.8f;

    private EcsComponentFilter<Gravity> _gravity;

    public GravitySystem(EcsWorld world)
    {
        _gravity = new(world);
    }

    public void FixedUpdate(float deltaTime)
    {
        foreach (var component in _gravity.Components)
        {
            if (component.Feet != null)
            {
                var ignoreLayer = 1 << component.Feet.gameObject.layer;

                if (IsStanding(component.Feet, ~ignoreLayer))
                    return;

                if (IsLanding(component.Feet, ~ignoreLayer, component.Velocity * deltaTime, out RaycastHit hit))
                {
                    component.transform.position -= Vector3.up * (component.Feet.transform.position.y - hit.point.y);
                    component.Velocity = 0;

                    continue;
                }
            }

            component.transform.position -= Vector3.up * component.Velocity * deltaTime;
            component.Velocity += GravityForce * deltaTime;
        }
    }

    private bool IsStanding(Transform checkBox, LayerMask layerMask)
            => Physics.CheckBox(checkBox.transform.position, checkBox.transform.lossyScale, checkBox.transform.rotation, layerMask);

    private bool IsLanding(Transform checkBox, LayerMask layerMask, float distance, out RaycastHit hit)
        => Physics.BoxCast(checkBox.position, checkBox.lossyScale / 2, Vector3.down, out hit, checkBox.rotation, distance, layerMask);
}
