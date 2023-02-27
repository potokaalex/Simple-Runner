using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DeathDetection : ITickable
{
    private Collider[] _overlaps = new Collider[8];
    private Filter<Dying> _dyings = new();

    public void Tick(float deltaTime)
    {
        for (var i = 0; i < _dyings.Count; i++)
            Detect(_dyings[i].Get<Dying>());
    }

    private void Detect(Dying dying)
    {
        var overlapsCount = GetOverlaps(dying.Object.transform, _overlaps);

        if (_overlaps.Length == overlapsCount)
            overlapsCount = GetOverlaps
                (dying.Object.transform, _overlaps = new Collider[_overlaps.Length * 2]);

        for (var i = 0; i < overlapsCount; i++)
        {
            if (_overlaps[i].TryGetComponent<ObstacleMarker>(out var obstacle))
            {
                if (dying.Entity.Contains<CharacterMarker>())
                    Debug.Log($"CHARACTER died by {obstacle.name}");
                else
                    dying.Entity.Destroy();
            }
        }
    }

    private int GetOverlaps(Transform objectTransform, Collider[] results)
        => Physics.OverlapBoxNonAlloc(objectTransform.position, objectTransform.lossyScale / 2, results);
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
