using _Project.Scripts.GameEngine.Systems.GameResources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GameEngine.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _unitContainer;
        
        public override void InstallBindings()
        {
            var resources = FindObjectsOfType<Resource>();
            
            new SaveLoadInstaller(Container);
            new UnitsInstaller(Container, _unitContainer);
            new ResourceInstaller(Container, resources);
        }
    }
}