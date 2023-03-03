using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class Run : EcsComponent
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }
}