using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

namespace MovementSystem
{
    public class MoveForward : EcsComponent
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }
}