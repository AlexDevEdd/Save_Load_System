using _Project.Scripts.GameEngine.SaveLoad;
using _Project.Scripts.SaveSystem;
using Zenject;

namespace _Project.Scripts.GameEngine.Installers
{
    public class SaveLoadInstaller
    {
        public SaveLoadInstaller(DiContainer container)
        {
            BindSaveSystem(container);
            BindGameRepository(container);
            BindUnitSaveLoader(container);
            BindResourceSaveLoader(container);
        }

        private void BindSaveSystem(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<SaveLoadSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameRepository(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<GameRepository>()
                .AsSingle()
                .NonLazy();
        }

        private void BindUnitSaveLoader(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<UnitSaveLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindResourceSaveLoader(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<ResourceSaveLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}