using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IAccountRepository
    {
        IEnumerable<Accounts> Accounts { get; }

        void AddAccount(Accounts account);

        void UpdateAccount(Accounts account);

        Accounts FindAccount(int userId);
    }
}
