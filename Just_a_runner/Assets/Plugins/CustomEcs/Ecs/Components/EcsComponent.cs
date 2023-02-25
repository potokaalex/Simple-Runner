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
            _entity = GetEntity();

            _entity.Add(this);
        }

        public virtual void OnDisable()
            => _entity.Remove(this);

        private Entity GetEntity()
        {
            foreach (var entity in World.Entities)
                if (entity.GameObject == this)
                    return entity;

            var newEntity = new Entity(this, gameObject);

            World.Entities.Add(newEntity);

            return newEntity;
        }
    }
}