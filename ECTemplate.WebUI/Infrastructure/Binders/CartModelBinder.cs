using System.Web.Mvc;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Infrastructure.Binders
{
    /// <summary>
    /// This class provide model binding for the shopping cart.
    /// </summary>
    public class CartModelBinder : IModelBinder
    {
        /// <summary>
        /// The session key.
        /// </summary>
        private const string sessionkey = "Cart";

        /// <summary>
        /// Peform the model binding for the shopping cart.
        /// </summary>
        /// <param name="controllerContext">Encapsulates information about an HTTP request that matches specified 
        /// System.Web.Routing.RouteBase and System.Web.Mvc.ControllerBase instances.</param>
        /// <param name="bindingContext">The context in which a model binder functions.</param>
        /// <returns>The shopping cart.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the Cart from the session

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
                cart = (Cart)controllerContext.HttpContext.Session[sessionkey];

            //create the Cart if there wasn't one in the session data

            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionkey] = cart;
            }

            return cart;
        }
    }
}