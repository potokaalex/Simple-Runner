using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnabledComponentByOnTrigger: MonoBehaviour
{
    public MonoBehaviour Component;
    public bool IsEnabled;

    private void OnTriggerEnter(Collider other)
    {
        Component.enabled = IsEnabled;
    }
}
