using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers {
    [ApiController]
    [Route ("api/ApiCommodities")]
    public class CommodityController {
        private CommodityService svc;
        public CommodityController (DbConnection conn) {
            svc = new CommodityService (conn);
        }

        [HttpGet]
        public IEnumerable<CommodityDTO> list () {
            return svc.list ();
        }

        [HttpGet ("{id}")]
        public CommodityDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] CommodityDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] CommodityDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}