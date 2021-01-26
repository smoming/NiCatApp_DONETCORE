using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class CashFlowService {
        private DbConnection _conn;
        private readonly string SP_ACCOUNT = "SP_ACCOUND_ADD";
        private readonly string SP_UNACCOUNT = "SP_ACCOUND_DELETE";

        public CashFlowService (DbConnection conn) {
            _conn = conn;
        }

        public void add (DateTime tradeDate) {
            using (var res = new BaseRepository<string> (_conn)) {
                res.doExecute (SP_ACCOUNT, toSqlParams (tradeDate));
            }
        }

        public void delete (DateTime tradeDate) {
            using (var res = new BaseRepository<string> (_conn)) {
                res.doExecute (SP_UNACCOUNT, toSqlParams (tradeDate));
            }
        }

        private DynamicParameters toSqlParams (DateTime tradeDate) {
            var p = new DynamicParameters ();
            p.Add ("i_TRADEDATE", tradeDate, DbType.Date, ParameterDirection.Input);
            return p;
        }
    }
}