using System.Web.Mvc;
using ECTemplate.WebUI.Models;

namespace ECTemplate.WebUI.Infrastructure.Binders
{
    /// <summary>
    /// This class provide model binding for the current user.
    /// </summary>
    public class UserViewModelBinder : IModelBinder
    {
        /// <summary>
        /// The session key.
        /// </summary>
        private const string sessionkey = "User";

        /// <summary>
        /// Peform the model binding for the current user.
        /// </summary>
        /// <param name="controllerContext">Encapsulates information about an HTTP request that matches specified 
        /// System.Web.Routing.RouteBase and System.Web.Mvc.ControllerBase instances.</param>
        /// <param name="bindingContext">The context in which a model binder functions.</param>
        /// <returns>The information of the current user..</returns>
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