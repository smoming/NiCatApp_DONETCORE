using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class CommodityService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_COMMODITY_LIST";
        private readonly string SP_GET = "SP_COMMODITY_GET";
        private readonly string SP_ADD = "SP_COMMODITY_ADD";
        private readonly string SP_UPDATE = "SP_COMMODITY_UPDATE";
        private readonly string SP_DELETE = "SP_COMMODITY_DELETE";

        public CommodityService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<CommodityDTO> list () {
            using (var res = new BaseRepository<CommodityDTO> (_conn)) {
                return res.doQuery (SP_LIST);
            }
        }

        public CommodityDTO get (string id) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<CommodityDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (CommodityDTO item) {
            using (var res = new BaseRepository<CommodityDTO> (_conn)) {
                res.doExecute (SP_ADD, toSqlParams (true, item));
            }
        }

        public void update (CommodityDTO item) {
            using (var res = new BaseRepository<CommodityDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (false, item));
            }
        }

        public void delete (string id) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<CommodityDTO> (_conn)) {
                res.doExecute (SP_DELETE, p);
            }
        }

        private DynamicParameters toSqlParams (bool doAdd, CommodityDTO item) {
            var p = new DynamicParameters ();
            if (!doAdd)
                p.Add ("i_ID", item.ID, DbType.String, ParameterDirection.Input);
            p.Add ("i_NAME", item.NAME, DbType.String, ParameterDirection.Input);
            p.Add ("i_NATIONID", item.NATIONID, DbType.String, ParameterDirection.Input);
            p.Add ("i_STYLE", item.STYLE, DbType.String, ParameterDirection.Input);
            p.Add ("i_SUPPLIERID", item.SUPPLIERID, DbType.String, ParameterDirection.Input);
            p.Add ("i_SUPPLIER_PRODUCTNO", item.SUPPLIER_PRODUCTNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_WHOLESALE_PRICE", item.WHOLESALE_PRICE, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_RETAIL_PRICE", item.RETAIL_PRICE, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_REMARK", item.REMARK, DbType.String, ParameterDirection.Input);
            return p;
        }
    }
}