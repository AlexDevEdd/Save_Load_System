using System.Linq;
using JetBrains.Annotations;
using SaveLoad;
using Zenject;

namespace GameEngine
{
    [UsedImplicitly]
    public class UnitSaveLoader : SaveLoader<UnitsData, UnitSystem>
    {
        public UnitSaveLoader(GameDataStorage dataStorage, UnitSystem system)
            : base(dataStorage, system) { }
        
        protected override UnitsData ConvertToData(UnitSystem system)
        {
            var unitsData = new UnitsData();
            foreach (var unit in system.GetAllUnits())
            {
                var data = new UnitData()
                {
                    Type = unit.UnitType,
                    HitPoints = unit.HitPoints,
                    Position = unit.Position,
                    Rotation = unit.Rotation
                };

                unitsData.Units.Add(data);
            }

            return unitsData;
        }

        protected override void SetUpData(UnitsData data, UnitSystem system)
        {
            if(data.Units.Count == 0) return;
            
            var units = system.GetAllUnits().ToList();
            if (units.Count > 0) 
                system.RemoveAll();
            
            foreach (var unit in data.Units) 
                system.SpawnUnit(unit);
        }
    }
}