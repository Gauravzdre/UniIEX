using Newtonsoft.Json;

namespace BlackKnight.UniIEX.ClientModels {
    public class HistoricalDataResponse {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("securityType")]
        public string SecurityType { get; set; }

        [JsonProperty("bidPrice")]
        public double BidPrice { get; set; }

        [JsonProperty("bidSize")]
        public double BidSize { get; set; }

        [JsonProperty("askPrice")]
        public double AskPrice { get; set; }

        [JsonProperty("askSize")]
        public int AskSize { get; set; }

        [JsonProperty("lastUpdated")]
        public double LastUpdated { get; set; }

        [JsonProperty("lastSalePrice")]
        public float LastSalePrice { get; set; }

        [JsonProperty("lastSaleSize")]
        public double LastSaleSize { get; set; }

        [JsonProperty("lastScaleTime")]
        public double LastScaleTime { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }
    }
}