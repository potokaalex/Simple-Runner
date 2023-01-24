using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

public class Slide : EcsComponent //Slide(r)
{
    public LayerMask IgnoreMask;

   private Collision _collision;

    //public StayCollisionDetector _stayDetector;
    //public Transform BOX;

    private List<Vector3> _normals = new();

    private Vector3 _normal;

    private List<Collision> _collisions = new();

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, _normal, Color.cyan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryAddNormal(collision);
        RecalculateAverageNormal();
    }

    private void OnCollisionExit(Collision collision)
    {
        TryRemoveNormal(collision);
        RecalculateAverageNormal();
    }

    private void TryAddNormal(Collision normal)
    {
        if (_collisions.Contains(normal))
            return;

        _collisions.Add(normal);
    }

    private void TryRemoveNormal(Collision normal)
    {
        _collisions.Remove(normal);
    }

    private void RecalculateAverageNormal()
    {
        var count = _collisions.Count;

        if (count < 1)
            return;

        _normal = Vector3.zero;

        foreach (var n in _collisions)
            _normal += n.contacts[0].normal;

        _normal /= count;
    }
}