using System.Collections.Generic;

namespace Ecs
{
    public class Systems
    {
        private List<IFixedTickable> _fixedTickables = new();
        private List<ITickable> _tickables = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var system in _fixedTickables)
                system.FixedTick(deltaTime);
        }

        public void Tick(float deltaTime)
        {
            foreach (var system in _tickables)
                system.Tick(deltaTime);
        }

        public Systems Add(Systems systems)
        {
            foreach (var system in systems._fixedTickables)
                _fixedTickables.Add(system);

            foreach (var system in systems._tickables)
                _tickables.Add(system);

            return this;
        }

        public Systems Add(ISystem system)
        {
            if (system is IFixedTickable fixedTickable)
                _fixedTickables.Add(fixedTickable);

            if (system is ITickable tickable)
                _tickables.Add(tickable);

            return this;
        }
    }
}