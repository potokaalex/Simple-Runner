using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using CollisionSystem;

namespace DeathSystem
{
    public class DeathHandler : ITickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private GameObject _character;

        public DeathHandler(CharacterMarker characterMarker)
            => _character = characterMarker.gameObject;

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < _events.Count; i++)
                Handle(_events[i].Get<EnterCollisionEvent>());
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