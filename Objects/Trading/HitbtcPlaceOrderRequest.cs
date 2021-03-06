﻿using HitBtc.Net.Converters;
using HitBtc.Net.Enums;
using Newtonsoft.Json;
using System;

namespace HitBtc.Net.Objects.Trading
{
    /// <summary>
    /// This class contains fields needed to placing different types of orders
    /// </summary>
    public class HitbtcPlaceOrderRequest
    {
        public HitbtcPlaceOrderRequest()
        {
        }

        public HitbtcPlaceOrderRequest(string symbol,
                                       HitBtcTradeSide side,
                                       decimal quantity,
                                       HitBtcOrderType type,
                                       decimal? price = null,
                                       string clientOrderId = null,
                                       bool? postOnly = false,
                                       bool? strictValidate = false,
                                       HitBtcOrderTimeInForce? timeInForce = HitBtcOrderTimeInForce.GoodTillCancelled,
                                       DateTime? expireTime = null,
                                       decimal? stopPrice = null
                                       )
        {
            ClientOrderId = clientOrderId;
            Symbol = symbol;
            Side = side;
            Type = type;
            TimeInForce = timeInForce;
            Quantity = quantity;
            Price = price;
            ExpireTime = expireTime;
            StrictValidate = strictValidate;
            StopPrice = stopPrice;
            PostOnly = postOnly;
        }

        /// <summary>
        /// Order unique identifier as assigned by trader. 
        /// Uniqueness must be guaranteed within a single trading day, including all active orders.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Trading symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Trade side. Accepted values: sell or buy
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(HitBtcTradeSideConverter))]
        public HitBtcTradeSide Side { get; set; }

        /// <summary>
        /// Accepted values: limit, market, stopLimit, stopMarket
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(HitBtcOrderTypeConverter))]
        public HitBtcOrderType Type { get; set; }

        /// <summary>
        /// Time in Force is a special instruction used when placing a trade to indicate how long an order will remain active before it is executed or expired.
        /// GTC - ''Good-Till-Cancelled'' order won't be closed until it is filled.
        /// IOC - ''Immediate-Or-Cancel'' order must be executed immediately.Any part of an IOC order that cannot be filled immediately will be cancelled.
        /// FOK - ''Fill-Or-Kill'' is a type of ''Time in Force'' designation used in securities trading that instructs a brokerage to execute a transaction immediately and completely or not execute it at all.
        /// Day - keeps the order active until the end of the trading day (UTC).
        /// GTD - ''Good-Till-Date''. The date is specified in expireTime.
        /// </summary>
        [JsonProperty("timeInForce"), JsonConverter(typeof(HitBtcOrderTimeInForceConverter))]
        public HitBtcOrderTimeInForce? TimeInForce { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Order price. Required for limit order types
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Required for orders with timeInForce = GTD
        /// </summary>
        [JsonProperty("expireTime")]
        public DateTime? ExpireTime { get; set; }

        /// <summary>
        /// Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.
        /// </summary>
        [JsonProperty("strictValidate")]
        public bool? StrictValidate { get; set; }

        /// <summary>
        /// Required for stop-limit and stop-market orders
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// If your post-only order causes a match with a pre-existing order as a taker, 
        /// then the order will be cancelled.
        /// </summary>
        [JsonProperty("postOnly")]
        public bool? PostOnly { get; set; }


        /// <summary>
        /// Generate request to place limit order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="postOnly"> If your post-only order causes a match with a pre-existing order as a taker, 
        ///  then the order will be cancelled.</param>
        /// <param name="timeInForce"></param>
        /// <param name="expireTime">Required for orders with timeInForce = GoodTillDate</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.</param>
        /// <returns></returns>
        public static HitbtcPlaceOrderRequest PlaceLimitOrderRequest(
                                       string symbol,
                                       HitBtcTradeSide side,
                                       decimal quantity,
                                       decimal price,
                                       string clientOrderId = null,
                                       bool postOnly = false,
                                       HitBtcOrderTimeInForce? timeInForce = HitBtcOrderTimeInForce.GoodTillCancelled,
                                       DateTime? expireTime = null,
                                       bool strictValidate = false)
        {
            return new HitbtcPlaceOrderRequest(symbol, side, quantity, HitBtcOrderType.Limit, price,
                                            clientOrderId, postOnly, strictValidate, timeInForce, expireTime);
        }
        /// <summary>
        /// Generate request to place market order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="timeInForce"></param>
        /// <param name="expireTime">Required for orders with timeInForce = GoodTillDate</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.</param>
        /// <returns></returns>
        public static HitbtcPlaceOrderRequest PlaceMarketOrderRequest(
                                    string symbol,
                                    HitBtcTradeSide side,
                                    decimal quantity,
                                    string clientOrderId = null,
                                    HitBtcOrderTimeInForce? timeInForce = HitBtcOrderTimeInForce.GoodTillCancelled,
                                    DateTime? expireTime = null,
                                    bool strictValidate = false)
        {
            return new HitbtcPlaceOrderRequest(symbol, side, quantity, HitBtcOrderType.Market, null,
                                            clientOrderId, false, strictValidate, timeInForce, expireTime);
        }

        /// <summary>
        /// Generate request to place stop market order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="timeInForce"></param>
        /// <param name="expireTime">Required for orders with timeInForce = GoodTillDate</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.</param>
        /// <returns></returns>
        public static HitbtcPlaceOrderRequest PlaceStopMarketOrderRequest(
                                   string symbol,
                                   HitBtcTradeSide side,
                                   decimal quantity,
                                   decimal stopPrice,
                                   string clientOrderId = null,
                                   HitBtcOrderTimeInForce? timeInForce = HitBtcOrderTimeInForce.GoodTillCancelled,
                                   DateTime? expireTime = null,
                                   bool strictValidate = false)
        {
            return new HitbtcPlaceOrderRequest(symbol, side, quantity, HitBtcOrderType.StopMarket, null,
                                            clientOrderId, false, strictValidate, timeInForce, expireTime, stopPrice);
        }
        /// <summary>
        /// Generate request to place limit order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="postOnly"> If your post-only order causes a match with a pre-existing order as a taker, 
        ///  then the order will be cancelled.</param>
        /// <param name="timeInForce"></param>
        /// <param name="expireTime">Required for orders with timeInForce = GoodTillDate</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.</param>
        /// <returns></returns>
        public static HitbtcPlaceOrderRequest PlaceStopLimitOrderRequest(
                                      string symbol,
                                      HitBtcTradeSide side,
                                      decimal quantity,
                                      decimal price,
                                      decimal stopPrice,
                                      string clientOrderId = null,
                                      bool postOnly = false,
                                      HitBtcOrderTimeInForce? timeInForce = HitBtcOrderTimeInForce.GoodTillCancelled,
                                      DateTime? expireTime = null,
                                      bool strictValidate = false)
        {
            return new HitbtcPlaceOrderRequest(symbol, side, quantity, HitBtcOrderType.StopLimit, price,
                                            clientOrderId, postOnly, strictValidate, timeInForce, expireTime, stopPrice);
        }
    }

}
