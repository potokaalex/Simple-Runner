using UnityEngine;
using System;

public class SecondOrderDynamics
{
    private const float PI = (float)Math.PI;

    private Vector3 previousPosition = default;//xp

    private Vector3 position = default;//y

    private Vector3 acceleration = default;//dy

    private float k1, k2, k3;

    public SecondOrderDynamics()
    => ChangeCoefficients(0, 0, 0);

    public SecondOrderDynamics(float frequency, float dampening, float response)
        => ChangeCoefficients(frequency, dampening, response);

    public void ChangeCoefficients(float frequency, float dampening, float response)
    {
        var PiF = PI * frequency;

        k1 = dampening / PiF;
        k2 = 1 / Squaring(2 * PiF);
        k3 = response * dampening / (2 * PiF);
    }

    Vector3 acceleration20;

    // current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed;

    //its simse to been fucking FUNCTION !
    public Vector3 Update(Vector3 target, float deltaTime, Vector3 velocity = default)//Vector3 current, 
    {
        if (velocity == default)
        {
            velocity = (target - previousPosition) / deltaTime;
            previousPosition = target;
        }

        // float k2_stable;

        var _stableK2 = GetMaxValue(k2, deltaTime * deltaTime / 2 + deltaTime * k1 / 2, deltaTime * k1);

        var _step = deltaTime * acceleration;

        position += _step;


        //acceleration20 += deltaTime * (targetPoint + k3 * velocity - position - k1 * acceleration) / k2_stable;

        acceleration += deltaTime * (target + k3 * velocity - position - k1 * acceleration) / _stableK2;

        return position;
    }

    private float Squaring(float value)
        => value * value;

    private float GetMaxValue(float value1, float value2, float value3)
    {
        if (value1 > value2)
            return value1 > value3 ? value1 : value3;
        else
            return value2 > value3 ? value2 : value3;
    }
}

/*
public class SecondOrderDynamics
{
    private const float PI = (float)Math.PI;

    private Vector3 previousPosition;
    private Vector3 acceleration;
    private Vector3 position;
    private float k1, k2, k3;

    public SecondOrderDynamics()
    => ChangeCoefficients(0, 0, 0);

    public SecondOrderDynamics(float frequency, float dampening, float response)
        => ChangeCoefficients(frequency, dampening, response);

    public void ChangeCoefficients(float frequency, float dampening, float response)
    {
        k1 = dampening / (PI * frequency);
        k2 = 1 / Squaring(2 * PI * frequency);
        k3 = response * dampening / (2 * PI * frequency);
    }

    // current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed;

    //its simse to been fucking FUNCTION !
    public Vector3 MoveNext(Vector3 currentPoint, Vector3 targetPoint, float deltaTime, Vector3 velocity = default)
    {
        var _stableK2 = GetMaxValue(k2, Squaring(deltaTime) / 2 + deltaTime * k1 / 2, deltaTime * k1);

        /*
        if (velocity == default)
        {
            velocity = (position - previousPosition) / deltaTime;
            previousPosition = position;
        }
        

        Debug.Log("B " + acceleration);

        position += deltaTime * acceleration;
        acceleration += deltaTime * (targetPoint + k3 * velocity - position - k1 * acceleration) / _stableK2;

        Debug.Log("A " + acceleration);

        Debug.Log("POS " + acceleration);
        return position;
    }

    private float Squaring(float value)
        => value * value;

    private float GetMaxValue(float value1, float value2, float value3)
    {
        if (value1 > value2)
            return value1 > value3 ? value1 : value3;
        else
            return value2 > value3 ? value2 : value3;
    }

    
    public Vector3 MoveNext(Vector3 currentPoint, Vector3 targetPoint, float deltaTime, Vector3 velocity = default)
    {
        var _stableK2 = GetMaxValue(k2, Squaring(deltaTime) / 2 + deltaTime * k1 / 2, deltaTime * k1);

        if (velocity == default)
        {
            velocity = (position - previousPosition) / deltaTime;
            previousPosition = position;
        }

        var this.position = deltaTime * acceleration;
        acceleration += deltaTime * (targetPoint + k3 * velocity - this.position - k1 * acceleration) / _stableK2;

        return this.position;
    }
}
*/