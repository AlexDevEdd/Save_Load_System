using System;
using Sirenix.OdinInspector;

namespace GameEngine
{
    [Serializable]
    public class GameBalance
    {
        [Title("Player configuration", TitleAlignment = TitleAlignments.Centered)]
        public PlayerStats PlayerStats;
    }
    
    [Serializable]
    public struct PlayerStats
    {
        public float BaseMoveSpeed;
        public float BaseDamage;
    }
}