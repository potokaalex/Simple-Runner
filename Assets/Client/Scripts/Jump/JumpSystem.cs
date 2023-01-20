using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace Ecs.Systems
{
    public class JumpSystem : IUpdateSystem, IFixedUpdateSystem
    {
        private ComponentFilter<Jump> _jumping = new();
        private HashSet<IEvent> _events;

        public JumpSystem(EventSystem eventSystem)
            => _events = eventSystem.GetEvents();

        private bool IsJumpKeyDown => Input.GetKeyDown(KeyCode.W);

        public void Update(float deltaTime)
        {
            if (!IsJumpKeyDown)
                return;

            foreach (var eventEntity in _events)
            {
                if (eventEntity is not CollisionStayEvent stayEvent)
                    continue;

                foreach (var component in _jumping)
                {
                    if (component.Detector != stayEvent.Sender)
                        continue;

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
}