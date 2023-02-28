using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ecs
{
    public class EventsRemove : ITickable
    {
        public void Tick(float deltaTime)
            => Update();

        private void Update()
        {
            var events = World.Events;

            if (!events.Contains<IComponent>())
                return;

            events.Get<IComponent>(out var components);
            var componentsLength = components.Count;

            for (var i = 0; i < componentsLength; i++)
                events.Remove(components[i]);
        }
    }
}