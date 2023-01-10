using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CharacterMovementInput : MonoBehaviour
{
    [SerializeField] private Character character;

    [Header("Move")]
    [SerializeField] private float maxRunVelocity;
    [SerializeField] private AnimationCurve runVelocityCurve;

    private ChangeableSingle runVelocity;
    private float previousForwardVelocity;

    private void Start()
    {
        runVelocity = new(maxRunVelocity, runVelocityCurve);
        previousForwardVelocity = maxRunVelocity;
    }

    void FixedUpdate()
    {
        var _deltaTime = Time.fixedDeltaTime;

        if (previousForwardVelocity != maxRunVelocity)
            UpdateForwardVelocity();

        character.movement.Run(runVelocity.GetValue(), _deltaTime);
        runVelocity.Move(_deltaTime);

        //Debug.Log(character.movement.RunVelocity);
    }

    private void UpdateForwardVelocity()
    {
        runVelocity.SetValue(maxRunVelocity, runVelocityCurve);
        previousForwardVelocity = maxRunVelocity;
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