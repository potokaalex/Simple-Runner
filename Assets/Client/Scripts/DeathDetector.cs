using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;

public class DeathDetector : IFixedUpdateSystem
{
    private Filter<EnterTriggerEvent> _enterEvents = Filter.Create<EnterTriggerEvent>();

    public void FixedUpdate(float deltaTime)
    {
        foreach (var enterEvent in _enterEvents)
        {
            if (enterEvent.Collider.TryGetComponent(out ObstacleMarker obstacle))
            {

            }
        }
    }
}

public class EnterTriggerEvent : IEvent
{
    public EcsComponent Sender;
    public Collider Collider;

    public EnterTriggerEvent(EcsComponent sender, Collider collider)
    {
        Sender = sender;
        Collider = collider;
    }
}