using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class DeliveryTypeService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_DELIVERYTYPE_LIST";
        private readonly string SP_GET = "SP_DELIVERYTYPE_GET";
        private readonly string SP_ADD = "SP_DELIVERYTYPE_ADD";
        private readonly string SP_UPDATE = "SP_DELIVERYTYPE_UPDATE";
        private readonly string SP_DELETE = "SP_DELIVERYTYPE_DELETE";

        public DeliveryTypeService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<DeliveryTypeDTO> list () {
            using (var res = new BaseRepository<DeliveryTypeDTO> (_conn)) {
                return res.doQuery (SP_LIST);
            }
        }

        public DeliveryTypeDTO get (string id) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<DeliveryTypeDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (DeliveryTypeDTO item) {
            using (var res = new BaseRepository<DeliveryTypeDTO> (_conn)) {
                res.doExecute (SP_ADD, toSqlParams (item));
            }
        }

        public void update (DeliveryTypeDTO item) {
            using (var res = new BaseRepository<DeliveryTypeDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (item));
            }
        }

        public void delete (string id) {
            using (var res = new BaseRepository<DeliveryTypeDTO> (_conn)) {
                res.doExecute (SP_DELETE, toSqlParams (get (id)));
            }
        }

        private DynamicParameters toSqlParams (DeliveryTypeDTO item) {
            var p = new DynamicParameters ();
            p.Add ("i_ID", item.ID, DbType.String, ParameterDirection.Input);
            p.Add ("i_NAME", item.NAME, DbType.String, ParameterDirection.Input);
            return p;
        }
    }
}