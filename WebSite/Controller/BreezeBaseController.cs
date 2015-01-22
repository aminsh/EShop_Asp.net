using System.Linq;
using System.Web.Http;
using Breeze.WebApi;
using DataAccess;
using Model;
using Newtonsoft.Json.Linq;

namespace WebSite.Controller
{
    [BreezeController]
    public class BreezeBaseController : ApiController
    {
        protected EFContextProvider<AppDbContext> _contextProvider =
            new EFContextProvider<AppDbContext>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
 
    }
}
