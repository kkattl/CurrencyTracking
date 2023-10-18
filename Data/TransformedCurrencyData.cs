namespace CurrencyTracking.Data
{
    public class TransformedCurrencyData
    {
        public string CurrencyCodeA { get; set; }
        public string CurrencyCodeB { get; set; }
        public string Date { get; set; }
        public float RateSell { get; set; }
        public float RateBuy { get; set; }
        public float RateCross { get; set; }
        public override string ToString()
        {
            return $"{CurrencyCodeA}|{CurrencyCodeB}|{Date}|{RateSell}|{RateBuy}|{RateCross}";
        }
    }
}
