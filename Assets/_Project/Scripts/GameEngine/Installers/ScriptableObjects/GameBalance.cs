using System;
using Sirenix.OdinInspector;

namespace _Project.Scripts.GameEngine.Installers.ScriptableObjects
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