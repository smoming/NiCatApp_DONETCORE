using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class ReceiptService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_RECEIPT_LIST";
        private readonly string SP_GET = "SP_RECEIPT_GET";
        private readonly string SP_ADD = "SP_RECEIPT_ADD";
        private readonly string SP_UPDATE = "SP_RECEIPT_UPDATE";
        private readonly string SP_DELETE = "SP_RECEIPT_DELETE";

        public ReceiptService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<ReceiptDTO> list (ReceiptQueryModel filter) {
            var p = new DynamicParameters ();
            p.Add ("i_TradeDate_S", filter.TradeDate_S, DbType.Date, ParameterDirection.Input);
            p.Add ("i_TradeDate_E", filter.TradeDate_E, DbType.Date, ParameterDirection.Input);
            using (var res = new BaseRepository<ReceiptDTO> (_conn)) {
                return res.doQuery (SP_LIST, p);
            }
        }

        public ReceiptDTO get (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<ReceiptDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (string[] transnos) {
            var p = new DynamicParameters ();
            p.Add ("i_OrderNos", string.Join (",", transnos), DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<ReceiptDTO> (_conn)) {
                res.doExecute (SP_ADD, p);
            }
        }

        public void update (ReceiptDTO item) {
            using (var res = new BaseRepository<ReceiptDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (false, handleNullToEmpty (item)));
            }
        }

        public void delete (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<ReceiptDTO> (_conn)) {
                res.doExecute (SP_DELETE, p);
            }
        }

        private DynamicParameters toSqlParams (bool doAdd, ReceiptDTO item) {
            var p = new DynamicParameters ();
            if (!doAdd)
                p.Add ("i_TRANSNO", item.TRANSNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_TRADEDATE", item.TRADEDATE, DbType.Date, ParameterDirection.Input);
            p.Add ("i_TRADEAMOUNT", item.TRADEAMOUNT, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_REMARK", item.REMARK, DbType.String, ParameterDirection.Input);
            return p;
        }

        private ReceiptDTO handleNullToEmpty (ReceiptDTO item) {
            if (item.TRANSNO == null)
                item.TRANSNO = "";
            if (item.REMARK == null)
                item.REMARK = "";
            return item;
        }
    }
}