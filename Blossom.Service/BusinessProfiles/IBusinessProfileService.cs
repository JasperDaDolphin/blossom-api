using Blossom.Data.Model.BusinessProfiles;
using Blossom.Service.Model.BusinessProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Service.BusinessProfiles
{
    public interface IBusinessProfileService
    {
        BusinessProfile CreateBusinessProfile(BusinessProfile profile);

        void DeleteBusinessProfile(Guid id);

        List<BusinessProfile> GetAll(Expression<Func<BusinessProfileEntity, bool>> filter = null);

        BusinessProfile GetById(Guid id);

        BusinessProfile UpdateBusinessProfile(BusinessProfile profile);
    }
}
