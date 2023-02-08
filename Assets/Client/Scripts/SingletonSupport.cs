//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

public class SingletonSupport : IFixedUpdateSystem
{
    Filter<ComponentAdded> _addeds = Filter.Create<ComponentAdded>();

    public void FixedUpdate(float deltaTime)
    {
        foreach (var component in _addeds)
            //if (typeof(IAloneInScene).IsAssignableFrom(component.GetType()))
            if (component is IAloneInScene)
            {
                Debug.Log("ComponentAdded");

                if (Object.FindObjectsOfType(component.GetType()).Length > 2)
                    throw new System.Exception($"An object of {component.GetType()} type should be the only one in the scene!");
            }
    }
}