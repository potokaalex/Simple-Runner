using UnityEngine;

public class CameraMovement : MonoBehaviour // плавное движение за объектом
{
    [SerializeField] private Transform trackingObject;
    [SerializeField] private Vector3 distanceFromObject;

    [SerializeField] private float speed;

    private void Update()
        => Move();

    private void Move()
    {
        var endPosition = trackingObject.position + distanceFromObject;
        var _step = (endPosition - transform.position) * speed * Time.deltaTime;

        transform.Translate(_step);
        transform.LookAt(trackingObject.position);
    }
}
