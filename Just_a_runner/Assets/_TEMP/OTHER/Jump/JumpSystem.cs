using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace Ecs.Systems
{
    /*
    public class JumpSystem : IUpdateSystem, IFixedUpdateSystem
    {
        private Filter<Jump> _jumping = new();
        private Filter<StayCollisionEvent> _stayEvents = new();

        private bool IsJumpKeyDown => Input.GetKeyDown(KeyCode.W);

        public void Update(float deltaTime)
        {
            if (!IsJumpKeyDown)
                return;

            foreach (var stayEvent in _stayEvents)
            {
                foreach (var component in _jumping)
                {
                    //if (component.Detector != stayEvent.Sender)
                    //   continue;

                    component.AnimationVelocity ??= new(component.VelocityCurve);
                    component.AnimationVelocity.Reset();
                }
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _jumping)
            {
                if (component.AnimationVelocity == null)
                    continue;

                component.transform.position += Vector3.up * component.AnimationVelocity.GetIncrement();
                component.AnimationVelocity.Move(deltaTime);
            }
        }
    }
    */
}