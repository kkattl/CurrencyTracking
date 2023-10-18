using CurrencyTracking.PatternObserver.Observers;
using CurrencyTracking.PatternObserver;
using System;
using System.Text;

namespace CurrencyTracking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MonoCurrencyPublisher publisher = new MonoCurrencyPublisher();

            publisher.AddObservers(new RateBuySellObserver(), new RateCrossObserver(), new RatesChangesObserver());

            publisher.StartObserve();
            Console.ReadKey();
        }
    }
}
