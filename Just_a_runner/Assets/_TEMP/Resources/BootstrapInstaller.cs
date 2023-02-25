using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<SceneLoader>()
            .FromInstance(new SceneLoader())
            .AsSingle();
    }
}
