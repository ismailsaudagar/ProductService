using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProductService.Models;

namespace ProductService.Controllers
{
    public class ProductCategoryController : ApiController
    {
        IsmailSalesEntities db = new IsmailSalesEntities();

        [EnableCors( "*", "*", "*")]
        public List<ProductCategory> GetCategoryName() //  api/ProductCategory/id
        {

            var categories = db.ProductCategories.ToList();
             
            return categories;


        }
    }
}
