using Newtonsoft.Json;
using OrderList.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace OrderList.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductContext db = new ProductContext();

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }

    }
}