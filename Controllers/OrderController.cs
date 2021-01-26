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
    [Route ("api/ApiOrders")]
    public class OrderController {
        private OrderService svc;
        public OrderController (DbConnection conn) {
            svc = new OrderService (conn);
        }

        [HttpGet]
        public IEnumerable<OrderDTO> list (DateTime? StartDate, DateTime? EndDate, string CommodityID, string ReceiptNo) {
            var filter = new OrderQueryModel () {
                TradeDate_S = StartDate,
                TradeDate_E = EndDate,
                CommodityID = CommodityID,
                ReceiptNo = ReceiptNo
            };
            return svc.list (filter);
        }

        [HttpGet ("{id}")]
        public OrderDTO get (string id) {
            return svc.get (id);
        }

        [HttpPost]
        public void add ([FromBody] OrderDTO item) {
            svc.add (item);
        }

        [HttpPut ("{id}")]
        public void update (string id, [FromBody] OrderDTO item) {
            svc.update (item);
        }

        [HttpDelete ("{id}")]
        public void delete (string id) {
            svc.delete (id);
        }

        [HttpGet ("GetUnPaid")]
        public IEnumerable<OrderDTO> unpaid () {
            return svc.list_unpaid ();
        }

        [HttpGet ("GetUnPurchase")]
        public IEnumerable<OrderDTO> unpurchase () {
            return svc.list_unpurchase ();
        }
    }
}