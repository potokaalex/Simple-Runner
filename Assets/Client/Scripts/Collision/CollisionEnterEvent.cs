using UnityEngine;
using Ecs;

namespace Collision
{
    public class CollisionEnterEvent : Event
    {
        public GameObject Sender;
        public UnityEngine.Collision Collision;
    }
}