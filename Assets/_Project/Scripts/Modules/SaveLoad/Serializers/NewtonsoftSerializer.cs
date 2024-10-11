using Unity.Plastic.Newtonsoft.Json;
using Utils;

namespace SaveLoad.Serializers
{
    internal class NewtonsoftSerializer : ISerializer
    {
        public bool TryDeserialize<TData>(string serializedData, out TData data)
        {
            data = JsonConvert.DeserializeObject<TData>(serializedData);
            return  data != null;
        }
    
        public bool TrySerialize<TData>(TData data, out string serializedData)
        {
            serializedData = JsonConvert.SerializeObject(data);
            return !serializedData.IsNullOrEmpty();
        }
    }
}