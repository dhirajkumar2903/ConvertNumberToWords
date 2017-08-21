using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc5;

namespace AKQA.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            InitializeDependencyInjection();
        }

        protected IUnityContainer InitializeDependencyInjection()
        {
            IUnityContainer container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        protected IUnityContainer BuildUnityContainer()
        {
            UnityConfigurationSection section =
                (UnityConfigurationSection)System.Configuration.ConfigurationManager.GetSection("unity");
            IUnityContainer container = section.Configure(new UnityContainer(), "main");
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            return container;
        }
    }
}
