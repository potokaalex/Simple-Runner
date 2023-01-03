using UnityEngine;

public class PhysicalMovement
{
    public PhysicalMovement(PhysicalEntity movableObject)
        => MovableObject = movableObject;

    public PhysicalEntity MovableObject;

    public void MovePosition(Vector3 direction, float speed) // 1m/sec , Update invoke
    {
        var _movableTransform = MovableObject.transform;
        var _direction = direction.normalized;

        //var _step = 

        //_movableTransform.position += ?;
        //MovableObject.GetRigidbody().velocity = direction * speed;
    }

    public void Rotate(Vector3 angel, float speed)
        => MovableObject.transform.rotation = Quaternion.Euler(angel * speed);
    // => MovableObject.GetRigidbody().MoveRotation(Quaternion.Euler(angel * speed));
}