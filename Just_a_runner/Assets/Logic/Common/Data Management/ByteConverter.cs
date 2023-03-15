namespace DataManagement
{
    public static class ByteConverter
    {
        public static byte[] Serialize(int source)
        {
            var result = new byte[4];

            result[0] = (byte)(source >> 24);
            result[1] = (byte)(source >> 16);
            result[2] = (byte)(source >> 8);
            result[3] = (byte)source;

            return result;
        }

        public static void Deserialize(byte[] source, out int result)
        {
            result = 0;

            result |= source[0] << 24;
            result |= source[1] << 16;
            result |= source[2] << 8;
            result |= source[3];
        }
    }
}