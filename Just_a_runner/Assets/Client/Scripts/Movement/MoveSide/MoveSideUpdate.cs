using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem
{
    public abstract class MoveSideUpdate
    {
        public void StartMove(MoveSide component)
        {
            component.PositionReader ??= new(component.Position);

            if (component.PositionReader.GetIncrement() == 0)
                component.PositionReader.Reset();
        }

        public void UpdateMove(MoveSide component, Vector3 direction, float deltaTime)
        {
            if (component.PositionReader == null)
                return;

            var velocity = component.PositionReader.GetIncrement();

            component.transform.position += direction.normalized * velocity;
            component.PositionReader.Move(deltaTime);
        }
    }
}
