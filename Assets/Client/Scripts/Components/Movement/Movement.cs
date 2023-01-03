using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CustomInspectorGraph;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour, IFunction
{
    public SecondOrderDynamics secondOrderDynamics = new();
    public SecondOrderDynamics graphSOD = new();

    [Range(-1f, 15f)] public float f = 1f;
    [Range(-1f, 5f)] public float d = 1f;
    [Range(-3f, 5f)] public float r = 0;
    //public Vector3 XVector;

    public Transform X;
    //public Vector3 speed;
    //public bool isInfinintySpeed;

    [SerializeField] private float heightShift;
    [SerializeField] private Graph graph;

    private void Awake()
    {
        secondOrderDynamics.ChangeCoefficients(f, d, r);
    }
    private void Update()
    {
        secondOrderDynamics.ChangeCoefficients(f, d, r);
        transform.position = secondOrderDynamics.Update(X.position, Time.deltaTime);
    }


    public float GetFunctionValue(float argument)
    {
        var _deltaTime = 1f / graph.DisplayData.GraphAccuracy;

        if (argument == 0)
            graphSOD = new();

        graphSOD.ChangeCoefficients(f, d, r);

        return graphSOD.Update(Vector3.one, _deltaTime).y + heightShift;
    }
}