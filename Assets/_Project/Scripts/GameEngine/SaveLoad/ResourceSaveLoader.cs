using System.Linq;
using _Project.Scripts.GameEngine.SaveLoad.SaveData;
using _Project.Scripts.GameEngine.Systems.GameResources;
using _Project.Scripts.SaveSystem;
using Zenject;

namespace _Project.Scripts.GameEngine.SaveLoad
{
    public class ResourceSaveLoader : SaveLoader<ResourcesData, ResourceSystem>
    {
        [Inject]
        public ResourceSaveLoader(GameRepository repository, ResourceSystem system)
            : base(repository, system) { }
        
        protected override ResourcesData ConvertToData(ResourceSystem system)
        {
            var resourceData = new ResourcesData();
            foreach (var resource in system.GetResources())
            {
                var data = new ResourceData()
                {
                    ID = resource.ID,
                    Amount = resource.Amount
                };

                resourceData.ResourceDatas.Add(data);
            }

            return resourceData;
        }

        protected override void SetUpData(ResourcesData data, ResourceSystem system)
        {
            if(data.ResourceDatas.Count == 0) return;
            
            var resources = system.GetResources().ToList();

            for (var index = 0; index < resources.Count; index++)
                resources[index].Amount = data.ResourceDatas[index].Amount;
        }
    }
}