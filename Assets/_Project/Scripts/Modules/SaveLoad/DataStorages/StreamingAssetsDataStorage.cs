using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utils;

namespace SaveLoad.DataStorages
{
    internal class StreamingAssetsDataStorage : IDataStorage
    {
        private bool _isInProgressNow;

        public async UniTask<string> ReadAsync<TData>(string key)
        {
            var path = BuildPath(key);
            if (!File.Exists(path))
            {
                Log.ColorLogDebugOnly($"First save for {key} haven't been yet", ColorType.Orange, LogStyle.Warning);
                return default;
            }

            try
            {
                return await File.ReadAllTextAsync(path);
            }
            catch (Exception e)
            {
                Log.ColorLog(e.ToString(), ColorType.Red, LogStyle.Error);
                return default;
            }
        }

        public async UniTask WriteAsync(string key, string data)
        {
            if(_isInProgressNow) return;
            
            var path = BuildPath(key);
            
            try
            {
                _isInProgressNow = true;
                if (File.Exists(path)) 
                    File.Delete(path);
                
                await File.WriteAllTextAsync(path, data);
                _isInProgressNow = false;
            }
            catch (Exception e)
            {
                _isInProgressNow = false;
                throw new ArgumentException($"Something went wrong : {e}");
            }
        }

        public void Remove(string key)
        {
            var path = BuildPath(key);
            if (!File.Exists(path))
            {
                Log.ColorLogDebugOnly($"First save for {key} haven't been yet", ColorType.Orange, LogStyle.Warning);
                return;
            }
        
            File.Delete(path);
        }
        
        private string BuildPath(string key)
            => Path.Combine(Application.persistentDataPath, key);
    }
}