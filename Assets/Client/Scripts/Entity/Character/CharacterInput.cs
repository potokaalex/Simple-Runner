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
    [SerializeField][Range(-100f, 100f)] private float rotateSpeed;

    private void Awake()
    {
        physicalMovement = new PhysicalMovement(character);
    }

    void Update()
    {
        var _direction = character.transform.rotation * Vector3.forward;

        if (Input.GetKeyDown(KeyCode.A))
            physicalMovement.Rotate(Vector3.down, rotateSpeed);
        if (Input.GetKeyDown(KeyCode.D))
            physicalMovement.Rotate(Vector3.up, rotateSpeed);

        physicalMovement.MovePosition(_direction, directionSpeed);

        //ToNorm();
    }

    public float T = 0.6f;

    private void ToNorm()
    {
        //Debug.Log();
        var _step = Vector3.zero - transform.rotation.eulerAngles;

        var _board = transform.rotation.eulerAngles.y < 180 ? Vector3.zero : Vector3.up * 180;
        //Quaternion

        Debug.Log(transform.localEulerAngles);

        transform.Rotate(Vector3.Lerp(_board, _step, T)); //= Quaternion.Euler();
    }

    // relic
    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
    //
}