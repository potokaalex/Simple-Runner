using UnityEngine;
using Ecs;
using CollisionSystem;

public class EnterCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public CollisionInfo CollisionInfo;

    public EnterCollisionEvent(EcsComponent sender, CollisionInfo collisionInfo)
    {
        Sender = sender;
        CollisionInfo = collisionInfo;
    }
}