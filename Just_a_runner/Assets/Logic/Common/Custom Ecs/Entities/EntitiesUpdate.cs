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
            if (!World.Events.Contains<IComponent>())
                return;

            World.Events.Get<IComponent>(out var components);

            for (var i = 0; i < components.Count; i++)
                World.Events.Remove(components[i]);
        }
    }
}
