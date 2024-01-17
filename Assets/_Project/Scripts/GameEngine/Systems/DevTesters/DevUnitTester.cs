using _Project.Scripts.GameEngine.SaveLoad.SaveData;
using _Project.Scripts.GameEngine.Systems.Units;
using _Project.Scripts.SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GameEngine.Systems.DevTesters
{
    //Нельзя менять!
    public sealed class DevUnitTester : MonoBehaviour
    {
        private UnitSystem _unitSystem;
        private ISaveSystem _saveSystem;
        
        [Inject]
        public void Construct(UnitSystem unitSystem, ISaveSystem saveSystem)
        {
            _unitSystem = unitSystem;
            _saveSystem = saveSystem;
        }
        
        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 0.38f)]
        public void SpawnUnit(UnitData data)
        {
           _unitSystem.SpawnUnit(data);
        }

        [Button(ButtonStyle.Box), GUIColor(0.99f, 1f, 0f)]
        public void DestroyUnit(Unit unit)
        {
            _unitSystem.RemoveUnit(unit);
        }
        
        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 1f)]
        public void Save()
        {
            _saveSystem.Save();
        }
        
        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 1f)]
        public void Load()
        {
            _saveSystem.Load();
        }
        
        [Button(ButtonStyle.Box), GUIColor(1f, 0.5f, 0.3f)]
        public void RemoveSaves()
        {
            _saveSystem.RemoveSaves();
        }
    }
}