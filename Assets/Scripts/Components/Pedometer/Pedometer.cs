using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedometer : MonoBehaviour
{
    [SerializeField] private Vector3 satrtPosition;
    [SerializeField] private Character character;

    private void FixedUpdate()
    {
        character.SetScore(character.transform.position.z - satrtPosition.z);
    }
}
