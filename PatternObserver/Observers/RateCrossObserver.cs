using CurrencyTracking.Data;
using System.Collections.Generic;
using System;

namespace CurrencyTracking.PatternObserver.Observers
{
    public class RateCrossObserver : IObserver
    {
        private string _data;

        public RateCrossObserver()
        {
            _data = "";
        }

        public void Update(List<TransformedCurrencyData> newData)
        {
            _data = "Cross list\n";
            _data += string.Format("|{0, 30}|{1, 30}|{2, 20}|{3, 10}|\n", "Currency A", "Currency B", "Date", "Rate Cross");

            foreach (TransformedCurrencyData pair in newData)
            {
                if (pair.RateCross != 0)
                {
                    _data += string.Format("|{0}|{1}|{2, 20}|{3, 10}|\n", pair.CurrencyCodeA.PadRight(30).Substring(0, 30), pair.CurrencyCodeB.PadRight(30).Substring(0, 30), pair.Date, pair.RateCross);
                }
            }
            _data += "\n";
            Console.WriteLine(_data);
        }
    }
}
