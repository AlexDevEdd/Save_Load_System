using Cysharp.Threading.Tasks;

namespace SaveLoad
{
    public interface ISaveSystem
    {
        public void Save();
        public void Save<TSystem>();
        public UniTask LoadAsync();
        public UniTask LoadAsync<TSystem>();
        public void RemoveSaves();
    }
}