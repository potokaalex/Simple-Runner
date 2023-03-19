using Infrastructure;
using CollisionSystem;
using UnityEngine;
using Ecs;

namespace DeathSystem
{
    public class DeathHandler : IFixedTickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private Infrastructure.StateMachine _stateMachine;
        private GameObject _character;

        public DeathHandler(CharacterMarker characterMarker, Infrastructure.StateMachine stateMachine)
        {
            _character = characterMarker.gameObject;
            _stateMachine = stateMachine;
        }

        public void FixedTick(float deltaTime)
        {
            foreach (var @event in _events.Components)
                Handle(@event);
        }

        private void Handle(EnterCollisionEvent @event)
        {
            //return;

            if (!World.TryGetEntity(@event.CollisionInfo.gameObject, out var entity))
                return;

            if (!entity.Contains<ObstacleMarker>())
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