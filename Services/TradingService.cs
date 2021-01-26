using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;

namespace NiCatApp_DONETCORE.Services {
    public class TradingService {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_TRADING_LIST";
        private readonly string SP_GET = "SP_TRADING_GET";
        private readonly string SP_ADD = "SP_TRADING_ADD";
        private readonly string SP_UPDATE = "SP_TRADING_UPDATE";
        private readonly string SP_DELETE = "SP_TRADING_DELETE";
        private readonly string SP_UNSHIPPED = "SP_TRADING_UNSHIPPED";

        public TradingService (DbConnection conn) {
            _conn = conn;
        }

        public IEnumerable<TradingDTO> list (TradingQueryModel filter) {
            var p = new DynamicParameters ();
            p.Add ("i_TradeDate_S", filter.TradeDate_S, DbType.Date, ParameterDirection.Input);
            p.Add ("i_TradeDate_E", filter.TradeDate_E, DbType.Date, ParameterDirection.Input);
            p.Add ("i_Buyer", filter.Buyer, DbType.String, ParameterDirection.Input);
            p.Add ("i_CommodityID", filter.CommodityID, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                return res.doQuery (SP_LIST, p);
            }
        }

        public TradingDTO get (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                return res.doQuery (SP_GET, p).FirstOrDefault ();
            }
        }

        public void add (TradingDTO item) {
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                res.doExecute (SP_ADD, toSqlParams (true, handleNullToEmpty (item)));
            }
        }

        public void update (TradingDTO item) {
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                res.doExecute (SP_UPDATE, toSqlParams (false, handleNullToEmpty (item)));
            }
        }

        public void delete (string transNo) {
            var p = new DynamicParameters ();
            p.Add ("i_TRANSNO", transNo, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                res.doExecute (SP_DELETE, p);
            }
        }

        public IEnumerable<TradingDTO> list_unshipped () {
            using (var res = new BaseRepository<TradingDTO> (_conn)) {
                return res.doQuery (SP_UNSHIPPED);
            }
        }

        private DynamicParameters toSqlParams (bool doAdd, TradingDTO item) {
            var p = new DynamicParameters ();
            if (!doAdd)
                p.Add ("i_TRANSNO", item.TRANSNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_TRADEDATE", item.TRADEDATE, DbType.Date, ParameterDirection.Input);
            p.Add ("i_BUYER", item.BUYER, DbType.String, ParameterDirection.Input);
            p.Add ("i_COMMODITYID", item.COMMODITYID, DbType.String, ParameterDirection.Input);
            p.Add ("i_TRADEQUANTITY", item.TRADEQUANTITY, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_TRADEAMOUNT", item.TRADEAMOUNT, DbType.Decimal, ParameterDirection.Input);
            p.Add ("i_SHIPPERNO", item.SHIPPERNO, DbType.String, ParameterDirection.Input);
            p.Add ("i_REMARK", item.REMARK, DbType.String, ParameterDirection.Input);
            return p;
        }

        private TradingDTO handleNullToEmpty (TradingDTO item) {
            if (item.TRANSNO == null)
                item.TRANSNO = "";
            if (item.BUYER == null)
                item.BUYER = "";
            if (item.COMMODITYID == null)
                item.COMMODITYID = "";
            if (item.SHIPPERNO == null)
                item.SHIPPERNO = "";
            if (item.REMARK == null)
                item.REMARK = "";
            return item;
        }
    }
}