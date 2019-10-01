using Newtonsoft.Json;

namespace BlackKnight.UniIEX.ClientModels {
    public class QuoteDataResponse {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("companyName")]
        public string CompanyName;

        [JsonProperty("primaryExchange")]
        public string PrimaryExchange;

        [JsonProperty("calculationPrice")]
        public string CalculationPrice;

        [JsonProperty("open")]
        public string Open;

        [JsonProperty("closeTime")]
        public string CloseTime;

        [JsonProperty("high")]
        public string High;

        [JsonProperty("low")]
        public string Low;

        [JsonProperty("latestPrice")]
        public float LatestPrice;

        [JsonProperty("latestSource")]
        public string LatestSource;

        [JsonProperty("lastestTime")]
        public string LatestTime;

        [JsonProperty("latestUpdate")]
        public string LatestUpdate;

        [JsonProperty("latestVolume")]
        public string LatestVolume;

        [JsonProperty("iexRealtimePrice")]
        public float IEXRealtimePrice;

        [JsonProperty("iexRealtimeSize")]
        public float IEXRealtimeSize;

        [JsonProperty("iexLastUpdated")]
        public double IEXLastUpdated;

        [JsonProperty("delayedPrice")]
        public string DelayedPrice;

        [JsonProperty("delayedPriceTime")]
        public string DelayedPriceTime;

        [JsonProperty("extendedPrice")]
        public string ExtendedPrice;

        [JsonProperty("extendedChange")]
        public string ExtendedChange;

        [JsonProperty("extendedChangePercent")]
        public string ExtendedChangePercent;

        [JsonProperty("extendedPriceTime")]
        public string ExtendedPriceTime;

        [JsonProperty("previousClose")]
        public float PreviousClose;

        [JsonProperty("change")]
        public float Change;

        [JsonProperty("changePercent")]
        public double ChangePercent;

        [JsonProperty("volume")]
        public string Volume;

        [JsonProperty("iexMarketPercent")]
        public long IEXMarketPercent;

        [JsonProperty("iexVolume")]
        public double IEXVolume;

        [JsonProperty("avgTotalVolume")]
        public double AvgTotalVolume;

        [JsonProperty("iexBidPrice")]
        public float IEXBidPrice;

        [JsonProperty("iexBidSize")]
        public float IEXBidSize;

        [JsonProperty("iexAskSize")]
        public float IEXAskSize;

        [JsonProperty("marketCap")]
        public double MarketCap;

        [JsonProperty("peRatio")]
        public float PeRatio;

        [JsonProperty("week52High")]
        public float Week52High;

        [JsonProperty("week52Low")]
        public float Week52Low;

        [JsonProperty("ytdChange")]
        public float YtdChange;

        [JsonProperty("lastTradeTime")]
        public float LastTradeTime;

        [JsonProperty("isUSMarketOpen")]
        public bool IsUSMarketOpen;
    }
}