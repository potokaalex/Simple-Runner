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
    public class Death : ITickable //DeathDetector if will be request system
    {
        private Filter<EnterCollisionEvent> _events = new();
        private GameObject _character;

        public Death(CharacterMarker characterMarker)
            => _character = characterMarker.gameObject;

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < _events.Count; i++)
                Detect(_events[i].Get<EnterCollisionEvent>());
        }

        private void Detect(EnterCollisionEvent @event)
        {
            if (@event.CollisionInfo.gameObject.TryGetComponent<ObstacleMarker>(out var obstacle))
                if (@event.Sender.Entity.Contains<DeathMarker>())
                    if (@event.Sender.gameObject == _character)
                        Debug.Log($"CHARACTER died by {obstacle.name}");
                    else
                        @event.Sender.Entity.Destroy();
        }
    }
}

public class EnterTriggerEvent : IComponent //рудимент
{
    public EcsComponent Sender;
    public Collider Collider;

    public EnterTriggerEvent(EcsComponent sender, Collider collider)
    {
        Sender = sender;
        Collider = collider;
    }

    public Entity Entity { get; }
}
