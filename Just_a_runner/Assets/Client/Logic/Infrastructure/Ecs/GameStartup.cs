using UnityEngine;

using MovementSystem;
using InputSystem;

using DeathSystem;
using RoadGeneration;
using Ecs;

public class GameStartup : MonoBehaviour
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
            .Add(Core())

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

    private Systems Core()
        => new Systems()
        .Add(new EntitiesUpdate())
        .Add(new EventsRemove());
}
