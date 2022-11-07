using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    [SerializeField] private Transform trackingTransform;

    public Transform TrackingTransform => trackingTransform; //unsafe

    /// <param name="timeMode">Smoothness coefficient. Use Time.deltaTime if you call this method in Update and Time.fixedDeltaTime, if in FixedUpdate.</param>
    /// <param name="smooth">Smoothness coefficient. Use values from 0 to infinity, but as this parameter increases, the tracking smoothness disappears.</param>
    public void SmoothMove(Vector3 distance,float timeMode, float sharpness)
    {
        var _offset = trackingTransform.position + distance - transform.position;
        var _step = Vector3.Lerp(Vector3.zero, _offset, timeMode * sharpness);

        transform.Translate(_step);
    }

    public void Rotate()
    => transform.Rotate(trackingTransform.rotation.eulerAngles);
}