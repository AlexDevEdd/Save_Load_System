using SaveLoad.Tests.DataStorage.Data;

namespace SaveLoad.Tests.DataStorage.Mocks
{
    internal class SerializableDataMock
    {
        public TestCurrenciesData CurrenciesData;
        public TestCharacterUpgradesData CharacterUpgradesData;
        
        public void Init()
        {
            CurrenciesData = new TestCurrenciesData();
            CurrenciesData.CurrencyDatas.Add(new TestCurrencyData("gold", 30f));
            CurrenciesData.CurrencyDatas.Add(new TestCurrencyData("soft", 10f));
            CurrenciesData.CurrencyDatas.Add(new TestCurrencyData("wood", 100f));

            CharacterUpgradesData = new TestCharacterUpgradesData(5);
            CharacterUpgradesData.UpgradeDatas.Add(new TestUpgradeData("speed", 5));
            CharacterUpgradesData.UpgradeDatas.Add(new TestUpgradeData("health", 100));
            CharacterUpgradesData.UpgradeDatas.Add(new TestUpgradeData("damage", 30));
            CharacterUpgradesData.UpgradeDatas.Add(new TestUpgradeData("armor", 1));
            CharacterUpgradesData.UpgradeDatas.Add(new TestUpgradeData("attackSpeed", 2));
        }
    }
}