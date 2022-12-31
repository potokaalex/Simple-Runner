using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] new Transform camera;
    [SerializeField] Transform character;
    [SerializeField][Range(0f, 10f)] private float smoothTime;
    [SerializeField][Range(-100f, 100f)] private float distanceToCharacter;
    [SerializeField] private Vector2 relativeRotation;

    private TrackingMovement trackingMovement;

    private void Start()
    {
        trackingMovement = new TrackingMovement(camera, character);
    }

    void FixedUpdate()
    {
        var _distance = Quaternion.Euler(relativeRotation.y, relativeRotation.x, 0) * Vector3.forward * distanceToCharacter;

        trackingMovement.SmoothMove(_distance, smoothTime, float.MaxValue, Time.fixedDeltaTime);
        trackingMovement.LookAtTracked();
    }
}