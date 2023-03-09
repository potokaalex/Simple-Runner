using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class MovePositionPattern : EcsComponent
    {
        public CurveReader PositionReader;
        public AnimationCurve Position;
        public Vector3 Direction;
    }
}