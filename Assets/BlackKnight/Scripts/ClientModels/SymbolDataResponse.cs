using Newtonsoft.Json;

namespace BlackKnight.UniIEX.ClientModels {
    public class SymbolDataResponse {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("iexId")]
        public string IEXId { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("curency")]
        public string Currency { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
    }
}