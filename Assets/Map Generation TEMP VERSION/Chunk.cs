using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private float lenght;

    [SerializeField] private int type;

    public float Lenght => lenght;

    public float TypeId => type;
}