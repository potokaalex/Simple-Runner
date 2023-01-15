using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public class EcsSystems
    {
        private HashSet<IUpdateSystem> _updateSystems = new();
        private HashSet<IFixedUpdateSystem> _fixedUpdateSystems = new();

        public void Add(ISystem system)
        {
            if (system is IUpdateSystem updateSystem)
                _updateSystems.Add(updateSystem);

            if (system is IFixedUpdateSystem fixedUpdateSystem)
                _fixedUpdateSystems.Add(fixedUpdateSystem);
        }

        public void Update(float deltaTime)
        {
            foreach (var system in _updateSystems)
                system.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var system in _fixedUpdateSystems)
                system.FixedUpdate(deltaTime);
        }
    }
}