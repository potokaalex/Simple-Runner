using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //sl.Load(SceneManager.GetSceneByName(GameScene));

        Container.Bind<SceneLoader>().AsSingle().NonLazy();
    }
}
