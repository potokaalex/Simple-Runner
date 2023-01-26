using System.Collections.Generic;
using UnityEngine;
using Ecs;

//namespace ComponentUpdate
//{
public class EventUpdate : IFixedUpdateSystem
{
    private EcsWorld _world = EcsWorld.FindWorld();

    public void FixedUpdate(float deltaTime)
    {
        //Debug.Log("Event UPDATE");

        _world.UpdateEvents();

    }
}
//}
