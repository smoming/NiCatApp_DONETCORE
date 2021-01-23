using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Services;

namespace NiCatApp_DONETCORE.Controllers
{
    [ApiController]
    [Route("api/ApiNation")]
    public class NationController
    {
        private DbConnection _conn;
        public NationController(DbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<NationDTO> list()
        {
            var svc = new NationService(_conn);
            return svc.list();
        }
    }
}