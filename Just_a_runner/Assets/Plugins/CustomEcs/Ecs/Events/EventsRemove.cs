using System.Runtime.CompilerServices;

namespace Ecs
{
    public class EventsRemove : ITickable
    {
        public void Tick(float deltaTime)
            => Update();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Update()
        {
            var events = World.Events;

            if(events.Count<IComponent>() < 1)
                return;

            events.Get<IComponent>(out var components);
            var componentsLength = components.Count;

            for (var i = 0; i < componentsLength; i++)
                events.Remove(components[i]);
        }
    }
}