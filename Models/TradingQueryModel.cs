using System;
using System.Collections.Generic;

namespace NiCatApp_DONETCORE.Models {
    public class TradingQueryModel {
        public DateTime? TradeDate_S { get; set; }
        public DateTime? TradeDate_E { get; set; }
        public string Buyer { get; set; }
        public string CommodityID { get; set; }
        public List<string> TransNos { get; set; }
        public bool? IsShipped { get; set; }
        public string ShipperNo { get; set; }
    }
}