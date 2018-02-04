using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    /// <summary>
    /// The view model that uses to bind to the view that cantains the product list info.
    /// </summary>
    public class ProductsListViewModel
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the paging info.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// Gets or sets the current category.
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}