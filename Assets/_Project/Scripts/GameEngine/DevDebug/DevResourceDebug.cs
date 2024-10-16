using System.Collections.Generic;
using System.Linq;
using SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class DevResourceDebug : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<string, Resource> _sceneResources = new();

        private ResourceSystem _resourceSystem;
        private ISaveSystem _saveSystem;
        
        [Inject]
        public void Construct(ResourceSystem resourceSystem, ISaveSystem saveSystem)
        {
            _resourceSystem = resourceSystem;
            _saveSystem = saveSystem;
            SetResources(_resourceSystem.GetResources());
        }

        private void SetResources(IEnumerable<Resource> resources)
        {
            _sceneResources = resources.ToDictionary(it => it.Id);
        }

        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 0.38f)]
        public void TryIncreaseAmountByID(string id, int increaseValue)
        {
            _resourceSystem.TryIncreaseAmountByID(id, increaseValue);
        }

        [Button(ButtonStyle.Box), GUIColor(0.99f, 1f, 0f)]
        public void TryDecreaseAmountByID(string id, int degreaseValue)
        {
           _resourceSystem.TryDecreaseAmountByID(id, degreaseValue);
        }
        
        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 1f)]
        public void Save()
        {
            _saveSystem.Save();
        }
        
        [Button(ButtonStyle.Box), GUIColor(0f, 1f, 1f)]
        public void Load()
        {
            _saveSystem.LoadAsync();
        }
        
        [Button(ButtonStyle.Box), GUIColor(1f, 0.5f, 0.3f)]
        public void RemoveSaves()
        {
            _saveSystem.RemoveSaves();
        }
    }
}