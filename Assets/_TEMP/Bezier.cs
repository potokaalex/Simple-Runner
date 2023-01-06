using UnityEngine;

public class Bezier
{
    private const float MIN_CORRELATION = 0f;
    private const float MAX_CORRELATION = 1f;

    //public void ChangeCoefficients()

    //getFunction
    public Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float correlation)
    {
        if (correlation < MIN_CORRELATION)
            correlation = MIN_CORRELATION;
        else if (correlation > MAX_CORRELATION)
            correlation = MAX_CORRELATION;

        var remainingCorrelation = MAX_CORRELATION - correlation;

        var _p0 = remainingCorrelation * remainingCorrelation * remainingCorrelation * p0;
        var _p1 = 3f * remainingCorrelation * remainingCorrelation * correlation * p1;
        var _p2 = 3f * remainingCorrelation * correlation * correlation * p2;
        var _p3 = correlation * correlation * correlation * p3;

        return _p0 + _p1 + _p2 + _p3;
    }

    public Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
}
