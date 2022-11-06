using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier: MonoBehaviour, ICollidingWith<Character>
{
    [SerializeField] private float value;

    public void Collide(Character character)
        => ChangeHealth(character);

    private void ChangeHealth(Character character)
    {
        character.ChangeHealth(value);

        if (character.IsTimeToKill)
            character.Kill();
    }
}
