using CurrencyTracking.Data;
using System.Collections.Generic;

namespace CurrencyTracking.PatternObserver.Observers
{
    public interface IObserver
    {
        void Update(List<TransformedCurrencyData> data);
    }
}
