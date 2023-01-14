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
    private Character character;

    public CharacterMovement(Character character)
    {
        transform = character.transform;
        this.character = character;
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

    private bool RaycastDown()
    {
        //out RaycastHit hit
        //var ray = new Ray(transform.position, Vector3.down);

        //Physics.Raycast(ray,);
        return false;
    }

    static float s = 0.0001f;
    Vector3 cubeCenter = Vector3.zero;
    Vector3 cubeSize = new(0.2f - s, 0f, 0.2f - s);

    public bool IsTimeToJump()
    {
        var _mask = LayerMask.GetMask("Default"); //character.gameObject.GetLa

        cubeCenter = transform.position + Vector3.down * (0.2f + s);

        var _result = Physics.CheckBox(cubeCenter, cubeSize, Quaternion.identity, _mask);

        Debug.Log(_result);

        return _result;
    }

    public void DrawCheckBox()
    {
        var _previousColor = Gizmos.color;

        Gizmos.color = Color.red;
        Gizmos.DrawCube(cubeCenter, cubeSize * 2);
        Gizmos.color = _previousColor;
    }

    public void SetRotation()
    {

    }
}