using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

public class Jump : EcsComponent
{
    public CurveReader AnimationVelocity;
    public AnimationCurve VelocityCurve;
    //public CollisionDetector Detector;
}
