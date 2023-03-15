using UnityEngine;
using System.IO;

namespace DataManagement
{
    public static class DataStorage
    {
        private const string Extension = ".dat";
        private static readonly string StoragePath;

        static DataStorage()
        {
            StoragePath = $"{Application.persistentDataPath}/DataStorage";

            if (!Directory.Exists(StoragePath))
                Directory.CreateDirectory(StoragePath);
        }

        public static bool Contains(string fileName)
            => File.Exists(GetFilePath(fileName));

        public static byte[] Load(string fileName)
            => Contains(fileName) ? File.ReadAllBytes(GetFilePath(fileName)) : null;

        public static void Save(string fileName, byte[] data)
        {
            using FileStream stream = new(GetFilePath(fileName), FileMode.Create);
            stream.Write(data);
        }

        private static string GetFilePath(string fileName)
            => $"{StoragePath}/{fileName + Extension}";
    }
}