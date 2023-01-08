using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovementInput : MonoBehaviour
{
    [SerializeField] private Character character;

    [Header("Move")]
    [SerializeField] private Vector3 direction;
    [SerializeField] private AnimationCurve velocityCurve;
    [SerializeField] private float velocity;
    //private Movement movement;

    [Header("Rotate")]
    [SerializeField][Range(-100f, 100f)] private float rotateSpeed;

    private ChangeableSingle forwardVelocity;

    private void Start()
    {
        forwardVelocity = new(velocity, velocityCurve);
    }

    void FixedUpdate()
    {
        MoveForward(Time.fixedDeltaTime);

        Debug.Log(character.movement.ForwardVelocity);
    }

    private void MoveForward(float deltaTime)
    {
        character.movement.MoveForward(forwardVelocity.MoveNext(deltaTime), deltaTime);
    }


    // relic
    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
    //
}


