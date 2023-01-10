using UnityEngine;
using System.Linq;

public class ChangeableSingle
{
    private AnimationCurve curve;
    private float previousMaxValue;
    private float maxCorrelation;
    private float correlation;
    private float aditional;
    private float value;

    public ChangeableSingle(float velocity, AnimationCurve curve = null)
        => SetValue(velocity, curve);

    public float GetValue()
        => value;

    public void Move(float time)
    {
        value = previousMaxValue + (correlation > maxCorrelation ? aditional : curve.Evaluate(correlation) * aditional);

        correlation += time;
    }

    public void SetValue(float value, AnimationCurve curve = null)
    {
        if (curve == null)
        {
            previousMaxValue = value;
            correlation = float.MaxValue;
            maxCorrelation = 0;
            aditional = 0;

            return;
        }

        previousMaxValue = this.value;
        this.curve = curve;
        maxCorrelation = curve.keys.Max(p => p.time);
        correlation = 0;
        aditional = value - previousMaxValue;
    }
}