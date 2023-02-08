using UnityEngine;

namespace Singleton
{
    public abstract class Singleton<T> where T : MonoBehaviour
    {
        public static T TryGetInstance()
        {
            var componentType = typeof(T);
            var components = Object.FindObjectsOfType(componentType, true);

            if (components == null || components.Length < 1)
            {
                Debug.LogError($"You are trying to access an uncreated {componentType}");
                return null;
            }

            var component = components[0] as T;

            if (components.Length < 2)
                return component;

            Debug.LogError($"An object of {componentType} type should be the only one in the scene!");

            return component;
        }
    }
}
