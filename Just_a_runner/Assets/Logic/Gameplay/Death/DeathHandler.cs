using Infrastructure.Menus;
using CollisionSystem;
using StateMachines; 
using Ecs;

namespace DeathSystem
{
    public class DeathHandler : IFixedTickable
    {
        private Filter<EnterCollisionEvent> _events = new();
        private IStateMachine _stateMachine;

        public DeathHandler(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void FixedTick(float deltaTime)
        {
            foreach (var @event in _events.Components)
                Handle(@event);
        }

        private CharacterMarker GetCharacter()
        {
            foreach (var entity in World.Entities)
                if (entity.Contains<CharacterMarker>())
                    return entity.Get<CharacterMarker>();

            return null;
        }

        private void Handle(EnterCollisionEvent @event)
        {
            if (!World.TryGetEntity(@event.CollisionInfo.gameObject, out var entity))
                return;

            if (!entity.Contains<ObstacleMarker>())
                return;

            if (!@event.Sender.Contains<DeathMarker>())
                return;

            if (@event.Sender.GameObject == GetCharacter().gameObject)
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