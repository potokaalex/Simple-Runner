using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem
{
    public class SurfaceHandler : EcsComponent
    {
        public EnterCollisionDetector EnterCollisionDetector;
        public ExitCollisionDetector ExitCollisionDetector;
        public List<ContactPoint> SurfaceContacts = new();
        public Vector3 SurfaceNormal;

        private void OnCollisionStay(Collision collision)
        {
            //Debug.DrawRay(transform.position, collision.contacts[0].normal, Color.red);
        }
    }
}
