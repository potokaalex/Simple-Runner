using UnityEngine;
using Ecs;

public class JumpSystem : IUpdateSystem, IFixedUpdateSystem
{
    private EcsComponentFilter<Jump> _jump;

    private bool IsJumpKeyDown => Input.GetKeyDown(KeyCode.W);

    public JumpSystem(EcsWorld world)
    {
        _jump = new(world);
    }

    public void Update(float deltaTime)
    {
        if (!IsJumpKeyDown)
        {
            return;
        }

        foreach (var component in _jump.Components)
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
        foreach (var component in _jump.Components)
        {
            if (component.AnimationVelocity == null)
                return;

            component.transform.position += Vector3.up * component.AnimationVelocity.GetIncrement();
            component.AnimationVelocity.Move(deltaTime);
        }
    }
}