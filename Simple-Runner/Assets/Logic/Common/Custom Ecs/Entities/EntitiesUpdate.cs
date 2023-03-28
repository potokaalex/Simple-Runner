using System.Runtime.CompilerServices;
using Infrastructure;
using Zenject;
using System;

namespace Ecs
{
    public class EntitiesUpdate : IInitializable, IDisposable
    {
        private IGameLoop _gameLoop;

        [Inject]
        public EntitiesUpdate(IGameLoop gameLoop)
            => _gameLoop = gameLoop;

        public void Initialize()
            => _gameLoop.OnFixedTick += FixedTick;

        public void Dispose()
            => _gameLoop.OnFixedTick -= FixedTick;

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
