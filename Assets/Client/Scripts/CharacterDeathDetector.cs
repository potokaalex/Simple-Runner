using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;
using Singleton;

public class CharacterDeathDetector : IFixedUpdateSystem
{
    private Filter<EnterTriggerEvent> _enterEvents = Filter.Create<EnterTriggerEvent>();

    public void FixedUpdate(float deltaTime)
    {
        foreach (var enterEvent in _enterEvents)
        {
            if (!enterEvent.Collider.TryGetComponent(out ObstacleMarker obstacle))
                continue;

            if (!enterEvent.Sender.TryGetComponent(out CharacterMarker character))
                continue;

            // открытие меню паузы/replay`я, остановка игры на паузу.

            Singleton<Level>.Instance.Defeat();
        }
    }
}


public class EnterTriggerEvent : IEvent
{
    public EcsComponent Sender;
    public Collider Collider;

    public EnterTriggerEvent(EcsComponent sender, Collider collider)
    {
        Sender = sender;
        Collider = collider;
    }
}

public interface IAloneInScene { }

public interface IAloneInScene<ComponentType> : IAloneInScene 
{
    public static void GetInstance() { }

}

