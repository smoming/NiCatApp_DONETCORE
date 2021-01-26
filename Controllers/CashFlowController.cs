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
    [Route ("api/ApiCashFlow")]
    public class CashFlowController {
        private CashFlowService svc;
        public CashFlowController (DbConnection conn) {
            svc = new CashFlowService (conn);
        }

        [HttpPost ("DoAccound")]
        public void DoAccound (DateTime xExeDate) {
            svc.add (xExeDate);
        }

        [HttpPost ("DoUnAccound")]
        public void DoUnAccound (DateTime xExeDate) {
            svc.delete (xExeDate);
        }
    }
}