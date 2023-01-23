using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Movement
{
    public class Move : EcsComponent
    {
        public AnimationCurve AnimationAcceleration;
        public CurveReader AccelerationReader;
        public Vector3 NormalizedDirection;
        public float Velocity;
    }
}
