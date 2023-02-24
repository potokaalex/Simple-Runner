using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

namespace MovementSystem
{
    public class Run : EcsComponent
    {
        //public SurfaceHandler SurfaceHandler;
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }
}