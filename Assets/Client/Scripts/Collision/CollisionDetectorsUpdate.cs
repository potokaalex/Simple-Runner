using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using System;

namespace CollisionSystem
{
    public class CollisionDetectorsUpdate : IFixedUpdateSystem
    {
        private Filter<BoxCollisionDetector> _detectors = Filter.Create<BoxCollisionDetector>();
        private int _detectionQuality_X = 2;
        private int _detectionQuality_Y = 2;
        private int _detectionQuality_Z = 2;

        public void FixedUpdate(float deltaTime)
        {
            foreach (var detector in _detectors)
            {
                var extents = detector.Body.bounds.extents;

                if (detector.PointsForRaycast_Up == null || detector.PointsForRaycast_Up.Length < 1)
                    detector.PointsForRaycast_Up = GetPointsForRaycast(new Vector2(extents.x, extents.z), new Vector2Int(_detectionQuality_X, _detectionQuality_Z));

                if (detector.PointsForRaycast_Right == null || detector.PointsForRaycast_Right.Length < 1)
                    detector.PointsForRaycast_Right = GetPointsForRaycast(new Vector2(extents.z, extents.y), new Vector2Int(_detectionQuality_Z, _detectionQuality_Y));

                if (detector.PointsForRaycast_Forward == null || detector.PointsForRaycast_Forward.Length < 1)
                    detector.PointsForRaycast_Forward = GetPointsForRaycast(new Vector2(extents.x, extents.y), new Vector2Int(_detectionQuality_X, _detectionQuality_Y));

                FindCollisions(detector);
            }
        }

        private Vector2[] GetPointsForRaycast(Vector2 extents, Vector2Int quality)
        {
            var normalizedQuality = quality + Vector2Int.one;
            var size = extents * 2;

            var step = size / quality;
            var position = -extents;

            var points = new Vector2[normalizedQuality.x * normalizedQuality.y];

            for (var x = 0; x <= quality.x; x += 1, position.x += step.x, position.y = -extents.y)
                for (var y = 0; y <= quality.y; y += 1, position.y += step.y)
                    points[x * normalizedQuality.x + y] = position;

            return points;
        }

        private RaycastHit Raycast(Vector3 origin, Vector3 direction, LayerMask ignoreMask, float maxDistance)
        {
            Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, ~ignoreMask);

            Debug.DrawRay(origin, direction * maxDistance, Color.magenta);

            return hit;
        }

        private void FindCollisions(BoxCollisionDetector detector)
        {
            var bounds = detector.Body.bounds;
            var startPoint = bounds.center;
            var additionalDistance = 0.01f;

            foreach (var castPoint in detector.PointsForRaycast_Up)
            {
                var castDistance = bounds.extents.y + additionalDistance;

                if (detector.DetectionSides.Up)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x + castPoint.x, startPoint.y, startPoint.z + castPoint.y),
                        Vector3.up, detector.IgnoreMask, castDistance), Side.Up);

                if (detector.DetectionSides.Down)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x + castPoint.x, startPoint.y, startPoint.z + castPoint.y),
                        Vector3.down, detector.IgnoreMask, castDistance), Side.Down);
            }

            foreach (var castPoint in detector.PointsForRaycast_Right)
            {
                var castDistance = bounds.extents.x + additionalDistance;

                if (detector.DetectionSides.Right)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x, startPoint.y + castPoint.y, startPoint.z + castPoint.x),
                        Vector3.right, detector.IgnoreMask, castDistance), Side.Right);

                if (detector.DetectionSides.Left)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x, startPoint.y + castPoint.y, startPoint.z + castPoint.x),
                        Vector3.left, detector.IgnoreMask, castDistance), Side.Left);
            }

            foreach (var castPoint in detector.PointsForRaycast_Forward)
            {
                var castDistance = bounds.extents.z + additionalDistance;

                if (detector.DetectionSides.Forward)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x + castPoint.x, startPoint.y + castPoint.y, startPoint.z),
                        Vector3.forward, detector.IgnoreMask, castDistance), Side.Forward);

                if (detector.DetectionSides.Back)
                    HandleCollisions(detector, Raycast(new Vector3(startPoint.x + castPoint.x, startPoint.y + castPoint.y, startPoint.z),
                        Vector3.back, detector.IgnoreMask, castDistance), Side.Back);
            }
        }

        private void HandleCollisions(BoxCollisionDetector detector, RaycastHit hit, Side collisionSide)
        {
            if (hit.collider == null)
                return;

            var collisionInfo = new CollisionInfo()
            {
                BodyCollider = detector.Body,
                HitInfo = hit,
                CollisionSide = collisionSide,
            };

            if (detector.Mode.Enter)
                if (!detector.Collisions.Contains(collisionInfo))
                    EnterCollision(detector, collisionInfo);

            if (detector.Mode.Exit)
                ExitCollision(detector, collisionInfo);

            if (detector.Mode.Stay)
                StayCollision(detector, collisionInfo);
        }

        private void EnterCollision(BoxCollisionDetector detector, CollisionInfo collisionInfo)
        {
            detector.Collisions.Add(collisionInfo);

            EcsWorld.AddEvent(new EnterCollisionEvent(detector, collisionInfo));
        }

        private void ExitCollision(BoxCollisionDetector detector, CollisionInfo collisionInfo)
        {
            if (detector.Collisions.Remove(collisionInfo))
                EcsWorld.AddEvent(new ExitCollisionEvent(detector, collisionInfo));
        }

        private void StayCollision(BoxCollisionDetector detector, CollisionInfo collisionInfo)
        {
            EcsWorld.AddEvent(new StayCollisionEvent(detector, collisionInfo));
        }
    }
}