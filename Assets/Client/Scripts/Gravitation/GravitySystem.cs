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
            component.Velocity += GravityForce * deltaTime;

            /*
            if (component.Feet != null)
            {
                var ignoreLayer = 1 << component.Feet.gameObject.layer;

                if (BoxCast(component.Feet, ~ignoreLayer, GravityForce * deltaTime, out RaycastHit hit))
                {
                    AplyGravity(component.transform, (component.Feet.transform.position.y + component.Feet.transform.localScale.y / 2 - hit.point.y) * deltaTime);

                    Debug.Log(component.Feet.transform.position.y - hit.point.y);

                    continue;
                }
            }
            */


            AplyGravity(component.transform, component.Velocity);
        }

        bool BoxCast(Transform checkBox, LayerMask layerMask, float distance, out RaycastHit hit)
            => Physics.BoxCast(checkBox.position, checkBox.lossyScale / 2, Vector3.down, out hit, checkBox.rotation, distance, layerMask);
    }

    public void Update(float deltaTime)
    {
        foreach (var component in _gravity.Components)
        {
            // Debug.Log("Component call");

            if (component.Feet != null)
            {
                // Debug.Log("Pre casting");


                var ignoreLayer = 1 << component.Feet.gameObject.layer;

                if (BoxCast(component.Feet, ~ignoreLayer, GravityForce * deltaTime, out RaycastHit hit))
                {
                    AplyGravity(component.transform, (component.Feet.transform.position.y - hit.point.y) * deltaTime);

                    Debug.Log(component.Feet.transform.position.y - hit.point.y);
                }
                //else
                //{
                //   AplyGravity(component.transform, GravityForce * deltaTime);
                //}
            }
            else
            {
                AplyGravity(component.transform, GravityForce * deltaTime);
            }
        }

        bool BoxCast(Transform checkBox, LayerMask layerMask, float distance, out RaycastHit hit)
            => Physics.BoxCast(checkBox.position, checkBox.lossyScale / 2, Vector3.down, out hit, checkBox.rotation, distance, layerMask);
    }

    private void AplyGravity(Transform transform, float offset)
        => transform.position -= Vector3.up * offset;
}
