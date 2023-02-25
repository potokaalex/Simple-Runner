using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;

public class CharacterDeathDetector : ITickable
{
    private Filter<EnterTriggerEvent> _enterEvents = new();

    public void Tick(float deltaTime)
    {
        /*
        foreach (var enterEvent in _enterEvents)
        {
            if (!enterEvent.Collider.TryGetComponent(out ObstacleMarker obstacle))
                continue;

            if (!enterEvent.Sender.TryGetComponent(out CharacterMarker character))
                continue;

            //PauseManager.IsPaused = true;

            DefeatMenu.Instance.Active(true);

            // открытие меню паузы/replay`я, остановка игры на паузу.
            //Singleton<Level>.Instance.Defeat();
        }
        */
    }
}


public class EnterTriggerEvent : IComponent
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