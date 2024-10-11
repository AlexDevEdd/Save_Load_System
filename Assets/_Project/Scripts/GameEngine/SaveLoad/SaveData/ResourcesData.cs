using System;
using System.Collections.Generic;

namespace GameEngine
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