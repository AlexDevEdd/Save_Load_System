using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameEngine
{
    [Serializable]
    public class UnitsData
    {
        [JsonProperty("units")]
        public List<UnitData> Units = new();
    }
}