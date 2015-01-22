using Microsoft.Data.Edm;
using Model;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace WebSite.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapODataRoute("MyOdata", "odata", GetImplicitModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();
        }


        public static IEdmModel GetImplicitModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Model";

            var users = builder.EntitySet<User>("Users");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<OrderDetail>("OrderDetails");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<ProductCategory>("ProductCategories");
            

            //var action = customer.Action("CalculatePrice");
            //action.Parameter<int>("OrderCount");
            //action.Parameter<Double>("Price");
            //action.Returns<Double>();


            return builder.GetEdmModel();

        }

        public static IEdmModel GetExplicitModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
       
            var users = builder.EntitySet<User>("Users");
            var orders = builder.EntitySet<Order>("Orders");
            var orderDetails = builder.EntitySet<OrderDetail>("OrderDetails");
            var products = builder.EntitySet<Product>("Products");
            var productCategories = builder.EntitySet<ProductCategory>("ProductCategories");


            var user = users.EntityType;
            var order = orders.EntityType;
            var orderDetail = orderDetails.EntityType;
            var product = products.EntityType;
            var productCategory = productCategories.EntityType;

            user.HasKey(c => c.ID);
            //user.HasMany(c => c.Orders);

            order.HasKey(u => u.ID);
            order.HasMany(o => o.OrderDetails);

            orderDetail.HasKey(od => od.ID);

            product.HasKey(p => p.ID);

            productCategory.HasKey(pc => pc.ID);
            productCategory.HasMany(pc => pc.Products);

            return builder.GetEdmModel();

        }
    }
}
