﻿using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcOrderBook : ICommonOrderBook
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("ask")]
        public List<HitBtcOrderBookEntry> Asks { get; set; }

        [JsonProperty("bid")]
        public List<HitBtcOrderBookEntry> Bids { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("askAveragePrice")]
        public decimal AskAveragePrice { get; set; }

        [JsonProperty("bidAveragePrice")]
        public decimal BidAveragePrice { get; set; }

        public IEnumerable<ISymbolOrderBookEntry> CommonBids => Asks;

        public IEnumerable<ISymbolOrderBookEntry> CommonAsks => Bids;
    }
}
