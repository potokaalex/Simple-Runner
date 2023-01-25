using UnityEngine;
using Ecs;

public struct ExitCollisionEvent : IEvent
{
    public EcsComponent Sender;
    public Collision Contact;

    public ExitCollisionEvent(EcsComponent sender, Collision contact)
    {
        Sender = sender;
        Contact = contact;
    }
}