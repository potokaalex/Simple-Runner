using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ecs.Core
{
    public static class EcsWorld
    {
        public static HashSet<EcsComponent> _components = new();

        public static event ComponentTransfer ComponentAdded;
        public static event ComponentTransfer ComponentRemoved;

        public static HashSet<EcsComponent> GetComponents() => _components;

        public static bool TryAddComponent(EcsComponent component)
        {
            if (!_components.Add(component))
                return false;

            ComponentAdded?.Invoke(component);

            return true;
        }

        public static bool TryRemoveComponent(EcsComponent component)
        {
            if (!_components.Remove(component))
                return false;

            ComponentRemoved?.Invoke(component);

            return true;
        }
    }
}