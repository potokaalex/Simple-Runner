using UnityEngine;
using Ecs;

namespace InputSystem
{
    public class KeyDown : IEvent, IComponent
    {
        public KeyCode KeyCode;

        public KeyDown(KeyCode keyCode)
        {
            KeyCode = keyCode;
        }

        public Entity Entity { get; }
    }
}

public interface IEvent { }