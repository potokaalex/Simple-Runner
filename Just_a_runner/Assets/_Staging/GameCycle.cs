using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public event Action<float> OnFixedTick;
    public event Action<float> OnTick;

    private void FixedUpdate()
    {
        OnFixedTick?.Invoke(Time.fixedDeltaTime);
    }


    private void Update()
        => OnTick?.Invoke(Time.deltaTime);
}