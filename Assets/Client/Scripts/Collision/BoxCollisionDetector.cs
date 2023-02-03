using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Ecs;

namespace CollisionSystem
{
    /*
    public class BoxCollisionDetector : EcsComponent
    {
        [HideInInspector] public List<CollisionInfo> Collisions = new();
        [HideInInspector] public Vector2[] PointsForRaycast_Up;
        [HideInInspector] public Vector2[] PointsForRaycast_Right;
        [HideInInspector] public Vector2[] PointsForRaycast_Forward;

        public BoxCollider Body;
        public LayerMask IgnoreMask;
        public Side DetectionSides;
        public CollisionMode Mode;

        [Serializable]
        public struct Side
        {
            public bool Up;
            public bool Down;
            public bool Left;
            public bool Right;
            public bool Back;
            public bool Forward;
        }

        [Serializable]
        public struct CollisionMode
        {
            public bool Enter;
            public bool Exit;
            public bool Stay;
        }
    }
    */
}