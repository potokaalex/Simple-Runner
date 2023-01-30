using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

namespace Movement
{
    public class MovementSystem : IFixedUpdateSystem
    {
        private Filter<Move> _moveComponents = Filter.Create<Move>();
        private Filter<Slide> _slideComponents = Filter.Create<Slide>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveComponents)
            {
                if (isCast)
                    return;

                component.gameObject.TryGetComponent(out PenetrationPrevention penetrationComponent);

                CAST(component, deltaTime, penetrationComponent);

                Move(component, deltaTime);
            }

            foreach (var component in _slideComponents)
            {
                Slide(component, deltaTime);
            }
        }

        bool isCast = false;

        private void CAST(Move component, float deltaTime, PenetrationPrevention penetrationPrevention)
        {
            var checkBox = penetrationPrevention.BOX;

            var distance = component.Velocity * deltaTime * component.NormalizedDirection;

            var ignoreLayer = 1 << penetrationPrevention.BOX.gameObject.layer;

            var colliders = Physics.OverlapBox(checkBox.position + distance, checkBox.lossyScale / 2, checkBox.rotation, ~ignoreLayer);

            if (colliders.Length < 1)
                return;

            if (!Physics.BoxCast(checkBox.position, checkBox.lossyScale / 2, component.NormalizedDirection, out RaycastHit hit, checkBox.rotation, component.Velocity * deltaTime, ~ignoreLayer))
                return;

            Debug.Log("hit point " + hit.point);

            var offset = new Vector3(hit.point.x * component.NormalizedDirection.x, hit.point.y * component.NormalizedDirection.y, hit.point.z * component.NormalizedDirection.z);

            Debug.Log("Pre-offset " + offset);


            component.transform.position += offset;

            Debug.Log("offset " + (checkBox.position - (checkBox.lossyScale / 2) - offset));


            component.Velocity = 0;

            isCast = true;
        }

        private void Move(Move component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.AnimationAcceleration);

            var velocity = component.Velocity * deltaTime;

            component.transform.position += component.NormalizedDirection.normalized * velocity;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);
        }

        private void Slide(Slide component, float deltaTime)
        {

        }



    }
}

public class PenetrationPrevention : EcsComponent
{
    public Transform BOX;
}