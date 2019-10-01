using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using BlackKnight.UniIEX.ClientModels;
#if !NET_4_6
using System.Threading.Tasks;
#endif

namespace BlackKnight.UniIEX {
    public class IEXClient {
        public IEXConfig Config { get; private set; }
        IEXUrlBuilder m_Builder;

        public IEXClient(IEXConfig config) {
            Config = config;
            m_Builder = new IEXUrlBuilder(Config);
        }

        // ================================================
        // API
        // ================================================


        /// <summary>
        /// Task Returns List of "SymbolDataResponse" 
        /// </summary>
        /// <returns></returns>
        public Task<List<SymbolDataResponse>> GetAllSymbols() {
            var source = new TaskCompletionSource<List<SymbolDataResponse>>();
            GetAllSymbols(
                response => source.SetResult(response),
                error => source.SetException(error)
            );
            return source.Task;
        }

        public void GetAllSymbols(Action<List<SymbolDataResponse>> onSuccess, Action<Exception> onFail) {
            Query(m_Builder.AllSymbolsQueryPath(),
                res => {
                    var obj = JsonConvert.DeserializeObject<List<SymbolDataResponse>>(res);
                    if (obj != null)
                        onSuccess.TryInvoke(obj);
                },
                fail => onFail.TryInvoke(new Exception("Query symbol response status: " + fail))
            );
        }


        /// <summary>
        /// task returns Stock Quote for a specific symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public Task<QuoteDataResponse> GetStockQuote(string symbol) {
            var source = new TaskCompletionSource<QuoteDataResponse>();
            GetStockQuote(symbol,
                response => source.SetResult(response),
                fail => source.SetException(fail)
                );
            return source.Task;
        }

        public void GetStockQuote(string symbol, Action<QuoteDataResponse> onSuccess, Action<Exception> onFail) {
            Query(m_Builder.GetStockQuotePath(symbol),
                res => {
                    var obj = JsonConvert.DeserializeObject<QuoteDataResponse>(res);
                    if (obj != null)
                        onSuccess.TryInvoke(obj);
                },
                fail => onFail.TryInvoke(new Exception("StockQuote symbol response status: " + fail))
            );
        }

        public Task<List<HistoricalDataResponse>> QuerySymbol(string symbol) {
            var source = new TaskCompletionSource<List<HistoricalDataResponse>>();
            QuerySymbol(symbol,
                response => source.SetResult(response),
                fail => source.SetException(fail)
                );
            return source.Task;
        }

        public void QuerySymbol(string symbol, Action<List<HistoricalDataResponse>> onSuccess, Action<Exception> onfail) {
            Query(m_Builder.GetSymbolQueryPath(symbol),
                res => {
                    var obj = JsonConvert.DeserializeObject<List<HistoricalDataResponse>>(res);
                    if (obj != null)
                        onSuccess.TryInvoke(obj);
                },
                fail => onfail.TryInvoke(new Exception("Query symbol response status: " + fail))
            );
        }

        // ================================================
        // TRANSPORT
        // ================================================
        async void Query(string url, Action<string> onSuccess, Action<Exception> onFail) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var uri = new Uri(url);
            HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode) {
                var str = await response.Content.ReadAsStringAsync();
                onSuccess.TryInvoke(str);
            }
            else {
                onFail.TryInvoke(new Exception(response.ReasonPhrase));
            }
        }
    }
}