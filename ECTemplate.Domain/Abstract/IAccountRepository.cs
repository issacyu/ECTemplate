using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    /// <summary>
    /// The class that depends on the IAccountRepository interface can obtain Account
    /// objects without needing to know anything about where they are coming from 
    /// or how the implementation class will deliver them.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets the account collection.
        /// </summary>
        IEnumerable<Accounts> Accounts { get; }

        /// <summary>
        /// Add the account to the database.
        /// </summary>
        /// <param name="account">The account that needs to be added into the database.</param>
        void AddAccount(Accounts account);

        /// <summary>
        /// Update the account from the database.
        /// </summary>
        /// <param name="account">The account that needs to be updated.</param>
        void UpdateAccount(Accounts account);

        /// <summary>
        /// Find the account from the database.
        /// </summary>
        /// <param name="userId">The user ID that uses to find the account.</param>
        /// <returns></returns>
        Accounts FindAccount(int userId);
    }
}
