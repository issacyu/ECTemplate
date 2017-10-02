using System.Web.Mvc;
using System.Web.Routing;
using ECTemplate.Domain.Entities;
using ECTemplate.WebUI.Models;
using ECTemplate.WebUI.Infrastructure.Binders;

namespace ECTemplate.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            ModelBinders.Binders.Add(typeof(CurrentUserViewModel), new UserViewModelBinder());
        }
    }
}
