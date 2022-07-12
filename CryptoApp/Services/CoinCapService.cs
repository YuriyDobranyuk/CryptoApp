using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoApp.DataTypes;
using CryptoApp.Models;
using Newtonsoft.Json;

namespace CryptoApp.Services
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _httpClient;

        public CoinCapService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CryptocurrencyModel>> GetCryptocurrency(int count)
        {
            var result = new List<CryptocurrencyModel>();

            var response = await _httpClient.GetAsync("https://api.coincap.io/v2/assets"); //TODO Url should be in the appsettings.json

            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Cryptocurrencies>(content)?.Data.Take(count).ToList() ?? new List<Cryptocurrency>();
               
                result = res.Select(item => new CryptocurrencyModel
                {
                    Name = $"{item.Symbol} {item.Name}",
                    Price = item.PriceUsd.ToString("C"),
                    Changes24h = string.Format("{0:0.00}%", item.ChangePercent24Hr),
                    Volume24h = item.VolumeUsd24Hr.ToString("C"),
                    MarketCap = item.MarketCapUsd.ToString("C"),
                }).ToList();
            }

            return result;
        }
    }
}
