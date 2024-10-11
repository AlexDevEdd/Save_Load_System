using Zenject;

namespace GameEngine
{
    public sealed class ResourceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var resources = FindObjectsOfType<Resource>();

            BindResourceSystem(resources);
        }

        private void BindResourceSystem(Resource[] resources)
        {
            Container.BindInterfacesAndSelfTo<ResourceSystem>()
                .AsSingle()
                .WithArguments(resources)
                .NonLazy();
        }
    }
}