using InputSystem;
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
            if (component.IsWallCheck)
                if (Physics.Raycast(component.transform.position, component.Direction, out var hit, 
                    component.PositionReader.GetValue(component.PositionReader.LastKeyTime)))
                    if (hit.transform.gameObject.TryGetComponent<Wall>(out var c))
                        return true;

            return false;
        }
    }
}
