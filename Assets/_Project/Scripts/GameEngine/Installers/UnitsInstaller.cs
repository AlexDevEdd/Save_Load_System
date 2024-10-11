using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class UnitsInstaller : MonoInstaller
    {
        [SerializeField] 
        private Transform _unitContainer;

        public override void InstallBindings()
        {
            BindUnitSystem();
            BindUnitFactory();
        }
        
        private void BindUnitSystem()
        {
            Container.BindInterfacesAndSelfTo<UnitSystem>()
                .AsSingle()
                .WithArguments(_unitContainer)
                .NonLazy();
        }

        private void BindUnitFactory()
        {
            Container.Bind<UnitFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}