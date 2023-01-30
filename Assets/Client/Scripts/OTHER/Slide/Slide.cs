using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;
using Slider;

public class Slide : EcsComponent //Slide(r)
{
    public LayerMask IgnoreMask;

    private ContactPoint _collision;

    //public StayCollisionDetector _stayDetector;
    //public Transform BOX;

    private List<Vector3> _normals = new();

    private Vector3 _normal;

    private List<Collision> _collisions = new();

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, _normal, Color.cyan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryAddNormal(collision);
        RecalculateAverageNormal();
    }

    private void OnCollisionExit(Collision collision)
    {
        TryRemoveNormal(collision);
        RecalculateAverageNormal();
    }

    private void TryAddNormal(Collision normal)
    {
        if (_collisions.Contains(normal))
            return;

        _collisions.Add(normal);
    }

    private void TryRemoveNormal(Collision normal)
    {
        _collisions.Remove(normal);
    }

    private void RecalculateAverageNormal()
    {
        var count = _collisions.Count;

        if (count < 1)
            return;

        _normal = Vector3.zero;

        foreach (var n in _collisions)
            _normal += n.contacts[0].normal;

        _normal /= count;
    }
}

public class SliderUpdateSystem : IFixedUpdateSystem
{
    //EventFilter<EnterCollisionEvent> _enterCollisionEvents = new();
    //EventFilter<ExitCollisionEvent> _exitCollisionEvents = new();

    //ComponentFilter<Slider.Slider> _slider = new();

    //private EcsWorld _world = EcsWorld.FindWorld();

    public void FixedUpdate(float deltaTime)
    {
        var enterCollisionEvents = new List<EnterCollisionEvent>();// _world.GetEventsByType<EnterCollisionEvent>();

        //Debug.Log("Event loading:");
        //Debug.Log($"EnterCollisionEventsCount : {enterCollisionEvents.Count()}");

        foreach (var enterEvent in enterCollisionEvents)
        {
            //Debug.Log("Enter event");

            enterEvent.Sender.TryGetComponent(out Slider.Slider sliderComponent);

           //Debug.Log(sliderComponent);

            if (enterEvent.Contact.contacts.Length < 1)
                continue;

            sliderComponent.TryAddContactPoint(enterEvent.Contact.contacts[0]);
            sliderComponent.RecalculateAverageNormal();

            //Debug.Log($"Enter-object name: {enterEvent.Contact.collider.name}");
        }

        var exitCollisionEvents = new List<ExitCollisionEvent>();
        foreach (var exitEvent in exitCollisionEvents)
        {
            //Debug.Log("Exit event");

            exitEvent.Sender.TryGetComponent(out Slider.Slider sliderComponent);

            //if (exitEvent.Contact.collider == null)
            //    continue;

            //if (sliderComponent == null)
            //    continue;

            // if (exitEvent.Contact == null)
            //    continue;

            sliderComponent.TryRemoveContactPoint(exitEvent.Contact.collider);
            sliderComponent.RecalculateAverageNormal();

            //Debug.Log($"Exit-object name: {exitEvent.Contact.collider.name}");
        }
    }
}





//Movement ?
//{
//MoveForward ?
//ChangeRoad ? 
//}

//positions update
//Move()