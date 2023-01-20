using UnityEngine;
using Ecs;

namespace Ecs.Systems
{
    public class JumpSystem : IUpdateSystem, IFixedUpdateSystem
    {
        private ComponentFilter<Jump> _jumping = new();

        private bool IsJumpKeyDown => Input.GetKeyDown(KeyCode.W);

        public void Update(float deltaTime)
        {
            if (!IsJumpKeyDown)
            {
                return;
            }

            foreach (var component in _jumping)
            {
                var ignoreLayer = 1 << component.CheckBox.gameObject.layer;

                if (IsCheckBoxOverlap(component.CheckBox, ~ignoreLayer))
                {
                    component.AnimationVelocity ??= new(component.VelocityCurve);
                    component.AnimationVelocity.Reset();
                }
            }

            bool IsCheckBoxOverlap(Transform checkBox, LayerMask layerMask)
                => Physics.CheckBox(checkBox.position, checkBox.lossyScale / 2, checkBox.rotation, layerMask);
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