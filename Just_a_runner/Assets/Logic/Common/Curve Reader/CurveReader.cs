namespace UnityEngine
{
    public class CurveReader
    {
        private AnimationCurve _curve;
        private float _previousValue;
        private float _value;

        public float LastKeyTime { get; private set; }

        public float Time { get; private set; }

        public CurveReader(AnimationCurve curve)
            => _curve = curve;

        public float GetValue()
            => _value;

        public float GetValue(float time)
            => _curve.Evaluate(time);

        public float GetIncrement()
            => _value - _previousValue;

        public void Move(float deltaTime)
        {
            _previousValue = _value;

            Time += deltaTime;

            _value = _curve.Evaluate(Time);
        }

        public void Reset()
        {
            _previousValue = 0;
            _value = 0;

            LastKeyTime = _curve.keys[_curve.keys.Length - 1].time;
            Time = 0;
        }
    }
}
