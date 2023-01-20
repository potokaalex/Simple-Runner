using UnityEngine;
using Ecs;
using Ecs.Core;

public struct CollisionStayEvent : IEvent
{
    public GameObject Sender;
    public Collider Contact;

    public CollisionStayEvent(GameObject sender, Collider contact)
    {
        Sender = sender;
        Contact = contact;
    }
}