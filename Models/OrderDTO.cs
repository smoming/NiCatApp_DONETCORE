using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class OrderDTO {
        [JsonPropertyName ("TransNo")]
        public String TRANSNO { get; set; }

        [JsonPropertyName ("TradeDate")]
        public DateTime TRADEDATE { get; set; }

        [JsonPropertyName ("CommodityID")]
        public String COMMODITYID { get; set; }

        [JsonPropertyName ("TradeQuantity")]
        public Decimal TRADEQUANTITY { get; set; }

        [JsonPropertyName ("TradeAmount")]
        public Decimal TRADEAMOUNT { get; set; }

        [JsonPropertyName ("ReceiptNo")]
        public String RECEIPTNO { get; set; }

        [JsonPropertyName ("PurchaseNo")]
        public String PURCHASENO { get; set; }

        [JsonPropertyName ("Remark")]
        public String REMARK { get; set; }
    }
}