using UnityEngine;
using System.IO;
using System;

namespace DataManagement
{
    public class SafeDataStorage : DataStorage
    {
        private const int Salt = -1206528112;

        public override bool Contains(string key)
            =>base.Contains(key.GetHashCode().ToString()) &&
            base.Contains(GetSecondaryKey(key).GetHashCode().ToString());

        public override byte[] Load(string key, byte[] defaultValue)
        {
            if (!Contains(key))
                return defaultValue;

            var saltedData = base.Load(GetSecondaryKey(key).GetHashCode().ToString(), null);
            var keyHash = key.GetHashCode();
            var data = base.Load(keyHash.ToString(), null);

            if (data.Length != saltedData.Length)
                return defaultValue;

            for (var i = 0; i < data.Length; i++)
                if (data[i] != (byte)((saltedData[i] ^ Salt) + keyHash))
                    return defaultValue;

            return data;
        }

        public override void Save(string key, byte[] data)
        {
            var keyHash = key.GetHashCode();

            base.Save(keyHash.ToString(), data);

            for (var i = 0; i < data.Length; i++)
                data[i] = (byte)((data[i] - keyHash) ^ Salt);

            base.Save(GetSecondaryKey(key).GetHashCode().ToString(), data);
        }

        private string GetSecondaryKey(string key)
            => key + Salt;
    }
}
