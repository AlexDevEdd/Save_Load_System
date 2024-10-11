using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using SaveLoad.DataStorages;
using SaveLoad.Serializers;
using Utils;
using Zenject;

namespace SaveLoad
{
    [UsedImplicitly]
    public sealed class GameDataStorage
    {
        private readonly string _saveKey;

        private readonly ISerializer _serializer;
        private readonly IDataStorage _dataStorage;
        
        private Dictionary<string, string> _gameState = new();

        public GameDataStorage(string key)
        {
            _saveKey = key;
            _serializer = new NewtonsoftSerializer();
            _dataStorage = new StreamingAssetsDataStorage();
        }
        
        public TData GetData<TData>()
        {
            var keyName = typeof(TData).Name;
            var serializedData = _gameState[keyName];
            
            if (_serializer.TryDeserialize<TData>(serializedData, out var data))
                return data;

            throw new ArgumentException($"Can't Deserialize data type of {keyName}");
        }

        public bool TryGetData<TData>(out TData data)
        {
            var keyName = typeof(TData).Name;
            if (_gameState.TryGetValue(keyName, out var serializedData))
            {
                if (_serializer.TryDeserialize(serializedData, out data))
                    return true;
                
                throw new ArgumentException($"Can't Deserialize data type of {keyName}");
            }
            
            Log.ColorLogDebugOnly($"First save for {keyName} haven't been yet", 
                ColorType.Orange, LogStyle.Warning);
            
            data = default;
            return false;
        }

        public void SetData<TData>(TData data)
        {
            var keyName = typeof(TData).Name;
            if (_serializer.TrySerialize(data, out var serializedData)) 
                _gameState[keyName] = serializedData;
        }

        public async UniTask LoadState()
        {
            var jsonData = await _dataStorage.ReadAsync<Dictionary<string, string>>(_saveKey);
            if(!jsonData.IsNullOrEmpty())
                _serializer.TryDeserialize(jsonData, out _gameState);
        }
        
        public async UniTask LoadState(string key)
        {
            var jsonData = await _dataStorage.ReadAsync<Dictionary<string, string>>(key);
            _serializer.TryDeserialize(jsonData, out _gameState);
        }

        public async UniTaskVoid SaveState()
        {
            if(_serializer.TrySerialize(_gameState, out var data))
            {
               await _dataStorage.WriteAsync(_saveKey, data);
            }
        }
        
        public void SaveState(string key)
        {
            if(_serializer.TrySerialize(_gameState, out var data))
            {
                _dataStorage.WriteAsync(key, data);
            }
        }

        public void RemoveSaves()
        {
            _dataStorage.Remove(_saveKey);
            _gameState.Clear();
        }
        
        public void RemoveSaves(string key)
        {
            _dataStorage.Remove(key);
            _gameState.Clear();
        }
    }
}