﻿using System;
using System.Collections.Generic;
using System.Linq;
using Binance.Net.Converters;
using Binance.Net.Enums;
using Newtonsoft.Json;

namespace Binance.Net.Objects.Models.Spot
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BinanceSymbol
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The status of the symbol
        /// </summary>
        [JsonConverter(typeof(SymbolStatusConverter))]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// The base asset
        /// </summary>
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// The precision of the base asset
        /// </summary>
        public int BaseAssetPrecision { get; set; }
        /// <summary>
        /// The quote asset
        /// </summary>
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// The precision of the quote asset
        /// </summary>
        [JsonProperty("quotePrecision")]
        public int QuoteAssetPrecision { get; set; }

        /// <summary>
        /// Allowed order types
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(SpotOrderTypeConverter))]
        public IEnumerable<SpotOrderType> OrderTypes { get; set; } = Array.Empty<SpotOrderType>();
        /// <summary>
        /// Ice berg orders allowed
        /// </summary>
        public bool IceBergAllowed { get; set; }
        /// <summary>
        /// Spot trading orders allowed
        /// </summary>
        public bool IsSpotTradingAllowed { get; set; }
        /// <summary>
        /// Trailling stop orders are allowed
        /// </summary>
        public bool AllowTrailingStop { get; set; }
        /// <summary>
        /// Margin trading orders allowed
        /// </summary>
        public bool IsMarginTradingAllowed { get; set; }
        /// <summary>
        /// If OCO(One Cancels Other) orders are allowed
        /// </summary>
        public bool OCOAllowed { get; set; }
        /// <summary>
        /// Whether or not it is allowed to specify the quantity of a market order in the quote asset
        /// </summary>
        [JsonProperty("quoteOrderQtyMarketAllowed")]
        public bool QuoteOrderQuantityMarketAllowed { get; set; }
        /// <summary>
        /// The precision of the base asset fee
        /// </summary>
        [JsonProperty("baseCommissionPrecision")]
        public int BaseFeePrecision { get; set; }
        /// <summary>
        /// The precision of the quote asset fee
        /// </summary>
        [JsonProperty("quoteCommissionPrecision")]
        public int QuoteFeePrecision { get; set; }
        /// <summary>
        /// Permissions types
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(AccountTypeConverter))]
        public IEnumerable<AccountType> Permissions { get; set; } = Array.Empty<AccountType>();
        /// <summary>
        /// Filters for order on this symbol
        /// </summary>
        public IEnumerable<BinanceSymbolFilter> Filters { get; set; } = Array.Empty<BinanceSymbolFilter>();

        /// <summary>
        /// Filter for max amount of iceberg parts for this symbol
        /// </summary>
        [JsonIgnore]        
        public BinanceSymbolIcebergPartsFilter? IceBergPartsFilter => Filters.OfType<BinanceSymbolIcebergPartsFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for max accuracy of the quantity for this symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolLotSizeFilter? LotSizeFilter => Filters.OfType<BinanceSymbolLotSizeFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for max accuracy of the quantity for this symbol, specifically for market orders
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolMarketLotSizeFilter? MarketLotSizeFilter => Filters.OfType<BinanceSymbolMarketLotSizeFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for max number of orders for this symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolMaxOrdersFilter? MaxOrdersFilter => Filters.OfType<BinanceSymbolMaxOrdersFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for max algorithmic orders for this symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolMaxAlgorithmicOrdersFilter? MaxAlgorithmicOrdersFilter => Filters.OfType<BinanceSymbolMaxAlgorithmicOrdersFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for the minimal quote quantity of an order for this symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolMinNotionalFilter? MinNotionalFilter => Filters.OfType<BinanceSymbolMinNotionalFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for the max accuracy of the price for this symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolPriceFilter? PriceFilter => Filters.OfType<BinanceSymbolPriceFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for the maximum deviation of the price
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolPercentPriceFilter? PricePercentFilter => Filters.OfType<BinanceSymbolPercentPriceFilter>().FirstOrDefault();
        /// <summary>
        /// Filter for the maximum position on a symbol
        /// </summary>
        [JsonIgnore]
        public BinanceSymbolMaxPositionFilter? MaxPositionFilter => Filters.OfType<BinanceSymbolMaxPositionFilter>().FirstOrDefault();
    }
}
