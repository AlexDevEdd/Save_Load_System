using UnityEngine;

namespace GameEngine
{
    public sealed class Resource : MonoBehaviour
    {
        [field: SerializeField]
        public string Id { get; private set; }

        [field: SerializeField]
        public int Amount { get; private set; }

        public void SetUpAmount(int amount)
        {
            Amount = amount;
        }
        
        public void Add(int amount)
        {
            Amount += amount;
        }
        
        public void Remove(int amount)
        {
            Amount -= amount;
        }
    }
}