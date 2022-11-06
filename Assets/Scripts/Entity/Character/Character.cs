using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class Character : PhysicalEntity // only data and interfaceS for them / 
{
    [SerializeField] private float health;

    public event Action IsKilled;

    private float score;


    public float GetScore() => score;
    public float SetScore(float value) => score = value;

    public float GetHealth() => health;
    public float ChangeHealth(float value) => health += value;

    public bool IsTimeToKill => health > 0 ? false : true;
    public void Kill() => IsKilled?.Invoke();
}
