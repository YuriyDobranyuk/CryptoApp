namespace CryptoApp.Model
{
    public class CryptocurrencyModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string Changes24h { get; set; }

        public string Volume24h { get; set; }

        public string MarketCap { get; set; }
    }
}
