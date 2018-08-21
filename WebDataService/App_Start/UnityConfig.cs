using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using WebDataModel;

namespace WebDataService
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IExceptionLogger, NLogExceptionLogger>(new ContainerControlledLifetimeManager());
            container.RegisterType<INopvDataRepository, NopvDataRepository>();
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}