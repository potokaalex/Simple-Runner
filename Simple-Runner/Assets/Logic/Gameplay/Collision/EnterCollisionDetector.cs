using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class EnterCollisionDetector : EcsComponent
    {
        public EnterCollisionEvent LastEventSent;
        public LayerMask IgnoreMask;

        private void OnCollisionEnter(Collision collision)
        {
            if ((IgnoreMask.value & (1 << collision.gameObject.layer)) != 0)
                return;

            if (LastEventSent == null)
                LastEventSent = new(Entity, collision);
            else
                LastEventSent.CollisionInfo = collision;

            World.Events.Add(LastEventSent);
        }
    }
}
