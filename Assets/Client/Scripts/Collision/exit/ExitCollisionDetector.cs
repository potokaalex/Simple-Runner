using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Ecs.Core;

[RequireComponent(typeof(Collider))]

public class ExitCollisionDetector : EcsComponent
{
    //public Collision Collision;

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log($"Exit");

        EcsWorld.AddEvent(new ExitCollisionEvent(this, collision));
    }
}
