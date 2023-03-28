using Infrastructure.Menus;
using CollisionSystem;
using StateMachines;
using Character;
using Ecs;

using UnityEngine;

namespace DeathSystem
{
    public class DeathHandler : IFixedTickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private Filter<CharacterMarker> _characters = new();
        private IStateMachine _stateMachine;

        public DeathHandler(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void FixedTick(float deltaTime)
        {
            foreach (var @event in _events.Components)
                Handle(@event);
        }

        private bool IsCharacter(GameObject gameObject)
        {
            foreach (var character in _characters.Components)
                if (gameObject == character.gameObject)
                    return true;

            return false;
        }

        private void Handle(EnterCollisionEvent @event)
        {
            if (!World.TryGetEntity(@event.CollisionInfo.gameObject, out var entity))
                return;

            if (!entity.Contains<ObstacleMarker>())
                return;

            if (!@event.Sender.Contains<DeathMarker>())
                return;

            if (IsCharacter(@event.Sender.GameObject))
                CharacterDeath();
            else
                DefaultDeath(@event.Sender);
        }

        private void CharacterDeath()
            => _stateMachine.SwitchTo<DefeatState>();

        private void DefaultDeath(Entity entity)
            => entity.Destroy();
    }
}
