using UnityEngine;
using Ecs;

namespace CollisionSystem
{
    public class EnterCollisionDetector : EcsComponent, ICollisionDetector
    {
        public LayerMask IgnoreMask;
        public EnterCollisionEvent LastEventSent;

        private void OnCollisionEnter(Collision collision)
        {
            if ((IgnoreMask.value & (1 << collision.gameObject.layer)) != 0)
                return;

            LastEventSent.CollisionInfo = collision;

            //EcsWorld.AddEvent(LastEventSent);
        }
    }

    public interface ICollisionDetector { }
}