using System;
using System.Collections.Generic;

namespace SaveLoad.Tests.DataStorage.Data
{
    [Serializable]
    public class TestCurrenciesData
    {
        public readonly List<TestCurrencyData> CurrencyDatas;

        public TestCurrenciesData()
        {
            CurrencyDatas = new List<TestCurrencyData>();
        }
    }
    
    
    [Serializable]
    public readonly struct TestCurrencyData
    {
        public readonly string Type;
        public readonly float Amount;
        
        public TestCurrencyData(string type, float amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}