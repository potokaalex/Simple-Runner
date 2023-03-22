using System;

namespace Infrastructure
{
    public interface IGameLoop
    {
        public event Action<float> OnFixedTick;
        public event Action<float> OnTick;
    }
}
