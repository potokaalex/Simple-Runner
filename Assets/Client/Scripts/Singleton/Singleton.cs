using UnityEngine;
using System;

namespace Singleton
{
    public static class Singleton<T> where T : MonoBehaviour, IAloneInScene
    {
        //private static T _instance;

        public static T Instance
        {
            get
            {
                //Debug.Log("pre-Get");

                var componentType = typeof(T);
                var components = UnityEngine.Object.FindObjectsOfType(componentType, true);

                if (components.Length == 1)
                    return (T)components[0];

                if (components == null || components.Length < 1)
                    throw new Exception($"An object of {componentType} type must be installed in the scene !");
                else
                    throw new Exception($"An object of {componentType} type should be the only one in the scene!");
            }
        }
    }
}
