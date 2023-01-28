using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class StayCollisionDetector : EcsComponent
{
    public Collision Collision;


    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("CollisionStay");

        //if 
        Collision = collision;
    }
}
