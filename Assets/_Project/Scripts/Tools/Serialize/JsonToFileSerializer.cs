using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.Utilities;
using UnityEngine;

namespace _Project.Scripts.Tools.Serialize
{
    public class JsonToFileSerializer : ISerializer
    {
        private readonly Сryptographer _сryptographer;
        
        private bool _isInProgressNow;
        
        public JsonToFileSerializer()
        {
            _сryptographer = new Сryptographer();
        }
        public bool TryDeserialize<TData>(string serializedData, out TData data)
        {
             data = JsonConvert.DeserializeObject<TData>(serializedData);
            return  data != null;
        }

        public bool TrySerialize<TData>(TData data, out string serializedData)
        {
             serializedData = JsonConvert.SerializeObject(data);
             return !serializedData.IsNullOrWhitespace();
        }

        public async UniTaskVoid SaveAsync<TData>(string key, TData data)
        {
            if(_isInProgressNow) return;
            
            var path = BuildPath(key);
            
            try
            {
                _isInProgressNow = true;
                if (File.Exists(path)) 
                    File.Delete(path);
                
                TrySerialize(data, out var serializedData);
                var encryptedData = _сryptographer.DecryptData(serializedData);

                await File.WriteAllBytesAsync(path, encryptedData);
                _isInProgressNow = false;
                
            }
            catch (Exception e)
            {
                _isInProgressNow = false;
                throw new ArgumentException($"Something went wrong : {e}");
            }
        }
        
        public async UniTask<TData> LoadAsync<TData>(string key)
        {
            var path = BuildPath(key);
            if (!File.Exists(path))
            {
                Log.ColorLogDebugOnly($"First save for {key} haven't been yet", ColorType.Orange, LogStyle.Warning);
                return default;
            }

            try
            {
                var jsonData = await _сryptographer.EncryptData(path);
                TryDeserialize<TData>(jsonData, out var data);
                return data;
            }
            catch (Exception e)
            {
                Log.ColorLog(e.ToString(), ColorType.Red, LogStyle.Error);
                return default;
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