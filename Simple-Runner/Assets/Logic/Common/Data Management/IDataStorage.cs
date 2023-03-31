namespace DataManagement
{
    public interface IDataStorage
    {
        public bool Contains(string key);

        public byte[] Load(string key, byte[] defaultValue);

        public void Save(string key, byte[] data);
    }
}
