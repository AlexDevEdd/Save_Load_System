using _Project.Scripts.GameEngine.Systems.GameResources;
using Zenject;
using Resource = _Project.Scripts.GameEngine.Systems.GameResources.Resource;

namespace _Project.Scripts.GameEngine.Installers
{
    public sealed class ResourceInstaller
    {
        public ResourceInstaller(DiContainer container, Resource[] resources)
        {
            container.BindInterfacesAndSelfTo<ResourceSystem>()
                .AsSingle()
                .WithArguments(resources)
                .NonLazy();
        }
    }
}