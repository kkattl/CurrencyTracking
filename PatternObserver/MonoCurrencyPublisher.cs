using CurrencyTracking.ApiReader;
using CurrencyTracking.Data;
using CurrencyTracking.PatternObserver.Observers;
using System.Collections.Generic;
using System.Threading;

namespace CurrencyTracking.PatternObserver
{
    public class MonoCurrencyPublisher
    {
        public List<TransformedCurrencyData> data { get; private set; }

        private Tracker _request;
        private List<IObserver> _observers;

        public MonoCurrencyPublisher()
        {
            this._request = new Tracker("https://api.monobank.ua/bank/currency");
            this.data = new List<TransformedCurrencyData>();
            this._observers = new List<IObserver>();
        }

        public void AddObservers(params IObserver[] observers)
        {
            foreach (IObserver observer in observers)
                this._observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void StartObserve()
        {
            while (true)
            {
                this.data = _request.GetRequest();

                foreach (IObserver observer in _observers)
                    observer.Update(data);

                Thread.Sleep(5 * 60 * 1000);
            }
        }
    }
}
