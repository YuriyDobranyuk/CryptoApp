using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoApp.DataTypes;
using CryptoApp.Model;
using Newtonsoft.Json;

namespace CryptoApp.Services
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _httpClient;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

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
                    Id = item.Id,
                    Name = $"{item.Symbol} {item.Name}",
                    Price = item.PriceUsd.ToString("C", culture),
                    Changes24h = string.Format("{0:0.00}%", item.ChangePercent24Hr),
                    Volume24h = item.VolumeUsd24Hr.ToString("C", culture),
                    MarketCap = item.MarketCapUsd.ToString("C", culture),
                }).ToList();
            }
            return result;
        }

        public async Task<DetailCryptocurrencyModel> GetCryptoCurrencyDetails(CryptocurrencyModel cryptocurrency)
        {
            var result = new DetailCryptocurrencyModel {
                Id = $"Id: {cryptocurrency.Id}",
                Name = $"Name: {cryptocurrency.Name}",
                Price = $"Price: {cryptocurrency.Price}",
                Volume24h = $"24h Volume: {cryptocurrency.Volume24h}",
                Changes24h = $"24h Changes: {cryptocurrency.Changes24h}",
                MarketCap = $"Market Cap: {cryptocurrency.MarketCap}"
            };
            var response = await _httpClient.GetAsync("https://api.coincap.io/v2/assets/" + cryptocurrency.Id + "/markets");
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<MarketsCryptocurrency>(content)?.Data.ToList() ??
                          new List<MarketCryptocurrency>();
                result.MarketsCryptocurrency = res.Select(item => new MarketCryptocurrencyModel
                {
                    ExchangeId = item.ExchangeId,
                    BaseId = item.BaseId,
                    QuoteId = item.QuoteId,
                    VolumeUsd24Hr = item.VolumeUsd24Hr.HasValue ? item.VolumeUsd24Hr.Value.ToString("C", culture) : string.Empty,
                    PriceUsd = item.PriceUsd.Value.ToString("C", culture),
                    VolumePercent = item.VolumePercent.HasValue ? string.Format("{0:0.0000}%", item.VolumePercent) : string.Empty
                }).ToList();
            }
            return result;
        }
    }
}
