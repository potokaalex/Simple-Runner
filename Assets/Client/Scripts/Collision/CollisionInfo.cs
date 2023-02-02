using UnityEngine;
using System;
using Ecs;

namespace CollisionSystem
{
    public struct CollisionInfo : IEquatable<CollisionInfo>
    {
        public Collider BodyCollider;
        public Collider SurfaceCollider;
        public Vector3 SurfaceNormal;
        public Vector3 CollisionPoint;
        public Side CollisionSide;
        

        public bool Equals(CollisionInfo other)
            => other.CollisionSide == CollisionSide && other.BodyCollider == BodyCollider && other.SurfaceCollider == SurfaceCollider && other.SurfaceNormal == SurfaceNormal;
    }
}