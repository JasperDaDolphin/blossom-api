using System.Collections.Generic;
using Blossom.Data.Model.BusinessProfiles;

namespace Blossom.Data.BusinessProfiles
{
    public interface IBusinessProfilesRepository : IRepository<BusinessProfileEntity>, IStringRepository<BusinessProfileEntity>
    {
    }
}