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
        public AnimationCurve VelocityCurve;
        public CurveReader Velocity;
        public Vector3 Direction;
    }
}
