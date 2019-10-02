using System;
using UnityEngine;

namespace BlackKnight.UniIEX.Examples {
    public class APITest : MonoBehaviour {
        IEXClient m_Client;
        string BaseUrl = "https://cloud.iexapis.com/";

        private void Start() {
            var config = new IEXConfig {
                IsSandbox = true,
                Token = "Your token Here"
            };

            m_Client = new IEXClient(config);
        }

        [ContextMenu("Query AAPL")]
        public void QuerySymbolTest() {
            QuerySymbol("aapl");
        }

        public async void ChainedRequests() {
            try {
                var allSymbos = await m_Client.GetAllSymbols();
                var firstSymbol = allSymbos[0].Symbol;
                var quote = await m_Client.GetStockQuote(firstSymbol);
                Debug.Log("Quote for " + firstSymbol + " " + quote);
            }
            catch(Exception e) {
                Debug.LogError(e);
            }
        }

        public async void QuerySymbol(string symbol) {
            //using Action
            m_Client.QuerySymbol(symbol,
                response => Debug.Log(response),
                error => Debug.LogError(error)
            );


            //using Task
            try {
                var response = await m_Client.QuerySymbol(symbol);
                Debug.Log(response);
            }
            catch(Exception e) {
                Debug.LogError(e);
            }
        }

        [ContextMenu("Get All Symbols")]
        public async void GetAllSymbols() {
            //using Actions
            m_Client.GetAllSymbols(
                response => Debug.Log(response),
                error => Debug.LogError(error)
            );

            //using Tasks
            try {
                var res = await m_Client.GetAllSymbols();
                Debug.Log(res);
            }
            catch (Exception e) {
                Debug.LogError(e);
            }
        }

        [ContextMenu("Get AAPL Stock Quote")]
        public void GetStockQuoteTest() {
            GetStockQuote("AAPL");
        }

        public async void GetStockQuote(string symbol) {
            //using Actions
            m_Client.GetStockQuote(symbol,
                response => Debug.Log(response),
                error => Debug.LogError(error)
            );

            //using tasks

            try {
                var response = await m_Client.GetStockQuote(symbol);
                Debug.Log(response);
            }
            catch(Exception e) {
                Debug.LogError(e);
            }
        }
    }
}