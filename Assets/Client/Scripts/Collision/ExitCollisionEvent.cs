using UnityEngine;
using Ecs;
using CollisionSystem;

public class ExitCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public CollisionInfo CollisionInfo;

    public ExitCollisionEvent(EcsComponent sender, CollisionInfo collisionInfo)
    {
        Sender = sender;
        CollisionInfo = collisionInfo;
    }
}