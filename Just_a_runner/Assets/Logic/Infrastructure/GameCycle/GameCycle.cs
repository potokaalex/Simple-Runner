using UnityEngine;
using System;

namespace Infrastructure
{
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
}