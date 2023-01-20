using UnityEngine;
using Ecs.Core;

namespace Ecs.Systems
{
    public class CollisionDetectionSystem : IUpdateSystem
    {
        private ComponentFilter<CollisionDetector> _detectors = new();

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

            foreach (var collider in colliders)
                EcsWorld.TryAddEvent(new CollisionStayEvent(detector.gameObject, collider));
        }
    }
}