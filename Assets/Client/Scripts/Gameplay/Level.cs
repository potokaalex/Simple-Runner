using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapGeneration;
using Singleton;

public class Level : MonoBehaviour
{
    public static Level Instance => Singleton<Level>.TryGetInstance();

    public Transform Character;
    public Map Map;
}
