using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Model;
using WebSite.Classes.BLogic;
using WebSite.Classes;

namespace WebSite.Controller
{
    public class ProductCategoriesController : EntitySetController<ProductCategory, int>
    {
        [Queryable]
        public override IQueryable<ProductCategory> Get()
        {
            return ProductCategoryManagement.Query();
        }

        protected override ProductCategory GetEntityByKey(int key)
        {
            return ProductCategoryManagement.Query().FirstOrDefault(pc => pc.ID == key);
        }

        [Queryable] // odata/ProductCategories(6)/Products
        public IQueryable<Product> GetProductsFromProductCategory([FromODataUri]int key)
        {
            return ProductManagement.Query().Where(p => p.ProductCategoryID == key);
        }

    }
}