using StateMachine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGlobalStateMachine();
        BindStateFactory();
        BindSceneLoader();
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

    private void BindSceneLoader()
    {
        Container
            .Bind<ISceneLoader>()
            .To<SceneLoader>()
            .AsSingle();
    }
}