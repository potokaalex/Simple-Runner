using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private PhysicalMovement physicalMovement;
    [SerializeField] private Character character;

    [Header("Move")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField][Range(-100f, 100f)] private float directionSpeed;

    [Header("Rotate")]
    [SerializeField] private Vector3 rotateAngle;
    [SerializeField][Range(-100f, 100f)] private float rotateSpeed;

    public Vector3 MovementDirection => movementDirection;
    public float DirectionSpeed => directionSpeed;
    public Vector3 RotateAngle => rotateAngle;
    public float RotateSpeed => rotateSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            physicalMovement.Rotate(Vector3.down, rotateSpeed);
        if (Input.GetKey(KeyCode.D))
            physicalMovement.Rotate(Vector3.up, rotateSpeed);

        physicalMovement.Move(Vector3.forward, directionSpeed);
    }


    // relic
    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
    //
}
