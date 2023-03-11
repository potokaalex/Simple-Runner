using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGameObjectByOnTrigger : MonoBehaviour
{
    public GameObject GameObject;
    public bool IsActive;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.SetActive(IsActive);
    }
}
