using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderList.Models
{
    class StatusContextInitializer : CreateDatabaseIfNotExists<StatusContext>
    {
        protected override void Seed(StatusContext db)
        {
            string statusJson = "[{'Id':1,'Name':'Новый'},{'Id':2,'Name':'Подтвержден'},{'Id':3,'Name':'Обработка'},{'Id':4,'Name':'Отгрузка'},{'Id':5,'Name':'Доставка'},{'Id':6,'Name':'Выполнен'}]";
            List<Status> statusesList = JsonConvert.DeserializeObject<List<Status>>(statusJson);
            foreach(var s in statusesList)
            {
                db.Statuses.Add(s);
            }
            db.SaveChanges();
        }
    }
    public class StatusContext : DbContext
    {
        static StatusContext()
        {
            Database.SetInitializer<StatusContext>(new StatusContextInitializer());
        }
        public StatusContext() : base("OrderList")
        { }
        public DbSet<Status> Statuses { get; set; }
    }
}