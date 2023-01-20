using UnityEngine;
using Ecs.Core;

public abstract class EcsComponent : MonoBehaviour
{
    public virtual void OnEnable()
    {
        EcsWorld.TryAddComponent(this);
    }

    public virtual void OnDisable()
    {
        EcsWorld.TryRemoveComponent(this);
    }
}