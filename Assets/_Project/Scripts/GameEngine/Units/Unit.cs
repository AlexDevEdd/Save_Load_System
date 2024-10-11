using UnityEngine;

namespace GameEngine
{
    public sealed class Unit : MonoBehaviour
    {
        [field: SerializeField]
        public UnitType UnitType { get; private set; }
        
        [field: SerializeField]
        public int HitPoints { get; private set; }
        
        public Vector3 Position => transform.position;
        public Vector3 Rotation => transform.eulerAngles;
        
        public void SetHitPoints(int amount)
        {
            HitPoints = amount;
        }
        
        private void Reset()
        {
            HitPoints = 10;
        }
    }
}