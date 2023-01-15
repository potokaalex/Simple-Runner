using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : EcsComponent
{
    public CurveReader AnimationVelocity;
    public AnimationCurve VelocityCurve;
    public Transform CheckBox;
}
