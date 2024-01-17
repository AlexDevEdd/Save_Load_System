using _Project.Scripts.GameEngine.SaveLoad.SaveData;
using UnityEngine;
using Zenject;
using PrefabProvider = _Project.Scripts.GameEngine.Installers.ScriptableObjects.PrefabProvider;

namespace _Project.Scripts.GameEngine.Systems.Units
{
    public sealed class UnitFactory
    {
        private readonly PrefabProvider _prefabProvider;
        
        [Inject]
        public UnitFactory(PrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public Unit CreateUnit(UnitData data, Transform container)
        {
            var prefab = _prefabProvider.GetUnitPrefab(data.Type);
            var unit = Object.Instantiate(prefab, data.Position, Quaternion.Euler(data.Rotation), container);
            unit.HitPoints = data.HitPoints;
            return unit;
        }
        
        public void DestroyUnit(Unit unit)
        {
            Object.Destroy(unit.gameObject);
        }
    }
}