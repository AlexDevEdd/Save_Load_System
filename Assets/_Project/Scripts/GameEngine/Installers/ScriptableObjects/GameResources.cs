using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.GameEngine.Installers.ScriptableObjects
{
    [Serializable]
    public class GameResources
    {
        [SerializeField] private List<Sprite> _icons;
        
        public bool TryGetSprite(string key, out Sprite sprite)
        {
            sprite = _icons.FirstOrDefault(s => s.name == key);
            if (sprite != null)
                return true;

            throw new ArgumentException($"doesn't exist Sprite key of {key}");
        }
        
        public bool TryGetSprite<T>(T type, out Sprite sprite) where T: Enum
        {
            sprite = _icons.FirstOrDefault(s => s.name.Equals(type.ToString()));
            if (sprite != null)
                return true;

            throw new ArgumentException($"doesn't exist Sprite key of {type}");
        }
    }
}