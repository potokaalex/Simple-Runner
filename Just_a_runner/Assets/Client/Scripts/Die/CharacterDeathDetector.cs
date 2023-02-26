using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterDeathDetector : ITickable
{
    private Filter<EnterTriggerEvent> _enterEvents = new();
    private Collider[] _colliders = new Collider[8];
    private Transform Character;

    public void Tick(float deltaTime)
    {
        var collidersCount = Physics.OverlapBoxNonAlloc(Character.transform.position, Character.transform.lossyScale / 2, _colliders);

        if (_colliders.Length == collidersCount)
            ExpandArray(Physics.OverlapBox(Character.transform.position, Character.transform.lossyScale / 2), out _colliders);

        for (var i = 0; i < collidersCount; i++)
            if (_colliders[i].TryGetComponent<ObstacleMarker>(out var c))
                Debug.Log("Death !");
    }

    private void ExpandArray(Collider[] additional, out Collider[] main)
    {
        main = new Collider[additional.Length * 2];

        for (var i = 0; i < additional.Length; i++)
            main[i] = additional[i];
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