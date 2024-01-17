using UnityEngine;
using Zenject;

namespace _Project.Scripts.GameEngine.Installers.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
    {
        [SerializeField, Space] private GameResources _gameResources;
        [SerializeField, Space] private PrefabProvider _prefabs;
        [SerializeField, Space] private GameBalance _balance;
        
        public override void InstallBindings()
        {
            BindingPrefabProvider();
            BindingBalance();
            BindGameResources();
        }
        
        private void BindingBalance()
        {
            Container.Bind<GameBalance>()
                .FromInstance(_balance)
                .AsSingle();
        }
        
        private void BindingPrefabProvider()
        {
            Container.Bind<PrefabProvider>()
                .FromInstance(_prefabs)
                .AsSingle();
        }

        private void BindGameResources()
        {
            Container.Bind<GameResources>()
                .FromInstance(_gameResources)
                .AsSingle();
        }
    }
}