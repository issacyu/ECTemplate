using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the navigation bar info.
    /// </summary>
    public class NavBarViewModel
    {
        /// <summary>
        /// Gets or sets the shopping cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public CurrentUserViewModel User { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public IEnumerable<string> Categories { get; set; }
    }
}