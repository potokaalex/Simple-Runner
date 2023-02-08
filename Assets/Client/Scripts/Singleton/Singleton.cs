using UnityEngine;

namespace Singleton
{
    public static class Singleton<T> where T : MonoBehaviour, IAloneInScene
    {
        private static T _instance;
        private static GameObject _singletonObject;

        public static T Instance
        {
            get
            {
                var componentType = typeof(T);
                var components = Object.FindObjectsOfType(componentType, true);

                if (_singletonObject == null)
                    _singletonObject = new GameObject("Singletons");

                if (components == null || components.Length < 1)
                    return _instance = _singletonObject.AddComponent<T>();

                if (components.Length == 1)
                    return _instance;

                Debug.LogError($"An object of {componentType} type should be the only one in the scene!");

                return _instance;
            }
        }
    }
}
