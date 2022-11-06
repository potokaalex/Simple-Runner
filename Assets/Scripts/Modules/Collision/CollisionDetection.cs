using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public event CollisionVoidDelegate IsCollisionEnter;
    public event CollisionVoidDelegate IsCollisionExit;

    private void OnCollisionEnter(Collision collision)
        => IsCollisionEnter?.Invoke(collision);

    private void OnCollisionExit(Collision collision)
       => IsCollisionExit?.Invoke(collision);
}