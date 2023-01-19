using UnityEngine;
using Ecs;

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