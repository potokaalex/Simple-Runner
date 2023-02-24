using UnityEngine;
using Ecs;
using CollisionSystem;

public class StayCollisionEvent : IEvent, IComponent
{
    public EcsComponent Sender;
    public Collision CollisionInfo;

    public StayCollisionEvent(EcsComponent sender, Collision collision)
    {
        Sender = sender;
        CollisionInfo = collision;
    }

    public Entity Entity { get; }
}

