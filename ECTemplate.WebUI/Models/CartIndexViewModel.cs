using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the shopping cart info.
    /// </summary>
    public class CartIndexViewModel
    {
        /// <summary>
        /// Gets or sets the shopping cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the return url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}