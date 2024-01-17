using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Tools.Serialize
{
    public interface ISerializer
    {
        public bool TryDeserialize<TData>(string serializedData, out TData data);
        public bool TrySerialize<TData>(TData data, out string serializedData);
        public UniTaskVoid SaveAsync<TData>(string key, TData data);
        public  UniTask<TData> LoadAsync<TData>(string key);
        public void Remove(string key);
    }
}