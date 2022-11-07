using UnityEngine;

public class PhysicalMovement : MonoBehaviour
{
    [SerializeField] private PhysicalEntity movingObject;

    public PhysicalEntity MovingObject => movingObject; //unsafe

    public void Move(Vector3 direction, float speed)
    => movingObject.GetRigidbody().velocity = direction * speed;

    public void Rotate(Vector3 angel, float speed)
        => movingObject.GetRigidbody().MoveRotation(Quaternion.Euler(angel * speed));
}