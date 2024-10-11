using SaveLoad;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class SaveLoadInstaller : MonoInstaller
    {
        [SerializeField]
        private string _saveKey;

        public override void InstallBindings()
        {
            BindSaveSystem();
            BindGameRepository();
            BindUnitSaveLoader();
            BindResourceSaveLoader();
        }
        
        private void BindSaveSystem()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameRepository()
        {
            Container.Bind<GameDataStorage>()
                .AsSingle()
                .WithArguments(_saveKey)
                .NonLazy();
        }

        private void BindUnitSaveLoader()
        {
            Container.BindInterfacesAndSelfTo<UnitSaveLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindResourceSaveLoader()
        {
            Container.BindInterfacesAndSelfTo<ResourceSaveLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}