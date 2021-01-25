using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers {
    [ApiController]
    [Route ("api/ApiDeliveryTypes")]
    public class DeliveryTypeController {
        private DeliveryTypeService svc;
        public DeliveryTypeController (DbConnection conn) {
            svc = new DeliveryTypeService (conn);
        }

        [HttpGet]
        public IEnumerable<DeliveryTypeDTO> list () {
            return svc.list ();
        }

        [HttpGet ("{id}")]
        public DeliveryTypeDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] DeliveryTypeDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] DeliveryTypeDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}