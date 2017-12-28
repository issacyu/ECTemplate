using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class that stores the data in the Product table.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The primary key of the Product table.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the product image data.
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Gets or sets the product image mime type.
        /// </summary>
        public string ImageMimeType { get; set; }
    }
}
