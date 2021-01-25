using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class CommodityDTO {
        [JsonPropertyName ("ID")]
        public String ID { get; set; }

        [JsonPropertyName ("Name")]
        public String NAME { get; set; }

        [JsonPropertyName ("Style")]
        public String STYLE { get; set; }

        [JsonPropertyName ("NationID")]
        public String NATIONID { get; set; }

        [JsonPropertyName ("SupplierID")]
        public String SUPPLIERID { get; set; }

        [JsonPropertyName ("SupplierProductNo")]
        public String SUPPLIER_PRODUCTNO { get; set; }

        [JsonPropertyName ("WholesalePrice")]
        public decimal WHOLESALE_PRICE { get; set; }

        [JsonPropertyName ("RetailPrice")]
        public decimal RETAIL_PRICE { get; set; }

        [JsonPropertyName ("Remark")]
        public String REMARK { get; set; }

    }
}