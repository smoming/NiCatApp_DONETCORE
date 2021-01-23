using System;
using System.Text.Json.Serialization;

namespace NiCatApp_DONETCORE.Models
{
    public class NationDTO
    {
        [JsonPropertyName("ID")]
        public String ID { get; set; }
        [JsonPropertyName("Name")]
        public String NAME { get; set; }
    }
}