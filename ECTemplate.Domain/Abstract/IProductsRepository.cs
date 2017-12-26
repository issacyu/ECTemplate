using ECTemplate.Domain.Entities;
using System.Collections.Generic;

namespace ECTemplate.Domain.Abstract
{
    /// <summary>
    /// The class that depends on the IProductRepository interface can obtain Product
    /// objects without needing to know anything about where they are coming from 
    /// or how the implementation class will deliver them.
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Gets the product collection.
        /// </summary>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Save a specific product into the database.
        /// </summary>
        /// <param name="product">The product that needs to be saved.</param>
        void SaveProduct(Product product);

        /// <summary>
        /// Delete a specific product from the database.
        /// </summary>
        /// <param name="productId">The product ID that needs to be deleted.</param>
        /// <returns></returns>
        Product DeleteProduct(int productId);
    }
}
