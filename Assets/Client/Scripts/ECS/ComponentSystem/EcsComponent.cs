using UnityEngine;
using Ecs;

public abstract class EcsComponent : MonoBehaviour
{
    public virtual void OnEnable()
    {
        EcsWorld.AddComponent(this);
    }

    public virtual void OnDisable()
    {
        EcsWorld.RemoveComponent(this);
    }
}