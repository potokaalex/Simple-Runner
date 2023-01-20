using UnityEngine;
using Ecs.Core;

namespace Ecs.Systems
{
    public class CollisionDetectionSystem : IUpdateSystem
    {
        private ComponentFilter<CollisionDetector> _detectors = new();
        private EventSystem _eventSystem;

        public CollisionDetectionSystem(EventSystem eventSystem)
            => _eventSystem = eventSystem;

        public void Update(float deltaTime)
        {
            foreach (var detector in _detectors)
            {
                if (detector == null)
                    continue;

                StayDetection(detector);
            }
        }

        private void StayDetection(CollisionDetector detector)
        {
            var detectorShape = detector.Box.transform;

            var colliders = Physics.OverlapBox(detectorShape.position, detectorShape.lossyScale / 2, detectorShape.rotation, ~detector.IgnoreMask);
            //Physics.OverlapBox works with delay

            foreach (var collider in colliders)
            {
                _eventSystem.TryAddEvent(new CollisionStayEvent(detector, collider));
            }
        }
    }
}