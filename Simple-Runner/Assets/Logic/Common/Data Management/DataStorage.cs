using UnityEngine;
using System.IO;

namespace DataManagement
{
    public class DataStorage : IDataStorage
    {
        private const string Extension = ".dat";
        private readonly string StoragePath
            = $"{Application.persistentDataPath}/DataStorage";

        public DataStorage()
        {
            if (!Directory.Exists(StoragePath))
                Directory.CreateDirectory(StoragePath);
        }

        public virtual bool Contains(string fileName)
            => File.Exists(GetFilePath(fileName));

        public virtual byte[] Load(string fileName, byte[] defaultValue)
            => File.Exists(GetFilePath(fileName)) ? File.ReadAllBytes(GetFilePath(fileName)) : defaultValue;

        public virtual void Save(string fileName, byte[] data)
        {
            PlayerPrefs.Save();

            using FileStream stream = new(GetFilePath(fileName), FileMode.Create);
            stream.Write(data);
        }

        private string GetFilePath(string fileName)
            => $"{StoragePath}/{fileName + Extension}";
    }
}
