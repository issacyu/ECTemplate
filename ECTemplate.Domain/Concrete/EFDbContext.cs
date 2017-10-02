using ECTemplate.Domain.Entities;
using System.Data.Entity;

namespace ECTemplate.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<LookUps> LookUps { get; set; }
    }
}
