using UnityEngine;
using System.Linq;

public class PositionMovement
{
    private Transform movable;
    private AnimationCurve velocityCurve;
    private float previousMaxVelocity;
    private float maxCorrelation;
    private float correlation;
    private float maxVelocity;
    private float velocity;

    public PositionMovement(Transform movable)
    {
        this.movable = movable;
    }

    public void SetVelocity(float velocity, AnimationCurve curve = null)
    {
        if (curve == null)
        {
            correlation = float.MaxValue;
            previousMaxVelocity = maxVelocity = velocity;
            return;
        }

        previousMaxVelocity = this.velocity;
        velocityCurve = curve;
        maxCorrelation = curve.keys.Max(p => p.time);
        correlation = 0;
        maxVelocity = velocity;
    }

    public void MovePosition(Vector3 direction, float deltaTime)
    {
        velocity = GetPositionVelocity(deltaTime);
        movable.position += GetPositionStep(direction, velocity, deltaTime);

        //Debug.Log(velocity);
    }

    private Vector3 GetPositionStep(Vector3 direction, float velocity, float deltaTime)
        => velocity * direction.normalized * deltaTime;

    private float GetPositionVelocity(float deltaTime)
    {
        var _additional = maxVelocity - previousMaxVelocity;
        var _step = correlation > maxCorrelation ? _additional : velocityCurve.Evaluate(correlation) * _additional;

        correlation += deltaTime;

        return previousMaxVelocity + _step;
    }
}