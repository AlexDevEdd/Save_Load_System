using JetBrains.Annotations;
using UnityEngine;

namespace GameEngine
{
    [UsedImplicitly]
    public sealed class UnitFactory
    {
        private readonly PrefabProvider _prefabProvider;
        
        public UnitFactory(PrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public Unit CreateUnit(UnitData data, Transform container)
        {
            var prefab = _prefabProvider.GetUnitPrefab(data.Type);
            var unit = Object.Instantiate(prefab, data.Position, Quaternion.Euler(data.Rotation), container);
            unit.SetHitPoints(data.HitPoints);
            return unit;
        }
        
        public void DestroyUnit(Unit unit)
        {
            Object.Destroy(unit.gameObject);
        }
    }
}