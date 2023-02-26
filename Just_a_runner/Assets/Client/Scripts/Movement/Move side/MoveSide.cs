using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public abstract class MoveSide : EcsComponent
    {
        public const float CheckWallDistance = 0.6f;

        public abstract CurveReader PositionReader { get; set; }

        public abstract AnimationCurve Position { get; set; }

        public abstract Vector3 Direction { get; }

        public abstract bool IsWallCheck { get; }
    }
}
