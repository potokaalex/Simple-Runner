using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

public class GameProcess : IFixedUpdateSystem
{
    private bool _isPaused;

    public bool IsPaused => _isPaused;

    public void FixedUpdate(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
