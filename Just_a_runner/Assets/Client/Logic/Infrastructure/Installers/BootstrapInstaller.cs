using StateMachine;
using System;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGlobalStateMachine();
        BindStateFactory();
        BindSceneLoader();
        BindGameCycle();

        BindBootstrapInitialization();
    }

    private void BindBootstrapInitialization()
    {
        Container
            .Bind<IInitializable>()
            .To<BootstrapInitialization>()
            .AsSingle();
    }

    private void BindGlobalStateMachine()
    {
        Container
            .Bind<GlobalStateMachine>()
            //.To<GlobalStateMachine>()
            .AsSingle();
    }

    private void BindStateFactory()// ?
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

    private void BindGameCycle()
    {
        Container
            .Bind<GameCycle>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
    }
}

public class BootstrapInitialization : IInitializable
{
    private GlobalStateMachine _stateMachine;
    private IStateFactory _stateFactory;

    public BootstrapInitialization(GlobalStateMachine stateMachine, IStateFactory stateFactory)
    {
        _stateFactory = stateFactory;
        _stateMachine = stateMachine;
    }

    public void Initialize()
    {
        StateMachineInitialize();

    }

    private void StateMachineInitialize()
    {
        _stateMachine.Add(_stateFactory.Create<MainMenuState>());
        _stateMachine.Add(_stateFactory.Create<GameLevelLoadingState>());
        //_stateMachine.Add(_stateFactory.Create<GameLevelState>());
        _stateMachine.Add(_stateFactory.Create<PauseState>());
        _stateMachine.Add(_stateFactory.Create<DefeatState>());

        _stateMachine.SwitchTo<MainMenuState>();
    }
}