using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;
using System.Linq;
using UnityEngine.TextCore.Text;

public class CharacterMovement
{
    public float RunVelocity { get; private set; }
    public float RunVelocityModifiers;
    public float JumpVelocity { get; private set; }
    public float JumpVelocityModifiers;

    private Transform transform;

    public CharacterMovement(Character character)
    {
        transform = character.transform;
    }

    public void Run(float velocity, float deltaTime)
    {
        RunVelocity = velocity;

        SetPosition(transform.position + (velocity + RunVelocityModifiers) * deltaTime * Vector3.forward);
    }

    public void Jump(Vector3 step)
    {
        SetPosition(transform.position + step);
    }

    public void Slip()
    {

    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }



    public void SetRotation()
    {

    }
}