using UnityEngine;
using Character;
using Ecs;

namespace MovementSystem
{
    public class CameraTrackingUpdate : IFixedTickable
    {
        private Filter<CharacterMarker> _characters = new();
        private Filter<CameraTracking> _trakings = new();

        public void FixedTick(float deltaTime)
        {
            foreach (var tracking in _trakings.Components)
                foreach (var character in _characters.Components)
                    Tracking(tracking, character);
        }

        public void Tracking(CameraTracking tracking, CharacterMarker character)
        {
            var step = character.transform.position + tracking.Distance - tracking.transform.position;

            if (!tracking.Constraints.IsX)
                tracking.transform.position += Vector3.right * step.x;

            if (!tracking.Constraints.IsY)
                tracking.transform.position += Vector3.up * step.y;

            if (!tracking.Constraints.IsZ)
                tracking.transform.position += Vector3.forward * step.z;
        }
    }
}
