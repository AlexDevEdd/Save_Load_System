using System;
using System.Collections.Generic;

namespace _Project.Scripts.GameEngine.SaveLoad.SaveData
{
    [Serializable]
    public class ResourcesData
    {
        public List<ResourceData> ResourceDatas;

        public ResourcesData()
        {
            ResourceDatas = new List<ResourceData>();
        }
    }
}