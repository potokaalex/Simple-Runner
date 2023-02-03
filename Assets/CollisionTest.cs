using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using CollisionSystem;
using System.Linq;
using System;

public class CollisionTest : EcsComponent
{
    public BoxCollider Body;
    public LayerMask IgnoreMask;

    public List<RaycastHit> Hits;

    private void Start()
    {
        var parentsRigidbody = GetComponentInParent<Rigidbody>();
        var selfRigidbody = GetComponent<Rigidbody>();
        //var parentsRigidbody = GetComponentInParent<Rigidbody>();

        if (parentsRigidbody == null && selfRigidbody == null)
            Debug.Log("No rb !");
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts.Length < 1)
            return;

        Debug.DrawRay(Body.transform.position, collision.contacts[0].normal, Color.red);
    }
}


/*
        if (hits.Length < 1)
        {
            StayPoints.Clear();

            Debug.Log("All_Exit !");
        }

        foreach (var hit in hits)
        {
            if (!StayPoints.Contains(hit.point))
                ;

            foreach (var hit in hits)
            {
                //Debug.Log(hit.point);

                if (point != hit.point)
                    removeds.Add(point);
            }
        }

        foreach (var r in removeds)
            RemoveAtStay(r);
*/


/*
ToDo:

*Enter-Detect
*Exit-Detect
*Stay-Detect
*/