namespace DataManagement
{
    public static class SafeDataStorage
    {
        private const int Salt = -1206528112;

        public static bool Contains(string key)
            => DataStorage.Contains(key.GetHashCode().ToString()) &&
            DataStorage.Contains(GetSecondaryKey(key).GetHashCode().ToString());

        public static byte[] Load(string key, byte[] defaultValue = null)
        {
            if (!Contains(key))
                return defaultValue;

            var saltedData = DataStorage.Load(GetSecondaryKey(key).GetHashCode().ToString());
            var keyHash = key.GetHashCode();
            var data = DataStorage.Load(keyHash.ToString());

            if (data.Length != saltedData.Length)
                return defaultValue;

            for (var i = 0; i < data.Length; i++)
                if (data[i] != (byte)((saltedData[i] ^ Salt) + keyHash))
                    return defaultValue;

            return data;
        }

        public static void Save(string key, byte[] data)
        {
            var keyHash = key.GetHashCode();

            DataStorage.Save(keyHash.ToString(), data);

            for (var i = 0; i < data.Length; i++)
                data[i] = (byte)((data[i] - keyHash) ^ Salt);

            DataStorage.Save(GetSecondaryKey(key).GetHashCode().ToString(), data);
        }

        private static string GetSecondaryKey(string key)
            => key + Salt;
    }
}
