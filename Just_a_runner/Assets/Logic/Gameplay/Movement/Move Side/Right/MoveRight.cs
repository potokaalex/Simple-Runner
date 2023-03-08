using UnityEngine;

namespace MovementSystem
{
    public class MoveRight : MoveSide
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
            => Vector3.right;

        public override bool IsWallCheck
            => _isWallCheck;
    }
}
