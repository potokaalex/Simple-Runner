using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

//movePosition - изменяет позицию в соответствии с кривой
//moveDirection - непрерывно двигает тело в неком направлении

//moveLeft & moveRight - производные от movePosition
//run - вообще чистое moveDirection
namespace MovementSystem
{
    public class MovePositionUpdate : IFixedTickable
    {
        private Filter<MoveLeft> _movable = new();


        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _movable.Entities)
                Move(entity.Get<MoveLeft>(), deltaTime);
        }

        //private Filter<MoveLeftKey> _keys = new();


        public void Move(MoveSide component, float deltaTime)
        {
            //if (_keys.Entities.Count > 0)
             //   StartMove(component);

            UpdateMove(component, deltaTime);
        }


        public void StartMove(MoveSide component)
        {
            component.PositionReader ??= new(component.Position);

            if (IsWall(component))
                return;

            if (component.PositionReader.GetIncrement() == 0)
                component.PositionReader.Reset();
        }

        public void UpdateMove(MoveSide component, float deltaTime)
        {
            if (component.PositionReader == null)
                return;

            var velocity = component.PositionReader.GetIncrement();

            component.transform.position += component.Direction.normalized * velocity;
            component.PositionReader.Move(deltaTime);
        }

        private bool IsWall(MoveSide component)
        {
            if (!component.IsWallCheck)
                return false;

            if (!Physics.Raycast(component.transform.position, component.Direction, out var hit,
                component.PositionReader.GetValue(component.PositionReader.LastKeyTime)))
                return false;

            if (World.TryGetEntity(hit.transform.gameObject, out var entity))
                if (entity.Contains<Wall>())
                    return true;

            return false;
        }
    }
}
