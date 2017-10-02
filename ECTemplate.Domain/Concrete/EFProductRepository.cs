using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = GetProduct(product.ProductID);
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
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = GetProduct(productId);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Product GetProduct(int productId)
        {
            return context.Products.Find(productId);
        }
    }
}
