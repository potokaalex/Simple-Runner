using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
    [SerializeField] private CollisionDetection collisionDetection;
    [SerializeField] private Character character;

    private void Awake()
    => collisionDetection.IsCollisionEnter += Collide;

    private void OnDisable()
    => collisionDetection.IsCollisionEnter -= Collide;

    private void Collide(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollidingWith<Character> collided))
            collided.Collide(character);
    }
}