using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ecs.Systems
{
    public class DeadByCollisionSystem : IFixedUpdateSystem
    {
        private ComponentFilter<DeadByCollision> _deadMarkers = new();
        private EventFilter<CollisionStayEvent> _stayEvents = new();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var stayEvent in _stayEvents)
            {
                foreach (var _deadMarker in _deadMarkers)
                {
                    if (_deadMarker.Detector == stayEvent.Sender)
                        Debug.Log("Dead!");
                }
            }
        }
    }
}

