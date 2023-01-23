using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

public class Slide : EcsComponent //Slide(r)
{
    public Transform BOX;

    private void FixedUpdate()
    {
        var ignoreLayer = 1 << BOX.gameObject.layer;

        var hits = Physics.BoxCastAll(BOX.position, BOX.lossyScale / 2, Vector3.down, BOX.rotation, 0f, ~ignoreLayer);

        //Physics.Box

        var normals = Vector3.zero;

        foreach (var hit in hits)
            normals += hit.normal;

        if (hits.Length < 1)
            return;

        Debug.Log(hits.Length);

        normals /= hits.Length;

        Debug.Log(normals);

        Debug.DrawRay(BOX.position, normals,Color.cyan);
    }

    //private void 
}