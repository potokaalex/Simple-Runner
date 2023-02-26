using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ecs
{
    public abstract class EcsComponent : MonoBehaviour, IComponent
    {
        private Entity _entity;

        public Entity Entity
            => _entity;

        public virtual void OnEnable()
        {
            if (TryGetEntity(out _entity))
                _entity.Add(this);
            else
                World.Entities.Add(_entity = new(this, gameObject));
        }

        public virtual void OnDisable()
            => _entity.Remove(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryGetEntity(out Entity entity)
        {
            foreach (var savedEntity in World.Entities)
            {
                if (savedEntity.GameObject == gameObject)
                {
                    entity = savedEntity;
                    return true;
                }
            }

            entity = null;

            return false;
        }
    }
}