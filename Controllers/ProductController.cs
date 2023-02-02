using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductService.Models;
using System.Web.Http.Cors;

namespace ProductService.Controllers
{
    // [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [EnableCors( "*","*","*")]
    public class ProductController : ApiController
    {
       IsmailSalesEntities db = new IsmailSalesEntities();

       // [Authorize]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        // GET: api/Products/5
        
        public Product Get(int id)
        {
            return db.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        // POST: api/Products
        public void Post([FromBody] Product p)
        {

            db.Products.Add(p);
            db.SaveChangesAsync();

        }

        // PUT: api/Products/5
        public string  Put(int id, [FromBody] Product p)
        {
            var producttoupdate = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
            string status = string.Empty;
            if(producttoupdate!=null)
            {
                producttoupdate.ProductName = p.ProductName;
                producttoupdate.ProductPrice = p.ProductPrice;
                producttoupdate.QuantityAvailable = p.QuantityAvailable;
                db.Entry(producttoupdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                status = "update success";           
            }
            else
            {
                status = "update failed";
            }
            return status;
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            db.Products.Remove(db.Products.Where(x => x.ProductID == id).SingleOrDefault());
            db.SaveChanges();     //git  repository created       
        }

       

    }
}
