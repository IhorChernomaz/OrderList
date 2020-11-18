using Newtonsoft.Json;
using OrderList.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace OrderList.Controllers
{
    public class StatusesController : ApiController
    {
        private StatusContext db = new StatusContext();

        // GET: api/Statuses
        [HttpGet]
        public IEnumerable<Status> GetStatuses()
        {
            return db.Statuses;
        }
    }
}