using UnityEngine;
using Ecs;
using CollisionSystem;

public class StayCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public CollisionInfo CollisionInfo;

    public StayCollisionEvent(EcsComponent sender, CollisionInfo collisionInfo)
    {
        Sender = sender;
        CollisionInfo = collisionInfo;
    }
}