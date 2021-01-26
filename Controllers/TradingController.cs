using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers {
    [ApiController]
    [Route ("api/ApiTradings")]
    public class TradingController {
        private TradingService svc;
        public TradingController (DbConnection conn) {
            svc = new TradingService (conn);
        }

        [HttpGet]
        public IEnumerable<TradingDTO> list (DateTime? StartDate, DateTime? EndDate, string Buyer, string CommodityID) {
            var filter = new TradingQueryModel () {
                TradeDate_S = StartDate,
                TradeDate_E = EndDate,
                Buyer = Buyer,
                CommodityID = CommodityID
            };
            return svc.list (filter);
        }

        [HttpGet ("{id}")]
        public TradingDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] TradingDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] TradingDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }

        [HttpGet ("GetUnShipped")]
        public IEnumerable<TradingDTO> unshipped () {
            return svc.list_unshipped ();
        }
    }
}