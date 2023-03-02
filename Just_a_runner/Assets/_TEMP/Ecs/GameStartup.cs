using UnityEngine;
//using Ecs.Systems;
using MovementSystem;
using InputSystem;
//using InputSystem;
//using CollisionSystem;
//using MapGeneration;
using DeathSystem;
using Zenject;
using RoadGeneration;
using System;
using System.Collections.Generic;
using Ecs;

public interface IStateFactory
{
    public StateType Create<StateType>() where StateType : IState;
}

public class StateFactory : IStateFactory
{
    private IInstantiator _instantiator;

    public StateFactory(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }

    public StateType Create<StateType>() where StateType : IState
    {
        return _instantiator.Instantiate<StateType>();
    }
}

public class GlobalStateMachine : IGlobalStateMachine, Zenject.IInitializable//сервис (bind)
{
    private Dictionary<Type, IState> _states = new();
    IStateFactory _factory;
    private IState _currentState;

    public GlobalStateMachine(IStateFactory factory)
    {

        _factory = factory;
    }

    public void Initialize()
    {
        _states.Add(typeof(BootstrapState), _currentState = _factory.Create<BootstrapState>());
        _states.Add(typeof(LoadingState), _factory.Create<LoadingState>());

        //

        _currentState.Enter();
    }

    public void SwitchTo<StateType>() where StateType : IState
    {
        _currentState?.Exit();
        _currentState = _states[typeof(StateType)];
        _currentState.Enter();
    }
}

public interface IGlobalStateMachine : IStateMachine { }


public interface IStateMachine
{
    public void SwitchTo<StateType>() where StateType : IState;
}

public interface IState
{
    public void Enter();

    public void Exit();
}


public class GameStartup : MonoBehaviour //временно управляет updata`ми, в будущем - состояние
{
    public CharacterMarker CharacterMarker;
    public RoadData RoadData;

    private Systems _updateSystems = new();
    private Systems _fixedUpdateSystems = new();

    //[Inject]
    //private void Constructor()
    //{
    //}

    private void Awake()
    {
        _fixedUpdateSystems
            .Add(new EntitiesUpdate())
            .Add(new EventsRemove())

            .Add(new RoadGenerator(CharacterMarker, RoadData))
            .Add(new DeathHandler(CharacterMarker))

            .Add(Movement());

        _updateSystems
            .Add(new InputUpdate());
    }

    private void Update()
    {
        //if (PauseManager.IsPaused)
        //    return;

        _updateSystems.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //if (PauseManager.IsPaused)
        //    return;

        _fixedUpdateSystems.Update(Time.fixedDeltaTime);
    }

    private Systems Movement()
        => new Systems()
        .Add(new MoveRightUpdate())
        .Add(new MoveLeftUpdate())
        .Add(new RunUpdate());
}
