using CurrencyTracking.Data;
using System;
using System.Collections.Generic;

namespace CurrencyTracking.ApiReader
{
    public class Decoder
    {
        public string DecodeCurrencyCode(int currencyCode)
        {
            CurrencyDictionary dictionary = new CurrencyDictionary();
            if (dictionary.currencyDictionary.TryGetValue(currencyCode, out string currencyName))
                return currencyName;
            else
                return "Unknown";
        }
        public string UnixTimeToDateTime(long unixTime)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public List<TransformedCurrencyData> DecodeList(List<CurrencyData> data)
        {
            List<TransformedCurrencyData> decodedData = new List<TransformedCurrencyData>();
            
            foreach (CurrencyData pair in data)
            {
                TransformedCurrencyData decodedPair = new TransformedCurrencyData();
                decodedPair.CurrencyCodeA = DecodeCurrencyCode(pair.CurrencyCodeA);
                decodedPair.CurrencyCodeB = DecodeCurrencyCode(pair.CurrencyCodeB);

                decodedPair.Date = UnixTimeToDateTime(pair.Date);

                decodedPair.RateBuy = pair.RateBuy;
                decodedPair.RateCross = pair.RateCross;
                decodedPair.RateSell = pair.RateSell;

                decodedData.Add(decodedPair);
            }

            return decodedData;
        }
    }
}

