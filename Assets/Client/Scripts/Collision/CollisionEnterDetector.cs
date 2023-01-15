namespace Collision
{
    public class CollisionEnterDetector : EcsComponent
    {
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            var collisionEvent = new CollisionEnterEvent
            {
                Sender = gameObject,
                Collision = collision
            };

            //World.TryAddEventEntity(collisionEvent);
        }
    }
}