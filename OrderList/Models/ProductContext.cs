using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderList.Models
{
    class ProductContextInitializer : CreateDatabaseIfNotExists<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            string productJson = "[{'id':1,'name':'iPhone 11 Pro','price':1200,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone11_pro__ejujupnldouq_large.jpg'},{'id':2,'name':'iPhone 11 Pro Max','price':1500,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone11_pro_max__br42x4fh0s2u_large.jpg'},{'id':3,'name':'iPhone 11','price':920,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone11__flwmadt3fvyq_large.jpg'}," +
                "{'id':4,'name':'iPhone XS','price':1000,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphoneXS__m9rwtpu277ue_large.jpg'},{'id':5,'name':'iPhone XS Max','price':1200,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphoneXSmax__btozkqkudp1e_large.jpg'},{'id':6,'name':'iPhone XR','price':800,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphoneXR__gmfkv1py74uq_large.jpg'}," +
                "{'id':7,'name':'iPhone X','price':750,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphoneX__xc1a7uy6rciu_large.jpg'},{'id':8,'name':'iPhone 8 Plus','price':720,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone8plus__exff3jiko4a6_large.jpg'},{'id':9,'name':'iPhone 8','price':700,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone8__c1zeua0f3k8y_large.jpg'},{'id':10,'name':'iPhone 7 Plus','price':560,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone7plus__fheppwnoslqq_large.jpg'},{'id':11,'name':'iPhone 7','price':500,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone7__bm3v8zud8iuu_large.jpg'}," +
                "{'id':12,'name':'iPhone 6s Plus','price':400,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone6splus__c3os19tmy5si_large.jpg'},{'id':13,'name':'iPhone 6s','price':360,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone6s__b5inxu5uh1de_large.jpg'},{'id':14,'name':'iPhone 6 Plus','price':350,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone6plus__cwa231d66auu_large.jpg'},{'id':15,'name':'iPhone 6','price':340,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphone6__bdf10vcqh3zm_large.jpg'},{'id':16,'name':'iPhone SE','price':300,'photoUrl':'https://www.apple.com/v/iphone/compare/n/images/overview/all_models_iphoneSE__bdubwl00w3o2_large.jpg'}]";
            List<Product> productsList = JsonConvert.DeserializeObject<List<Product>>(productJson);
            foreach (var p in productsList)
            {
                db.Products.Add(p);
            }
            db.SaveChanges();
        }
    }
    public class ProductContext : DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(new ProductContextInitializer());
        }
        public ProductContext() : base("OrderList")
        { }
        public DbSet<Product> Products { get; set; }
    }
}