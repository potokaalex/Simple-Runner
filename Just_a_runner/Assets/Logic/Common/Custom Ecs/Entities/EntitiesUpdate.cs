using System.Runtime.CompilerServices;

namespace Ecs
{
    public class EntitiesUpdate : IFixedTickable
    {
        public void FixedTick(float deltaTime)
        {
            WorldEntitiesUpdate();
            EventsUpdate();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WorldEntitiesUpdate() 
        {
            for (var i = 0; i < World.Entities.Count; i++)
                World.Entities[i].Update();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EventsUpdate() 
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