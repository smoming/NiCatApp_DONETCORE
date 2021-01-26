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
    [Route ("api/ApiPurchase")]
    public class PurchaseController {
        private PurchaseService svc;
        public PurchaseController (DbConnection conn) {
            svc = new PurchaseService (conn);
        }

        [HttpGet]
        public IEnumerable<PurchaseDTO> list (DateTime? StartDate, DateTime? EndDate) {
            var filter = new PurchaseQueryModel () {
                TradeDate_S = StartDate,
                TradeDate_E = EndDate
            };
            return svc.list (filter);
        }

        [HttpGet ("{id}")]
        public PurchaseDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] string[] transnos) {
            svc.add (transnos);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] PurchaseDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}