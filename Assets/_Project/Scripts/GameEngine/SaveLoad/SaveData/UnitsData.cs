using System;
using System.Collections.Generic;

namespace _Project.Scripts.GameEngine.SaveLoad.SaveData
{
    [Serializable]
    public class UnitsData
    {
        public List<UnitData> Units;

        public UnitsData()
        {
            Units = new List<UnitData>();
        }
    }
}