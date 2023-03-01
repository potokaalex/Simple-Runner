using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private BootstrapState.Settings _bootstrapState;

    public override void InstallBindings()
    {
        BindSceneLoader();
        BindStateFactory();
        BindGlobalStateMachine();

        BindBootstrapStateSettings();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<SceneLoader>()
            .AsSingle();
    }

    private void BindStateFactory()
    {
        Container
            .Bind<IStateFactory>()
            .To<StateFactory>()
            .AsSingle();
    }

    private void BindGlobalStateMachine()
    {
        Container
            .Bind(typeof(IInitializable), typeof(IGlobalStateMachine))
            .To<GlobalStateMachine>()
            .AsSingle();
    }

    private void BindBootstrapStateSettings()
    {
        Container
            .Bind<BootstrapState.Settings>()
            .FromInstance(_bootstrapState)
            .AsSingle();
    }
}
