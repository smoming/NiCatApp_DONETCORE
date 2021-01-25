using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class SupplierService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_SUPPLIER_LIST";
        private readonly string SP_GET = "SP_SUPPLIER_GET";
        private readonly string SP_ADD = "SP_SUPPLIER_ADD";
        private readonly string SP_UPDATE = "SP_SUPPLIER_UPDATE";
        private readonly string SP_DELETE = "SP_SUPPLIER_DELETE";

        public SupplierService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<SupplierDTO> list () {
            using (var res = new BaseRepository<SupplierDTO> (_conn)) {
                return res.doQuery (SP_LIST);
            }
        }

        public SupplierDTO get (string id) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<SupplierDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (SupplierDTO item) {
            using (var res = new BaseRepository<SupplierDTO> (_conn)) {
                res.doExecute (SP_ADD, toSqlParams (item));
            }
        }

        public void update (SupplierDTO item) {
            using (var res = new BaseRepository<SupplierDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (item));
            }
        }

        public void delete (string id) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<SupplierDTO> (_conn)) {
                res.doExecute (SP_DELETE, p);
            }
        }

        private DynamicParameters toSqlParams (SupplierDTO item) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", item.ID, DbType.String, ParameterDirection.Input);
            p.Add ("i_NAME", item.NAME, DbType.String, ParameterDirection.Input);
            p.Add ("i_NATIONID", item.NATIONID, DbType.String, ParameterDirection.Input);
            return p;
        }
    }
}