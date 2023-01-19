using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;


public class CollisionDetectionSystem : IUpdateSystem
{
    private EcsComponentFilter<CollisionDetector> _detectors;
    private EcsWorld _world;

    public CollisionDetectionSystem(EcsWorld world)
    {
        _detectors = new(world);
        _world = world;
    }

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
            _world.TryAddEvent(new CollisionStayEvent(detector.gameObject, collider));
    }
}