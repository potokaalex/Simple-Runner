using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using CollisionSystem;
using System.Linq;

public class CollisionTest : MonoBehaviour
{
    public BoxCollider Body;
    public LayerMask IgnoreMask;

    public List<Vector3> StayNormals;

    private void FixedUpdate()
    {
        var castDistance = 0.01f;
        var bounds = Body.bounds;
        var hits = Physics.BoxCastAll(bounds.center, new Vector3(bounds.extents.x, bounds.extents.y, 0), Vector3.forward, Body.transform.rotation, bounds.extents.z + castDistance, ~IgnoreMask);

        var errorRate = 1E-3f; //0.0001f;

        foreach (var hit in hits)
        {
            if (hit.distance == 0)
                continue;

            if (float.IsNaN(hit.normal.magnitude))
                continue;

            if (!StayNormalsContains(hit.normal))
            {
                AddToStay(hit.normal);
            }
            //else
            //-Stay-

            Debug.DrawLine(Body.transform.position, hit.point);
            Debug.DrawRay(Body.transform.position, hit.normal, Color.red);
        }

        Debug.Log(hits.Length);

        var REMOVED = new List<Vector3>();

        foreach (var normal in StayNormals)
            if (!HitsContains(normal))
                REMOVED.Add(normal);

        foreach (var r in REMOVED)
            RemoveAtStay(r);

        bool StayNormalsContains(Vector3 point)
        {
            foreach (var normal in StayNormals)
            {
                if (normal.magnitude >= point.magnitude - errorRate &&
                    normal.magnitude <= point.magnitude + errorRate)
                {
                    return true;
                }

                Debug.Log($"Point magnitude: {point.magnitude}, normal: {normal.magnitude}");
            }



            return false;
        }

        bool HitsContains(Vector3 point)
        {
            foreach (var hit in hits)
                if (hit.normal == point)
                    return true;

            return false;
        }
    }

    private void AddToStay(Vector3 point)
    {
        StayNormals.Add(point);

        Debug.Log("-Enter-");
    }

    private void RemoveAtStay(Vector3 point)
    {
        if (StayNormals.Remove(point))
            Debug.Log("-Exit-");
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