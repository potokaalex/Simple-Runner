using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public abstract class MoveSide : EcsComponent
    {
        public abstract CurveReader PositionReader { get; set; }
        public abstract AnimationCurve Position { get; set; }
    }
}
