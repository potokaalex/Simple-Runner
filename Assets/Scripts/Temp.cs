using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Temp : MonoBehaviour
{
    Quaternion currentState;
    private void Start()
    {
        //store initial state
        currentState = Quaternion.identity;
    }

    private void Update()
    {
        //draw axes tripod in viewport for demo
        Debug.DrawRay(Vector3.zero, currentState * Vector3.up, Color.green);
        Debug.DrawRay(Vector3.zero, currentState * Vector3.right, Color.red);
        Debug.DrawRay(Vector3.zero, currentState * Vector3.forward, Color.blue);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Rotate things around X"))
        {
            Rotate(Quaternion.Euler(90, 0, 0));
        }
        if (GUILayout.Button("Rotate things around Y"))
        {
            Rotate(Quaternion.Euler(0, 90, 0));
        }
        if (GUILayout.Button("Rotate things around Z"))
        {
            Rotate(Quaternion.Euler(0, 0, 90));
        }

        if (GUILayout.Button("Check State"))
        {
            Vector3 currentUp = currentState * Vector3.up;
            if (Vector3.Dot(currentUp, Vector3.up) > 0.9f)
            {
                Debug.Log("Current State has up pointing up");
            }
            else
            {
                Debug.Log("Current State has up pointing somwhere else");
            }
        }
    }

    void Rotate(Quaternion rotation)
    {
        //apply rotation to array
        //...
        //...

        //Modify tracked state
        currentState = rotation * currentState;
    }
}

