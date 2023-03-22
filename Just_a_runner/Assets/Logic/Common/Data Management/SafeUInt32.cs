using System;

namespace DataManagement
{
    public struct SafeUInt32 : IEquatable<SafeUInt32>
    {
        private long _value;
        private int _salt;

        public SafeUInt32(uint value)
        {
            _salt = UnityEngine.Random.Range(int.MinValue / 2, int.MaxValue / 3);
            _value = value ^ _salt;
        }

        public static implicit operator uint(SafeUInt32 safe)
            => (uint)(safe._value ^ safe._salt);

        public static uint Deserialize(byte[] data)
        {
            ByteConverter.Deserialize(data, out var result);
            return (uint)result;
        }

        public byte[] Serialize()
            => ByteConverter.Serialize((int)(_value ^ _salt));

        public bool Equals(SafeUInt32 other)
            => other._value == _value && other._salt == _salt;
    }
}
