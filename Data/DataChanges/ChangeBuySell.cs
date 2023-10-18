namespace CurrencyTracking.Data.DataChanges
{
    public class ChangeBuySell
    {
        public string CurrencyCodeA { get; set; }
        public string CurrencyCodeB { get; set; }
        public string Date { get; set; }
        public float RateSell { get; set; }
        public float RateSellChange { get; set; }
        public float RateBuy { get; set; }
        public float RateBuyChange { get; set; }

        public ChangeBuySell(TransformedCurrencyData newData, TransformedCurrencyData oldData)
        {
            this.CurrencyCodeA = newData.CurrencyCodeA;
            this.CurrencyCodeB = newData.CurrencyCodeB;

            this.Date = newData.Date;

            this.RateBuy = newData.RateBuy;
            this.RateSell = newData.RateSell;

            this.RateBuyChange = (newData.RateBuy - oldData.RateBuy) / (oldData.RateBuy) * 100;
            this.RateSellChange = (newData.RateSell - oldData.RateSell) / (oldData.RateSell) * 100;
        }

        public override string ToString()
        {
            return string.Format("|{0, 25}|{1, 25}|{2, 20}|{3, 10}|{4, 10}%|{5, 10}|{6, 10}%|", CurrencyCodeA, CurrencyCodeB, Date,
                        RateBuy, RateBuyChange.ToString("F4"), RateSell, RateSellChange.ToString("F4"));
        }
    }
}
