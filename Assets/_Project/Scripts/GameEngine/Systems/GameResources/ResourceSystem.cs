using System.Collections.Generic;
using _Project.Scripts.Tools;
using Zenject;

namespace _Project.Scripts.GameEngine.Systems.GameResources
{
    public class ResourceSystem
    {
        private readonly Dictionary<string, Resource> _resources = new();

        [Inject]
        public ResourceSystem(IEnumerable<Resource> resources)
        {
            foreach (var resource in resources) 
                _resources.TryAdd(resource.ID, resource);
        }
        
        public void TryIncreaseAmountByID(string id, int degreaseValue)
        {
            if (_resources.TryGetValue(id, out var resource))
                resource.Amount += degreaseValue;
            else
                Log.ColorLogDebugOnly($"Doesn't exit resource id {id}", ColorType.Orange, LogStyle.Warning);
        }
        
        public void TryDecreaseAmountByID(string id, int degreaseValue)
        {
            if (_resources.TryGetValue(id, out var resource))
                resource.Amount -= degreaseValue;
            else
                Log.ColorLogDebugOnly($"Doesn't exit resource id {id}", ColorType.Orange, LogStyle.Warning);
        }
        
        public IEnumerable<Resource> GetResources()
        {
            return _resources.Values;
        }
    }
}