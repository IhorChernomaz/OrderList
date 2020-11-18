using Newtonsoft.Json;
using OrderList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace OrderList.Controllers
{
    public class OrdersController : ApiController
    {
        private OrderContext db = new OrderContext();

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders;
        }

        [HttpPost]
        [Route("api/orders/add")]
        public Order Add([FromBody]Order order)
        {
           /* var orderList = db.Orders;
            var _id = (orderList != null && !orderList.Any())? orderList.Max(x => x.OrderId) : 0;*/
            order.OrderId = db.Orders.Count() + 1;
            order.StatusId = 1;
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        [HttpPost]
        public Order Update(int id, [FromBody]Order order)
        {
            if (id == order.OrderId)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            return order;
        }

        [HttpPost]
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
