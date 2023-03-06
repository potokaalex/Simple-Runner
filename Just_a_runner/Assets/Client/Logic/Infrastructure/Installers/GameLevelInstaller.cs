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
    [SerializeField] private GameLevelSettings _settings;

    public override void InstallBindings()
    {
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
            .FromInstance(settings)
            .AsSingle()
            .NonLazy();
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
    private IGlobalStateMachine _stateMachine;

    private GameLevelSettings _settings;
    DiContainer _container;

    public GameLevelInitializing(IGlobalStateMachine stateMachine, GameLevelSettings levelSettings, DiContainer container)
    {
        _stateMachine = stateMachine;
        _settings = levelSettings;

        _container = container;//.Create<GameLevelState>();
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

        //_container.Instantiate<GameLevelState>();
        //Debug.Log("SwitchTo");
        //Debug.Log(_container.GetDependencyContracts<>());
        _stateMachine.SwitchTo<GameLevelState>();
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