using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private Character character;

    [Header("Move")]
    [SerializeField] private Vector3 direction;
    [SerializeField] private AnimationCurve velocityCurve;
    [SerializeField] private float velocity;
    private Movement movement;

    [Header("Rotate")]
    [SerializeField][Range(-100f, 100f)] private float rotateSpeed;

    private void Awake()
    {
        movement = new(character.transform);
    }

    void FixedUpdate()
    {
        movement.SetVelocity(velocity);
        movement.MovePosition(direction, Time.fixedDeltaTime);
    }


    // relic
    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
    //
}