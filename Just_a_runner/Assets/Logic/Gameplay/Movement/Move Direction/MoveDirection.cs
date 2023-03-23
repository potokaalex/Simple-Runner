using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class MoveDirection : EcsComponent
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public Vector3 Direction;
        public float Velocity;
    }
}