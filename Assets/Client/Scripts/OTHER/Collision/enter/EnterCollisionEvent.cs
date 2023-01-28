using UnityEngine;
using Ecs;

public struct EnterCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public Collision Contact;

    public EnterCollisionEvent(EcsComponent sender, Collision contact)
    {
        Sender = sender;
        Contact = contact;
    }
}