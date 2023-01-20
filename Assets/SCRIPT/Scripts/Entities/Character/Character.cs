using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;
using System.Linq;

public class Character : MonoBehaviour
{
    public Collider Collider;
    public CharacterMovement movement;

    private void Awake()
    {
        movement = new(this);
    }

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

    private void OnDrawGizmos()
    {
        if (movement != null)
            movement.DrawCheckBox();
    }


}