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
    [Route ("api/ApiShippers")]
    public class ShipperController {
        private ShipperService svc;
        public ShipperController (DbConnection conn) {
            svc = new ShipperService (conn);
        }

        [HttpGet]
        public IEnumerable<ShipperDTO> list (DateTime? StartDate, DateTime? EndDate, string Buyer) {
            var filter = new ShipperQueryModel () {
                TradeDate_S = StartDate,
                TradeDate_E = EndDate,
                Buyer = Buyer
            };
            return svc.list (filter);
        }

        [HttpGet ("{id}")]
        public ShipperDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] string[] transnos) {
            svc.add (transnos);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] ShipperDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}