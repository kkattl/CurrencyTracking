using CurrencyTracking.Data;
using System.Collections.Generic;
using System;

namespace CurrencyTracking.PatternObserver.Observers
{
    public class RateBuySellObserver : IObserver
    {
        private string _data;

        public RateBuySellObserver()
        {
            _data = "";
        }

        public void Update(List<TransformedCurrencyData> newData)
        {
            _data = "Buy/Sell list\n";
            _data += string.Format("|{0, 25}|{1, 25}|{2, 20}|{3, 10}|{4, 10}|\n", "Currency A", "Currency B", "Date", "Rate Buy", "Rate Sell");

            foreach (TransformedCurrencyData pair in newData)
            {
                if (pair.RateBuy != 0)
                {
                    _data += string.Format("|{0, 25}|{1, 25}|{2, 20}|{3, 10}|{4, 10}|\n", pair.CurrencyCodeA, pair.CurrencyCodeB, pair.Date,
                        pair.RateBuy, pair.RateSell);
                }
            }
            _data += "\n";
            Console.WriteLine(_data);
        }
    }
}
