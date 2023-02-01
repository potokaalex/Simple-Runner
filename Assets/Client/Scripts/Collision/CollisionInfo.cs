using UnityEngine;
using System;
using Ecs;

namespace CollisionSystem
{
    public struct CollisionInfo : IEquatable<CollisionInfo>
    {
        public Collider BodyCollider;
        public RaycastHit HitInfo;
        public Side CollisionSide;

        public bool Equals(CollisionInfo other)
            => other.CollisionSide == CollisionSide && other.BodyCollider == BodyCollider && other.HitInfo.collider == HitInfo.collider && other.HitInfo.normal == HitInfo.normal;
    }
}