using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private PhysicalMovement characterMover;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            characterMover.Rotate(Vector3.down);
        if (Input.GetKey(KeyCode.D))
            characterMover.Rotate(Vector3.up);

        characterMover.Move(Vector3.forward);
    }
}
