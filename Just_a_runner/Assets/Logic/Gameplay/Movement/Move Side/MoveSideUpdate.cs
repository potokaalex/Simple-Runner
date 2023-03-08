using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public abstract class MoveSideUpdate
    {
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