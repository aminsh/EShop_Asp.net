using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Model;
using WebSite.Classes.BLogic;

namespace WebSite.Controller
{
    public class ProductController :ApiController
    {
        [HttpGet]
        public IQueryable<Product> Products(int productCategoryId)
        {
            return ProductManagement.Query().Where(p => p.ProductCategoryID == productCategoryId);
        }
    }
}