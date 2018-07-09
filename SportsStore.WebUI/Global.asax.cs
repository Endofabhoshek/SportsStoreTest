using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SportsStore.WebUI.Infrastructure;
using System.Data.Entity;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Binders;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EFDbContext>(null);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
