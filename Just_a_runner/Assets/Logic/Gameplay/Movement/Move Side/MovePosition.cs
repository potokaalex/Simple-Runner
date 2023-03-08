using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace MovementSystem
{
    class MovePosition : EcsComponent
    {
        public CurveReader PositionReader;
        public AnimationCurve Position;
        public Vector3 Direction;
        //public bool IsWallCheck;
    }
}
