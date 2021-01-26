using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class ReceiptDTO {
        [JsonPropertyName ("TransNo")]
        public String TRANSNO { get; set; }

        [JsonPropertyName ("TradeDate")]
        public DateTime TRADEDATE { get; set; }

        [JsonPropertyName ("TradeAmount")]
        public Decimal TRADEAMOUNT { get; set; }

        [JsonPropertyName ("Remark")]
        public String REMARK { get; set; }
    }
}