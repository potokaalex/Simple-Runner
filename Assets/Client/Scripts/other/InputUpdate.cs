using System.Collections.Generic;
using UnityEngine;
using Ecs;

//namespace
public class InputUpdate : IUpdateSystem
{
    private EcsWorld _world = EcsWorld.FindWorld();

    public void Update(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.A))
            _world.AddEvent(new KeyDown(KeyCode.A));

    }
}

public struct KeyDown : IEvent
{
    public KeyCode KeyCode;

    public KeyDown(KeyCode keyCode)
    {
        KeyCode = keyCode;
    }
}