using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ecs.Systems
{
    public class DeadByCollisionSystem : IFixedUpdateSystem
    {
        private ComponentFilter<DeadByCollision> _deadMarkers = new();
        private HashSet<IEvent> _events;

        public DeadByCollisionSystem(EventSystem eventSystem)
            => _events = eventSystem.GetEvents();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var eventEntity in _events)
            {
                if (eventEntity is not CollisionStayEvent stayEvent)
                    continue;

                foreach (var _deadMarker in _deadMarkers)
                {
                    if (_deadMarker.Detector == stayEvent.Sender)
                        Debug.Log("Dead!");
                }
            }
        }
    }
}

