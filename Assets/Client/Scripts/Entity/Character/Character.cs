using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class Character : MonoBehaviour
{
    public CharacterMovement movement;


    //[SerializeField] CharacterMovementInput movement;


    //entityData ?

    [SerializeField] private float health;

    public event Action IsKilled;

    public bool IsTimeToKill
        => KillCondition == null ? health <= 0 : KillCondition.Invoke();

    private Func<bool> KillCondition { get; set; }

    // Im not sure, is this should be here ? 
    private float score;
    public float GetScore() => score;
    public float SetScore(float value) => score = value;
    //


    //public 



    public float GetHealth() => health;
    public float ChangeHealth(float value) => health += value;

    public void ChangeKillCondition(Func<bool> newCondition) => KillCondition = newCondition;
    public void Kill() => IsKilled?.Invoke();
}


public class CharacterMovement
{
    public readonly float velocity;

    private Transform transform;

    public CharacterMovement(Character character)
    {
        transform = character.transform;
    }


    public void SetVelocity(float velocity, AnimationCurve curve = null) //кривая описывающая изменение скорости. Null - мнгновенное изменение.
    {

    }

    public void SetPosition(Vector3 position)
    {
        // transform.position = position;
    }

    public void SetRotation()
    {

    }
}