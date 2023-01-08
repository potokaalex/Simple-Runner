using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;
using System.Linq;

public class CharacterMovement
{
    //public SC velocity; // 100 %

    private Transform transform;

    public CharacterMovement(Character character)
    {
        transform = character.transform;
    }


    public float ForwardVelocity { get; private set; }
    private ChangeableSingle forwardVelocityModifier = new(0);

    public void SetForwardVelocityModifier(float velocity, AnimationCurve curve = null) //кривая описывающая изменение скорости. Null - мнгновенное изменение.
    {
        forwardVelocityModifier.SetValue(velocity, curve);
    }

    public void MoveForward(float velocity, float deltaTime)
    {
        ForwardVelocity = velocity;

        transform.position += (velocity + forwardVelocityModifier.MoveNext(deltaTime)) * deltaTime * Vector3.forward;
    }

    public void SetRotation()
    {

    }
}