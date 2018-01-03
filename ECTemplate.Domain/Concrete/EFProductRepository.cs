using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The repository class that implements the IProductsRepository interface and uses an instance of
    /// EFDbContext to retrieve data from the database using the Entity Framework.
    /// </summary>
    public class EFProductRepository : IProductsRepository
    {
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EFProductRepository()
        {
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>

        private EFDbContext Context = new EFDbContext();

        /// <summary>
        /// Gets the product collection.
        /// </summary>
        public IEnumerable<Product> Products => Context.Products;

        /// <summary>
        /// Add the product into the database.
        /// </summary>
        /// <param name="product">The product that uses to add into the database.</param>
        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                Context.Products.Add(product);
            }
            else
            {
                Product dbEntry = FindProduct(product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete the product in the database.
        /// </summary>
        /// <param name="productId">The product ID that uses to delete the product.</param>
        /// <returns></returns>
        public Product DeleteProduct(int productId)
        {
            Product dbEntry = FindProduct(productId);
            if(dbEntry != null)
            {
                Context.Products.Remove(dbEntry);
                Context.SaveChanges();
            }
            return dbEntry;
        }

        /// <summary>
        /// Find the product in the database.
        /// </summary>
        /// <param name="productId">The product ID that uses to find the product.</param>
        /// <returns>The product.</returns>
        public Product FindProduct(int productId)
        {
            return Context.Products.Find(productId);
        }
    }
}
