using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers {
    [ApiController]
    [Route ("api/ApiNation")]
    public class NationController {
        private NationService svc;
        public NationController (DbConnection conn) {
            svc = new NationService (conn);
        }

        [HttpGet]
        public IEnumerable<NationDTO> list () {
            return svc.list ();
        }

        [HttpGet ("{id}")]
        public NationDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] NationDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] NationDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}