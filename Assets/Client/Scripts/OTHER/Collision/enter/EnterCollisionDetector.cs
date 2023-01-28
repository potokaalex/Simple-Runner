using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Ecs;

[RequireComponent(typeof(Collider))]

public class EnterCollisionDetector : EcsComponent
{
    //public Collision Collision;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Enter");

        EcsWorld.AddEvent(new EnterCollisionEvent(this, collision));
    }
}
