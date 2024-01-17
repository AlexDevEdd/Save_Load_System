using UnityEngine;

namespace _Project.Scripts.GameEngine.Systems.Units
{
    //Нельзя менять!
    public sealed class Unit : MonoBehaviour
    {
        [SerializeField] private UnitType _unitType;
        [SerializeField] private int _hitPoints;
        
        public UnitType UnitType => _unitType;
        public Vector3 Position => transform.position;
        public Vector3 Rotation => transform.eulerAngles;
        
        public int HitPoints
        {
            get => _hitPoints;
            set => _hitPoints = value;
        }
        
        private void Reset()
        {
            _hitPoints = 10;
        }
    }
}