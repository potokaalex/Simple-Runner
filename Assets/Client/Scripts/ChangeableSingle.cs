using UnityEngine;
using System.Linq;

public class ChangeableSingle
{
    private AnimationCurve curve;
    private float maxCorrelation;
    private float correlation;
    private float aditional;
    private float value;

    public ChangeableSingle(float velocity, AnimationCurve curve = null)
    {
        SetValue(velocity, curve);
    }

    public float MoveNext(float deltaTime) //deltaTime this is Time step
    {
        var _step = correlation > maxCorrelation ? aditional : curve.Evaluate(correlation) * aditional;

        correlation += deltaTime;

        return value += _step;
    }

    public void SetValue(float velocity, AnimationCurve curve = null)
    {
        if (curve == null)
        {
            correlation = float.MaxValue;
            aditional = 0;
            return;
        }

        this.curve = curve;
        maxCorrelation = curve.keys.Max(p => p.time);
        correlation = 0;
        aditional = velocity - value;
    }
}