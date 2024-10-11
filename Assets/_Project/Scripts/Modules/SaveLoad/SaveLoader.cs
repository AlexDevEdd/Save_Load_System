namespace SaveLoad
{
    public abstract class SaveLoader<TData, TSystem> : ISaveLoader
    {
        private readonly GameDataStorage _dataStorage;
        private readonly TSystem _system;
        
        protected SaveLoader(GameDataStorage dataStorage, TSystem system)
        {
            _dataStorage = dataStorage;
            _system = system;
        }
        
        public void SaveData()
        {
            var data = ConvertToData(_system);
            _dataStorage.SetData(data);
        }

        public void LoadData()
        {
            if (_dataStorage.TryGetData(out TData data)) 
                 SetUpData(data, _system);
        }

        protected abstract TData ConvertToData(TSystem audioSystem);
        protected abstract void SetUpData(TData data, TSystem audioSystem);

        protected virtual void SetUpDefaultData(TSystem system) { }
    }
}