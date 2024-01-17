using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.GameEngine.SaveLoad.SaveData;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GameEngine.Systems.Units
{
    public sealed class UnitSystem : IInitializable
    {
        private List<Unit> _activeUnits = new ();
        
        private readonly UnitFactory _unitFactory;
        private readonly Transform _container;
        
        [Inject]
        public UnitSystem(UnitFactory unitFactory, Transform container)
        {
            _unitFactory = unitFactory;
            _container = container;
        }
        
        public void Initialize()
        {
            _activeUnits = _container.GetComponentsInChildren<Unit>().ToList();
        }

        public Unit SpawnUnit(UnitData data)
        {
            var unit = _unitFactory.CreateUnit(data, _container);
            _activeUnits.Add(unit);
            return unit;
        }

        public void RemoveUnit(Unit unit)
        {
            if (_activeUnits.Remove(unit)) 
                _unitFactory.DestroyUnit(unit);
        }
        
        public void RemoveAll()
        {
            for (int i = 0; i < _activeUnits.Count; i++) 
                _unitFactory.DestroyUnit(_activeUnits[i]);

            _activeUnits.Clear();
        }
        
        public IEnumerable<Unit> GetAllUnits()
        {
            return _activeUnits;
        }
    }
}