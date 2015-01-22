using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataAccess;

namespace WebSite.Classes
{
    public class DIManager
    {
        public static readonly WindsorContainer Container = new WindsorContainer();

        static DIManager()
        {
            Container.Register(new ComponentRegistration(typeof(IWorkUnit)).ImplementedBy(typeof(EfWorkUnit)).LifeStyle.PerWebRequest);
            Container.Register(new ComponentRegistration(typeof(IRepository<>)).ImplementedBy(typeof(EfRepository<>)).LifeStyle.PerWebRequest);
        }
    }
}