using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Systems;
using MovementSystem;
using InputSystem;

namespace MovementSystem
{
    public class MoveRight : MoveSide
    {
        [SerializeField] private AnimationCurve _position;

        public override AnimationCurve Position
        {
            get => _position;
            set => _position = value;
        }

        public override CurveReader PositionReader { get; set; }
    }
}
