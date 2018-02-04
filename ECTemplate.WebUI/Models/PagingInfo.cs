using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the paging info.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the item per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// GEts or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Compute and return the total pages.
        /// </summary>
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }

    }
}