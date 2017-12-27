using ECTemplate.Domain.Entities;
using System.Data.Entity;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The context class that will associate the model with the database.
    /// </summary>
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the product collection.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the account collection.
        /// </summary>
        public DbSet<Accounts> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the order collection.
        /// </summary>
        public DbSet<Orders> Orders { get; set; }

        /// <summary>
        /// Gets or sets the order detail collection.
        /// </summary>
        public DbSet<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the address collection.
        /// </summary>
        public DbSet<Addresses> Addresses { get; set; }
    }
}
