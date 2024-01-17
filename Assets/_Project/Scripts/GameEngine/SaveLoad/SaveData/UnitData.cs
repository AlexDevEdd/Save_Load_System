using System;
using _Project.Scripts.GameEngine.Systems.Units;
using _Project.Scripts.Tools.Serialize;

namespace _Project.Scripts.GameEngine.SaveLoad.SaveData
{
    [Serializable]
    public struct UnitData
    {
        public UnitType Type;
        public int HitPoints;

        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}