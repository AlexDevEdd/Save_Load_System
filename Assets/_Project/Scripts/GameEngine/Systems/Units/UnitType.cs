using Sirenix.OdinInspector;

namespace _Project.Scripts.GameEngine.Systems.Units
{
    [EnumPaging]
    public enum UnitType : byte
    {
        None = 0,
        Orc_Archer = 1,
        Orc_Catapult = 2,
        Orc_Heavy_Infantry = 3,
        Orc_Heavy_Catapult = 4,
        Orc_Light_Infantry = 5,
        Orc_Light_Cavalry = 6,
        Orc_Mounted_Shaman = 7,
        Orc_Shaman = 8,
        Orc_Spearman = 9,
        Orc_Worker = 10,
        
        WK_Catapult = 11,
        WK_Heavy_Cavalry = 12,
        WK_Heavy_Infantry_A = 13,
        WK_Heavy_Infantry_B = 14,
        WK_Light_Archer_A = 15,
        WK_Light_Archer_B = 16,
        WK_Light_Cavalry = 17,
        WK_Light_Infantry_A = 18,
        WK_Light_Infantry_B = 19,
        WK_Mage_A = 20,
        WK_Mage_B = 21,
        WK_Mounted_Mage = 22,
        WK_Mounted_Priest = 23,
        WK_Priest = 24,
        WK_Spearman_A = 25,
        WK_Spearman_B = 26,
        WK_Worker = 27,
    }
}