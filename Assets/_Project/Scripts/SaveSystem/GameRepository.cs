using System;
using System.Collections.Generic;
using _Project.Scripts.Tools;
using _Project.Scripts.Tools.Serialize;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _Project.Scripts.SaveSystem
{
    public class GameRepository
    {
        private const string SAVE_KEY = "GAME_REPOSITORY";

        private readonly ISerializer _serializer;
        private Dictionary<string, string> _gameState = new();
        
        [Inject]
        public GameRepository()
        {
            _serializer = new JsonToFileSerializer();
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
            var data = await _serializer.LoadAsync<Dictionary<string, string>>(SAVE_KEY);
            if(data != null)
                _gameState = data;
        }

        public void SaveState()
        {
            _serializer.SaveAsync(SAVE_KEY, _gameState).Forget();
        }

        public void RemoveSaves()
        {
            _serializer.Remove(SAVE_KEY);
            _gameState.Clear();
        }
    }
}