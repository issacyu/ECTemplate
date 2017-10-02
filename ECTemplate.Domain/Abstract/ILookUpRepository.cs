using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface ILookUpRepository
    {
        IEnumerable<LookUps> LookUps { get; }

        LookUps FindLookUp();

        void UpdateLookUp();
    }
}
