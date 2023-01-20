using UnityEngine;
using Ecs.Core;
using System.Collections.Generic;

public abstract class EcsComponent : MonoBehaviour
{

    public void OnEnable()
    {
        EcsWorld.TryAddComponent(this);
    }

    public void OnDisable()
    {
        EcsWorld.TryRemoveComponent(this);
    }
}