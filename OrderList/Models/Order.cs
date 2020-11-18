using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderList.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}