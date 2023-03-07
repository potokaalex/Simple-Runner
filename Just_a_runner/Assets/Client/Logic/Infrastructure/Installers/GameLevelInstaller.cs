using StateMachine;
using Zenject;
using Ecs;
using UnityEngine;

using MovementSystem;
using InputSystem;

using DeathSystem;
using RoadGeneration;

//убрать вездесущее GAME !
public class GameLevelInstaller : MonoInstaller
{
    [SerializeField] private GameLevelSettings _settings = new();

    public override void InstallBindings()
    {
        BindStateFactory();
        BindGameLevelInitializing();
        BindGameLevelSettings(_settings);
    }

    private void BindGameLevelInitializing()
    {
        Container
            .Bind<IInitializable>()
            .To<GameLevelInitializing>()
            .AsSingle();
    }

    private void BindGameLevelSettings(GameLevelSettings settings)
    {
        Container
            .Bind<GameLevelSettings>()
            .FromInstance(settings);
        //  .AsSingle();
    }

    private void BindStateFactory()// ?
    {
        Container
            .Bind<IStateFactory>()
            .To<StateFactory>()
            .AsSingle();
    }
}

[System.Serializable]
public class GameLevelSettings
{
    public CharacterMarker CharacterMarker;
    public RoadData RoadData;

    public Systems FixedTickableSystems = new();
    public Systems TickableSystems = new();
}

public class GameLevelInitializing : Zenject.IInitializable
// Составляет списки систем
// Красиво перекидывает состояние игры.

{
    private GlobalStateMachine _stateMachine;

    private GameLevelSettings _settings;
    private IStateFactory _factory;
    DiContainer _container;

    public GameLevelInitializing(GlobalStateMachine stateMachine, GameLevelSettings levelSettings, IStateFactory factory)
    {
        _stateMachine = stateMachine;
        _settings = levelSettings;

        _factory = factory;
        //_container = container;//.Create<GameLevelState>();
    }

    public void Initialize()
    {
        _settings.FixedTickableSystems
            .Add(Core())

            .Add(new RoadGenerator(_settings.CharacterMarker, _settings.RoadData))
            .Add(new DeathHandler(_settings.CharacterMarker))

            .Add(Movement());

        _settings.TickableSystems
            .Add(new InputUpdate());

        _stateMachine.Add(_factory.Create<GameLevelState>());
        _stateMachine.SwitchTo<GameLevelState>();

        //_container.Instantiate<GameLevelState>();
        //Debug.Log("SwitchTo");
        //Debug.Log(_container.GetDependencyContracts<>());
    }


    private Systems Movement()
        => new Systems()
        .Add(new MoveRightUpdate())
        .Add(new MoveLeftUpdate())
        .Add(new RunUpdate());

    private Systems Core()
        => new Systems()
        .Add(new EntitiesUpdate())
        .Add(new EventsRemove());
}