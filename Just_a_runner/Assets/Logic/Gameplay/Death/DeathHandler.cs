using CollisionSystem;
using UnityEngine;
using Ecs;

namespace DeathSystem
{
    public class DeathHandler : IFixedTickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private GameObject _character;

        public DeathHandler(CharacterMarker characterMarker)
            => _character = characterMarker.gameObject;

        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _events.Entities)
                Handle(entity.Get<EnterCollisionEvent>());
        }

        private void Handle(EnterCollisionEvent @event)
        {
            if (IsContainsObstacleMarker(@event.CollisionInfo.gameObject))
                if (@event.Sender.Contains<DeathMarker>())
                    if (@event.Sender.GameObject == _character)
                        CharacterDeath(@event.Sender);
                    else
                        DefaultDeath(@event.Sender);
        }

        private bool IsContainsObstacleMarker(GameObject gameObject)
        {
            foreach (var savedEntity in World.Entities)
                if (savedEntity.GameObject == gameObject)
                    return savedEntity.Contains<ObstacleMarker>();

            return false;
        }

        private void CharacterDeath(Entity entity)
        {
            //смерть персонажа
            //

            Debug.Log("Character death");
        }

        private void DefaultDeath(Entity entity)
        {
            entity.Destroy();
        }
    }
}