using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CharacterMovementInput : MonoBehaviour
{
    [SerializeField] private Character character;

    [Header("Move")]
    [SerializeField] private AnimationCurve runVelocity;
    [SerializeField] private AnimationCurve jumpVelocity;
    [SerializeField] private AnimationCurve changeRoadVelocity;

    private CurveReader run;
    private CurveReader jump;
    private CurveReader changeRoad;
    private Vector3 changeRoadDirection;

    private void Start()
    {
        run = new(runVelocity);
        jump = new(jumpVelocity);
        changeRoad = new(changeRoadVelocity);

        jump.Move(float.MaxValue);
        changeRoad.Move(float.MaxValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ChangeRoad(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangeRoad(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.W))
            Jump();
        else if (Input.GetKeyDown(KeyCode.S))
            Slip();
    }

    private void FixedUpdate()
    {
        var _deltaTime = Time.fixedDeltaTime;

        RunUpdate(_deltaTime);
        JumpUpdate(_deltaTime);
        ChangeRoadUpdate(_deltaTime);
    }

    private void RunUpdate(float deltaTime)
    {
        character.movement.Run(run.GetValue(), deltaTime);

        run.Move(deltaTime);
    }

    private void JumpUpdate(float deltaTime)
    {
        character.movement.Jump(Vector3.up * jump.GetIncrement());

        jump.Move(deltaTime);
    }

    private void ChangeRoadUpdate(float deltaTime)
    {
        character.movement.Jump(changeRoadDirection * changeRoad.GetIncrement());

        changeRoad.Move(deltaTime);
    }

    private void ChangeRoad(Vector3 direction)
    {
        if (changeRoad.Time <= changeRoad.LastKeyTime)
            return;

        changeRoadDirection = direction;

        changeRoad.Reset();
    }

    private void Jump()
    {
        if (jump.Time <= jump.LastKeyTime)
            return;

        jump.Reset();
    }

    public void Slip()
    {

    }
}

/*
    // relic
    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
    //
*/