using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECTemplate.Domain.Entities
{
    /// <summary>
    /// A model class for the shopping cart. Unlike other classes in the entities folder,
    /// this class only uses to manipulate the shopping cart. There's no database table in the database.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets the line collection.
        /// </summary>
        private List<CartLine> LineCollection = new List<CartLine>();

        /// <summary>
        /// Add the product information into the shopping cart.
        /// </summary>
        /// <param name="product">The product that needs to be added..</param>
        /// <param name="quantity">The quantity of the product.</param>
        public void AddItem(Product product, int quantity)
        {
            CartLine line = LineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                LineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
                line.Quantity += quantity;
        }

        /// <summary>
        /// Remove the product from the shopping cart.
        /// </summary>
        /// <param name="product">The product that needs to be removed.</param>
        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        /// <summary>
        /// Calculate the total price of the products in the shopping cart.
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return LineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        /// <summary>
        /// Remove all the product from the shopping cart.
        /// </summary>
        public void Clear()
        {
            LineCollection.Clear();
        }

        /// <summary>
        /// Gets the lines collection.
        /// </summary>
        public IEnumerable<CartLine> Lines
        {
            get { return LineCollection; }
        }
    }

    /// <summary>
    /// An inner class that represents the product and its quantity.
    /// </summary>
    public class CartLine
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
