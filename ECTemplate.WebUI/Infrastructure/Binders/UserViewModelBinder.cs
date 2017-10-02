using System.Web.Mvc;
using ECTemplate.Domain.Entities;
using ECTemplate.WebUI.Models;

namespace ECTemplate.WebUI.Infrastructure.Binders
{
    public class UserViewModelBinder : IModelBinder
    {
        private const string sessionkey = "User";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the User from the session

            CurrentUserViewModel user = null;
            if (controllerContext.HttpContext.Session != null)
                user = (CurrentUserViewModel)controllerContext.HttpContext.Session[sessionkey];

            //create the User if there wasn't one in the session data

            if (user == null)
            {
                user = new CurrentUserViewModel();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionkey] = user;
            }

            return user;
        }
    }
}