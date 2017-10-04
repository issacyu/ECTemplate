using System.Linq;
using System.Collections.Generic;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EFAccountRepository : IAccountRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Accounts> Accounts => context.Accounts;

        public void AddAccount(Accounts Account)
        {
            Accounts dbEntry = new Accounts()
            {
                UserId = Account.UserId,
                UserFirstName = Account.UserFirstName,
                UserLastName = Account.UserLastName,
                UserEmail = Account.UserEmail,
                UserType = "User",
                UserPassword = Account.UserPassword,
                UserAddressId = Account.UserAddressId
            };

            context.Accounts.Add(dbEntry);
            context.SaveChanges();
        }

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

                context.SaveChanges();
            }
        }

        public Accounts FindAccount(int userId)
        {
            Accounts dbEntry = Accounts.FirstOrDefault(a => Equals(a.UserId, userId));
            return dbEntry;
        }
    }
}
