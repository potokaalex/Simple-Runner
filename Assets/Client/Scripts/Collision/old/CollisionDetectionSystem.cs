using UnityEngine;
using Ecs.Core;

namespace Ecs.Systems
{
    public class CollisionDetectionSystem : IUpdateSystem
    {
        private ComponentFilter<CollisionDetector> _detectorComponents = new();

        public void Update(float deltaTime)
        {
            foreach (var detector in _detectorComponents)
            {
                if (detector == null)
                    continue;

                StayDetection(detector);
            }
        }

        private void StayDetection(CollisionDetector detector)
        {
            var detectorShape = detector.Box.transform;

            //Physics.OverlapBox works with delay
            var colliders = Physics.OverlapBox(detectorShape.position, detectorShape.lossyScale / 2, detectorShape.rotation, ~detector.IgnoreMask); 

            foreach (var collider in colliders)
            {
                //EcsWorld.AddEvent(new CollisionStayEvent(detector,collider));
            }
        }
    }
}