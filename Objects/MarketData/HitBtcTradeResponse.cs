﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Objects.MarketData
{
    public class HitBtcTradeResponse
    {
        public Dictionary<string, List<HitBtcTrade>> Body { get; set; }
    }
}