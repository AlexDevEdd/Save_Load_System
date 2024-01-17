using System.Collections.Generic;
using Zenject;

namespace _Project.Scripts.SaveSystem
{
    public sealed class SaveLoadSystem : ISaveSystem, IInitializable
    {
        private readonly GameRepository _repository;
        private readonly IEnumerable<ISaveLoader> _loaders;

        [Inject]
        public SaveLoadSystem(GameRepository repository, IEnumerable<ISaveLoader> loaders)
        {
            _repository = repository;
            _loaders = loaders;
        }
        
        public void Initialize()
        {
            Load();
        }

        public void Save()
        {
            foreach (var loader in _loaders) 
                loader.SaveGame();
            
            _repository.SaveState();
        }

        public async void Load()
        {
           await _repository.LoadState();
           
           foreach (var loader in _loaders) 
               loader.LoadGame();
        }
        
        public void RemoveSaves()
        {
            _repository.RemoveSaves();
        }
    }
}