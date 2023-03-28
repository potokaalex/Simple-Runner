using UnityEngine;
using Ecs;

namespace MovementSystem
{
    public class CameraTracking : EcsComponent
    {
        public Vector3 Distance;
        public AxisConstraints Constraints;
    }
}
