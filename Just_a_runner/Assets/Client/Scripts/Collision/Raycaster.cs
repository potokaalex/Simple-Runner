using UnityEngine;
using Ecs;
using System.Collections.Generic;

public abstract class Raycaster : EcsComponent
{
    //if ((_ignoreMask.value & (1 << collider.gameObject.layer)) != 0)

    public abstract LayerMask IgnoreMask { get; }

    public abstract float Distance { get; }

    public abstract Vector3 Direction { get; }
}

public class RaycastersUpdate : ITickable
{
    private Filter<Raycaster> _raycasters = new();

    public void Tick(float deltaTime)
    {
       // if (_raycasters.Count < 1)
        //    return;

       // _raycasters[0].Get<Raycaster>(out var components);

       // foreach (var component in components)
       //     Detect(component as Raycaster);
    }

    private void Detect(Raycaster raycaster)
    {
        Debug.DrawRay(raycaster.transform.position, raycaster.Direction * raycaster.Distance);

        if (Physics.Raycast(raycaster.transform.position,
            raycaster.Direction,
            out var hit, raycaster.Distance,
            ~raycaster.IgnoreMask))

            World.Events.Add(new HitEvent(raycaster, hit));
    }
}

public struct HitEvent : IComponent
{
    public EcsComponent Sender;
    public RaycastHit Hit;

    public HitEvent(EcsComponent sender, RaycastHit hit)
    {
        Sender = sender;
        Hit = hit;
    }

    public Entity Entity
        => World.Events;
}