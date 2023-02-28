using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class EnterCollisionDetector : EcsComponent
    {
        public LayerMask IgnoreMask;
        public EnterCollisionEvent LastEventSent;

        private void OnCollisionEnter(Collision collision)
        {
            if ((IgnoreMask.value & (1 << collision.gameObject.layer)) != 0)
                return;

            if (LastEventSent == null)
                LastEventSent = new(this, collision);
            else
                LastEventSent.CollisionInfo = collision;

            World.Events.Add(LastEventSent);
        }
    }
}