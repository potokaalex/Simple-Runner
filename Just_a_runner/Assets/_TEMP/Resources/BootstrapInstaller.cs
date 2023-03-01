using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Ecs;

public class BootstrapInstaller : MonoInstaller, Zenject.IInitializable
{
    public override void InstallBindings()
    {
        BindSceneLoader();

        BindGlobalStateMachine();

        BindStateFactory();

        BindGlobalStates();

        Container.BindInterfacesTo<GlobalStatesInitializer>().AsSingle();
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
            .Bind<IGlobalStateMachine>()
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
        //  .Bind<BootstrapState>()
    }

    public void Initialize()
    {
        Container.Resolve<IGlobalStateMachine>();
    }
}

public class GlobalStatesInitializer : Zenject.IInitializable
{
    private IStateFactory _stateFactory;
    private GlobalStateMachine _stateMachine;

    public GlobalStatesInitializer(IStateFactory stateFactory, GlobalStateMachine stateMachine)
    {
        _stateFactory = stateFactory;
        _stateMachine = stateMachine;
    }

    public void Initialize()//кидаем в 1-е состояние
    {
        Debug.Log("Initialize");

        _stateFactory.Create<BootstrapState>();

        //ets
        _stateMachine.SwitchTo<BootstrapState>();
    }
}
