namespace CryptoApp.DataTypes
{
    public class Cryptocurrency
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal PriceUsd { get; set; }

        public double ChangePercent24Hr { get; set; }

        public decimal VolumeUsd24Hr { get; set; }

        public decimal MarketCapUsd { get; set; }
    }
}
