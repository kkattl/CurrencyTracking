namespace CurrencyTracking.Data
{
    public class CurrencyData
    {
        public int CurrencyCodeA { get; set; }
        public int CurrencyCodeB { get; set; }
        public long Date { get; set; }
        public float RateSell { get; set; }
        public float RateBuy { get; set; }
        public float RateCross { get; set; }
        public override string ToString()
        {
            return $"{CurrencyCodeA}|{CurrencyCodeB}|{Date}|{RateSell}|{RateBuy}|{RateCross}";
        }
    }
}
