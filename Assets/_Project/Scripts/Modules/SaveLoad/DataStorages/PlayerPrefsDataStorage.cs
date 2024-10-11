using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SaveLoad.DataStorages
{
    internal sealed class PlayerPrefsDataStorage : IDataStorage
    {
        public UniTask<string> ReadAsync<TData>(string key)
        {
            var data = PlayerPrefs.GetString(key, string.Empty);
            return UniTask.FromResult(data);
        }

        public UniTask WriteAsync(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
            PlayerPrefs.Save();

            return UniTask.CompletedTask;
        }

        public void Remove(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}