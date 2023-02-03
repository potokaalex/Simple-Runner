using UnityEngine;
using Ecs;
using CollisionSystem;

public class EnterCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public Collision CollisionInfo;

    public EnterCollisionEvent(EcsComponent sender, Collision collision)
    {
        Sender = sender;
        CollisionInfo = collision;
    }
}