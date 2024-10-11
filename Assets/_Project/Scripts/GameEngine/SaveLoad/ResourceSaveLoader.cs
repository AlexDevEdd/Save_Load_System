using System.Linq;
using JetBrains.Annotations;
using SaveLoad;

namespace GameEngine
{
    [UsedImplicitly]
    public class ResourceSaveLoader : SaveLoader<ResourcesData, ResourceSystem>
    {
        public ResourceSaveLoader(GameDataStorage dataStorage, ResourceSystem system)
            : base(dataStorage, system) { }
        
        protected override ResourcesData ConvertToData(ResourceSystem system)
        {
            var resourceData = new ResourcesData();
            foreach (var resource in system.GetResources())
            {
                var data = new ResourceData()
                {
                    ID = resource.Id,
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
                resources[index].SetUpAmount(data.ResourceDatas[index].Amount);
        }
    }
}