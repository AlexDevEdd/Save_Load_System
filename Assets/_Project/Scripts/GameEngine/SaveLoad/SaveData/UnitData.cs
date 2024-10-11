using System;
using Utils;

namespace GameEngine
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