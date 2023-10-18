namespace CurrencyTracking.Data.DataChanges
{
    public class ChangeCross
    {
        public string CurrencyCodeA { get; set; }
        public string CurrencyCodeB { get; set; }
        public string Date { get; set; }
        public float RateCross { get; set; }
        public float RateCrossChange { get; set; }

        public ChangeCross(TransformedCurrencyData newData, TransformedCurrencyData oldData)
        {
            this.CurrencyCodeA = newData.CurrencyCodeA;
            this.CurrencyCodeB = newData.CurrencyCodeB;

            this.Date = newData.Date;

            this.RateCross = newData.RateCross;

            this.RateCrossChange = (newData.RateCross - oldData.RateCross) / (oldData.RateCross) * 100;
        }

        public override string ToString()
        {
            return string.Format("|{0, 30}|{1, 30}|{2, 20}|{3, 10}|{4, 10}%|", CurrencyCodeA.PadRight(30).Substring(0, 30), CurrencyCodeB.PadRight(30).Substring(0, 30), Date,
                        RateCross, RateCrossChange.ToString("F4"));
        }
    }
}
