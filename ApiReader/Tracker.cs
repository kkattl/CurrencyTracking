using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System;
using CurrencyTracking.Data;

namespace CurrencyTracking.ApiReader
{
    public class Tracker
    {
        private string _address;


        public Tracker(string address)
        {
            _address = address;
        }


        public List<TransformedCurrencyData> GetRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response;
                    List<TransformedCurrencyData> transformedCurrencies = new List<TransformedCurrencyData>();
                    do
                    {
                        response = client.GetAsync(_address).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonContent = response.Content.ReadAsStringAsync().Result;

                            List<CurrencyData> jsonObject = JsonConvert.DeserializeObject<List<CurrencyData>>(jsonContent);

                            Decoder decoder = new Decoder();

                            transformedCurrencies = decoder.DecodeList(jsonObject);
                        }
                        else
                        {
                            Console.WriteLine($"Помилка при виконанні запиту: {response.StatusCode}");
                            Thread.Sleep(5000);
                        }
                    } while ((int)response.StatusCode == 429);

                    return transformedCurrencies;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                    return null;
                }
            }
            //private List<CurrencyData> ParseCurrency(string jsonContent)
            //{
            //    try
            //    {
            //        var currencyDataList = JsonConvert.DeserializeObject<List<CurrencyData>>(jsonContent);

            //        if (currencyDataList == null || currencyDataList.Count == 0)
            //        {
            //            Console.WriteLine("Помилка розпарсування JSON даних.");
            //            return null;
            //        }

            //        List<CurrencyData> parsedData = new List<CurrencyData>();

            //        foreach (var currencyData in currencyDataList)
            //        {
            //            CurrencyData parsedCurrencyData = new CurrencyData
            //            {
            //                CurrencyCodeA = currencyData.CurrencyCodeA,
            //                CurrencyCodeB = currencyData.CurrencyCodeB,
            //                Date = currencyData.Date,
            //                RateSell = currencyData.RateSell,
            //                RateBuy = currencyData.RateBuy,
            //                RateCross = currencyData.RateCross
            //            };
            //            parsedData.Add(parsedCurrencyData);
            //        }

            //        return parsedData;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Помилка парсингу JSON: {ex.Message}");
            //        return null;
            //    }
            //}
        }
    }
}
