using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CameraInput : MonoBehaviour
{
    [SerializeField] private TrackMovement trackMovement;
    [SerializeField][Range(0f, 10f)] private float sharpness;
    [SerializeField] private Vector3 trackDistance; //4 15 -10
    public Vector3 TrackDistance => trackDistance;

    void FixedUpdate()
    {
        trackMovement.SmoothMove(trackDistance, Time.fixedDeltaTime, sharpness);
        trackMovement.Rotate();
    }
}

