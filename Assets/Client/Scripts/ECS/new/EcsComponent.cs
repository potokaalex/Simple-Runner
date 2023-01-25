using UnityEngine;
using Ecs.Core;
using Ecs;

public abstract class EcsComponent : MonoBehaviour
{
    public EcsWorld EcsWorld
    {
        get => EcsWorld != null ? EcsWorld : EcsWorld = EcsWorld.FindWorld();
        private set { }
    }

    public virtual void OnEnable()
    {
        EcsWorld.TryAddComponent(this);
    }

    public virtual void OnDisable()
    {
        EcsWorld.TryRemoveComponent(this);
    }
}