using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public abstract class MoveSideSystem : MovePositionSystem
    {
        private protected void Move(
            MovePositionPattern component, 
            float deltaTime, 
            bool IsStartMove, 
            bool isWallCheck)
        {
            if (IsStartMove)
                StartMove(component, isWallCheck);

            Update(component, deltaTime);
        }

        private void StartMove(MovePositionPattern component, bool isWallCheck)
        {
            component.PositionReader ??= new(component.Position);

            if (IsWall(component, isWallCheck))
                return;


            if (component.PositionReader.GetIncrement() == 0)
                component.PositionReader.Reset();
        }

        private bool IsWall(MovePositionPattern component, bool isWallCheck)
        {
            if (!isWallCheck)
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