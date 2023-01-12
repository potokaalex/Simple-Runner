using UnityEngine;

public class CurveReader
{
    private AnimationCurve curve;
    private float previousValue;
    private float value;

    public float LastKeyTime { get; private set; }

    public float Time { get; private set; }

    public CurveReader(AnimationCurve curve)
        => this.curve = curve;

    public float GetValue()
        => value;

    public float GetIncrement()
        => value - previousValue;

    public void Move(float deltaTime)
    {
        previousValue = value;

        Time += deltaTime;

        value = curve.Evaluate(Time);
    }

    public void Reset()
    {
        previousValue = 0;
        value = 0;

        LastKeyTime = curve.keys[curve.keys.Length - 1].time;
        Time = 0;
    }
}