using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class ShipperDTO {
        [JsonPropertyName ("TransNo")]
        public String TRANSNO { get; set; }

        [JsonPropertyName ("TradeDate")]
        public DateTime TRADEDATE { get; set; }

        [JsonPropertyName ("Buyer")]
        public String BUYER { get; set; }

        [JsonPropertyName ("TradeAmount")]
        public Decimal TRADEAMOUNT { get; set; }

        [JsonPropertyName ("Fee")]
        public Decimal FEE { get; set; }

        [JsonPropertyName ("Delivery")]
        public String DELIVERY { get; set; }

        [JsonPropertyName ("Remark")]
        public String REMARK { get; set; }
    }
}