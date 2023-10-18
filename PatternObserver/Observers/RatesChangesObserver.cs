using CurrencyTracking.Data.DataChanges;
using CurrencyTracking.Data;
using System.Collections.Generic;
using System;

namespace CurrencyTracking.PatternObserver.Observers
{
    public class RatesChangesObserver : IObserver
    {
        List<TransformedCurrencyData> data;

        public void Update(List<TransformedCurrencyData> newData)
        {
            if (data == null)
            {
                data = newData;
            }

            List<ChangeBuySell> buySell = new List<ChangeBuySell>();
            List<ChangeCross> cross = new List<ChangeCross>();

            for (int i = 0; i < newData.Count; i++)
            {
                if (newData[i].RateBuy != 0)
                {
                    if ((newData[i].RateBuy != data[i].RateBuy) || (newData[i].RateSell != data[i].RateSell))
                        buySell.Add(new ChangeBuySell(newData[i], data[i]));
                }
                else
                {
                    if (newData[i].RateCross != data[i].RateCross)
                    {
                        cross.Add(new ChangeCross(newData[i], data[i]));
                    }
                }
            }

            Console.WriteLine("Buy/Sell changes");
            if (buySell.Count == 0)
            {
                Console.WriteLine("No changes");
            }
            else
            {
                Console.WriteLine(string.Format("|{0, 25}|{1, 25}|{2, 20}|{3, 11}|{4, 10}|{5, 10}|{6, 11}|", "Currency A", "Currency B", "Date",
                        "Buy", "%", "Sell", "%"));

                foreach (ChangeBuySell change in buySell)
                    Console.WriteLine(change);
            }

            Console.WriteLine("Cross changes");
            if (cross.Count == 0)
            {
                Console.WriteLine("No changes");
            }
            else
            {
                Console.WriteLine(string.Format("|{0, 30}|{1, 30}|{2, 20}|{3, 10}|{4, 11}|", "Currency A", "Currency B", "Date",
                        "Cross", "%"));
                foreach (ChangeCross change in cross)
                    Console.WriteLine(change);
            }
            Console.WriteLine("\n");
            data = newData;
        }

    }
}
