using System.Collections.Generic;

namespace Ecs
{
    public class Systems
    {
        private List<IInitializable> _initializables = new();
        private List<ITickable> _tickables = new();
        private List<IDestroyable> _destroyables = new();

        public void Initialize()
        {
            foreach (var system in _initializables)
                system.Initialize();
        }

        public void Update(float deltaTime)
        {
            foreach (var system in _tickables)
                system.Tick(deltaTime);
        }

        public void Destroy()
        {
            foreach (var system in _destroyables)
                system.Destroy();
        }

        public Systems Add(Systems systems)
        {
            foreach (var system in systems._initializables)
                _initializables.Add(system);

            foreach (var system in systems._tickables)
                _tickables.Add(system);

            foreach (var system in systems._destroyables)
                _destroyables.Add(system);

            return this;
        }

        public Systems Add(ISystem system)
        {
            if (system is IInitializable initializable)
                _initializables.Add(initializable);

            else if (system is ITickable tickable)
                _tickables.Add(tickable);

            else if (system is IDestroyable destroyable)
                _destroyables.Add(destroyable);

            return this;
        }

        public bool TryRemove(ISystem system)
        {
            if (system is IInitializable initializable)
                return _initializables.Remove(initializable);

            else if (system is ITickable tickable)
                return _tickables.Remove(tickable);

            else if (system is IDestroyable destroyable)
                return _destroyables.Remove(destroyable);

            return false;
        }
    }
}