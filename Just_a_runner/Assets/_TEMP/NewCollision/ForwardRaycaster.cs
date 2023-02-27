using UnityEngine;

public class ForwardRaycaster : Raycaster
{
    [SerializeField] private LayerMask _ignoreMask;
    [SerializeField] private float _distance;

    public override LayerMask IgnoreMask
        => _ignoreMask;

    public override float Distance
        => _distance;

    public override Vector3 Direction
        => Vector3.forward;
}
