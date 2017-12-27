using System.Linq;
using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    /// <summary>
    /// The repository class that implements the IAccountRepository interface and uses an instance of
    /// EFDbContext to retrieve data from the database using the Entity Framework.
    /// </summary>
    public class EFAccountRepository : IAccountRepository
    {
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EFAccountRepository()
        {
            Context = new EFDbContext();
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        private EFDbContext Context { get; set; }

        /// <summary>
        /// Gets the account collection.
        /// </summary>
        public IEnumerable<Accounts> Accounts => Context.Accounts;

        /// <summary>
        /// Add the account into the database.
        /// </summary>
        /// <param name="Account">The account that uses to add into the database.</param>
        public void AddAccount(Accounts Account)
        {
            if (Account.UserId == 0)
            {
                Context.Accounts.Add(Account);
                Context.SaveChanges();
            }
            else
            {
                Accounts dbEntry = new Accounts()
                {
                    UserId = Account.UserId,
                    UserFirstName = Account.UserFirstName,
                    UserLastName = Account.UserLastName,
                    UserEmail = Account.UserEmail,
                    UserType = "User",
                    UserPassword = Account.UserPassword,
                    AddressId = Account.AddressId
                };

                Context.Accounts.Add(dbEntry);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Update an existing account in the database.
        /// </summary>
        /// <param name="account">The account that needs to be updated.</param>
        public void UpdateAccount(Accounts account)
        {
            Accounts dbEntry = FindAccount(account.UserId);

            if (dbEntry != null)
            {
                dbEntry.UserId = account.UserId;
                dbEntry.UserFirstName = account.UserFirstName;
                dbEntry.UserLastName = account.UserLastName;
                dbEntry.UserEmail = account.UserEmail;
                dbEntry.UserPassword = account.UserPassword;

                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Find the account in the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to find the account.</param>
        /// <returns>The account.</returns>
        public Accounts FindAccount(int userId)
        {
            Accounts dbEntry = Accounts.FirstOrDefault(a => Equals(a.UserId, userId));
            return dbEntry;
        }
    }
}
