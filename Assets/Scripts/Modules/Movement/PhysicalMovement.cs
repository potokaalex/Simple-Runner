using UnityEngine;

public class PhysicalMovement
{
    public PhysicalMovement(PhysicalEntity movableObject)
        => MovableObject = movableObject;

    public PhysicalEntity MovableObject;

    public void Move(Vector3 direction, float speed)
        => MovableObject.GetRigidbody().velocity = direction * speed;

    public void Rotate(Vector3 angel, float speed)
        => MovableObject.GetRigidbody().MoveRotation(Quaternion.Euler(angel * speed));
}