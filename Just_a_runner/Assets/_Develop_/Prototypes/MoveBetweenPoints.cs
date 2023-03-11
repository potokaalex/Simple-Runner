using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementSystem;

public class MoveBetweenPoints : MonoBehaviour
{
    public List<Transform> Points;
    public float Speed;

    private float _time;
    private int _currentPointIndex;

    private void FixedUpdate()
    {
        UpdatePosition(Time.fixedDeltaTime);
    }

    private void UpdatePosition(float deltaTime)
    {
        transform.position = Vector3.Lerp
            (transform.position, Points[_currentPointIndex].position, _time += deltaTime * Speed);

        if (transform.position == Points[_currentPointIndex].position)
        {
            _currentPointIndex++;
            _time = 0;
        }

        if (_currentPointIndex >= Points.Count)
            _currentPointIndex = 0;
    }
}
