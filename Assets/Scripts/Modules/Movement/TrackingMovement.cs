using UnityEngine;
using UnityEngine.UIElements;

public class TrackingMovement
{
    public Transform Movable;
    public Transform Tracked;

    private Vector3 velocity;

    public TrackingMovement(Transform movable, Transform tracked)
    {
        Movable = movable;
        Tracked = tracked;
    }

    /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
    public void SmoothMove(Vector3 distance, float smoothTime, float maxSpeed, float deltaTime)
    {
        var _step = Tracked.position + distance - Movable.position;
        Movable.position += Vector3.SmoothDamp(Vector3.zero, _step, ref velocity, smoothTime, maxSpeed, deltaTime);
    }

    public void SmoothMove(Vector3 distance, float smoothTime)
    => SmoothMove(distance, smoothTime, float.MaxValue, Time.deltaTime);

    public void LookAtTracked()
        => Movable.LookAt(Tracked);
}