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

    //public List<float> RunVelocityModifiers = new();

    private Transform transform;

    public CharacterMovement(Character character)
    {
        transform = character.transform;
    }

    //set the speed modifier

    public void Run(float velocity, float deltaTime)
    {
        RunVelocity = velocity;

        //float _modifierValue = 0;
       // if (RunVelocityModifiers != null)
        //    foreach (var modifier in RunVelocityModifiers)
         //       _modifierValue += modifier;

        transform.position += (velocity) * deltaTime * Vector3.forward;
    }

    public void SetRotation()
    {

    }
}

public class Modifier<T>
{
    private float time;

    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }

}