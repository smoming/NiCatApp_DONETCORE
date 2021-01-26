using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class OrderService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_ORDER_LIST";
        private readonly string SP_GET = "SP_ORDER_GET";
        private readonly string SP_ADD = "SP_ORDER_ADD";
        private readonly string SP_UPDATE = "SP_ORDER_UPDATE";
        private readonly string SP_DELETE = "SP_ORDER_DELETE";
        private readonly string SP_UNPAID = "SP_ORDER_UNPAID";
        private readonly string SP_UNPURCHASE = "SP_ORDER_UNPURCHASE";

        public OrderService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<OrderDTO> list (OrderQueryModel filter) {
            var p = new DynamicParameters ();
            p.Add ("i_TradeDate_S", filter.TradeDate_S, DbType.Date, ParameterDirection.Input);
            p.Add ("i_TradeDate_E", filter.TradeDate_E, DbType.Date, ParameterDirection.Input);
            p.Add ("i_CommodityID", filter.CommodityID, DbType.String, ParameterDirection.Input);
            p.Add ("i_TransNos", filter.TransNos, DbType.String, ParameterDirection.Input);
            p.Add ("i_ReceiptNo", filter.ReceiptNo, DbType.String, ParameterDirection.Input);
            p.Add ("i_PurchaseNo", filter.PurchaseNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                return res.doQuery (SP_LIST, p);
            }
        }

        public OrderDTO get (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (OrderDTO item) {
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                res.doExecute (SP_ADD, toSqlParams (true, handleNullToEmpty (item)));
            }
        }

        public void update (OrderDTO item) {
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (false, handleNullToEmpty (item)));
            }
        }

        public void delete (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                res.doExecute (SP_DELETE, p);
            }
        }

        public IEnumerable<OrderDTO> list_unpaid () {
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                return res.doQuery (SP_UNPAID);
            }
        }

        public IEnumerable<OrderDTO> list_unpurchase () {
            using (var res = new BaseRepository<OrderDTO> (_conn)) {
                return res.doQuery (SP_UNPURCHASE);
            }
        }

        private DynamicParameters toSqlParams (bool doAdd, OrderDTO item) {
            var p = new DynamicParameters ();
            if (!doAdd)
                p.Add ("i_TRANSNO", item.TRANSNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_TRADEDATE", item.TRADEDATE, DbType.Date, ParameterDirection.Input);
            p.Add ("i_COMMODITYID", item.COMMODITYID, DbType.String, ParameterDirection.Input);
            p.Add ("i_TRADEQUANTITY", item.TRADEQUANTITY, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_TRADEAMOUNT", item.TRADEAMOUNT, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_RECEIPTNO", item.RECEIPTNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_PURCHASENO", item.PURCHASENO, DbType.String, ParameterDirection.Input);
            p.Add ("i_REMARK", item.REMARK, DbType.String, ParameterDirection.Input);
            return p;
        }

        private OrderDTO handleNullToEmpty (OrderDTO item) {
            if (item.TRANSNO == null)
                item.TRANSNO = "";
            if (item.COMMODITYID == null)
                item.COMMODITYID = "";
            if (item.RECEIPTNO == null)
                item.RECEIPTNO = "";
            if (item.PURCHASENO == null)
                item.PURCHASENO = "";
            if (item.REMARK == null)
                item.REMARK = "";
            return item;
        }
    }
}