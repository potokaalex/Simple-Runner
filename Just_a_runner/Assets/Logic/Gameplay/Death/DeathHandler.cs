using Infrastructure.StateMachine;
using CollisionSystem;
using UnityEngine;
using Ecs;

namespace DeathSystem
{
    public class DeathHandler : IFixedTickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private GlobalStateMachine _stateMachine;
        private GameObject _character;

        public DeathHandler(CharacterMarker characterMarker, GlobalStateMachine stateMachine)
        {
            _character = characterMarker.gameObject;
            _stateMachine = stateMachine;
        }

        public void FixedTick(float deltaTime)
        {
            foreach (var entity in _events.Entities)
                Handle(entity.Get<EnterCollisionEvent>());
        }

        private bool IsContainsObstacleMarker(GameObject gameObject)
        {
            foreach (var savedEntity in World.Entities)
                if (savedEntity.GameObject == gameObject)
                    return savedEntity.Contains<ObstacleMarker>();

            return false;
        }

        private void Handle(EnterCollisionEvent @event)
        {
            if (!IsContainsObstacleMarker(@event.CollisionInfo.gameObject))
                return;

            if (!@event.Sender.Contains<DeathMarker>())
                return;

            if (@event.Sender.GameObject == _character)
                CharacterDeath();
            else
                DefaultDeath(@event.Sender);
        }

        private void CharacterDeath()
        {
            _stateMachine.SwitchTo<DefeatState>();
        }

        private void DefaultDeath(Entity entity)
        {
            entity.Destroy();
        }
    }
}