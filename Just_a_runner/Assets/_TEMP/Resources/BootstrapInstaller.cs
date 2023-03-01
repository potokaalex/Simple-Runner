using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
//using Ecs;
using System.Linq;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log(Container.AllContracts.Count());
        BindSceneLoader();
        Debug.Log(Container.AllContracts.Count());

        BindGlobalStateMachine();

        BindStateFactory();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<SceneLoader>()
            .FromInstance(new SceneLoader())
            .AsSingle();
    }

    private void BindGlobalStateMachine()
    {
        Container
            .Bind(typeof(IInitializable), typeof(IGlobalStateMachine))
            .To<GlobalStateMachine>()
            .AsSingle();
    }

    private void BindStateFactory()
    {
        Container
            .Bind<IStateFactory>()
            .To<StateFactory>()
            .AsSingle();
    }

    private void BindGlobalStates()
    {
        //Container
        //  .Bind<BootstrapState>().AsSingle();
    }
}
