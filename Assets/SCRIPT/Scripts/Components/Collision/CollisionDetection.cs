using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public event CollisionVoidDelegate IsCollisionEnter;
    public event CollisionVoidDelegate IsCollisionExit;

    private void OnCollisionEnter(UnityEngine.Collision collision)
        => IsCollisionEnter?.Invoke(collision);

    private void OnCollisionExit(UnityEngine.Collision collision)
       => IsCollisionExit?.Invoke(collision);
}