using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class StayCollisionDetector : EcsComponent, ICollisionDetector
    {
        public LayerMask IgnoreMask;
        public StayCollisionEvent LastEventSent;

        private void OnCollisionStay(Collision collision)
        {
            if ((IgnoreMask.value & (1 << collision.gameObject.layer)) != 0)
                return;

            LastEventSent.CollisionInfo = collision;

            EcsWorld.AddEvent(LastEventSent);
        }
    }
}