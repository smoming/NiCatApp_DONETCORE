using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models {
    public class SupplierDTO {
        [JsonPropertyName ("ID")]
        public String ID { get; set; }

        [JsonPropertyName ("Name")]
        public String NAME { get; set; }

        [JsonPropertyName ("NationID")]
        public String NATIONID { get; set; }
    }
}