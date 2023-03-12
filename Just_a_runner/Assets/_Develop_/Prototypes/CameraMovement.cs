using UnityEngine;
using Ecs;

namespace UnityTemplateProjects
{
    public class CameraMovement : MonoBehaviour // скрипт слежения за объектом ?
    {
        [SerializeField] private CharacterMarker _character;
        [SerializeField] private Vector3 _distance;
        public bool IsXConstraint;
        public bool IsYConstraint;
        public bool IsZConstraint;

        private void Start()
        {
            _distance = transform.position - _character.transform.position;
        }

        private void Update()
        {
            if (_character == null)
                return;

            var different = transform.position - (_character.transform.position + _distance);

            if (!IsXConstraint)
                transform.position -= Vector3.right * different.x;

            if (!IsYConstraint)
                transform.position -= Vector3.up * different.y;

            if (!IsZConstraint)
                transform.position -= Vector3.forward * different.z;
        }
    }
}