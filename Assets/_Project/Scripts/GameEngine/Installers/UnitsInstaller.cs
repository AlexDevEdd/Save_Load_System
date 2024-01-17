using _Project.Scripts.GameEngine.Systems.Units;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GameEngine.Installers
{
    public class UnitsInstaller
    {
        public UnitsInstaller(DiContainer container, Transform unitContainer)
        {
            BindUnitSystem(container, unitContainer);
            BindUnitFactory(container);
        }

        private void BindUnitSystem(DiContainer container, Transform unitContainer)
        {
            container.BindInterfacesAndSelfTo<UnitSystem>()
                .AsSingle()
                .WithArguments(unitContainer)
                .NonLazy();
        }

        private void BindUnitFactory(DiContainer container)
        {
            container.Bind<UnitFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}