namespace CryptoApp.DataTypes
{
    public class MarketCryptocurrency
    {
        public string ExchangeId { get; set; }
        public string BaseId { get; set; }
        public string QuoteId { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? VolumePercent { get; set; }
    }
}
