using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class Character : PhysicalEntity // only data and interfaceS for them //
{
    [SerializeField] private float health;

    public event Action IsKilled;

    public bool IsTimeToKill => KillCondition.Invoke();

    private Func<bool> KillCondition
    {
        get => KillCondition == null ? () => health <= 0 : KillCondition;
        set { }
    }

    // Im not sure, is this should be here ? 
    private float score;
    public float GetScore() => score;
    public float SetScore(float value) => score = value;
    //

    public float GetHealth() => health;
    public float ChangeHealth(float value) => health += value;

    public void ChangeKillCondition(Func<bool> newCondition) => KillCondition = newCondition;
    public void Kill() => IsKilled?.Invoke();
}