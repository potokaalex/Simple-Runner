using UnityEngine;
using Ecs;

namespace InputSystem
{
    public class KeyDown : IComponent
    {
        public KeyCode KeyCode;

        private Entity _entity;

        public KeyDown(KeyCode keyCode)
        {
            KeyCode = keyCode;

            _entity = World.Events;
        }

        public Entity Entity
            => _entity;
    }

    public class KeyDown_W : IComponent
    {
        public Entity Entity
            => World.Events;
    }

    public class KeyDown_A : IComponent
    {
        public Entity Entity
            => World.Events;
    }

    public class KeyDown_S : IComponent
    {
        public Entity Entity
            => World.Events;
    }

    public class KeyDown_D : IComponent
    {
        public Entity Entity
            => World.Events;
    }

    public class KeyDown_Space : IComponent
    {
        public Entity Entity
            => World.Events;
    }
}