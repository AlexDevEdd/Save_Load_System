using System.Collections.Generic;
using JetBrains.Annotations;
using Utils;

namespace GameEngine
{
    [UsedImplicitly]
    public class ResourceSystem
    {
        private readonly Dictionary<string, Resource> _resources = new();
        
        public ResourceSystem(IEnumerable<Resource> resources)
        {
            foreach (var resource in resources) 
                _resources.TryAdd(resource.Id, resource);
        }
        
        public void TryIncreaseAmountByID(string id, int degreaseValue)
        {
            if (_resources.TryGetValue(id, out var resource))
                resource.Add(degreaseValue);
            else
                Log.ColorLogDebugOnly($"Doesn't exit resource id {id}", ColorType.Orange, LogStyle.Warning);
        }
        
        public void TryDecreaseAmountByID(string id, int degreaseValue)
        {
            if (_resources.TryGetValue(id, out var resource))
                resource.Remove(degreaseValue);
            else
                Log.ColorLogDebugOnly($"Doesn't exit resource id {id}", ColorType.Orange, LogStyle.Warning);
        }
        
        public IEnumerable<Resource> GetResources()
        {
            return _resources.Values;
        }
    }
}