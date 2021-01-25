using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers {
    [ApiController]
    [Route ("api/ApiSuppliers")]
    public class SupplierController {
        private SupplierService svc;
        public SupplierController (DbConnection conn) {
            svc = new SupplierService (conn);
        }

        [HttpGet]
        public IEnumerable<SupplierDTO> list () {
            return svc.list ();
        }

        [HttpGet ("{id}")]
        public SupplierDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] SupplierDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] SupplierDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }
    }
}