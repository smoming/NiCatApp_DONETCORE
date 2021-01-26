using System;
using System.Collections.Generic;

namespace NiCatApp_DONETCORE.Models {
    public class ShipperQueryModel {
        public DateTime? TradeDate_S { get; set; }
        public DateTime? TradeDate_E { get; set; }
        public string Buyer { get; set; }
    }
}