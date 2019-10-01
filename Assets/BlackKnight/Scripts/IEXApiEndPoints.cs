namespace BlackKnight.UniIEX {
    public class IEXUrlBuilder {
        IEXConfig Config { get; set; }

        public IEXUrlBuilder(IEXConfig config) {
            Config = config;
        }

        public string GetBasePath(bool isSandbox) {
            return Config.IsSandbox ? "https://sandbox.iexapis.com" : "https://cloud.iexapis.com";
        }

        public string GetSymbolQueryPath(string symbol) {
            var path = "{0}/stable/tops?token={1}&&sym={2}";
            return string.Format(path, GetBasePath(Config.IsSandbox), Config.Token, symbol);
        }

        public string GetStockQuotePath(string symbol) {
            var path = "{0}/stable/stock/{1}/quote?token={2}";
            return string.Format(path, GetBasePath(Config.IsSandbox), Config.Token, symbol);
        }

        public string AllSymbolsQueryPath() {
            var path = "{0}/beta/ref-data/symbols?token={1}";
            return string.Format(path, GetBasePath(Config.IsSandbox), Config.Token);
        }
    }
}