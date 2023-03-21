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

        private float _initialVelocity;

        private void Awake()
            => _initialVelocity = Velocity;

        public void Reset()
        {
            AccelerationReader.Reset();
            Velocity = _initialVelocity;
        }
    }
}