using System.Linq;
using System.Web.Http.OData;
using Model;
using WebSite.Classes.BLogic;
using System.Web.Http;

namespace WebSite.Controller
{
    public class ProductsController : EntitySetController<Product, int>
    {
        [Queryable]
        public override IQueryable<Product> Get()
        {
            return ProductManagement.Query();
        }

       
    }
}