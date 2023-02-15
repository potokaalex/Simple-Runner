using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private const string GameScene = "SampleScene";

    [Inject]
    private void Construct(SceneLoader loader)
    {
        loader.Load(GameScene);
    }
}