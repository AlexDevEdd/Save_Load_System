using System.Linq;
using _Project.Scripts.GameEngine.SaveLoad.SaveData;
using _Project.Scripts.GameEngine.Systems.Units;
using _Project.Scripts.SaveSystem;
using Zenject;

namespace _Project.Scripts.GameEngine.SaveLoad
{
    public class UnitSaveLoader : SaveLoader<UnitsData, UnitSystem>
    {
        [Inject]
        public UnitSaveLoader(GameRepository repository, UnitSystem system)
            : base(repository, system) { }
        
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