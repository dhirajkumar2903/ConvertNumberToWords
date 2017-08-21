using System.Web.Http;

namespace AKQA.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //InitializeDependencyInjection();

        }

        //protected IUnityContainer InitializeDependencyInjection()
        //{
        //    IUnityContainer container = BuildUnityContainer();
        //    DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        //    return container;
        //}

        //protected IUnityContainer BuildUnityContainer()
        //{
        //    UnityConfigurationSection section =
        //        (UnityConfigurationSection)System.Configuration.ConfigurationManager.GetSection("unity");
        //    IUnityContainer container = section.Configure(new UnityContainer(), "main");
        //    ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        //    return container;
        //}
    }
}
