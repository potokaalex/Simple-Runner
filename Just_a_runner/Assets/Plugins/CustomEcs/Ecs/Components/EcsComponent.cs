using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ecs
{
    public abstract class EcsComponent : MonoBehaviour, IComponent
    {
        private Entity _entity;

        public Entity Entity
            => _entity;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void OnEnable()
            => _entity = GetEntity();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void OnDisable()
            => _entity.Remove(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Entity GetEntity()
        {
            foreach (var entity in World.Entities)
                if (entity.GameObject == this)
                    return entity;

            var newEntity = new Entity(this, gameObject);

            return newEntity;
        }
    }
}