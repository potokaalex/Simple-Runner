using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class EnterCollisionEvent : IComponent
    {
        public Collision CollisionInfo;
        public Entity Sender;

        public EnterCollisionEvent(Entity sender, Collision collision)
        {
            CollisionInfo = collision;
            Sender = sender;
        }

        public Entity Entity
             => World.Events;
    }
}
