using UnityEngine;
using Ecs;

namespace UnityTemplateProjects
{
    public class CameraMovement : MonoBehaviour // скрипт слежения за объектом ?
    {
        [SerializeField] private CharacterMarker _character;
        [SerializeField] private Vector3 _distance;

        private void Start()
        {
            _distance = transform.position - _character.transform.position;
        }

        private void Update()
        {
            if (_character == null)
                return;

            transform.position = new Vector3(
                _character.transform.position.x + _distance.x,
                transform.position.y,
                _character.transform.position.z + _distance.z);
        }
    }
}