using GlobalStateMachine; // is it necessary namespace? Why isn`t simple StateMachine?
using StateMachine;
using Zenject;

using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("123");
        BindGlobalStateMachine();
        BindStateFactory();
        BindSceneLoader();
    }

    private void BindGlobalStateMachine()
    {
        Container
            .Bind(typeof(IInitializable), typeof(IGlobalStateMachine))
            .To<GlobalStateMachine.GlobalStateMachine>()
            .AsSingle();
    }

    private void BindStateFactory()
    {
        Container
            .Bind<IStateFactory>()
            .To<StateFactory>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<ISceneLoader>()
            .To<SceneLoader>()
            .AsSingle();
    }
}
