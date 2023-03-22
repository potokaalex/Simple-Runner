using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Ecs;
using Character;

public class Following : EcsComponent
{
    public GameObject Pursued;
    public Vector3 Distance;
}

public class CameraFollowing : IFixedTickable
{
    private Filter<Following> _followings = new();
    private Filter<CharacterMarker> _characters = new();

    public void FixedTick(float deltaTime)
    {
        foreach (var character in _characters.Components)
            foreach (var following in _followings.Components)
                Follow(following, character);
    }

    public void Follow(Following following, CharacterMarker character)
    {
        var different = following.transform.position - (character.transform.position + following.Distance);

        following.transform.position -= Vector3.forward * different.z;
    }
}
