using UnityEngine;
using Ecs.Core;
using Ecs;

public abstract class EcsComponent : MonoBehaviour
{
    private EcsWorld _world;
    public EcsWorld EcsWorld => _world == null ? EcsWorld.FindWorld() : _world;

    public virtual void OnEnable()
    {
        EcsWorld.AddComponent(this);
    }

    public virtual void OnDisable()
    {
        if (EcsWorld == null)
            return;

        EcsWorld.RemoveComponent(this);
    }
}