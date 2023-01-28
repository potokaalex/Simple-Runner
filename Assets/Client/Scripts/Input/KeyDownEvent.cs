using UnityEngine;
using Ecs;

namespace InputSystem
{
    public class KeyDown : IEvent
    {
        public KeyCode KeyCode;

        public KeyDown(KeyCode keyCode)
        {
            KeyCode = keyCode;
        }
    }
}
