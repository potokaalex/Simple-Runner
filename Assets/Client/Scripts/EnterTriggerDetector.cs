using UnityEngine;
using Ecs;

[RequireComponent(typeof(Collider))]
public class EnterTriggerDetector : EcsComponent
{
    [SerializeField] private LayerMask _ignoreMask;

    private EnterTriggerEvent _previousEvent;

    private void OnTriggerEnter(Collider collider)
    {
        if ((_ignoreMask.value & (1 << collider.gameObject.layer)) != 0)
            return;

        SendEvent(collider);
    }

    private void SendEvent(Collider collider)
    {
        if (_previousEvent == null)
            _previousEvent = new(this, null);

        _previousEvent.Collider = collider;

        EcsWorld.AddEvent(_previousEvent);
    }
}