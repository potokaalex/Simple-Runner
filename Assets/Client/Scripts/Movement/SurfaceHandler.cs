using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CollisionSystem;

namespace MovementSystem
{
    public class SurfaceHandler : EcsComponent
    {
        public Transform parant;

        public EnterCollisionDetector EnterCollisionDetector;
        public ExitCollisionDetector ExitCollisionDetector;

        public List<Vector3> Normals = new();
        public Vector3 SurfaceNormal;

        private void FixedUpdate()
        {
            if (Normals.Count < 1)
                return;

            var averageNormal = Vector3.zero;

            foreach (var n in Normals)
                averageNormal += n;

            averageNormal /= Normals.Count;

            parant.rotation = Quaternion.LookRotation(averageNormal);

            Normals.Clear();
        }


        private void OnCollisionStay(Collision collision)
        {
            if (collision.contacts.Length < 1)
                return;

            var normal = collision.contacts[0].normal;

            Normals.Add(normal);

            Debug.DrawRay(transform.position, normal, Color.red);
            Debug.DrawRay(transform.position, GetProjection(normal), Color.green);
            /*
            if (Normals.Contains(normal))
                return;

            AddNormal(normal);
            ReCalculateAverageNormal();

            Debug.Log("Aded new Normal !");
            */
        }
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
