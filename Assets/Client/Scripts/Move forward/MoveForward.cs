using UnityEngine;

public class MoveForward : EcsComponent
{
    public CurveReader AnimationVelocity;
    public AnimationCurve VelocityCurve;
    public float AdditionalVelocity;
}
