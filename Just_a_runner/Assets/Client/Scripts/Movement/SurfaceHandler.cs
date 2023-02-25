using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CollisionSystem;
using Ecs;

namespace MovementSystem
{
    public class SurfaceHandler : EcsComponent // SurfaceDetector
    {
        public Transform parent;

        public EnterCollisionDetector EnterCollisionDetector;
        public ExitCollisionDetector ExitCollisionDetector;

        public List<Vector3> Normals = new();
        public List<Vector3> CurrentNormals = new();

        public Vector3 SurfaceNormal;

        public LayerMask IgnoreMask;

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 1f, ~IgnoreMask))
            {
                //Debug.Log(Vector3.Angle(hit.normal, Vector3.forward));

                var engle = hit.transform.rotation.x;

                parent.rotation = hit.transform.rotation;//Quaternion.AngleAxis(engle, Vector3.right);

            }


            Debug.DrawRay(transform.position, Vector3.forward);

            /*
            var remined = Normals.Except(CurrentNormals);

            
            foreach (var r in remined)
                RemoveNormal(r);

            if (CurrentNormals.Count < 1)
                return;

            foreach (var n in CurrentNormals)
                AddNormal(n);

            ReCalculateAverageNormal();

            //

            CurrentNormals.Clear();
            */
        }

        /*
        private void OnCollisionStay(Collision collision)
        {
            if (collision.contacts.Length < 1)
                return;

            var normal = collision.contacts[0].normal;

            //CurrentNormals.Add(normal);

            Debug.DrawRay(transform.position, normal, Color.red);
            Debug.DrawRay(transform.position, GetProjection(normal), Color.green);

            parent.rotation = Quaternion.LookRotation(normal);

            if (Normals.Contains(normal))
                return;

            AddNormal(normal);

            Debug.Log("Aded new Normal !");
            
        }
        */

        /*
        private void OnCollisionExit(Collision collision)
        {
            if (collision.contacts.Length < 1)
                return;

            RemoveNormal(collision.contacts[0].normal);

            if (Normals.Count > 1)
                ReCalculateAverageNormal();
        }
        */

        private void AddNormal(Vector3 normal)
        {
            Normals.Add(normal);
        }

        private void RemoveNormal(Vector3 normal)
        {
            Normals.Remove(normal);
        }

        private void ReCalculateAverageNormal()
        {
            SurfaceNormal = Vector3.zero;

            foreach (var n in Normals)
                SurfaceNormal += n;

            SurfaceNormal /= Normals.Count;
        }

        private Vector3 GetProjection(Vector3 normal) => Vector3.forward - Vector3.Dot(Vector3.forward, normal) * normal;
    }
}
