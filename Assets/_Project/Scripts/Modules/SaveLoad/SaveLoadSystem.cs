using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace SaveLoad
{
    [UsedImplicitly]
    public sealed class SaveLoadSystem : ISaveSystem, IInitializable, IDisposable
    {
        private readonly GameDataStorage _dataStorage;
        private readonly IEnumerable<ISaveLoader> _loaders;

        public SaveLoadSystem(GameDataStorage dataStorage, IEnumerable<ISaveLoader> loaders)
        {
            _dataStorage = dataStorage;
            _loaders = loaders;
        }

        async void IInitializable.Initialize()
        {
            await _dataStorage.LoadState();
            LoadAsync().Forget();
        }

        public void Save()
        {
            foreach (var loader in _loaders) 
                loader?.SaveData();
            
            _dataStorage.SaveState().Forget();
        }
        
        public void Save<TSystem>()
        {
            var loader = _loaders.FirstOrDefault(l => l is TSystem);
            loader?.SaveData();
            
            _dataStorage.SaveState().Forget();
        }
        
        public async UniTask LoadAsync()
        {
            foreach (var loader in _loaders)
                loader?.LoadData();

            await UniTask.CompletedTask;
        }
        
        public async UniTask LoadAsync<TSystem>()
        {
            var loader = _loaders.FirstOrDefault(l => l is TSystem);
            loader?.LoadData();
            await UniTask.CompletedTask;
        }

        public void RemoveSaves()
        {
            _dataStorage.RemoveSaves();
        }

        public void Dispose()
        {
            Save();
        }
    }
}