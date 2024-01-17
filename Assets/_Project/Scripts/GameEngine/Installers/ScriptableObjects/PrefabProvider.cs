using System;
using _Project.Scripts.GameEngine.Systems.Units;
using _Project.Scripts.Tools;
using _Project.Scripts.Tools.Serialize;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.GameEngine.Installers.ScriptableObjects
{
    [Serializable]
    public class PrefabProvider
    {
        [Title("Unit References", TitleAlignment = TitleAlignments.Centered)]
        [SerializeField]private SerializableDictionary<UnitType, Unit> _unitReferences;
        
        [Title("Prefab References", TitleAlignment = TitleAlignments.Centered)]
        [SerializeField]private SerializableDictionary<string, GameObject> _prefabReferences;

        public T GetPrefab<T>(string key) where T: MonoBehaviour
        {
            if (_prefabReferences.TryGetValue(key, out var prefab))
                return prefab.GetOrAddComponent<T>();

            throw new ArgumentException($"Doesn't exist KEY of {key}");
        }
        
        public Unit GetUnitPrefab(UnitType key)
        {
            if (_unitReferences.TryGetValue(key, out var prefab))
                return prefab;

            throw new ArgumentException($"Doesn't not exist KEY of {key}");
        }
    }
}
