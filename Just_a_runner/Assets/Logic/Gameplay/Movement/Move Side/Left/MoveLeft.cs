using UnityEngine;

namespace MovementSystem
{
    public class MoveLeft : MoveSide
    {
        [SerializeField] private AnimationCurve _position;
        [SerializeField] private bool _isWallCheck;

        public override AnimationCurve Position
        {
            get => _position;
            set => _position = value;
        }

        public override CurveReader PositionReader { get; set; }

        public override Vector3 Direction
            => Vector3.left;

        public override bool IsWallCheck
            => _isWallCheck;
    }
}