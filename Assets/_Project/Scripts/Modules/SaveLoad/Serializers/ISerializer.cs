namespace SaveLoad.Serializers
{
    public interface ISerializer
    {
        public bool TryDeserialize<TData>(string serializedData, out TData data);
        public bool TrySerialize<TData>(TData data, out string serializedData);
    }
}