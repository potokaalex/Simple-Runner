using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class EnterCollisionEvent : IComponent
    {
        public EcsComponent Sender;
        public Collision CollisionInfo;

        public EnterCollisionEvent(EcsComponent sender, Collision collision)
        {
            Sender = sender;
            CollisionInfo = collision;
        }

        public Entity Entity
             => World.Events;
    }
}