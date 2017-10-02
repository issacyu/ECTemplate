using System;
using System.Collections.Generic;
using System.Linq;
using ECTemplate.Domain.Entities;
using ECTemplate.Domain.Abstract;

namespace ECTemplate.Domain.Concrete
{
    public class EFLookUpRepository : ILookUpRepository
    {
        EFDbContext context = new EFDbContext();

        IEnumerable<LookUps> LookUps => context.LookUps;

        IEnumerable<LookUps> ILookUpRepository.LookUps => throw new NotImplementedException();

        public LookUps FindLookUp()
        {
            return LookUps.FirstOrDefault();
        }

        public void UpdateLookUp()
        {
            LookUps dbEntry = FindLookUp();

            dbEntry.UserId += 1;
            dbEntry.AddressId += 1;
            dbEntry.OrderId += 1;

            context.SaveChanges();
        }
    }
}
