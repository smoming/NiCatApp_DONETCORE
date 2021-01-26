using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class PurchaseDTO {
        [JsonPropertyName ("TransNo")]
        public String TRANSNO { get; set; }

        [JsonPropertyName ("TradeDate")]
        public DateTime TRADEDATE { get; set; }

        [JsonPropertyName ("Fee")]
        public Decimal FEE { get; set; }

        [JsonPropertyName ("Remark")]
        public String REMARK { get; set; }
    }
}