using System;
using System.Collections.Generic;

namespace SaveLoad.Tests.DataStorage.Data
{
    [Serializable]
    public class TestCharacterUpgradesData
    {
        public readonly List<TestUpgradeData> UpgradeDatas;

        public TestCharacterUpgradesData(int collectionSize)
        {
            UpgradeDatas = new List<TestUpgradeData>(collectionSize);
        }
    }
    
    
    [Serializable]
    public readonly struct TestUpgradeData
    {
        public readonly string Id;
        public readonly int Level;

        public TestUpgradeData(string id, int level)
        {
            Id = id;
            Level = level;
        }
    }
}